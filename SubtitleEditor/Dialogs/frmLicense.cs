using System;

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

public partial class frmLicense
{
    public frmLicense()
    {
        InitializeComponent();
    }

    private void frmLicense_Load(object sender, EventArgs e)
    {
        TextBox1.SelectionLength = 0;
    }

    public void LoadLangStrings()
    {
        Text = Generic.loadStringFromLangFile("licenseWord");
    }
}