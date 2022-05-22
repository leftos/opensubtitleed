using System;
using System.Text;
using System.Windows.Forms;
using OpenSubtitleEditor.My;

namespace OpenSubtitleEditor;

public partial class frmUnknownFormat
{
    public frmUnknownFormat()
    {
        InitializeComponent();
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void cmbSubFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (cmbSubFormat.Text ?? "")
        {
            case "SubRip (SRT)":
            {
                MyProject.Forms.frmMain.mySubtitles.setSubFormat("SubRip");
                break;
            }
        }

        ReloadSub();
    }

    private void cmbEncoding_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (cmbEncoding.Text ?? "")
        {
            case "ANSI":
            {
                MyProject.Forms.frmMain.mySubtitles.setSubEncoding(Encoding.Default);
                break;
            }
            case "UTF-8":
            {
                MyProject.Forms.frmMain.mySubtitles.setSubEncoding(Encoding.UTF8);
                break;
            }
            case "Unicode":
            {
                MyProject.Forms.frmMain.mySubtitles.setSubEncoding(Encoding.Unicode);
                break;
            }
            case "Unicode Big Endian":
            {
                MyProject.Forms.frmMain.mySubtitles.setSubEncoding(Encoding.BigEndianUnicode);
                break;
            }
        }

        ReloadSub();
    }

    private void ReloadSub()
    {
        var testSubtitle = new Subtitles.SubtitleType();
        var failed = false;

        switch (MyProject.Forms.frmMain.mySubtitles.getSubFormat() ?? "")
        {
            case "SubRip":
            {
                testSubtitle = MyProject.Forms.frmMain.mySubtitles.miniLoadSRTSubRip();
                if (!(testSubtitle.ID == -1))
                {
                    lblIndex.Text = testSubtitle.ID.ToString();
                    lblShow.Text = testSubtitle.showTime;
                    lblHide.Text = testSubtitle.hideTime;
                    lblText.Text = testSubtitle.text;
                    btnOK.Enabled = true;
                }
                else
                {
                    failed = true;
                }

                break;
            }
        }

        if (failed)
        {
            lblIndex.Text = "";
            lblShow.Text = "";
            lblHide.Text = "";
            lblText.Text = Generic.loadStringFromLangFile("noSubtitlesWithCurrentSettings");
            btnOK.Enabled = false;
        }
    }

    private void frmUnknownFormat_Load(object sender, EventArgs e)
    {
        switch (MyProject.Forms.frmMain.mySubtitles.getSubFormat() ?? "")
        {
            case "SubRip":
            {
                cmbSubFormat.SelectedIndex = 0;
                break;
            }

            default:
            {
                cmbSubFormat.SelectedIndex = 0;
                break;
            }
        }

        cmbEncoding.SelectedIndex = 0;
    }

    public void LoadLangStrings()
    {
        lblExplanation.Text = Generic.loadStringFromLangFile("unknownFormatExplanation");
        lblEncoding.Text = Generic.loadStringFromLangFile("encoding");
        lblHideLabel.Text = Generic.loadStringFromLangFile("hideTableHeader");
        lblIndexLabel.Text = Generic.loadStringFromLangFile("subtitleEntryWord");
        lblShowLabel.Text = Generic.loadStringFromLangFile("showTableHeader");
        lblSubFormat.Text = Generic.loadStringFromLangFile("subtitleFormat");
        lblTextLabel.Text = Generic.loadStringFromLangFile("subtitleTableHeader");
        grpPreview.Text = Generic.loadStringFromLangFile("previewWord");
    }
}