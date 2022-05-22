using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenSubtitleEditor.My;
using WMPLib;

namespace OpenSubtitleEditor;

public class Subtitles
{
    private int currentIndex;
    private string currentLine;
    private Encoding subEncoding = Encoding.Default;
    private string subFormat;
    private int subsCount;
    private StreamReader subsFileReader;
    private StreamWriter subsFileWriter;

    private string[] subTextParts = new string[3];

    // Declare array to hold all subtitles
    private SubtitleType[] SubtitleArray = { };
    private string thirdPart;

    // Constructor

    // Public Functions and Methods
    public SubtitleType getAll(int index)
    {
        return SubtitleArray[index];
    }

    public void setAll(int index, SubtitleType subtitle)
    {
        try
        {
            SubtitleArray[index] = subtitle;
        }
        catch (IndexOutOfRangeException ex)
        {
            Array.Resize(ref SubtitleArray, index + 1);
            SubtitleArray[index] = subtitle;
        }

        setShowTimeInMS(index, subtitle.showTimeInMS);
        setHideTimeInMS(index, subtitle.hideTimeInMS);
    }

    public SubtitleType getAllbyID(int myID)
    {
        var index = default(int);
        for (int i = 0, loopTo = SubtitleArray.Count() - 1; i <= loopTo; i++)
            if (SubtitleArray[i].ID == myID)
            {
                index = i;
                break;
            }

        return SubtitleArray[index];
    }

    public int getID(int index)
    {
        return SubtitleArray[index].ID;
    }

    public void setID(int index, int myID)
    {
        SubtitleArray[index].ID = myID;
    }

    public string getShowTime(int index)
    {
        return SubtitleArray[index].showTime;
    }

    public void setShowTime(int index, string myShowTime)
    {
        SubtitleArray[index].showTime = myShowTime;
        SubtitleArray[index].showTimeInMS = Generic.convertShowHideCellToMiliseconds(myShowTime);
    }

    public int getShowTimeInMS(int index)
    {
        return SubtitleArray[index].showTimeInMS;
    }

    public void setShowTimeInMS(int index, int myshowTimeInMS)
    {
        SubtitleArray[index].showTimeInMS = myshowTimeInMS;
        SubtitleArray[index].showTime = Generic.convertMilisecondsToShowHideCell(myshowTimeInMS);
    }

    public string getHideTime(int index)
    {
        return SubtitleArray[index].hideTime;
    }

    public void setHideTime(int index, string myHideTime)
    {
        SubtitleArray[index].hideTime = myHideTime;
        SubtitleArray[index].hideTimeInMS = Generic.convertShowHideCellToMiliseconds(myHideTime);
    }

    public int getHideTimeInMS(int index)
    {
        return SubtitleArray[index].hideTimeInMS;
    }

    public void setHideTimeInMS(int index, int myHideTimeInMS)
    {
        SubtitleArray[index].hideTimeInMS = myHideTimeInMS;
        SubtitleArray[index].hideTime = Generic.convertMilisecondsToShowHideCell(myHideTimeInMS);
    }

    public string getText(int index)
    {
        return SubtitleArray[index].text;
    }

    public void setText(int index, string myText)
    {
        SubtitleArray[index].text = myText;
    }

    public string getTranslationText(int index)
    {
        return SubtitleArray[index].translationText;
    }

    public void setTranslationText(int index, string myTranslationText)
    {
        SubtitleArray[index].translationText = myTranslationText;
    }

    public bool getIsBold(int index)
    {
        return Conversions.ToBoolean(SubtitleArray[index].isBold);
    }

    public void setIsBold(int index, bool myIsBold)
    {
        SubtitleArray[index].isBold = Conversions.ToString(myIsBold);
    }

    public bool getIsItalic(int index)
    {
        return Conversions.ToBoolean(SubtitleArray[index].isItalic);
    }

    public void setIsItalic(int index, bool myIsItalic)
    {
        SubtitleArray[index].isItalic = Conversions.ToString(myIsItalic);
    }

    public string getPropertiesString(int index)
    {
        return SubtitleArray[index].propertiesString;
    }

    public void setPropertiesString(int index, string myPropertiesString)
    {
        SubtitleArray[index].propertiesString = myPropertiesString;
    }

