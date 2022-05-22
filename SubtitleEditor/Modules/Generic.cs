using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenSubtitleEditor.My;

namespace OpenSubtitleEditor;
// Open Subtitle Editor
// Copyright (c) 2009-2010 Discovery OSS Team
// 
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

// Generic functions & variables of the program go here.

internal static class Generic
{
    public static StreamReader langFileReader;
    public static StreamWriter fileWriter;

    public static string AppRegKey =
        @"HKEY_CURRENT_USER\Software\" + Application.CompanyName + @"\" + Application.ProductName;

    public static string currentLanguageFile;
    public static string newLine = Conversions.ToString('\r') + '\n';
    public static string DecimalSeparator = Strings.Mid((1d / 2d).ToString(), 2, 1);
    public static bool movieLoaded;
    public static bool incompleteLanguageFile;

    // Add a line to the debug list
    public static void addToDebugList(string text)
    {
        MyProject.Forms.frmMain.tmrDebug.Enabled = false;
        MyProject.Forms.frmMain.tick = 0;
        MyProject.Forms.frmMain.lstDebug.Items.Insert(0, Conversions.ToString(DateAndTime.TimeOfDay) + " - " + text);
        // frmMain.tmrDebug.Enabled = True ' TODO: Remove comment here
        if (!ReferenceEquals(MyProject.Forms.frmMain.tabControl.SelectedTab, MyProject.Forms.frmMain.tabDebug))
            MyProject.Forms.frmMain.tabDebug.ImageKey = "information";
    }

