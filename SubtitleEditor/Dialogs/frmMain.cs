using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AxWMPLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using OpenSubtitleEditor.My;
using OpenSubtitleEditor.My.Resources;
using WMPLib;

namespace OpenSubtitleEditor;

public partial class frmMain
{
    public int commonDelay;
    public double currentFPS;

    // Row number for the subtitle matching the current video time
    public int currentRow;
    public string[] cursub = new string[4];
    public int delayAfter;

    public int delayBefore;
    private bool editMode;

    public Subtitles mySubtitles = new();
    public int oldRow = -1;
    private string readyStatusString;
    public int stopDblClickPrevTime;
    public bool stopOnEndOfSub;

    public StreamReader subsFileReader;
    private Subtitles.SubtitleType tempSub;
    public short tick;

    public string VersionComment = "beta";
    private bool wasPaused;

    public frmMain()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if (Generic.AlreadyRunning())
        {
            Interaction.MsgBox(Generic.loadStringFromLangFile("alreadyRunningOSE"), MsgBoxStyle.Exclamation);
            Environment.Exit(0);
        }

        var myImages = new ImageList();
        myImages.Images.Add("information", SystemIcons.Information);
        tabControl.ImageList = myImages;

        if (MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "NotFirstRun", null) is null)
        {
            var temp = "Open Subtitle Editor has a video preview feature which uses Windows Media " +
                       "Player technology. That means that any video that the Windows Media Player " +
                       "that is currently installed on your computer can play, Open Subtitle Editor " +
                       "can play as well." + Generic.newLine + Generic.newLine +
                       "However, if you receive an error while trying to play a video file or " +
                       "only hear sound and see no video playing, then it's quite probable that " +
                       "you're missing a required codec." + Generic.newLine + Generic.newLine +
                       "See warning.txt for more information. It's located in the folder that Open " +
                       @"Subtitle Editor was installed (by default, C:\Program Files\Open Subtitle Editor).";


            Interaction.MsgBox(temp, MsgBoxStyle.Information);

            // Remove old Open Subtitle Editor registry entries.
            var tempReg = Registry.CurrentUser;
            tempReg.DeleteSubKeyTree(@"Software\Discovery Open-Source Development Group\" + Application.ProductName, false);

            MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "NotFirstRun", 1);
        }

        lblShowSub.Left = mPlayer.Left;
        Text = Application.ProductName + " " + Generic.VersionNumberInterpretation();
        Generic.addToDebugList(Application.ProductName + " " + Generic.VersionNumberInterpretation());

        // Get language file setting from registry and load it.
        if (MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "LanguageFile", null) is null)
            Generic.loadTranslation(2);
        else
            Generic.loadTranslation(1);

        nudShow.Accelerations.Add(new NumericUpDownAcceleration(2, 100m));
        nudShow.Accelerations.Add(new NumericUpDownAcceleration(5, 500m));
        nudShow.Accelerations.Add(new NumericUpDownAcceleration(8, 1000m));
        nudShow.Accelerations.Add(new NumericUpDownAcceleration(11, 5000m));

        nudHide.Accelerations.Add(new NumericUpDownAcceleration(2, 100m));
        nudHide.Accelerations.Add(new NumericUpDownAcceleration(5, 500m));
        nudHide.Accelerations.Add(new NumericUpDownAcceleration(8, 1000m));
        nudHide.Accelerations.Add(new NumericUpDownAcceleration(11, 5000m));

        mPlayer.uiMode = "none";
        mPlayer.Ctlenabled = false;
        mPlayer.enableContextMenu = false;
        mPlayer.settings.volume = sldVolume.Value;

        rtbSubtitle.Left = chkBold.Right + 10;

        rtbSubtitle.SelectionAlignment = HorizontalAlignment.Center;

        cmbFRorFFby.SelectedIndex = 2;
        toolTip.SetToolTip(sldVolume, sldVolume.Value.ToString());
        ViewTabsToolStripMenuItem_Click(null, null);

        LoadSettings();
        Generic.parseKnownLanguageFiles();
    }

    private void dgvSubtitles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if ((e.ColumnIndex == 1) | (e.ColumnIndex == 2))
            if (!((getFirstDebugListItem() ?? "") == (Generic.loadStringFromLangFile("pleaseCheckForOverlaps") ?? "")))
                Generic.addToDebugList(Generic.loadStringFromLangFile("pleaseCheckForOverlaps"));

        switch (e.ColumnIndex)
        {
            case 1:
            {
                mySubtitles.setShowTime(e.RowIndex,
                    Conversions.ToString(dgvSubtitles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                break;
            }
            case 2:
            {
                mySubtitles.setHideTime(e.RowIndex,
                    Conversions.ToString(dgvSubtitles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                break;
            }
            case 3:
            {
                mySubtitles.setText(e.RowIndex,
                    Conversions.ToString(dgvSubtitles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                break;
            }
        }
    }

    private void dgvSubtitles_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (TimerSub.Enabled)
            {
                mPlayer.Ctlcontrols.currentPosition = (mySubtitles.getShowTimeInMS(e.RowIndex) + commonDelay) / 1000d;
                updateCurrentPositionLabel();
                playMovie();
            }
        }
        catch
        {
            Generic.addToDebugList(
                Generic.loadStringFromLangFile("unableToMoveToSelectedSub") + " (" + e.RowIndex + ")");
            ViewTabsToolStripMenuItem.Checked = true;
            tabControl.SelectedTab = tabDebug;
            ViewTabsToolStripMenuItem_Click(null, null);
        }
    }

    private void StartMovieOnStartSubtitle(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (string.IsNullOrEmpty(mPlayer.URL))
            return;

        var toEdit = new string[4];
        double subSeconds;
        var cursub = new string[3];


        try
        {
            oldRow = -1;
            TimerSub.Enabled = false;


            subSeconds = (mySubtitles.getShowTimeInMS(e.RowIndex) - delayBefore + commonDelay) / 1000d;
            stopDblClickPrevTime = mySubtitles.getHideTimeInMS(e.RowIndex);

            mPlayer.Ctlcontrols.currentPosition = subSeconds;

            mPlayer.Ctlcontrols.play();
            findSubForCurrentTime();

            Timer.Enabled = true;
        }
        catch
        {
            Generic.addToDebugList(
                Generic.loadStringFromLangFile("unableToMoveToSelectedSub") + " (" + e.RowIndex + ")");
            ViewTabsToolStripMenuItem.Checked = true;
            tabControl.SelectedTab = tabDebug;
            ViewTabsToolStripMenuItem_Click(null, null);
        }
    }

    private void CheckIfMovieShouldStop(object sender, EventArgs e)
    {
        double subSeconds;
        var curpos = new string[3];

        pnlTimerOnly.Enabled = true;

        findSubForCurrentTime();

        subSeconds = (stopDblClickPrevTime + delayAfter + commonDelay) / 1000d;

        if (mPlayer.Ctlcontrols.currentPosition > subSeconds) mPlayer.Ctlcontrols.pause();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    public void LoadLangStrings()
    {
        // langFileReader = My.Computer.FileSystem.OpenTextFileReader(My.Computer.Registry.GetValue(AppRegKey, "LanguageFile", Nothing))

        // While Not langFileReader.EndOfStream
        // Dim line As String = langFileReader.ReadLine
        // If Not (line = "" Or Microsoft.VisualBasic.Left(line, 1) = ("!"c)) Then
        // Dim splitLine As String() = line.Split(New Char() {","c}, 2)
        // Dim controlName As String = splitLine(0)
        // Dim controlText As String = LTrim(splitLine(1))

        // Dim a As Object = Me.GetType().GetField(controlName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Static).GetValue(Me)
        // a.Text = "Hello"

        // 'Dim controlField As FieldInfo = Me.GetType().GetField(controlName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Static)
        // 'Dim textProperty As PropertyInfo = controlField.GetType().GetProperty("Text")
        // End If

        // End While

        readyStatusString = Generic.loadStringFromLangFile("readyStatus");
        SubtitleToolStripMenuItem.Text = Generic.loadStringFromLangFile("subtitleMenu");
        OpenToolStripMenuItem.Text = Generic.loadStringFromLangFile("openMenuItem");
        SaveToolStripMenuItem.Text = Generic.loadStringFromLangFile("saveMenuItem");
        ExitToolStripMenuItem.Text = Generic.loadStringFromLangFile("exitMenuItem");
        MovieToolStripMenuItem.Text = Generic.loadStringFromLangFile("movieMenu");
        EditToolStripMenuItem.Text = Generic.loadStringFromLangFile("preferencesMenu");
        LanguageToolStripMenuItem.Text = Generic.loadStringFromLangFile("languageMenu");
        LoadTranslationToolStripMenuItem.Text = Generic.loadStringFromLangFile("loadTranslationMenuItem");
        PreviewSettingsToolStripMenuItem.Text = Generic.loadStringFromLangFile("previewSettingsMenuItem");
        MovieOpenToolStripMenuItem.Text = Generic.loadStringFromLangFile("openMenuItem");
        PlayToolStripMenuItem.Text = Generic.loadStringFromLangFile("play/pauseMenu");
        ForwardToolStripMenuItem.Text = Generic.loadStringFromLangFile("forwardMenu");
        RewindToolStripMenuItem.Text = Generic.loadStringFromLangFile("rewindMenu");
        VolumeToolStripMenuItem.Text = Generic.loadStringFromLangFile("volumeText");
        volumeUpToolStripMenuItem.Text = Generic.loadStringFromLangFile("upWord");
        volumeDownToolStripMenuItem.Text = Generic.loadStringFromLangFile("downWord");
        MuteToolStripMenuItem.Text = Generic.loadStringFromLangFile("muteMenu");
        MaxToolStripMenuItem.Text = Generic.loadStringFromLangFile("maxMenu");
        PlayRateToolStripMenuItem.Text = Generic.loadStringFromLangFile("playRate");
        playRateUpToolStripMenuItem.Text = Generic.loadStringFromLangFile("upWord");
        playRateDownToolStripMenuItem.Text = Generic.loadStringFromLangFile("downWord");
        ResetToolStripMenuItem.Text = Generic.loadStringFromLangFile("resetMenu");
        EditToolStripMenuItem1.Text = Generic.loadStringFromLangFile("editMenu");
        AddToolStripMenuItem.Text = Generic.loadStringFromLangFile("addMenu");
        OnCurrentMoviePositionToolStripMenuItem.Text = Generic.loadStringFromLangFile("onCurrentMoviePositionMenu");
        StartSelectedOnCurrentPositionToolStripMenuItem.Text = Generic.loadStringFromLangFile("startSelectedHere");
        EndSelectedOnCurrentPositionToolStripMenuItem.Text = Generic.loadStringFromLangFile("endSelectedHere");
        DelayToolStripMenuItem.Text = Generic.loadStringFromLangFile("delayMenu");
        ApplyCurrentConstantDelayToolStripMenuItem.Text = Generic.loadStringFromLangFile("applyConstantDelayMenu");
        ApplyCustomDelayToolStripMenuItem.Text = Generic.loadStringFromLangFile("applyCustomDelayMenu");
        FPSConversionToolStripMenuItem.Text = Generic.loadStringFromLangFile("fpsConversionMenu");
        SetCurrentFPSToolStripMenuItem.Text = Generic.loadStringFromLangFile("setCurrentFPSMenu");
        ConvertToToolStripMenuItem.Text = Generic.loadStringFromLangFile("convertToMenu");
        CurFPS23976ToolStripMenuItem.Text = "23" + Generic.DecimalSeparator + "976";
        ToFPS23976ToolStripMenuItem.Text = CurFPS23976ToolStripMenuItem.Text;
        dgvSubtitles.Columns["subShow"].HeaderText = Generic.loadStringFromLangFile("showTableHeader");
        dgvSubtitles.Columns["subHide"].HeaderText = Generic.loadStringFromLangFile("hideTableHeader");
        dgvSubtitles.Columns["subText"].HeaderText = Generic.loadStringFromLangFile("subtitleTableHeader");
        dgvSubtitles.Columns["subProperties"].HeaderText = Generic.loadStringFromLangFile("propertiesTableHeader");
        NewToolStripMenuItem.Text = Generic.loadStringFromLangFile("newMenu");
        PALNTSCFormatsToolStripMenuItem.Text = Generic.loadStringFromLangFile("pal/ntscFormats");
        PALNTSCFormatsToolStripMenuItem1.Text = PALNTSCFormatsToolStripMenuItem.Text;
        ComputerUsedToolStripMenuItem.Text = Generic.loadStringFromLangFile("otherFPS");
        ComputerUsedToolStripMenuItem1.Text = ComputerUsedToolStripMenuItem.Text;
        CheckForOverlappingSubtitlesToolStripMenuItem.Text = Generic.loadStringFromLangFile("checkForOverlapsMenu");
        AboutToolStripMenuItem.Text = Generic.loadStringFromLangFile("AboutToolStripMenuItem");
        HelpToolStripMenuItem.Text = Generic.loadStringFromLangFile("helpMenu");
        lblShow.Text = Generic.loadStringFromLangFile("showTableHeader") + ":";
        lblHide.Text = Generic.loadStringFromLangFile("hideTableHeader") + ":";
        tabSubPrev.Text = Generic.loadStringFromLangFile("previewTab");
        lblDuration.Text = Generic.loadStringFromLangFile("durationWord") + ":";
        SortSubtitlesBasedOnShowTimingToolStripMenuItem.Text = Generic.loadStringFromLangFile("sortSubsMenuItem");
        grpStatus.Text = Generic.loadStringFromLangFile("currentStatus");
        lblConstantDelayLabel.Text = Generic.loadStringFromLangFile("constantDelayLabel");
        lblEndAfterLabel.Text = Generic.loadStringFromLangFile("endAfterLabel");
        lblStartBeforeLabel.Text = Generic.loadStringFromLangFile("startBeforeLabel");
        var secondsText = Generic.loadStringFromLangFile("secondsText");
        var minutesText = Generic.loadStringFromLangFile("minutesText");
        toolTip.SetToolTip(cmbFRorFFby,
            Generic.loadStringFromLangFile("setTimeToFForFRby") + Generic.newLine + Generic.newLine + "10 = 0" +
            Generic.DecimalSeparator + "01 " + secondsText + Generic.newLine + "100 = 0" + Generic.DecimalSeparator +
            "1 " + secondsText + Generic.newLine + "1000 = 1 " + secondsText + Generic.newLine + "10000 = 10 " +
            secondsText + Generic.newLine + "60000 = 1 " + minutesText + Generic.newLine + "120000 = 2 " + minutesText +
            Generic.newLine + "600000 = 10 " + minutesText);


        lblVolume.Text = Generic.loadStringFromLangFile("volumeText");
        lblPlayRateLabel.Text = Generic.loadStringFromLangFile("playRate");
        CopyToClipboardToolStripMenuItem.Text = Generic.loadStringFromLangFile("copyToClipboard");
        tabDebug.Text = Generic.loadStringFromLangFile("debug");
        ViewTabsToolStripMenuItem.Text = Generic.loadStringFromLangFile("viewTabsMenuItem");
        btnQuickAdd.Text = Generic.loadStringFromLangFile("btnQuickAdd");
        btnQuickEdit.Text = Generic.loadStringFromLangFile("btnQuickEdit");
        chkPauseAfterQuick.Text = Generic.loadStringFromLangFile("chkPauseAfterQuick");
        toolTip.SetToolTip(btnQuickAdd, Generic.loadStringFromLangFile("quickAddToolTip"));
        toolTip.SetToolTip(btnQuickEdit, Generic.loadStringFromLangFile("quickAddToolTip"));
    }

    private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Generic.loadTranslation(2);
    }

    private void LoadTranslationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Generic.loadTranslation(0);
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (subtitleFileSaved())
        {
            mySubtitles.open();
        }
        else
        {
            var response = Interaction.MsgBox(Generic.loadStringFromLangFile("tableNotEmptyPrompt"),
                (MsgBoxStyle)((int)MsgBoxStyle.Question + (int)MsgBoxStyle.YesNoCancel));
            switch (response)
            {
                case Constants.vbYes:
                {
                    mySubtitles.save();
                    mySubtitles.open();
                    break;
                }
                case Constants.vbNo:
                {
                    mySubtitles.open();
                    break;
                }
                case Constants.vbCancel:
                {
                    return;
                }
            }
        }
    }

    private void MovieOpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Generic.openMovie();
        playMovie();
        ViewTabsToolStripMenuItem.Checked = true;
        ViewTabsToolStripMenuItem_Click(null, null);
    }

    private void TimerSub_Tick(object sender, EventArgs e)
    {
        var cursub = new string[4];
        var CDelayInMS = commonDelay / 1000d;

        pnlTimerOnly.Enabled = false;

        updateCurrentPositionLabel();

        if (dgvSubtitles.Rows.Count == 0)
            return;

        findSubForCurrentTime();
    }

    private void showSubForCurrentRow()
    {
        if (currentRow == -1)
            return;

        cursub = Generic.convertMultiLineTextToArray(mySubtitles.getText(currentRow));

        lblShowSub.Text = "";

        formatSubtitle();

        lblShowSub.Visible = true;
        for (int i = 0, loopTo = cursub.Length - 1; i <= loopTo; i++)
            if (!(i == cursub.Length - 1))
                lblShowSub.Text = lblShowSub.Text + cursub[i] + Generic.newLine;
            else
                lblShowSub.Text = lblShowSub.Text + cursub[i];

        if (editMode == false)
        {
            if (dgvSubtitles.MultiSelect)
                foreach (DataGridViewRow row in dgvSubtitles.Rows)
                    row.Selected = false;
            dgvSubtitles.Rows[currentRow].Selected = true;
            scrollToSelectedRow();
            dgvSubtitles_SelectionChanged(null, null);
        }
    }

    public void findSubForCurrentTime()
    {
        string curPosTemp;
        var subStartTemp = new string[4];
        var subStartTempSec = new string[3];
        var subSeconds = new double[2];
        bool foundSub;

        // Try
        foundSub = false;

        curPosTemp = mPlayer.Ctlcontrols.currentPosition.ToString();

        for (int i = 0, loopTo = dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            subStartTemp = Strings.Split(Conversions.ToString(dgvSubtitles.Rows[i].Cells[1].Value), ":");
            subStartTempSec = Strings.Split(subStartTemp[2], ",");
            subSeconds[0] = Conversions.ToDouble((Conversions.ToDouble(subStartTemp[0]) * 3600d).ToString() +
                                                 (Conversions.ToDouble(subStartTemp[1]) * 60d +
                                                  Conversions.ToDouble(subStartTempSec[0]) +
                                                  Conversions.ToDouble(subStartTempSec[1]) / 1000d +
                                                  commonDelay / 1000d));
            subStartTemp = Strings.Split(Conversions.ToString(dgvSubtitles.Rows[i].Cells[2].Value), ":");
            subStartTempSec = Strings.Split(subStartTemp[2], ",");
            subSeconds[1] = Conversions.ToDouble((Conversions.ToDouble(subStartTemp[0]) * 3600d).ToString() +
                                                 (Conversions.ToDouble(subStartTemp[1]) * 60d +
                                                  Conversions.ToDouble(subStartTempSec[0]) +
                                                  Conversions.ToDouble(subStartTempSec[1]) / 1000d +
                                                  commonDelay / 1000d));
            if ((i == 0) & (subSeconds[0] > mPlayer.Ctlcontrols.currentPosition))
            {
                currentRow = -1;
                return;
            }

            if ((subSeconds[1] > mPlayer.Ctlcontrols.currentPosition) &
                (subSeconds[0] < mPlayer.Ctlcontrols.currentPosition))
            {
                currentRow = i;

                if (oldRow == currentRow)
                    return;

                foundSub = true;
                oldRow = i;
                break;
            }
        }

        if (foundSub)
        {
            lblShowSub.Visible = true;
            showSubForCurrentRow();
        }
        else
        {
            lblShowSub.Text = "";
            lblShowSub.Visible = false;
            // dgvSubtitles.ClearSelection()
        }
        // Catch

        // End Try
    }

    private void PreviewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        PauseMovieAndAllTimers();
        MyProject.Forms.frmPreviewSettings.ShowDialog();
    }

    private void PauseMovieAndAllTimers()
    {
        mPlayer.Ctlcontrols.pause();
        Timer.Enabled = false;
        TimerSub.Enabled = false;
    }

    public void LoadSettings()
    {
        delayBefore = Conversions.ToInteger(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "StartDelay", 0));
        delayAfter = Conversions.ToInteger(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "EndDelay", 0));
        commonDelay = Conversions.ToInteger(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "AddDelay", 0));
        stopOnEndOfSub =
            Conversions.ToBoolean(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "stopOnEndOfSub", true));

        lblStartBefore.Text = delayBefore + " ms";
        lblEndAfter.Text = delayAfter + " ms";
        lblConstantDelay.Text = commonDelay + " ms";
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!(dgvSubtitles.Rows.Count == 0))
            mySubtitles.save();
    }

    private void PlayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        btnPlay_Click(null, null);
    }

    private void ForwardToolStripMenuItem_Click(object sender, EventArgs e)
    {
        btnFF_Click(null, null);
    }

    private void RewindToolStripMenuItem_Click(object sender, EventArgs e)
    {
        btnFR_Click(null, null);
    }

    private void volumeUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sldVolume.Value += 5;
    }

    private void volumeDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sldVolume.Value -= 5;
    }

    private void MuteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mPlayer.settings.volume = 0;
    }

    private void MaxToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mPlayer.settings.volume = 100;
    }

    private void playRateUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mPlayer.settings.rate += 0.25d;
        lblPlayRate.Text = mPlayer.settings.rate + "x";
    }

    private void playRateDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mPlayer.settings.rate -= 0.25d;
        lblPlayRate.Text = mPlayer.settings.rate + "x";
    }

    private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mPlayer.settings.rate = 1d;
    }

    private void StartSelectedOnCurrentPositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var curpos = new string[3];
        short milisecondsTemp;

        if (dgvSubtitles.SelectedCells.Count == 0)
            return;

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        var secondsTemp = Conversions.ToShort(curpos[0]);
        if (curpos.Count() == 1)
            milisecondsTemp = 0;
        else
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));

        var timeInMS = secondsTemp * 1000 + milisecondsTemp;
        var row = dgvSubtitles.SelectedCells[0].OwningRow.Index;

        Generic.convertMilisecondsToShowHideCell(timeInMS, row, true);
        dgvSubtitles_SelectionChanged(null, null);
    }

    private void EndSelectedOnCurrentPositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var curpos = new string[3];
        short milisecondsTemp;

        if (dgvSubtitles.SelectedCells.Count == 0)
            return;

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        var secondsTemp = Conversions.ToShort(curpos[0]);
        if (curpos.Count() == 1)
            milisecondsTemp = 0;
        else
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));

        var timeInMS = secondsTemp * 1000 + milisecondsTemp;
        var row = dgvSubtitles.SelectedCells[0].OwningRow.Index;

        Generic.convertMilisecondsToShowHideCell(timeInMS, row, false);
        dgvSubtitles_SelectionChanged(null, null);
    }

    private void OnCurrentMoviePositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var curpos = new string[3];
        short milisecondsTemp;
        var tempSub = new Subtitles.SubtitleType();

        mPlayer.Ctlcontrols.pause();

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        if (curpos.Count() == 1)
        {
            Array.Resize(ref curpos, 2);
            curpos[1] = "000";
            milisecondsTemp = 0;
        }
        else
        {
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));
        }

        var timeInMS = Conversions.ToInteger(curpos[0]) * 1000 + milisecondsTemp;

        var checkTemp = Generic.checkIfNewSubtitleExistsOnGivenTime(timeInMS);
        if (checkTemp > 0)
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("subtitleEntryWord") + " " + checkTemp + ": " +
                                   Generic.loadStringFromLangFile("subtitleAlreadyExistsOnGivenTime"));
            ViewTabsToolStripMenuItem.Checked = true;
            tabControl.SelectedTab = tabDebug;
            ViewTabsToolStripMenuItem_Click(null, null);
            return;
        }

        dgvSubtitles.Rows.Add();
        tempSub.ID = dgvSubtitles.RowCount;
        tempSub.showTimeInMS = timeInMS;
        tempSub.hideTimeInMS = timeInMS + 500;
        tempSub.text = "";
        tempSub.isBold = Conversions.ToString(false);
        tempSub.isItalic = Conversions.ToString(false);
        tempSub.translationText = "";
        mySubtitles.setAll(tempSub.ID - 1, tempSub);

        mySubtitles.passLineToDataGridView(tempSub.ID - 1);

        dgvSubtitles_SelectionChanged(null, null);

        Generic.sortDGV();
    }

    private void ApplyCurrentConstantDelayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        for (int i = 0, loopTo = dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            var startTime = Generic.convertShowHideCellToMiliseconds(i, true);
            var endTime = Generic.convertShowHideCellToMiliseconds(i, false);

            startTime += commonDelay;
            endTime += commonDelay;

            Generic.convertMilisecondsToShowHideCell(startTime, i, true);
            Generic.convertMilisecondsToShowHideCell(endTime, i, false);
        }
    }

    private void CurFPS23976ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = true;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 23.976d;
    }

    private void CurFPS25ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = true;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 25d;
    }

    private void ToFPS23976ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 23.976d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(23.976d);

        CurFPS23976ToolStripMenuItem.PerformClick();
    }

    private void ToFPS25ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 25d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(25d);

        CurFPS25ToolStripMenuItem.PerformClick();
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (subtitleFileSaved() == false)
        {
            var response = Interaction.MsgBox(Generic.loadStringFromLangFile("tableNotEmptyNewPrompt"),
                (MsgBoxStyle)((int)MsgBoxStyle.Question + (int)MsgBoxStyle.YesNoCancel));
            switch (response)
            {
                case Constants.vbYes:
                {
                    mySubtitles.save();
                    dgvSubtitles.Rows.Clear();
                    mySubtitles.clear();
                    break;
                }
                case Constants.vbNo:
                {
                    dgvSubtitles.Rows.Clear();
                    mySubtitles.clear();
                    break;
                }
                case Constants.vbCancel:
                {
                    return;
                }
            }
        }
    }

    private void CurFPS15ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = true;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 15d;
    }

    private void CurFPS20ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = true;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 20d;
    }

    private void CurFPS24ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = true;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 24d;
    }

    private void CurFPS2997ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = true;
        CurFPS30ToolStripMenuItem.Checked = false;
        currentFPS = 29.97d;
    }

    private void CurFPS30ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurFPS23976ToolStripMenuItem.Checked = false;
        CurFPS25ToolStripMenuItem.Checked = false;
        CurFPS15ToolStripMenuItem.Checked = false;
        CurFPS20ToolStripMenuItem.Checked = false;
        CurFPS24ToolStripMenuItem.Checked = false;
        CurFPS2997ToolStripMenuItem.Checked = false;
        CurFPS30ToolStripMenuItem.Checked = true;
        currentFPS = 30d;
    }

    private void ToFPS15ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 15d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(15d);

        CurFPS15ToolStripMenuItem.PerformClick();
    }

    private void ToFPS20ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 20d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(20d);

        CurFPS20ToolStripMenuItem.PerformClick();
    }

    private void ToFPS24ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 24d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(24d);

        CurFPS24ToolStripMenuItem.PerformClick();
    }

    private void toFPS2997ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 29.97d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(29.97d);

        CurFPS2997ToolStripMenuItem.PerformClick();
    }

    private void ToFPS30ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        if ((currentFPS == 0d) | (currentFPS == 30d))
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("noFPSsetOrCurrentFPS"));
            return;
        }

        Generic.ConvertToFPS(30d);

        CurFPS30ToolStripMenuItem.PerformClick();
    }

    private void CheckForOverlappingSubtitles(object sender, EventArgs e)
    {
        if (dgvSubtitles.RowCount == 0)
            return;

        Generic.addToDebugList(Generic.loadStringFromLangFile("startingCheckForOverlaps"));
        int startTime;
        int endTime;
        var problemsCount = 0;

        for (int i = 0, loopTo = dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            startTime = Generic.convertShowHideCellToMiliseconds(i, true);
            endTime = Generic.convertShowHideCellToMiliseconds(i, false);

            if (endTime <= startTime)
            {
                Generic.addToDebugList(Generic.loadStringFromLangFile("subtitleEntryWord") + " " +
                                       Generic.getSubtitleID(i) + ":" + " " +
                                       Generic.loadStringFromLangFile("hideTimeLessOrEqual"));
                problemsCount += 1;
            }

            if (!(i == dgvSubtitles.RowCount - 1))
            {
                startTime = Generic.convertShowHideCellToMiliseconds(i + 1, true);

                if (startTime < endTime)
                {
                    Generic.addToDebugList(Generic.loadStringFromLangFile("subtitleEntryWord") + " " +
                                           Generic.getSubtitleID(i) + ":" + " " +
                                           Generic.loadStringFromLangFile("nextLineStartsBeforePreviousEnds"));
                    problemsCount += 1;
                }
            }
        }

        if (problemsCount == 0)
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("allTimingsCorrect"));
        }
        else
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("checkEnded") + " " + problemsCount + " " +
                                   Generic.loadStringFromLangFile("soManyProblemsFound"));
            ViewTabsToolStripMenuItem.Checked = true;
            tabControl.SelectedTab = tabDebug;
            ViewTabsToolStripMenuItem_Click(null, null);
        }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MyProject.Forms.frmAbout.ShowDialog();
    }

    private void ApplyCustomDelayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int delay, percentComplete;
        try
        {
            delay = Conversions.ToInteger(Interaction.InputBox(Generic.loadStringFromLangFile("addCustomDelayPrompt"),
                DefaultResponse: "0"));
        }
        catch
        {
            return;
        }

        for (int i = 0, loopTo = dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            var startTime = Generic.convertShowHideCellToMiliseconds(i, true);
            var endTime = Generic.convertShowHideCellToMiliseconds(i, false);

            startTime += delay;
            endTime += delay;

            Generic.convertMilisecondsToShowHideCell(startTime, i, true);
            Generic.convertMilisecondsToShowHideCell(endTime, i, false);

            percentComplete = (int)Math.Round(i / (double)dgvSubtitles.RowCount);

            statusStrip.Text = percentComplete + "% completed, please wait...";
            Invalidate();
        }
    }

    private void GreekToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "LanguageFile",
            Application.StartupPath + @"\Languages\Greek.sel");
        Generic.loadTranslation(1);
    }

    private void nudShow_upDownButtonClick(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
            mtbShow.Text = Generic.convertMilisecondsToShowHideCell((int)Math.Round(nudShow.Value));
    }

    private void nudHide_UpDownButtonClick(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
            mtbHide.Text = Generic.convertMilisecondsToShowHideCell((int)Math.Round(nudHide.Value));
    }

    private void nudDuration_UpDownButtonClick(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
            mtbDuration.Text = Generic.convertMilisecondsToShowHideCell((int)Math.Round(nudDuration.Value));
    }

    private void mtbShow_TextChanged(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
        {
            dgvSubtitles.SelectedCells[0].OwningRow.Cells["subShow"].Value = mtbShow.Text;
            mySubtitles.setShowTime(dgvSubtitles.SelectedCells[0].OwningRow.Index, mtbShow.Text);
            if (rbtLockShow.Checked | rbtLockHide.Checked)
            {
                checkIfHideLessThanShow("Show");
                calculateDuration();
            }
            else if (rbtLockDuration.Checked)
            {
                nudHide.Value = nudShow.Value + nudDuration.Value;
            }
        }
    }

    private void mtbHide_TextChanged(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
        {
            dgvSubtitles.SelectedCells[0].OwningRow.Cells["subHide"].Value = mtbHide.Text;
            mySubtitles.setHideTime(dgvSubtitles.SelectedCells[0].OwningRow.Index, mtbHide.Text);
            if (rbtLockShow.Checked | rbtLockHide.Checked)
            {
                checkIfHideLessThanShow("Hide");
                calculateDuration();
            }
            else if (rbtLockDuration.Checked)
            {
                nudShow.Value = nudHide.Value - nudDuration.Value;
            }
        }
    }

    private void mtbDuration_TextChanged(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedCells.Count > 0)
        {
            if (rbtLockShow.Checked)
                nudHide.Value = nudShow.Value + nudDuration.Value;
            else if (rbtLockHide.Checked)
                nudShow.Value = nudHide.Value - nudDuration.Value;
            else
                nudHide.Value = nudShow.Value + nudDuration.Value;
            nudHide_UpDownButtonClick(null, null);
        }
    }

    private void calculateDuration()
    {
        nudDuration.Value = nudHide.Value - nudShow.Value;
        mtbDuration.Text = Generic.convertMilisecondsToShowHideCell((int)Math.Round(nudDuration.Value));
    }

    private void rtbSubtitle_TextChanged(object sender, EventArgs e)
    {
        if (mPlayer.playState == WMPPlayState.wmppsPlaying)
            return;
        var temp2 = "";

        if (dgvSubtitles.SelectedCells.Count > 0)
        {
            if (!string.IsNullOrEmpty(rtbSubtitle.Text))
            {
                foreach (var temp3 in rtbSubtitle.Lines)
                    temp2 = temp2 + temp3 + " | ";
                temp2 = Strings.Left(temp2, temp2.Length - 3);
            }

            mySubtitles.setText(dgvSubtitles.SelectedCells[0].OwningRow.Index, temp2);
            mySubtitles.passLineToDataGridView(dgvSubtitles.SelectedCells[0].OwningRow.Index);
        }
    }

    public void tmrDebug_Tick(object sender, EventArgs e)
    {
        switch (tick)
        {
            case 0:
            {
                lblStatus.Text = lstDebug.Items[0].ToString();
                break;
            }
            case 30:
            {
                if (Generic.incompleteLanguageFile == false)
                    lblStatus.Text = Generic.loadStringFromLangFile("readyStatus");
                tmrDebug.Enabled = false;
                break;
            }
        }

        tick = (short)(tick + 1);
    }

    private void dgvSubtitles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        findSubForCurrentTime();
        dgvSubtitles_SelectionChanged(null, null);
    }

    private void mPlayer_OpenStateChange(object sender, _WMPOCXEvents_OpenStateChangeEvent e)
    {
        if (mPlayer.openState == WMPOpenState.wmposMediaOpen)
        {
            sldPosition.Maximum = (int)Math.Round(mPlayer.currentMedia.duration);
            mPlayer.Ctlcontrols.pause();
        }
    }

    private void mPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
    {
        if (mPlayer.playState == WMPPlayState.wmppsStopped)
        {
            lblShowSub.Visible = false;
            btnPlay.BackgroundImage = Resources.play;
        }
        else if (mPlayer.playState == WMPPlayState.wmppsPlaying)
        {
            btnPlay.BackgroundImage = Resources.pause;
        }
        else
        {
            mPlayer.Ctlcontrols.pause();
            btnPlay.BackgroundImage = Resources.play;
        }
        // Debug.Print(mPlayer.playState)
    }

    private void chkBold_CheckedChanged(object sender, EventArgs e)
    {
        if (!(dgvSubtitles.SelectedCells.Count == 0))
        {
            mySubtitles.setIsBold(dgvSubtitles.SelectedCells[0].OwningRow.Index, chkBold.Checked);
            dgvSubtitles_SelectionChanged(null, null);
        }
        else
        {
            chkBold.Checked = false;
        }
    }

    private void chkItalic_CheckedChanged(object sender, EventArgs e)
    {
        if (!(dgvSubtitles.SelectedCells.Count == 0))
        {
            mySubtitles.setIsItalic(dgvSubtitles.SelectedCells[0].OwningRow.Index, chkItalic.Checked);
            dgvSubtitles_SelectionChanged(null, null);
        }
        else
        {
            chkItalic.Checked = false;
        }
    }


    public void formatSubtitle()
    {
        formatSubtitle(currentRow);
    }

    public void formatSubtitle(int row)
    {
        var tempProperties = new string[3];
        tempProperties = Strings.Split(mySubtitles.getPropertiesString(row), ",");
        switch (tempProperties[0] ?? "")
        {
            case "BI":
            {
                rtbSubtitle.Font = new Font(rtbSubtitle.Font, (FontStyle)((int)FontStyle.Bold + (int)FontStyle.Italic));
                lblShowSub.Font = new Font(lblShowSub.Font, (FontStyle)((int)FontStyle.Bold + (int)FontStyle.Italic));
                break;
            }
            case "B":
            {
                rtbSubtitle.Font = new Font(rtbSubtitle.Font, FontStyle.Bold);
                lblShowSub.Font = new Font(lblShowSub.Font, FontStyle.Bold);
                break;
            }
            case "I":
            {
                rtbSubtitle.Font = new Font(rtbSubtitle.Font, FontStyle.Italic);
                lblShowSub.Font = new Font(lblShowSub.Font, FontStyle.Italic);
                break;
            }

            case var @case when @case == "":
            {
                rtbSubtitle.Font = new Font(rtbSubtitle.Font, FontStyle.Regular);
                lblShowSub.Font = new Font(lblShowSub.Font, FontStyle.Regular);
                break;
            }
        }

        mySubtitles.convertPropertiesStringToProperties(row);
    }

    private void updateSubtitleProperties()
    {
        var tempProperties = new string[3];
        var currentRow = dgvSubtitles.SelectedCells[0].OwningRow.Index;

        tempProperties = Strings.Split(mySubtitles.getPropertiesString(currentRow), ",");
        if (chkBold.Checked)
        {
            if (chkItalic.Checked)
                tempProperties[0] = "BI";
            else
                tempProperties[0] = "B";
        }
        else if (chkItalic.Checked)
        {
            tempProperties[0] = "I";
        }
        else
        {
            tempProperties[0] = "";
        }

        if (tempProperties.Length == 1)
            mySubtitles.setPropertiesString(currentRow, tempProperties[0]);
        else
            mySubtitles.setPropertiesString(currentRow, tempProperties[0] + "," + tempProperties[1]);
        mySubtitles.convertPropertiesStringToProperties(currentRow);
        mySubtitles.passLineToDataGridView(currentRow);
    }

    private void updateSubtitlePropertiesInDB()
    {
        var tempProperties = new string[3];
        tempProperties[1] = "";
        tempProperties =
            Strings.Split(Conversions.ToString(dgvSubtitles.SelectedCells[0].OwningRow.Cells["subProperties"].Value),
                ",");
        // If chkBold.Checked = True Then 
        if (string.IsNullOrEmpty(tempProperties[1]))
            dgvSubtitles.SelectedCells[0].OwningRow.Cells["subProperties"].Value = tempProperties[0];
        else
            dgvSubtitles.SelectedCells[0].OwningRow.Cells["subProperties"].Value =
                tempProperties[0] + "," + tempProperties[1];
    }

    private void SortSubtitlesBasedOnShowTimingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Generic.sortDGV();
        mySubtitles.passDataGridViewToArray();
    }

    public void scrollToSelectedRow()
    {
        var halfWay = (int)Math.Round(dgvSubtitles.DisplayedRowCount(false) / 2d);
        if ((dgvSubtitles.FirstDisplayedScrollingRowIndex + halfWay > dgvSubtitles.SelectedRows[0].Index) |
            (dgvSubtitles.FirstDisplayedScrollingRowIndex + dgvSubtitles.DisplayedRowCount(false) - halfWay <=
             dgvSubtitles.SelectedRows[0].Index))
        {
            var targetRow = dgvSubtitles.SelectedRows[0].Index;

            targetRow = Math.Max(targetRow - halfWay, 0);
            dgvSubtitles.FirstDisplayedScrollingRowIndex = targetRow;
        }
    }

    private void btnPlay_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(mPlayer.URL))
        {
            if (mPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                mPlayer.Ctlcontrols.pause();
                btnPlay.BackgroundImage = Resources.play;
            }
            else
            {
                playMovie();
                btnPlay.BackgroundImage = Resources.pause;
            }
        }
    }

    private void btnFR_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(cmbFRorFFby.Text) & !string.IsNullOrEmpty(mPlayer.URL))
        {
            var temp = Strings.Split(cmbFRorFFby.Text, " ms");
            TimerSub.Enabled = false;
            mPlayer.Ctlcontrols.currentPosition -= Conversions.ToInteger(temp[0]) / 1000d;
            if (!(dgvSubtitles.RowCount == 0)) findSubForCurrentTime();
            if (mPlayer.playState == WMPPlayState.wmppsPlaying)
                TimerSub.Enabled = true;
            else
                updateCurrentPositionLabel();
        }
    }

    private void btnFF_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(cmbFRorFFby.Text) & !string.IsNullOrEmpty(mPlayer.URL))
        {
            var temp = Strings.Split(cmbFRorFFby.Text, " ms");
            TimerSub.Enabled = false;
            mPlayer.Ctlcontrols.currentPosition += Conversions.ToDouble(temp[0]) / 1000d;
            if (!(dgvSubtitles.RowCount == 0)) findSubForCurrentTime();
            if (mPlayer.playState == WMPPlayState.wmppsPlaying)
                TimerSub.Enabled = true;
            else
                updateCurrentPositionLabel();
        }
    }

    private void btnToStart_Click(object sender, EventArgs e)
    {
        TimerSub.Enabled = false;
        mPlayer.Ctlcontrols.currentPosition = 0d;
        if (!(dgvSubtitles.RowCount == 0)) findSubForCurrentTime();
        TimerSub.Enabled = true;
    }

    private void btnToEnd_Click(object sender, EventArgs e)
    {
        mPlayer.Ctlcontrols.currentPosition = mPlayer.currentMedia.duration;
    }

    private void cmbFRorFFby_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsNumber(e.KeyChar) == false) e.Handled = true;
    }

    private void sldVolume_Scroll(object sender, EventArgs e)
    {
        mPlayer.settings.volume = sldVolume.Value;
        toolTip.SetToolTip(sldVolume, sldVolume.Value.ToString());
    }

    public void updateCurrentPositionLabel()
    {
        var curpos = new string[2];
        int curposint;
        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        if (curpos.Count() == 2)
        {
            curpos[1] = Strings.Left(curpos[1], 3);
            if (curpos[1].Length == 2)
                curpos[1] = curpos[1] + "0";
            else if (curpos[1].Length == 1) curpos[1] = curpos[1] + "00";
            curposint = Conversions.ToInteger(curpos[0]) * 1000 + Conversions.ToInteger(curpos[1]);
            lblCurPos.Text = Generic.convertMilisecondsToShowHideCell(curposint);
        }
        else
        {
            curposint = Conversions.ToInteger(curpos[0]) * 1000;
            lblCurPos.Text = Generic.convertMilisecondsToShowHideCell(curposint);
        }

        if (sldPosition.Maximum == 0)
            sldPosition.Maximum = (int)Math.Round(mPlayer.currentMedia.duration);
        sldPosition.Value = (int)Math.Round(mPlayer.Ctlcontrols.currentPosition);
    }

    private void sldPosition_MouseDown(object sender, MouseEventArgs e)
    {
        if (mPlayer.playState == WMPPlayState.wmppsPlaying)
        {
            mPlayer.Ctlcontrols.pause();
            wasPaused = false;
        }
        else
        {
            wasPaused = true;
        }
    }

    private void sldPosition_MouseUp(object sender, MouseEventArgs e)
    {
        if ((mPlayer.playState == WMPPlayState.wmppsPaused) & (wasPaused == false)) mPlayer.Ctlcontrols.play();
    }

    private void sldPosition_Scroll(object sender, EventArgs e)
    {
        mPlayer.Ctlcontrols.currentPosition = sldPosition.Value;
    }

    private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(Conversions.ToString(lstDebug.SelectedItem));
    }

    private void tabDebug_Enter(object sender, EventArgs e)
    {
        tabDebug.ImageIndex = -1;
    }

    public void ViewTabsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ViewTabsToolStripMenuItem.Checked)
            // If mPlayer.URL = "" Then
            // MessageBox.Show("No video is loaded")
            // ViewTabsToolStripMenuItem.Checked = False
            // Else
            tabControl.Visible = true;
        // End If
        else
            tabControl.Visible = false;
    }

    private void checkIfHideLessThanShow(string sender)
    {
        if (nudHide.Value - nudShow.Value < 0m)
        {
            if (rbtLockShow.Checked)
            {
                nudHide.Value = nudShow.Value;
                nudHide_UpDownButtonClick(null, null);
            }
            else if (rbtLockHide.Checked)
            {
                nudShow.Value = nudHide.Value;
                nudShow_upDownButtonClick(null, null);
            }
            else if (sender == "Show")
            {
                nudHide.Value = nudShow.Value;
                nudHide_UpDownButtonClick(null, null);
            }
            else if (sender == "Hide")
            {
                nudShow.Value = nudHide.Value;
                nudShow_upDownButtonClick(null, null);
            }
        }
    }

    private void btnQuickAdd_MouseDown(object sender, MouseEventArgs e)
    {
        if (string.IsNullOrEmpty(mPlayer.URL))
            return;

        var curpos = new string[3];
        short milisecondsTemp;

        editMode = true;

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        if (curpos.Count() == 1)
        {
            Array.Resize(ref curpos, 2);
            curpos[1] = "000";
            milisecondsTemp = 0;
        }
        else
        {
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));
        }

        var timeInMS = Conversions.ToInteger(curpos[0]) * 1000 + milisecondsTemp;

        var checkTemp = Generic.checkIfNewSubtitleExistsOnGivenTime(timeInMS);
        if (checkTemp > 0)
        {
            Generic.addToDebugList(Generic.loadStringFromLangFile("subtitleEntryWord") + " " + checkTemp + ": " +
                                   Generic.loadStringFromLangFile("subtitleAlreadyExistsOnGivenTime"));
            ViewTabsToolStripMenuItem.Checked = true;
            tabControl.SelectedTab = tabDebug;
            ViewTabsToolStripMenuItem_Click(null, null);
            return;
        }

        tempSub.ID = dgvSubtitles.RowCount;
        // If dgvSubtitles.AllowUserToAddRows Then tempSub.ID = dgvSubtitles.RowCount - 1
        tempSub.showTimeInMS = timeInMS;
        tempSub.text = "";
        tempSub.isBold = Conversions.ToString(false);
        tempSub.isItalic = Conversions.ToString(false);
        tempSub.translationText = "";
    }

    private void btnQuickAdd_MouseUp(object sender, MouseEventArgs e)
    {
        if (string.IsNullOrEmpty(mPlayer.URL))
            return;

        var curpos = new string[3];
        short milisecondsTemp;

        if (chkPauseAfterQuick.Checked) mPlayer.Ctlcontrols.pause();

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        if (curpos.Count() == 1)
        {
            Array.Resize(ref curpos, 2);
            curpos[1] = "000";
            milisecondsTemp = 0;
        }
        else
        {
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));
        }

        var timeInMS = Conversions.ToInteger(curpos[0]) * 1000 + milisecondsTemp;

        tempSub.hideTimeInMS = timeInMS;
        mySubtitles.setAll(tempSub.ID, tempSub);

        mySubtitles.addNewLineToDataGridView(tempSub.ID);

        dgvSubtitles_SelectionChanged(null, null);

        Generic.sortDGV();

        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lstDebug.Items[0],
                Generic.loadStringFromLangFile("pleaseCheckForOverlaps"), false)))
            Generic.addToDebugList(Generic.loadStringFromLangFile("pleaseCheckForOverlaps"));

        editMode = false;
    }

    private void btnQuickEdit_MouseDown(object sender, MouseEventArgs e)
    {
        if (string.IsNullOrEmpty(mPlayer.URL))
            return;

        var curpos = new string[3];
        short milisecondsTemp;

        editMode = true;

        if (dgvSubtitles.SelectedCells.Count == 0)
            return;

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        var secondsTemp = Conversions.ToShort(curpos[0]);
        if (curpos.Count() == 1)
            milisecondsTemp = 0;
        else
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));

        var timeInMS = secondsTemp * 1000 + milisecondsTemp;
        var row = dgvSubtitles.SelectedCells[0].OwningRow.Index;

        Generic.convertMilisecondsToShowHideCell(timeInMS, row, true);
        dgvSubtitles_SelectionChanged(null, null);
    }

    private void btnQuickEdit_MouseUp(object sender, MouseEventArgs e)
    {
        if (string.IsNullOrEmpty(mPlayer.URL))
            return;

        var curpos = new string[3];
        short milisecondsTemp;

        if (dgvSubtitles.SelectedCells.Count == 0)
            return;

        curpos = Strings.Split(mPlayer.Ctlcontrols.currentPosition.ToString(), Generic.DecimalSeparator, 2);
        var secondsTemp = Conversions.ToShort(curpos[0]);
        if (curpos.Count() == 1)
            milisecondsTemp = 0;
        else
            milisecondsTemp = Conversions.ToShort(Strings.Left(curpos[1], 3));

        var timeInMS = secondsTemp * 1000 + milisecondsTemp;
        var row = dgvSubtitles.SelectedCells[0].OwningRow.Index;

        Generic.convertMilisecondsToShowHideCell(timeInMS, row, false);
        dgvSubtitles_SelectionChanged(null, null);

        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lstDebug.Items[0],
                Generic.loadStringFromLangFile("pleaseCheckForOverlaps"), false)))
            Generic.addToDebugList(Generic.loadStringFromLangFile("pleaseCheckForOverlaps"));

        editMode = false;
    }

    private void stopMovie()
    {
        mPlayer.Ctlcontrols.stop();
        TimerSub.Enabled = false;
        lblShowSub.Text = "";
        pnlTimerOnly.Visible = true;
        oldRow = -1;
    }

    private void playMovie()
    {
        mPlayer.Ctlcontrols.currentPosition = Generic.convertShowHideCellToMiliseconds(lblCurPos.Text) / 1000d;
        mPlayer.Ctlcontrols.play();
        sldPosition.Maximum = (int)Math.Round(mPlayer.currentMedia.duration);
        editMode = false;
        lblPlayRate.Text = mPlayer.settings.rate + "x";
        findSubForCurrentTime();
        TimerSub.Enabled = true;
    }

    public void ReformatInvalidString(ref string str)
    {
        if (string.IsNullOrEmpty(str))
            str = new string("00:00:00,000".ToCharArray());
        str.Trim();
        if (string.IsNullOrEmpty(str) | (str.Length <= 10)) str = "00:00:00,000";
    }


    internal void dgvSubtitles_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvSubtitles.SelectedRows.Count > 0)
        {
            // Is there a subtitle entry for this row
            // If Subtitles.SubtitleType.
            nudDuration.Enabled = true;
            nudHide.Enabled = true;
            nudShow.Enabled = true;
            mtbHide.Enabled = true;
            mtbShow.Enabled = true;
            mtbDuration.Enabled = true;
            btnQuickEdit.Enabled = true;

            var rowNumber = dgvSubtitles.SelectedCells[0].OwningRow.Index;

            var argstr = Conversions.ToString(dgvSubtitles.Rows[rowNumber].Cells[1].Value);
            ReformatInvalidString(ref argstr);
            dgvSubtitles.Rows[rowNumber].Cells[1].Value = argstr;
            var argstr1 = Conversions.ToString(dgvSubtitles.Rows[rowNumber].Cells[2].Value);
            ReformatInvalidString(ref argstr1);
            dgvSubtitles.Rows[rowNumber].Cells[2].Value = argstr1;

            nudShow.Value = Generic.convertShowHideCellToMiliseconds(rowNumber, true);
            nudHide.Value = Generic.convertShowHideCellToMiliseconds(rowNumber, false);
            calculateDuration();
            nudShow_upDownButtonClick(null, null);
            nudHide_UpDownButtonClick(null, null);
            rtbSubtitle.Lines =
                Generic.convertMultiLineTextToArray(
                    Conversions.ToString(dgvSubtitles.SelectedCells[0].OwningRow.Cells[3].Value));
            chkBold.Checked = mySubtitles.getIsBold(rowNumber);
            chkItalic.Checked = mySubtitles.getIsItalic(rowNumber);
            updateSubtitleProperties();
            formatSubtitle(rowNumber);
        }
        else
        {
            nudDuration.Enabled = false;
            nudHide.Enabled = false;
            nudShow.Enabled = false;
            mtbHide.Enabled = false;
            mtbShow.Enabled = false;
            mtbDuration.Enabled = false;
            mtbHide.Text = "__:__:__.___";
            mtbShow.Text = "__:__:__.___";
            mtbDuration.Text = "__:__:__.___";
            btnQuickEdit.Enabled = false;
        }
    }

    private void dgvSubtitles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        // Dim tempSub As New Subtitles.SubtitleType
        // tempSub.ID = dgvSubtitles.RowCount
        // tempSub.showTimeInMS = 0
        // tempSub.hideTimeInMS = 0
        // tempSub.text = ""
        // tempSub.isBold = False
        // tempSub.isItalic = False
        // tempSub.translationText = ""

        // mySubtitles.setAll(tempSub.ID - 1, tempSub)

        // ReformatInvalidString(dgvSubtitles.Rows(e.RowIndex).Cells(1).Value())
        // ReformatInvalidString(dgvSubtitles.Rows(e.RowIndex).Cells(2).Value())
    }


    // **** Incomplete ****
    private bool subtitleFileSaved()
    {
        var result = false;

        if (dgvSubtitles.RowCount > 0)
        {
            if (string.IsNullOrEmpty(Conversions.ToString(dgvSubtitles.Rows[0].Cells[3].Value))) result = true;
        }
        else
        {
            result = true;
        }

        return result;
    }

    private void btnQuickEdit_MouseHover(object sender, EventArgs e)
    {
        // dgvSubtitles.CurrentRow.DataGridView.BackgroundColor = System.Drawing.Color.Aqua

        dgvSubtitles.SelectedRows[0].Cells[1].Selected = true;
        // dgvSubtitles.SelectedRows(0).Cells(2).DataGridView.BackgroundColor = Color.Aqua
    }

    private void OnNextLineToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var tempSub = new Subtitles.SubtitleType();
        tempSub.ID = dgvSubtitles.RowCount + 1;
        tempSub.showTimeInMS = 0;
        tempSub.hideTimeInMS = 0;
        tempSub.text = "";
        tempSub.isBold = Conversions.ToString(false);
        tempSub.isItalic = Conversions.ToString(false);
        tempSub.translationText = "";

        mySubtitles.setAll(tempSub.ID - 1, tempSub);
        dgvSubtitles.Rows.Add();
    }

    private void btnShowHidePanel_Click(object sender, EventArgs e)
    {
        if (SplitContainer1.Panel1Collapsed)
        {
            SplitContainer1.Panel1Collapsed = false;
            btnShowHidePanel.BackgroundImage = Resources.leftarrow;
        }
        else
        {
            SplitContainer1.Panel1Collapsed = true;
            btnShowHidePanel.BackgroundImage = Resources.rightarrow;
        }

        rtbSubtitle.Left = chkBold.Right + 10;
    }

    public string getFirstDebugListItem()
    {
        return lstDebug.Items[0].ToString();
    }
}