    public void getAllExts()
    {
        string fileWord;
        fileWord = Generic.loadStringFromLangFile("fileWord");
        MyProject.Forms.frmMain.dlgSubOpen.Filter = "SubRip " + fileWord + " (*.srt)|*.srt|" + "Text " + fileWord +
                                                    " (*.txt)|*.txt|" + "Any " + fileWord + " (*.*)|*.*";

        MyProject.Forms.frmMain.dlgSubSave.Filter = MyProject.Forms.frmMain.dlgSubOpen.Filter;
    }

    public void clear()
    {
        SubtitleArray = new SubtitleType[] { };
    }

    public string getSubFormat()
    {
        return subFormat;
    }

    public void setSubFormat(string mySubFormat)
    {
        subFormat = mySubFormat;
    }

    public Encoding getSubEncoding()
    {
        return subEncoding;
    }

    public void setSubEncoding(Encoding mySubEncoding)
    {
        subEncoding = mySubEncoding;
    }

    /// <summary>
    ///     Opens a FileOpen dialog and continues to open the subtitle file, load it into the
    ///     frmMain.mySubtitles array and the DataGridView.
    /// </summary>
    /// <remarks></remarks>
    public void open()
    {
        var failed = false;

        // Get extensions OSE supports.
        getAllExts();

        // If user picks a file, continue.
        if (MyProject.Forms.frmMain.dlgSubOpen.ShowDialog() == DialogResult.OK)
        {
            // Disable display of subtitles while loading a new file.
            if (MyProject.Forms.frmMain.mPlayer.playState == WMPPlayState.wmppsPlaying)
                MyProject.Forms.frmMain.TimerSub.Enabled = false;

            // Guess the subtitle format from the file extension.
            switch (Strings.LCase(Strings.Right(MyProject.Forms.frmMain.dlgSubOpen.FileName, 3)) ?? "")
            {
                case "srt":
                {
                    subFormat = "SubRip";
                    break;
                }

                default:
                {
                    subFormat = "Unknown";
                    failed = true;
                    break;
                }
            }

            // See if there's a Unicode BOM.
            var binaryReader = new BinaryReader(File.OpenRead(MyProject.Forms.frmMain.dlgSubOpen.FileName));

            var first = binaryReader.ReadByte();
            var second = binaryReader.ReadByte();

            if ((first == Convert.ToByte("FF", 16)) & (second == Convert.ToByte("FE", 16)))
            {
                subEncoding = Encoding.Unicode;
            }
            else if ((first == Convert.ToByte("FE", 16)) & (second == Convert.ToByte("FF", 16)))
            {
                subEncoding = Encoding.BigEndianUnicode;
            }
            else if ((first == Convert.ToByte("EF", 16)) & (second == Convert.ToByte("BB", 16)))
            {
                subEncoding = Encoding.UTF8;
            }
            else
            {
                // If the file's not Unicode...
                subEncoding = Encoding.Default;
                failed = true;
            }

            binaryReader.Close();

            // If the subtitle format isn't certain and/or the encoding isn't unicode, we ask the user
            // to pick for themselves.
            if (failed)
            {
                MyProject.Forms.frmUnknownFormat.ShowDialog(MyProject.Forms.frmMain);
                if (MyProject.Forms.frmUnknownFormat.DialogResult == DialogResult.Cancel)
                {
                    if ((MyProject.Forms.frmMain.mPlayer.playState == WMPPlayState.wmppsPaused) |
                        (MyProject.Forms.frmMain.mPlayer.playState == WMPPlayState.wmppsPlaying))
                    {
                        MyProject.Forms.frmMain.findSubForCurrentTime();
                        MyProject.Forms.frmMain.TimerSub.Enabled = true;
                    }

                    return;
                }
            }

            var startTime = DateTime.Now;

            subsFileReader =
                MyProject.Computer.FileSystem.OpenTextFileReader(MyProject.Forms.frmMain.dlgSubOpen.FileName,
                    subEncoding);

            MyProject.Forms.frmMain.dgvSubtitles.Rows.Clear();
            clear();

            switch (subFormat ?? "")
            {
                case "SubRip":
                {
                    LoadSRTSubRip();
                    break;
                }
            }

            passArrayToDataGridView();

            subsFileReader.Close();

            Generic.updateTitle();

            if ((MyProject.Forms.frmMain.mPlayer.playState == WMPPlayState.wmppsPaused) |
                (MyProject.Forms.frmMain.mPlayer.playState == WMPPlayState.wmppsPlaying))
            {
                MyProject.Forms.frmMain.findSubForCurrentTime();
                MyProject.Forms.frmMain.TimerSub.Enabled = true;
            }

            MyProject.Forms.frmMain.CheckForOverlappingSubtitlesToolStripMenuItem.PerformClick();

            resetFPSsetting();

            MyProject.Forms.frmMain.dgvSubtitles_SelectionChanged(null, null);

            var endTime = DateTime.Now;
            Generic.addToDebugList(Generic.loadStringFromLangFile("parsedgen") + " " + subsCount + " " +
                                   Generic.loadStringFromLangFile("subsgen") + " " +
                                   Generic.loadStringFromLangFile("in_somany_seconds1") + " " +
                                   (endTime - startTime).Seconds + "." +
                                   (endTime - startTime).Milliseconds.ToString("000") + " " +
                                   Generic.loadStringFromLangFile("in_somany_seconds2"));
        }
    }