    /// <summary>
    ///     Load a string from the translation file.
    /// </summary>
    /// <param name="text">
    ///     The string that is used to identify the translation string inside the SEL file
    ///     and around the program
    /// </param>
    /// <returns>Returns translated string only if found.</returns>
    /// <remarks>
    ///     Doesn't always return value, will call "loadTranslation" to reset to English if the wanted
    ///     string is not found.
    /// </remarks>
    public static string loadStringFromLangFile(string text, bool fallback = false)
    {
        string currentLine;
        var currentFields = new string[3];

        if (!fallback)
            langFileReader = MyProject.Computer.FileSystem.OpenTextFileReader(
                Conversions.ToString(MyProject.Computer.Registry.GetValue(AppRegKey, "LanguageFile", null)));
        else
            langFileReader =
                MyProject.Computer.FileSystem.OpenTextFileReader(Application.StartupPath + @"\Languages\English.sel");

        while (!langFileReader.EndOfStream)
        {
            currentLine = langFileReader.ReadLine();
            if (!string.IsNullOrEmpty(currentLine) & !(Strings.Left(currentLine, 1) == "!"))
            {
                currentFields = Strings.Split(currentLine, ",", Conversions.ToInteger("2"));
                if ((currentFields[0] ?? "") == (text ?? ""))
                {
                    langFileReader.Close();
                    return Strings.LTrim(currentFields[1]);
                }
            }
        }

        addToDebugList("Could not find translated line for entry " + "\"" + text + "\"" + ".");
        langFileReader.Close();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(
                MyProject.Computer.Registry.GetValue(AppRegKey, "LanguageFile", null),
                Application.StartupPath + @"\Languages\English.sel", false)))
        {
            pauseForCriticalError();
            return null;
        }

        return loadStringFromLangFile(text, true);
    }

    public static void pauseForCriticalError()
    {
        Interaction.MsgBox(
            Operators.ConcatenateObject(
                "A critical error has occured. Last debug message was:" + Conversions.ToString('\r') + '\n' +
                Conversions.ToString('\r') + '\n', MyProject.Forms.frmMain.lstDebug.Items[0]), MsgBoxStyle.Critical);
        try
        {
            fileWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(
                Application.LocalUserAppDataPath + @"\debug " + " " + DateAndTime.DateString + " " +
                Strings.Format(DateTime.Now, "hh.mm.ss") + ".txt", false);
            addToDebugList("Succesfully opened debug file.");
            for (int i = 0, loopTo = MyProject.Forms.frmMain.lstDebug.Items.Count - 1; i <= loopTo; i++)
                fileWriter.WriteLine(MyProject.Forms.frmMain.lstDebug.Items[i]);
            addToDebugList("Succesfully wrote all items to debug file.");
            fileWriter.Close();
            addToDebugList("Succesfully closed debug file.");
        }
        catch (Exception ex)
        {
            addToDebugList("WARNING: Could not create or write to debug file.");
        }
    }

    public static void loadTranslation(short loadType)
    {
        // loadtype:
        // 0 = Open Load Translation dialog
        // 1 = Load From Registry
        // 2 = Reset To English

        if (loadType == 0)
        {
            MyProject.Forms.frmMain.dlgOpen.Filter = loadStringFromLangFile("languagefile") + " (*.sel)|*.sel";
            MyProject.Forms.frmMain.dlgOpen.InitialDirectory = Application.StartupPath + @"\Languages";
            if (MyProject.Forms.frmMain.dlgOpen.ShowDialog() == DialogResult.OK)
            {
                langFileReader =
                    MyProject.Computer.FileSystem.OpenTextFileReader(MyProject.Forms.frmMain.dlgOpen.FileName);
                if (!(langFileReader.ReadLine() == "! Actual Open Subtitle Editor Language File"))
                {
                    addToDebugList("File selected was not a Subtitle Editor language file, resetting to English.");
                    loadTranslation(2);
                    return;
                }

                currentLanguageFile = MyProject.Forms.frmMain.dlgOpen.SafeFileName;
                MyProject.Computer.Registry.SetValue(AppRegKey, "LanguageFile",
                    MyProject.Forms.frmMain.dlgOpen.FileName);
            }
            else
            {
                return;
            }
        }

        else if (loadType == 1)
        {
            try
            {
                langFileReader = MyProject.Computer.FileSystem.OpenTextFileReader(
                    Conversions.ToString(MyProject.Computer.Registry.GetValue(AppRegKey, "LanguageFile", null)));
                var temp = Strings.Split(
                    Conversions.ToString(MyProject.Computer.Registry.GetValue(AppRegKey, "LanguageFile", null)), @"\");
                currentLanguageFile = temp[temp.Count() - 1];
            }
            catch (Exception langNotFound)
            {
                addToDebugList("Saved Language file could not be found. Resetting to English.");
                loadTranslation(2);
                return;
            }
        }

        else if (loadType == 2)
        {
            try
            {
                langFileReader =
                    MyProject.Computer.FileSystem.OpenTextFileReader(
                        Application.StartupPath + @"\Languages\English.sel");
                MyProject.Computer.Registry.SetValue(AppRegKey, "LanguageFile",
                    Application.StartupPath + @"\Languages\English.sel");
                incompleteLanguageFile = false;
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                addToDebugList(
                    "CRITICAL: Languages directory not found! Verify correct installation and contact the project administrator!");
                pauseForCriticalError();
            }
            catch (FileNotFoundException fileNotFound)
            {
                addToDebugList(
                    "CRITICAL: English language file not found! Verify correct installation and contact the project administrator!");
                pauseForCriticalError();
            }
        }

        MyProject.Forms.frmMain.LoadLangStrings();
        MyProject.Forms.frmPreviewSettings.LoadLangStrings();
        MyProject.Forms.frmAbout.LoadLangStrings();
        MyProject.Forms.frmLicense.LoadLangStrings();
        MyProject.Forms.frmUnknownFormat.LoadLangStrings();

        if (incompleteLanguageFile)
        {
            Interaction.MsgBox(
                "The translation file you've chosen (" + currentLanguageFile + ") is incomplete or corrupted." +
                newLine + newLine +
                "You can visit the program's website to see if a translation file compatible with the version you're using (" +
                VersionNumberInterpretation() + ") is available." + newLine + newLine +
                "The program will now reset to English.", MsgBoxStyle.Exclamation);
            loadTranslation(2);
        }

        if (!((MyProject.Forms.frmMain.getFirstDebugListItem() ?? "") ==
              (loadStringFromLangFile("succesfulload") ?? ""))) addToDebugList(loadStringFromLangFile("succesfulload"));
        incompleteLanguageFile = false;
    }

    public static void openMovie()
    {
        string fileWord, allFiles;
        fileWord = loadStringFromLangFile("fileWord");
        allFiles = loadStringFromLangFile("allFiles");
        MyProject.Forms.frmMain.dlgMovOpen.Filter = "AVI " + fileWord + " (*.avi)|*.avi|MPEG " + fileWord +
                                                    " (*.mpg;*.mpeg)|*.mpg;*.mpeg|" + allFiles + " (*.*)|*.*";
        if (MyProject.Forms.frmMain.dlgMovOpen.ShowDialog() == DialogResult.OK)
        {
            MyProject.Forms.frmMain.mPlayer.URL = MyProject.Forms.frmMain.dlgMovOpen.FileName;
            MyProject.Forms.frmMain.mPlayer.settings.volume = 100;
            addToDebugList(loadStringFromLangFile("loadedmovie"));
            MyProject.Forms.frmMain.mPlayer.Visible = true;
            movieLoaded = true;
            MyProject.Forms.frmMain.ViewTabsToolStripMenuItem.Checked = true;
            MyProject.Forms.frmMain.sldPosition.Value = 0;
            MyProject.Forms.frmMain.sldPosition.Maximum = 0;
            updateTitle();
        }
    }

    public static int convertShowHideCellToMiliseconds(string showHideValue)
    {
        int timeInMS;
        try
        {
            var hoursTemp = Conversions.ToShort(Strings.Mid(showHideValue, 1, 2));
            var minutesTemp = Conversions.ToShort(Strings.Mid(showHideValue, 4, 2));
            var secondsTemp = Conversions.ToShort(Strings.Mid(showHideValue, 7, 2));
            var milisecondsTemp = Conversions.ToShort(Strings.Mid(showHideValue, 10, 3));

            timeInMS = hoursTemp * 3600000 + minutesTemp * 60000 + secondsTemp * 1000 + milisecondsTemp;
        }
        catch
        {
            timeInMS = 0;
        }
        return timeInMS;
    }

    /// <summary>
    ///     Converts the value of a Show or Hide column's cell to miliseconds.
    /// </summary>
    /// <param name="row">Row index in the DataGridView</param>
    /// <param name="showColumnIsTrue">
    ///     'True' if we want to convert the value that's in the Show column, 'False' if we want to
    ///     conver the value that's in the Hide column
    /// </param>
    /// <returns>The cell's value (show or hide time) in miliseconds</returns>
    /// <remarks></remarks>
    public static int convertShowHideCellToMiliseconds(int row, bool showColumnIsTrue)
    {
        short column;
        if (showColumnIsTrue)
            column = 1;
        else
            column = 2;

        var hoursTemp =
            Conversions.ToShort(Strings.Mid(
                Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[column].Value), 1, 2));
        var minutesTemp =
            Conversions.ToShort(Strings.Mid(
                Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[column].Value), 4, 2));
        var secondsTemp =
            Conversions.ToShort(Strings.Mid(
                Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[column].Value), 7, 2));
        var milisecondsTemp =
            Conversions.ToShort(Strings.Mid(
                Conversions.ToString(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[column].Value), 10, 3));

        var timeInMS = hoursTemp * 3600000 + minutesTemp * 60000 + secondsTemp * 1000 + milisecondsTemp;

        return timeInMS;
    }

    public static string convertMilisecondsToShowHideCell(int timeInMS)
    {
        var hoursTemp = (short)(timeInMS / 3600000);
        var minutesTemp = (short)(timeInMS % 3600000 / 60000);
        var secondsTemp = (short)(timeInMS % 3600000 % 60000 / 1000);
        var milisecondsTemp = (short)(timeInMS % 3600000 % 60000 % 1000);

        var cellData = Strings.Format(hoursTemp, "00") + ":" + Strings.Format(minutesTemp, "00") + ":" +
                       Strings.Format(secondsTemp, "00") + "," + Strings.Format(milisecondsTemp, "000");
        return cellData;
    }

    /// <summary>
    ///     Converts a value in miliseconds to that of a Show or Hide column's cell.
    /// </summary>
    /// <param name="row">Row index in the DataGridView</param>
    /// <param name="showColumnIsTrue">
    ///     'True' if we want to pass the value to the cell that's in the Show column, 'False' if we want to
    ///     pass the value to the cell that's in the Hide column
    /// </param>
    /// <remarks></remarks>
    public static void convertMilisecondsToShowHideCell(int timeInMS, int row, bool showColumnIsTrue)
    {
        short column;
        if (showColumnIsTrue)
            column = 1;
        else
            column = 2;

        var hoursTemp = (short)(timeInMS / 3600000);
        var minutesTemp = (short)(timeInMS % 3600000 / 60000);
        var secondsTemp = (short)(timeInMS % 3600000 % 60000 / 1000);
        var milisecondsTemp = (short)(timeInMS % 3600000 % 60000 % 1000);

        var cellData = Strings.Format(hoursTemp, "00") + ":" + Strings.Format(minutesTemp, "00") + ":" +
                       Strings.Format(secondsTemp, "00") + "," + Strings.Format(milisecondsTemp, "000");

        MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[column].Value = cellData;
    }

    /// <summary>
    ///     Converts a string that is supposed to spread among multiple lines,
    ///     for example the Subtitle column of the DataGridView, using the default
    ///     separator, " | ".
    /// </summary>
    public static string[] convertMultiLineTextToArray(string text)
    {
        var returnArray = new string[4];
        returnArray = Strings.Split(text, " | ", 3);
        return returnArray;
    }

    /// <summary>
    ///     Converts a string that is supposed to spread among multiple lines,
    ///     for example the Subtitle column of the DataGridView, using a custom separator.
    /// </summary>
    /// <param name="text">The string that is to be splitted into an array.</param>
    /// <param name="splitAtChar">The separator char or string. Usually " | ".</param>
    public static string[] convertMultiLineTextToArray(string text, string splitAtChar)
    {
        var returnArray = new string[4];
        returnArray = Strings.Split(text, splitAtChar, 3);
        return returnArray;
    }

    public static void updateTitle()
    {
        string movieLoadedName;

        if (movieLoaded)
            movieLoadedName = " [" + MyProject.Forms.frmMain.dlgMovOpen.SafeFileName + "]";
        else
            movieLoadedName = "";

        MyProject.Forms.frmMain.Text = Application.ProductName + " - " +
                                       MyProject.Forms.frmMain.dlgSubOpen.SafeFileName + movieLoadedName;
    }

    public static long convertMilisecondsToFrames(int timeInMS, double FPS)
    {
        return (long)Math.Round(timeInMS / (FPS / 1000d));
    }

    public static int convertFramesToMiliseconds(long frames, double FPS)
    {
        return (int)Math.Round(frames * (FPS / 1000d));
    }

    public static void ConvertToFPS(double toFPS)
    {
        for (int i = 0, loopTo = MyProject.Forms.frmMain.dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            var startTime = convertShowHideCellToMiliseconds(i, true);
            var endTime = convertShowHideCellToMiliseconds(i, false);

            var startFrame = convertMilisecondsToFrames(startTime, MyProject.Forms.frmMain.currentFPS);
            var endFrame = convertMilisecondsToFrames(endTime, MyProject.Forms.frmMain.currentFPS);

            startTime = convertFramesToMiliseconds(startFrame, toFPS);
            endTime = convertFramesToMiliseconds(endFrame, toFPS);

            convertMilisecondsToShowHideCell(startTime, i, true);
            convertMilisecondsToShowHideCell(endTime, i, false);
        }
    }

    public static int getSubtitleID(int row)
    {
        return Conversions.ToInteger(MyProject.Forms.frmMain.dgvSubtitles.Rows[row].Cells[0].Value);
    }

    public static int checkIfNewSubtitleExistsOnGivenTime(int timeInMS)
    {
        for (int i = 0, loopTo = MyProject.Forms.frmMain.dgvSubtitles.RowCount - 1; i <= loopTo; i++)
        {
            var startTime = convertShowHideCellToMiliseconds(i, true);
            var endTime = convertShowHideCellToMiliseconds(i, false);
            if (i == 0)
            {
                if (timeInMS < startTime)
                    return 0;
            }
            else
            {
                var endTimePrev = convertShowHideCellToMiliseconds(i - 1, false);
                if ((timeInMS > endTimePrev) & (timeInMS < startTime))
                    return 0;
            }


            if ((timeInMS >= startTime) & (timeInMS <= endTime)) return getSubtitleID(i);
        }

        return 0;
    }

    public static void sortDGV()
    {
        for (int i = 0, loopTo = MyProject.Forms.frmMain.dgvSubtitles.RowCount - 1; i <= loopTo; i++)
            try
            {
                MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells["hiddenShow"].Value =
                    convertShowHideCellToMiliseconds(i, true);
            }
            catch
            {
                Interaction.MsgBox(i);
            }

        MyProject.Forms.frmMain.dgvSubtitles.Sort(MyProject.Forms.frmMain.dgvSubtitles.Columns["hiddenShow"],
            ListSortDirection.Ascending);
        for (int i = 0, loopTo1 = MyProject.Forms.frmMain.dgvSubtitles.RowCount - 1; i <= loopTo1; i++)
            MyProject.Forms.frmMain.dgvSubtitles.Rows[i].Cells[0].Value = i + 1;

        MyProject.Forms.frmMain.mySubtitles.passDataGridViewToArray();
    }

    // Return True if another instance
    // of this program is already running.
    public static bool AlreadyRunning()
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

    public static void parseKnownLanguageFiles()
    {
        // Greek
        if (File.Exists(Application.StartupPath + @"\Languages\Greek.sel"))
            MyProject.Forms.frmMain.GreekToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.GreekToolStripMenuItem.Visible = false;

        // Portuguese (Brazil)
        if (File.Exists(Application.StartupPath + @"\Languages\Brazilian Portuguese.sel"))
            MyProject.Forms.frmMain.BrazilianPortugueseToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.BrazilianPortugueseToolStripMenuItem.Visible = false;

        // French
        if (File.Exists(Application.StartupPath + @"\Languages\French.sel"))
            MyProject.Forms.frmMain.FrenchToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.FrenchToolStripMenuItem.Visible = false;

        // Italian
        if (File.Exists(Application.StartupPath + @"\Languages\Italian.sel"))
            MyProject.Forms.frmMain.ItalianoToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.ItalianoToolStripMenuItem.Visible = false;

        // Hebrew
        if (File.Exists(Application.StartupPath + @"\Languages\Hebrew.sel"))
            MyProject.Forms.frmMain.HebrewToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.HebrewToolStripMenuItem.Visible = false;

        // Polish
        if (File.Exists(Application.StartupPath + @"\Languages\Polish.sel"))
            MyProject.Forms.frmMain.PolishToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.PolishToolStripMenuItem.Visible = false;

        // Spanish
        if (File.Exists(Application.StartupPath + @"\Languages\Spanish.sel"))
            MyProject.Forms.frmMain.SpanishToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.SpanishToolStripMenuItem.Visible = false;

        // Spanish (Alternative)
        if (File.Exists(Application.StartupPath + @"\Languages\Spanish2.sel"))
            MyProject.Forms.frmMain.SpanishAlternativeToolStripMenuItem.Visible = true;
        else
            MyProject.Forms.frmMain.SpanishAlternativeToolStripMenuItem.Visible = false;
    }

    public static string VersionNumberInterpretation()
    {
        var major = (short)MyProject.Application.Info.Version.Major;
        var minor = (short)MyProject.Application.Info.Version.Minor;
        var build = (short)MyProject.Application.Info.Version.Build;
        var revision = MyProject.Application.Info.Version.Revision;

        if (build == 0)
        {
            if (minor == 0)
            {
                if (string.IsNullOrEmpty(MyProject.Forms.frmMain.VersionComment))
                    return major + " (Revision " + revision + ")";
                return major + " " + MyProject.Forms.frmMain.VersionComment + " (Revision " + revision + ")";
            }

            if (string.IsNullOrEmpty(MyProject.Forms.frmMain.VersionComment))
                return major + "." + minor + " (Revision " + revision + ")";
            return major + "." + minor + " " + MyProject.Forms.frmMain.VersionComment + " (Revision " + revision + ")";
        }

        if (string.IsNullOrEmpty(MyProject.Forms.frmMain.VersionComment))
            return major + "." + minor + "." + build + " (Revision " + revision + ")";
        return major + "." + minor + "." + build + " " + MyProject.Forms.frmMain.VersionComment + " (Revision " +
               revision + ")";
    }
}