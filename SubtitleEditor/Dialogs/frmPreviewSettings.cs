using System;
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

public partial class frmPreviewSettings
{
    public frmPreviewSettings()
    {
        InitializeComponent();
    }

    private void frmPreviewSettings_Load(object sender, EventArgs e)
    {
        nudStartDelay.Value =
            Conversions.ToDecimal(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "StartDelay", 0));
        nudEndDelay.Value =
            Conversions.ToDecimal(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "EndDelay", 0));
        nudAddDelay.Value =
            Conversions.ToDecimal(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "AddDelay", 0));
        chkStopOnEndOfSub.Checked =
            Conversions.ToBoolean(MyProject.Computer.Registry.GetValue(Generic.AppRegKey, "stopOnEndOfSub", true));
    }

    public void LoadLangStrings()
    {
        lblAddDelay.Text = Generic.loadStringFromLangFile("addDelay");
        lblEndDelay.Text = Generic.loadStringFromLangFile("endDelay");
        lblStartDelay.Text = Generic.loadStringFromLangFile("startDelay");
        chkStopOnEndOfSub.Text = Generic.loadStringFromLangFile("stopOnEndOfSub");
        btnCancel.Text = Generic.loadStringFromLangFile("cancelButton");
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "StartDelay", nudStartDelay.Value);
        MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "EndDelay", nudEndDelay.Value);
        MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "AddDelay", nudAddDelay.Value);
        MyProject.Computer.Registry.SetValue(Generic.AppRegKey, "stopOnEndOfSub", chkStopOnEndOfSub.Checked);

        MyProject.Forms.frmMain.LoadSettings();
    }

    private void chkStopOnEndOfSub_CheckedChanged(object sender, EventArgs e)
    {
        if (chkStopOnEndOfSub.Checked)
        {
            nudStartDelay.Enabled = true;
            nudEndDelay.Enabled = true;
        }
        else
        {
            nudStartDelay.Enabled = false;
            nudEndDelay.Enabled = false;
        }
    }
}