    public void save()
    {
        getAllExts();

        if (MyProject.Forms.frmMain.dlgSubSave.ShowDialog() == DialogResult.OK)
        {
            var startTime = DateTime.Now;

            passDataGridViewToArray();

            Generic.fileWriter =
                MyProject.Computer.FileSystem.OpenTextFileWriter(MyProject.Forms.frmMain.dlgSubSave.FileName, false,
                    subEncoding);

            switch (Strings.LCase(Strings.Right(MyProject.Forms.frmMain.dlgSubSave.FileName, 3)) ?? "")
            {
                case "srt":
                {
                    SaveSRTSubRip();
                    break;
                }
            }

            Generic.fileWriter.Close();

            MyProject.Forms.frmMain.dlgSubOpen.FileName = MyProject.Forms.frmMain.dlgSubSave.FileName;
            Generic.updateTitle();

            var endTime = DateTime.Now;
            Generic.addToDebugList(Generic.loadStringFromLangFile("parsedgen") + " " + subsCount + " " +
                                   Generic.loadStringFromLangFile("subsgen") + " " +
                                   Generic.loadStringFromLangFile("in_somany_seconds1") + " " +
                                   (endTime - startTime).Seconds + "." +
                                   (endTime - startTime).Milliseconds.ToString("000") + " " +
                                   Generic.loadStringFromLangFile("in_somany_seconds2"));
        }
    }

    private void parseProperties(ref string[] subTextParts)
    {
        var finalPart = (short)(subTextParts.Length - 1);

        if ((Strings.Left(subTextParts[0], 3) == "<b>") & (Strings.Right(subTextParts[finalPart], 4) == "</b>"))
        {
            SubtitleArray[currentIndex].isBold = Conversions.ToString(true);
            subTextParts[0] = Strings.Right(subTextParts[0], subTextParts[0].Length - 3);
            subTextParts[finalPart] = Strings.Left(subTextParts[finalPart], subTextParts[finalPart].Length - 4);
            if ((Strings.Left(subTextParts[0], 3) == "<i>") & (Strings.Right(subTextParts[finalPart], 4) == "</i>"))
            {
                SubtitleArray[currentIndex].isItalic = Conversions.ToString(true);
                subTextParts[0] = Strings.Right(subTextParts[0], subTextParts[0].Length - 3);
                subTextParts[finalPart] = Strings.Left(subTextParts[finalPart], subTextParts[finalPart].Length - 4);
            }
        }
        else
        {
            SubtitleArray[currentIndex].isBold = Conversions.ToString(false);
        }

        if ((Strings.Left(subTextParts[0], 3) == "<i>") & (Strings.Right(subTextParts[finalPart], 4) == "</i>"))
        {
            SubtitleArray[currentIndex].isItalic = Conversions.ToString(true);
            subTextParts[0] = Strings.Right(subTextParts[0], subTextParts[0].Length - 3);
            subTextParts[finalPart] = Strings.Left(subTextParts[finalPart], subTextParts[finalPart].Length - 4);
            if ((Strings.Left(subTextParts[0], 3) == "<b>") & (Strings.Right(subTextParts[finalPart], 4) == "</b>"))
            {
                SubtitleArray[currentIndex].isBold = Conversions.ToString(true);
                subTextParts[0] = Strings.Right(subTextParts[0], subTextParts[0].Length - 3);
                subTextParts[finalPart] = Strings.Left(subTextParts[finalPart], subTextParts[finalPart].Length - 4);
            }
        }
        else
        {
            SubtitleArray[currentIndex].isItalic = Conversions.ToString(false);
        }

        convertPropertiesToPropertiesString();
    }

