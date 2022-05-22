using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Translator.My;

namespace Translator;
// This file is part of Open Subtitle Editor.
// 
// Open Subtitle Editor is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Open Subtitle Editor is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Open Subtitle Editor.  If not, see <http://www.gnu.org/licenses/>.

public partial class frmTranslator
{
    private string[] currentData;
    private string currentLine;
    private string currentName;

    private StreamReader fileReader;
    private StreamWriter fileWriter;
    private FolderBrowserDialog folderDialog = new();

    public frmTranslator()
    {
        InitializeComponent();
    }

    private void frmTranslator_Load(object sender, EventArgs e)
    {
        if (AlreadyRunning())
        {
            Interaction.MsgBox(
                "The Interface Translator for Open Subtitle Editor is already running. If the problem persists, try logging off your user account and logging back on.",
                MsgBoxStyle.Exclamation);
            Environment.Exit(0);
        }

        {
            ref var withBlock = ref folderDialog;
            // Desktop is the root folder in the dialog.
            withBlock.RootFolder = Environment.SpecialFolder.Desktop;
            // Select the C:\Windows directory on entry.
            if (Directory.Exists(Application.StartupPath + @"\source"))
                withBlock.SelectedPath = Application.StartupPath + @"\source";
            else
                withBlock.SelectedPath = Application.StartupPath;

            // Prompt the user with a custom message.
            withBlock.Description = "Select the \"source\" or \"Languages\" directory";

            if (withBlock.ShowDialog() == DialogResult.Cancel) Environment.Exit(0);
        }

        try
        {
            // IMPORTANT DEBUGGING INFORMATION: Check for source files suceeds only if the folder selected
            // is the one containing the whole solution.
            fileReader =
                MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                                 @"\SubtitleEditor\Dialogs\frmMain.vb");

            LoadFromSource();
        }
        catch (Exception ex)
        {
            TryLanguage();
        }
    }

    private void LoadFromSource()
    {
        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Dialogs\frmPreviewSettings.vb");

        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Modules\Generic.vb");

        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Modules\Subtitles.vb");

        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Dialogs\frmAbout.vb");

        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Dialogs\frmLicense.vb");

        ReadStrings();

        fileReader =
            MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath +
                                                             @"\SubtitleEditor\Dialogs\frmUnknownFormat.vb");

        ReadStrings();

        fileReader.Close();

        dgvLines.Sort(dgvLines.Columns[0], ListSortDirection.Ascending);

        bool Repeat;
        string first, second;
        here: ;

        for (int i = 0, loopTo = dgvLines.RowCount - 1; i <= loopTo; i++)
        {
            if (i >= dgvLines.RowCount - 1)
                break;
            first = Conversions.ToString(dgvLines.Rows[i].Cells[0].Value);
            second = Conversions.ToString(dgvLines.Rows[i + 1].Cells[0].Value);
            if ((first ?? "") == (second ?? "")) dgvLines.Rows.Remove(dgvLines.Rows[i + 1]);
        }

        Repeat = false;
        for (int i = 0, loopTo1 = dgvLines.RowCount - 1; i <= loopTo1; i++)
        {
            if (i >= dgvLines.RowCount - 1)
                break;
            first = Conversions.ToString(dgvLines.Rows[i].Cells[0].Value);
            second = Conversions.ToString(dgvLines.Rows[i + 1].Cells[0].Value);
            if ((first ?? "") == (second ?? ""))
            {
                Repeat = true;
                break;
            }
        }

        if (Repeat)
            goto here;

        for (var i = dgvLines.RowCount - 1; i >= 0; i -= 1)
        {
            first = Conversions.ToString(dgvLines.Rows[i].Cells[0].Value);
            if (first == "yVal text As Strin") dgvLines.Rows.RemoveAt(i);
        }
    }

    private void TryLanguage()
    {
        try
        {
            fileReader = MyProject.Computer.FileSystem.OpenTextFileReader(folderDialog.SelectedPath + @"\English.sel");
        }
        catch (Exception ex)
        {
            Environment.Exit(0);
        }

        if (!(fileReader.ReadLine() == "! Actual Open Subtitle Editor Language File"))
        {
            Interaction.MsgBox(
                "The English language file is corrupted. Please re-install the program, and if the problem persists contact the project administrator.");
            return;
        }

        string currentLine;
        var currentFields = new string[3];
        while (!fileReader.EndOfStream)
        {
            currentLine = fileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine) & !(Strings.Left(currentLine, 1) == "!"))
            {
                currentFields = Strings.Split(currentLine, ",", Conversions.ToInteger("2"));
                dgvLines.Rows.Add(currentFields[0], Strings.LTrim(currentFields[1]));
            }
        }

        fileReader.Close();
    }

    private void OpenOriginalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        dlgOpen.Filter = "Language File (*.sel)|*.sel";
        dlgOpen.InitialDirectory = Application.StartupPath + @"\Languages";
        dlgOpen.FileName = "";
        if (dlgOpen.ShowDialog() == DialogResult.OK)
        {
            fileReader = MyProject.Computer.FileSystem.OpenTextFileReader(dlgOpen.FileName);
            if (!(fileReader.ReadLine() == "! Actual Open Subtitle Editor Language File"))
            {
                Interaction.MsgBox("File selected was not a Subtitle Editor language file.");
                return;
            }
        }
        else
        {
            return;
        }

        foreach (DataGridViewRow row in dgvLines.Rows)
            row.Cells[1].Value = "";

        string currentLine;
        var currentFields = new string[3];
        while (!fileReader.EndOfStream)
        {
            currentLine = fileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine) & !(Strings.Left(currentLine, 1) == "!"))
            {
                currentFields = Strings.Split(currentLine, ",", Conversions.ToInteger("2"));
                for (int i = 0, loopTo = dgvLines.RowCount - 1; i <= loopTo; i++)
                    if ((currentFields[0] ?? "") == (Conversions.ToString(dgvLines.Rows[i].Cells[0].Value) ?? ""))
                    {
                        dgvLines.Rows[i].Cells[1].Value = Strings.LTrim(currentFields[1]);
                        break;
                    }
            }
        }

        fileReader.Close();
    }

    private void OpenTranslationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        dlgOpen.Filter = "Language File (*.sel)|*.sel";
        dlgOpen.InitialDirectory = Application.StartupPath + @"\Languages";
        dlgOpen.FileName = "";
        if (dlgOpen.ShowDialog() == DialogResult.OK)
        {
            fileReader = MyProject.Computer.FileSystem.OpenTextFileReader(dlgOpen.FileName);
            if (!(fileReader.ReadLine() == "! Actual Open Subtitle Editor Language File"))
            {
                Interaction.MsgBox("File selected was not a Subtitle Editor language file, resetting to English.");
                return;
            }
        }
        else
        {
            return;
        }

        foreach (DataGridViewRow row in dgvLines.Rows)
            row.Cells[2].Value = "";

        string currentLine;
        var currentFields = new string[3];
        while (!fileReader.EndOfStream)
        {
            currentLine = fileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine) & !(Strings.Left(currentLine, 1) == "!"))
            {
                currentFields = Strings.Split(currentLine, ",", Conversions.ToInteger("2"));
                for (int i = 0, loopTo = dgvLines.RowCount - 1; i <= loopTo; i++)
                    if ((currentFields[0] ?? "") == (Conversions.ToString(dgvLines.Rows[i].Cells[0].Value) ?? ""))
                    {
                        dgvLines.Rows[i].Cells[2].Value = Strings.LTrim(currentFields[1]);
                        break;
                    }
            }
        }

        fileReader.Close();

        checkIfComplete();
    }

    private void SaveTranslationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        dlgSave.Filter = dlgOpen.Filter;
        dlgSave.InitialDirectory = dlgOpen.InitialDirectory;
        if (dlgSave.ShowDialog() == DialogResult.OK)
        {
            fileWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(dlgSave.FileName, false);

            fileWriter.WriteLine("! Actual Open Subtitle Editor Language File");
            for (int i = 0, loopTo = dgvLines.RowCount - 1; i <= loopTo; i++)
                if (Conversions.ToBoolean(
                        !Operators.ConditionalCompareObjectEqual(dgvLines.Rows[i].Cells[2].Value, "", false)))
                    fileWriter.WriteLine(Operators.ConcatenateObject(
                        Operators.ConcatenateObject(dgvLines.Rows[i].Cells[0].Value, ", "),
                        dgvLines.Rows[i].Cells[2].Value));
            fileWriter.Close();
        }
    }

    // Return True if another instance
    // of this program is already running.
    public bool AlreadyRunning()
    {
        // Get our process name.
        var my_proc = Process.GetCurrentProcess();
        var my_name = my_proc.ProcessName;

        // Get information about processes with this name.
        var procs = Process.GetProcessesByName(my_name);

        // If there is only one, it's us.
        if (procs.Length == 1)
            return false;

        // If there is more than one process,
        // see if one has a StartTime before ours.
        int i;
        var loopTo = procs.Length - 1;
        for (i = 0; i <= loopTo; i++)
            if (procs[i].StartTime < my_proc.StartTime)
                return true;

        // If we get here, we were first.
        return false;
    }

    public void ReadStrings()
    {
        while (!fileReader.EndOfStream)
        {
            currentLine = fileReader.ReadLine();
            currentData = Strings.Split(currentLine, "loadStringFromLangFile(");
            if (currentData.Count() == 2)
            {
                currentData = Strings.Split(currentData[1], ")");
                currentName = Strings.Mid(currentData[0], 2, currentData[0].Length - 2);
                dgvLines.Rows.Add(currentName, "", "");
            }
        }
    }

    private void checkIfComplete()
    {
        var incomplete = false;
        foreach (DataGridViewRow row in dgvLines.Rows)
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row.Cells[2].Value, "", false)))
                incomplete = true;

        if (incomplete)
        {
            lblStatus.Text = "Current translation seems incomplete. (Double-click to go to first missing line.)";
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);
            lblStatus.ForeColor = Color.Red;
        }
        else
        {
            lblStatus.Text = "Current translation seems complete.";
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Regular);
            lblStatus.ForeColor = Color.Black;
        }
    }

    private void dgvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (ReferenceEquals(dgvLines.SelectedCells[0].OwningColumn, dgvLines.Columns[2])) checkIfComplete();
    }

    private void StatusStrip1_DoubleClick(object sender, EventArgs e)
    {
        if (lblStatus.ForeColor == Color.Red)
            foreach (DataGridViewRow row in dgvLines.Rows)
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row.Cells[2].Value, "", false)))
                {
                    for (int i = 0, loopTo = dgvLines.RowCount - 1; i <= loopTo; i++)
                        dgvLines.Rows[i].Selected = false;
                    row.Selected = true;
                    scrollToSelectedRow();
                    return;
                }
    }

    private void scrollToSelectedRow()
    {
        var halfWay = (int)Math.Round(dgvLines.DisplayedRowCount(false) / 2d);
        if ((dgvLines.FirstDisplayedScrollingRowIndex + halfWay > dgvLines.SelectedRows[0].Index) |
            (dgvLines.FirstDisplayedScrollingRowIndex + dgvLines.DisplayedRowCount(false) - halfWay <=
             dgvLines.SelectedRows[0].Index))
        {
            var targetRow = dgvLines.SelectedRows[0].Index;

            targetRow = Math.Max(targetRow - halfWay, 0);
            dgvLines.FirstDisplayedScrollingRowIndex = targetRow;
        }
    }
}