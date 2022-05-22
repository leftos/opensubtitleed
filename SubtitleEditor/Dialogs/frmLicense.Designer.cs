using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace OpenSubtitleEditor
{
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

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmLicense : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicense));
            TextBox1 = new TextBox();
            btnOK = new Button();
            SuspendLayout();
            // 
            // TextBox1
            // 
            TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            TextBox1.Location = new Point(12, 12);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.ReadOnly = true;
            TextBox1.ScrollBars = ScrollBars.Vertical;
            TextBox1.Size = new Size(381, 477);
            TextBox1.TabIndex = 1;
            TextBox1.TabStop = false;
            TextBox1.Text = resources.GetString("TextBox1.Text");
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(318, 498);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // frmLicense
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 533);
            ControlBox = false;
            Controls.Add(btnOK);
            Controls.Add(TextBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLicense";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmLicense";
            Load += new EventHandler(frmLicense_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal TextBox TextBox1;
        internal Button btnOK;
    }
}