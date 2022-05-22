using System;
using System.IO;
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

public sealed partial class frmAbout
{
    private string ApplicationTitle;

    public frmAbout()
    {
        InitializeComponent();
    }

    private void AboutBox1_Load(object sender, EventArgs e)
    {
        // Set the title of the form.

        if (!string.IsNullOrEmpty(MyProject.Application.Info.Title))
            ApplicationTitle = MyProject.Application.Info.Title;
        else
            ApplicationTitle = Path.GetFileNameWithoutExtension(MyProject.Application.Info.AssemblyName);
    }

    /// <summary>
    ///     Tries and loads all translation strings from the current language file.
    /// </summary>
    /// <remarks>
    ///     If a certain line is missing, the program resets to English and prints the missing
    ///     line in the Debug window, as well as shows a message telling the user to look for an updated
    ///     version of the language file.
    /// </remarks>
    public void LoadLangStrings()
    {
        Text = string.Format(Generic.loadStringFromLangFile("aboutWord") + " {0}", ApplicationTitle);
        // Initialize all of the text displayed on the About Box.
        // TODO: Customize the application's assembly information in the "Application" pane of the project 
        // properties dialog (under the "Project" menu).
        LabelProductName.Text = MyProject.Application.Info.ProductName;
        LabelVersion.Text = Generic.loadStringFromLangFile("versionWord") + " " + Generic.VersionNumberInterpretation();
        LabelCopyright.Text = MyProject.Application.Info.Copyright;
        LabelCompanyName.Text = MyProject.Application.Info.CompanyName;
        TextBoxDescription.Text = MyProject.Application.Info.Description + Generic.newLine + Generic.newLine +
                                  Generic.loadStringFromLangFile("licensedString");
        btnLicense.Text = Generic.loadStringFromLangFile("licenseWord");
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnLicense_Click(object sender, EventArgs e)
    {
        MyProject.Forms.frmLicense.ShowDialog();
    }
}