    public void convertPropertiesToPropertiesString()
    {
        if (Conversions.ToBoolean(SubtitleArray[currentIndex].isBold) &
            Conversions.ToBoolean(SubtitleArray[currentIndex].isItalic))
            SubtitleArray[currentIndex].propertiesString = "BI";
        else if (Conversions.ToBoolean(SubtitleArray[currentIndex].isBold) &
                 (Conversions.ToBoolean(SubtitleArray[currentIndex].isItalic) == false))
            SubtitleArray[currentIndex].propertiesString = "B";
        else if ((Conversions.ToBoolean(SubtitleArray[currentIndex].isBold) == false) &
                 Conversions.ToBoolean(SubtitleArray[currentIndex].isItalic))
            SubtitleArray[currentIndex].propertiesString = "I";
        else if ((Conversions.ToBoolean(SubtitleArray[currentIndex].isBold) == false) &
                 (Conversions.ToBoolean(SubtitleArray[currentIndex].isItalic) == false))
            SubtitleArray[currentIndex].propertiesString = "";
    }

    public void convertPropertiesToPropertiesString(int index)
    {
        if (Conversions.ToBoolean(SubtitleArray[index].isBold) & Conversions.ToBoolean(SubtitleArray[index].isItalic))
            SubtitleArray[index].propertiesString = "BI";
        else if (Conversions.ToBoolean(SubtitleArray[index].isBold) &
                 (Conversions.ToBoolean(SubtitleArray[index].isItalic) == false))
            SubtitleArray[index].propertiesString = "B";
        else if ((Conversions.ToBoolean(SubtitleArray[index].isBold) == false) &
                 Conversions.ToBoolean(SubtitleArray[index].isItalic))
            SubtitleArray[index].propertiesString = "I";
        else if ((Conversions.ToBoolean(SubtitleArray[index].isBold) == false) &
                 (Conversions.ToBoolean(SubtitleArray[index].isItalic) == false))
            SubtitleArray[index].propertiesString = "";
    }

    public void convertPropertiesStringToProperties()
    {
        switch (SubtitleArray[currentIndex].propertiesString ?? "")
        {
            case "BI":
            {
                SubtitleArray[currentIndex].isBold = Conversions.ToString(true);
                SubtitleArray[currentIndex].isItalic = Conversions.ToString(true);
                break;
            }
            case "B":
            {
                SubtitleArray[currentIndex].isBold = Conversions.ToString(true);
                SubtitleArray[currentIndex].isItalic = Conversions.ToString(false);
                break;
            }
            case "I":
            {
                SubtitleArray[currentIndex].isBold = Conversions.ToString(false);
                SubtitleArray[currentIndex].isItalic = Conversions.ToString(true);
                break;
            }

            case var @case when @case == "":
            {
                SubtitleArray[currentIndex].isBold = Conversions.ToString(false);
                SubtitleArray[currentIndex].isItalic = Conversions.ToString(false);
                break;
            }
        }
    }

    public void convertPropertiesStringToProperties(int index)
    {
        switch (SubtitleArray[index].propertiesString ?? "")
        {
            case "BI":
            {
                SubtitleArray[index].isBold = Conversions.ToString(true);
                SubtitleArray[index].isItalic = Conversions.ToString(true);
                break;
            }
            case "B":
            {
                SubtitleArray[index].isBold = Conversions.ToString(true);
                SubtitleArray[index].isItalic = Conversions.ToString(false);
                break;
            }
            case "I":
            {
                SubtitleArray[index].isBold = Conversions.ToString(false);
                SubtitleArray[index].isItalic = Conversions.ToString(true);
                break;
            }

            case var @case when @case == "":
            {
                SubtitleArray[index].isBold = Conversions.ToString(false);
                SubtitleArray[index].isItalic = Conversions.ToString(false);
                break;
            }
        }
    }

