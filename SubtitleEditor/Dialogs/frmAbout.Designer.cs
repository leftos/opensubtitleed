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
    public partial class frmAbout : Form
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

        internal TableLayoutPanel TableLayoutPanel;
        internal PictureBox LogoPictureBox;
        internal Label LabelProductName;
        internal Label LabelVersion;
        internal Label LabelCompanyName;
        internal TextBox TextBoxDescription;
        internal Button OKButton;
        internal Label LabelCopyright;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            TableLayoutPanel = new TableLayoutPanel();
            LogoPictureBox = new PictureBox();
            LabelProductName = new Label();
            LabelVersion = new Label();
            LabelCopyright = new Label();
            LabelCompanyName = new Label();
            TextBoxDescription = new TextBox();
            OKButton = new Button();
            OKButton.Click += new EventHandler(OKButton_Click);
            btnLicense = new Button();
            btnLicense.Click += new EventHandler(btnLicense_Click);
            TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.ColumnCount = 2;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.0f));
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.0f));
            TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0);
            TableLayoutPanel.Controls.Add(LabelProductName, 1, 0);
            TableLayoutPanel.Controls.Add(LabelVersion, 1, 1);
            TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2);
            TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3);
            TableLayoutPanel.Controls.Add(TextBoxDescription, 1, 4);
            TableLayoutPanel.Controls.Add(OKButton, 1, 6);
            TableLayoutPanel.Controls.Add(btnLicense, 1, 5);
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Location = new Point(9, 9);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 7;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.1845f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.963099f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25.0f));
            TableLayoutPanel.Size = new Size(396, 300);
            TableLayoutPanel.TabIndex = 0;
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Dock = DockStyle.Fill;
            LogoPictureBox.Image = (Image)resources.GetObject("LogoPictureBox.Image");
            LogoPictureBox.Location = new Point(3, 3);
            LogoPictureBox.Name = "LogoPictureBox";
            TableLayoutPanel.SetRowSpan(LogoPictureBox, 6);
            LogoPictureBox.Size = new Size(124, 266);
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // LabelProductName
            // 
            LabelProductName.Dock = DockStyle.Fill;
            LabelProductName.Location = new Point(136, 0);
            LabelProductName.Margin = new Padding(6, 0, 3, 0);
            LabelProductName.MaximumSize = new Size(0, 17);
            LabelProductName.Name = "LabelProductName";
            LabelProductName.Size = new Size(257, 17);
            LabelProductName.TabIndex = 0;
            LabelProductName.Text = "Product Name";
            LabelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelVersion
            // 
            LabelVersion.Dock = DockStyle.Fill;
            LabelVersion.Location = new Point(136, 27);
            LabelVersion.Margin = new Padding(6, 0, 3, 0);
            LabelVersion.MaximumSize = new Size(0, 17);
            LabelVersion.Name = "LabelVersion";
            LabelVersion.Size = new Size(257, 17);
            LabelVersion.TabIndex = 0;
            LabelVersion.Text = "Version";
            LabelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelCopyright
            // 
            LabelCopyright.Dock = DockStyle.Fill;
            LabelCopyright.Location = new Point(136, 54);
            LabelCopyright.Margin = new Padding(6, 0, 3, 0);
            LabelCopyright.MaximumSize = new Size(0, 17);
            LabelCopyright.Name = "LabelCopyright";
            LabelCopyright.Size = new Size(257, 17);
            LabelCopyright.TabIndex = 0;
            LabelCopyright.Text = "Copyright";
            LabelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelCompanyName
            // 
            LabelCompanyName.Dock = DockStyle.Fill;
            LabelCompanyName.Location = new Point(136, 81);
            LabelCompanyName.Margin = new Padding(6, 0, 3, 0);
            LabelCompanyName.MaximumSize = new Size(0, 17);
            LabelCompanyName.Name = "LabelCompanyName";
            LabelCompanyName.Size = new Size(257, 17);
            LabelCompanyName.TabIndex = 0;
            LabelCompanyName.Text = "Company Name";
            LabelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBoxDescription
            // 
            TextBoxDescription.Dock = DockStyle.Fill;
            TextBoxDescription.Location = new Point(136, 111);
            TextBoxDescription.Margin = new Padding(6, 3, 3, 3);
            TextBoxDescription.Multiline = true;
            TextBoxDescription.Name = "TextBoxDescription";
            TextBoxDescription.ReadOnly = true;
            TextBoxDescription.ScrollBars = ScrollBars.Both;
            TextBoxDescription.Size = new Size(257, 131);
            TextBoxDescription.TabIndex = 0;
            TextBoxDescription.TabStop = false;
            TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text");
            // 
            // OKButton
            // 
            OKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OKButton.DialogResult = DialogResult.Cancel;
            OKButton.Location = new Point(318, 275);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 22);
            OKButton.TabIndex = 0;
            OKButton.Text = "&OK";
            // 
            // btnLicense
            // 
            btnLicense.Anchor = AnchorStyles.Right;
            btnLicense.Location = new Point(318, 248);
            btnLicense.Name = "btnLicense";
            btnLicense.Size = new Size(75, 21);
            btnLicense.TabIndex = 3;
            btnLicense.Text = "License";
            btnLicense.UseVisualStyleBackColor = true;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = OKButton;
            ClientSize = new Size(414, 318);
            Controls.Add(TableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            Padding = new Padding(9);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutBox1";
            TableLayoutPanel.ResumeLayout(false);
            TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            Load += new EventHandler(AboutBox1_Load);
            ResumeLayout(false);

        }
        internal Button btnLicense;

    }
}