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
    public partial class frmPreviewSettings : Form
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
            lblStartDelay = new Label();
            lblMs1 = new Label();
            nudStartDelay = new NumericUpDown();
            nudEndDelay = new NumericUpDown();
            lblMs2 = new Label();
            lblEndDelay = new Label();
            nudAddDelay = new NumericUpDown();
            lblMs3 = new Label();
            lblAddDelay = new Label();
            chkStopOnEndOfSub = new CheckBox();
            chkStopOnEndOfSub.CheckedChanged += new EventHandler(chkStopOnEndOfSub_CheckedChanged);
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudStartDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEndDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAddDelay).BeginInit();
            SuspendLayout();
            // 
            // lblStartDelay
            // 
            lblStartDelay.AutoSize = true;
            lblStartDelay.Location = new Point(12, 9);
            lblStartDelay.Name = "lblStartDelay";
            lblStartDelay.Size = new Size(114, 13);
            lblStartDelay.TabIndex = 1;
            lblStartDelay.Text = "Start preview earlier by";
            // 
            // lblMs1
            // 
            lblMs1.AutoSize = true;
            lblMs1.Location = new Point(326, 9);
            lblMs1.Name = "lblMs1";
            lblMs1.Size = new Size(20, 13);
            lblMs1.TabIndex = 2;
            lblMs1.Text = "ms";
            // 
            // nudStartDelay
            // 
            nudStartDelay.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudStartDelay.Location = new Point(228, 7);
            nudStartDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudStartDelay.Name = "nudStartDelay";
            nudStartDelay.Size = new Size(92, 20);
            nudStartDelay.TabIndex = 3;
            nudStartDelay.TextAlign = HorizontalAlignment.Right;
            // 
            // nudEndDelay
            // 
            nudEndDelay.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudEndDelay.Location = new Point(228, 35);
            nudEndDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudEndDelay.Name = "nudEndDelay";
            nudEndDelay.Size = new Size(92, 20);
            nudEndDelay.TabIndex = 6;
            nudEndDelay.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMs2
            // 
            lblMs2.AutoSize = true;
            lblMs2.Location = new Point(326, 37);
            lblMs2.Name = "lblMs2";
            lblMs2.Size = new Size(20, 13);
            lblMs2.TabIndex = 5;
            lblMs2.Text = "ms";
            // 
            // lblEndDelay
            // 
            lblEndDelay.AutoSize = true;
            lblEndDelay.Location = new Point(12, 37);
            lblEndDelay.Name = "lblEndDelay";
            lblEndDelay.Size = new Size(103, 13);
            lblEndDelay.TabIndex = 4;
            lblEndDelay.Text = "End preview later by";
            // 
            // nudAddDelay
            // 
            nudAddDelay.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudAddDelay.Location = new Point(228, 63);
            nudAddDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudAddDelay.Minimum = new decimal(new int[] { 10000, 0, 0, (int)-2147483648L });
            nudAddDelay.Name = "nudAddDelay";
            nudAddDelay.Size = new Size(92, 20);
            nudAddDelay.TabIndex = 9;
            nudAddDelay.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMs3
            // 
            lblMs3.AutoSize = true;
            lblMs3.Location = new Point(326, 65);
            lblMs3.Name = "lblMs3";
            lblMs3.Size = new Size(20, 13);
            lblMs3.TabIndex = 8;
            lblMs3.Text = "ms";
            // 
            // lblAddDelay
            // 
            lblAddDelay.AutoSize = true;
            lblAddDelay.Location = new Point(12, 65);
            lblAddDelay.Name = "lblAddDelay";
            lblAddDelay.Size = new Size(159, 13);
            lblAddDelay.TabIndex = 7;
            lblAddDelay.Text = "Add delay to preview start && end";
            // 
            // chkStopOnEndOfSub
            // 
            chkStopOnEndOfSub.AutoSize = true;
            chkStopOnEndOfSub.Location = new Point(12, 91);
            chkStopOnEndOfSub.Name = "chkStopOnEndOfSub";
            chkStopOnEndOfSub.Size = new Size(172, 17);
            chkStopOnEndOfSub.TabIndex = 10;
            chkStopOnEndOfSub.Text = "Stop preview on end of subtitle";
            chkStopOnEndOfSub.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(95, 130);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 11;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(176, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmPreviewSettings
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 165);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(chkStopOnEndOfSub);
            Controls.Add(nudAddDelay);
            Controls.Add(lblMs3);
            Controls.Add(lblAddDelay);
            Controls.Add(nudEndDelay);
            Controls.Add(lblMs2);
            Controls.Add(lblEndDelay);
            Controls.Add(nudStartDelay);
            Controls.Add(lblMs1);
            Controls.Add(lblStartDelay);
            MaximizeBox = false;
            Name = "frmPreviewSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Preview Settings";
            ((System.ComponentModel.ISupportInitialize)nudStartDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEndDelay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAddDelay).EndInit();
            Load += new EventHandler(frmPreviewSettings_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblStartDelay;
        internal Label lblMs1;
        internal NumericUpDown nudStartDelay;
        internal NumericUpDown nudEndDelay;
        internal Label lblMs2;
        internal Label lblEndDelay;
        internal NumericUpDown nudAddDelay;
        internal Label lblMs3;
        internal Label lblAddDelay;
        internal CheckBox chkStopOnEndOfSub;
        internal Button btnOK;
        internal Button btnCancel;
    }
}