    public void passArrayToDataGridView()
    {
        for (int i = 0, loopTo = SubtitleArray.Count() - 1; i <= loopTo; i++)
            MyProject.Forms.frmMain.dgvSubtitles.Rows.Add(SubtitleArray[i].ID, SubtitleArray[i].showTime,
                SubtitleArray[i].hideTime, SubtitleArray[i].text, SubtitleArray[i].propertiesString);
    }

    public void passArrayToDataGridView(bool clearBeforeAdding)
    {
        if (clearBeforeAdding) MyProject.Forms.frmMain.dgvSubtitles.Rows.Clear();
        for (int i = 0, loopTo = SubtitleArray.Count() - 1; i <= loopTo; i++)
            MyProject.Forms.frmMain.dgvSubtitles.Rows.Add(SubtitleArray[i].ID, SubtitleArray[i].showTime,
                SubtitleArray[i].hideTime, SubtitleArray[i].text, SubtitleArray[i].propertiesString);
    }

    public void passLineToDataGridView(int row)
    {
        MyProject.Forms.frmMain.dgvSubtitles.Rows[row].SetValues(SubtitleArray[row].ID, SubtitleArray[row].showTime,
            SubtitleArray[row].hideTime, SubtitleArray[row].text, SubtitleArray[row].propertiesString);
    }

    public void addNewLineToDataGridView(int row)
    {
        MyProject.Forms.frmMain.dgvSubtitles.Rows.Add(SubtitleArray[row].ID.ToString(), SubtitleArray[row].showTime,
            SubtitleArray[row].hideTime, SubtitleArray[row].text, SubtitleArray[row].propertiesString);
    }

    public void passDataGridViewToArray()
    {
        for (int i = 0, loopTo = MyProject.Forms.frmMain.dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            setID(i, Conversions.ToInteger(MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["subIndex"].Value));
            setShowTime(i, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["subShow"].Value));
            setHideTime(i, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["subHide"].Value));
            setText(i, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["subText"].Value));
            setPropertiesString(i,
                Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["subProperties"].Value));
        }
    }

    public void passLineToArray(int row)
    {
        setID(row, Conversions.ToInteger(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells["subIndex"].Value));
        setShowTime(row, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells["subShow"].Value));
        setHideTime(row, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells["subHide"].Value));
        setText(row, Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells["subText"].Value));
        setPropertiesString(row,
            Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells["subProperties"].Value));
    }

    private void resetFPSsetting()
    {
        MyProject.Forms.frmMain.CurFPS15ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS20ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS23976ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS24ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS25ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS2997ToolStripMenuItem.Checked = false;
        MyProject.Forms.frmMain.CurFPS30ToolStripMenuItem.Checked = false;
    }

    // Support for various formats.
    private void LoadSRTSubRip()
    {
        string currentLine;

        subsCount = 0;

        while (!subsFileReader.EndOfStream)
        {
            currentLine = subsFileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine))
            {
                currentLine = subsFileReader.ReadLine();
                currentLine = subsFileReader.ReadLine();
                currentLine = subsFileReader.ReadLine();
                if (!string.IsNullOrEmpty(currentLine))
                {
                    currentLine = subsFileReader.ReadLine();
                    if (!string.IsNullOrEmpty(currentLine)) currentLine = subsFileReader.ReadLine();
                }

                subsCount += 1;
            }
        }

        currentIndex = -1;

        SubtitleArray = new SubtitleType[subsCount];

        subsFileReader.Close();
        subsFileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(MyProject.Forms.frmMain.dlgSubOpen.FileName, subEncoding);

        while (!subsFileReader.EndOfStream)
        {
            currentLine = subsFileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine))
            {
                currentIndex += 1;
                SubtitleArray[currentIndex].ID = Conversions.ToInteger(currentLine);

                currentLine = subsFileReader.ReadLine();
                subTextParts = Strings.Split(currentLine, " --> ", Conversions.ToInteger("2"));
                setShowTime(currentIndex, subTextParts[0]);
                setHideTime(currentIndex, subTextParts[1]);

                subTextParts = new string[3];
                subTextParts[0] = "";
                subTextParts[1] = "";
                subTextParts[2] = "";

                subTextParts[0] = subsFileReader.ReadLine();
                subTextParts[1] = subsFileReader.ReadLine();
                if (!string.IsNullOrEmpty(subTextParts[1]))
                {
                    subTextParts[1] = " | " + subTextParts[1];
                    subTextParts[2] = subsFileReader.ReadLine();
                    if (!string.IsNullOrEmpty(subTextParts[2]))
                        subTextParts[2] = " | " + subTextParts[2];
                    else
                        Array.Resize(ref subTextParts, 2);
                }
                else
                {
                    Array.Resize(ref subTextParts, 1);
                }

                parseProperties(ref subTextParts);

                switch (subTextParts.Length)
                {
                    case 1:
                    {
                        setText(currentIndex, subTextParts[0]);
                        break;
                    }
                    case 2:
                    {
                        setText(currentIndex, subTextParts[0] + subTextParts[1]);
                        break;
                    }
                    case 3:
                    {
                        setText(currentIndex, subTextParts[0] + subTextParts[1] + subTextParts[2]);
                        break;
                    }
                }


                Generic.addToDebugList(Generic.loadStringFromLangFile("counterline") + " " +
                                       SubtitleArray[currentIndex].ID);
            }
        }
    }

    public SubtitleType miniLoadSRTSubRip()
    {
        var testSubtitle = new SubtitleType();

        try
        {
            subsFileReader =
                MyProject.Computer.FileSystem.OpenTextFileReader(MyProject.Forms.frmMain.dlgSubOpen.FileName,
                    subEncoding);

            currentLine = subsFileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine))
            {
                testSubtitle.ID = Conversions.ToInteger(currentLine);

                currentLine = subsFileReader.ReadLine();
                subTextParts = Strings.Split(currentLine, " --> ", Conversions.ToInteger("2"));
                testSubtitle.showTime = subTextParts[0];
                testSubtitle.hideTime = subTextParts[1];

                subTextParts = new string[3];
                subTextParts[0] = "";
                subTextParts[1] = "";
                subTextParts[2] = "";

                subTextParts[0] = subsFileReader.ReadLine();
                subTextParts[1] = subsFileReader.ReadLine();
                if (!string.IsNullOrEmpty(subTextParts[1]))
                {
                    subTextParts[2] = subsFileReader.ReadLine();
                    if (string.IsNullOrEmpty(subTextParts[2])) Array.Resize(ref subTextParts, 2);
                }
                else
                {
                    Array.Resize(ref subTextParts, 1);
                }

                switch (subTextParts.Length)
                {
                    case 1:
                    {
                        testSubtitle.text = subTextParts[0];
                        break;
                    }
                    case 2:
                    {
                        testSubtitle.text = subTextParts[0] + Generic.newLine + subTextParts[1];
                        break;
                    }
                    case 3:
                    {
                        testSubtitle.text = subTextParts[0] + Generic.newLine + subTextParts[1] + Generic.newLine +
                                            subTextParts[2];
                        break;
                    }
                }
            }

            return testSubtitle;
        }

        catch
        {
            testSubtitle.ID = -1;
            return testSubtitle;
        }
    }

    private void SaveSRTSubRip()
    {
        var subText = new string[3];

        for (int i = 0, loopTo = MyProject.Forms.frmMain.dgvSubtitles.Rows.Count - 1; i <= loopTo; i++)
        {
            Generic.fileWriter.WriteLine(SubtitleArray[i].ID);
            Generic.fileWriter.WriteLine(SubtitleArray[i].showTime + " --> " + SubtitleArray[i].hideTime);

            subText = Strings.Split(SubtitleArray[i].text, " | ", 3);

            if (subText.Count() == 1)
                Generic.fileWriter.WriteLine(subText[0]);
            else if (subText.Count() == 2)
                Generic.fileWriter.WriteLine(subText[0] + Generic.newLine + subText[1]);
            else if (subText.Count() == 3)
                Generic.fileWriter.WriteLine(subText[0] + Generic.newLine + subText[1] + Generic.newLine + subText[2]);

            Generic.fileWriter.WriteLine();
        }
    }

    public struct SubtitleType
    {
        public int ID;
        public string showTime;
        public int showTimeInMS;
        public string hideTime;
        public int hideTimeInMS;
        public string text;
        public string translationText;
        public string isBold;
        public string isItalic;
        public string propertiesString;
    }
}