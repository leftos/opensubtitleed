using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace OpenSubtitleEditor
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmUnknownFormat : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnknownFormat));
            TableLayoutPanel1 = new TableLayoutPanel();
            btnOK = new Button();
            btnOK.Click += new EventHandler(OK_Button_Click);
            btnCancel = new Button();
            btnCancel.Click += new EventHandler(Cancel_Button_Click);
            lblExplanation = new Label();
            lblSubFormat = new Label();
            cmbSubFormat = new ComboBox();
            cmbSubFormat.SelectedIndexChanged += new EventHandler(cmbSubFormat_SelectedIndexChanged);
            cmbEncoding = new ComboBox();
            cmbEncoding.SelectedIndexChanged += new EventHandler(cmbEncoding_SelectedIndexChanged);
            lblEncoding = new Label();
            grpPreview = new GroupBox();
            lblIndexLabel = new Label();
            lblIndex = new Label();
            lblShow = new Label();
            lblShowLabel = new Label();
            lblHide = new Label();
            lblHideLabel = new Label();
            lblText = new Label();
            lblTextLabel = new Label();
            TableLayoutPanel1.SuspendLayout();
            grpPreview.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(btnOK, 0, 0);
            TableLayoutPanel1.Controls.Add(btnCancel, 1, 0);
            TableLayoutPanel1.Location = new Point(277, 289);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Size = new Size(146, 29);
            TableLayoutPanel1.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.None;
            btnOK.Location = new Point(3, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(67, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(76, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(67, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            // 
            // lblExplanation
            // 
            lblExplanation.Location = new Point(13, 13);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new Size(410, 56);
            lblExplanation.TabIndex = 1;
            lblExplanation.Text = resources.GetString("lblExplanation.Text");
            // 
            // lblSubFormat
            // 
            lblSubFormat.AutoSize = true;
            lblSubFormat.Location = new Point(12, 69);
            lblSubFormat.Name = "lblSubFormat";
            lblSubFormat.Size = new Size(77, 13);
            lblSubFormat.TabIndex = 2;
            lblSubFormat.Text = "Subtitle Format";
            // 
            // cmbSubFormat
            // 
            cmbSubFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubFormat.FormattingEnabled = true;
            cmbSubFormat.Items.AddRange(new object[] { "SubRip (SRT)" });
            cmbSubFormat.Location = new Point(299, 66);
            cmbSubFormat.Name = "cmbSubFormat";
            cmbSubFormat.Size = new Size(121, 21);
            cmbSubFormat.TabIndex = 3;
            // 
            // cmbEncoding
            // 
            cmbEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEncoding.FormattingEnabled = true;
            cmbEncoding.Items.AddRange(new object[] { "ANSI", "UTF-8", "Unicode", "Unicode Big Endian" });
            cmbEncoding.Location = new Point(299, 93);
            cmbEncoding.Name = "cmbEncoding";
            cmbEncoding.Size = new Size(121, 21);
            cmbEncoding.TabIndex = 5;
            // 
            // lblEncoding
            // 
            lblEncoding.AutoSize = true;
            lblEncoding.Location = new Point(12, 96);
            lblEncoding.Name = "lblEncoding";
            lblEncoding.Size = new Size(52, 13);
            lblEncoding.TabIndex = 4;
            lblEncoding.Text = "Encoding";
            // 
            // grpPreview
            // 
            grpPreview.Controls.Add(lblText);
            grpPreview.Controls.Add(lblTextLabel);
            grpPreview.Controls.Add(lblHide);
            grpPreview.Controls.Add(lblHideLabel);
            grpPreview.Controls.Add(lblShow);
            grpPreview.Controls.Add(lblShowLabel);
            grpPreview.Controls.Add(lblIndex);
            grpPreview.Controls.Add(lblIndexLabel);
            grpPreview.Location = new Point(15, 127);
            grpPreview.Name = "grpPreview";
            grpPreview.Size = new Size(408, 149);
            grpPreview.TabIndex = 6;
            grpPreview.TabStop = false;
            grpPreview.Text = "Preview";
            // 
            // lblIndexLabel
            // 
            lblIndexLabel.AutoSize = true;
            lblIndexLabel.Location = new Point(10, 29);
            lblIndexLabel.Name = "lblIndexLabel";
            lblIndexLabel.Size = new Size(33, 13);
            lblIndexLabel.TabIndex = 7;
            lblIndexLabel.Text = "Index";
            // 
            // lblIndex
            // 
            lblIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIndex.Location = new Point(381, 29);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(21, 13);
            lblIndex.TabIndex = 8;
            lblIndex.Text = "0";
            lblIndex.TextAlign = ContentAlignment.TopRight;
            // 
            // lblShow
            // 
            lblShow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblShow.Location = new Point(327, 51);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(75, 13);
            lblShow.TabIndex = 10;
            lblShow.Text = "00:00:00,000";
            lblShow.TextAlign = ContentAlignment.TopRight;
            // 
            // lblShowLabel
            // 
            lblShowLabel.AutoSize = true;
            lblShowLabel.Location = new Point(10, 51);
            lblShowLabel.Name = "lblShowLabel";
            lblShowLabel.Size = new Size(34, 13);
            lblShowLabel.TabIndex = 9;
            lblShowLabel.Text = "Show";
            // 
            // lblHide
            // 
            lblHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHide.Location = new Point(327, 74);
            lblHide.Name = "lblHide";
            lblHide.Size = new Size(75, 13);
            lblHide.TabIndex = 12;
            lblHide.Text = "00:00:00,000";
            lblHide.TextAlign = ContentAlignment.TopRight;
            // 
            // lblHideLabel
            // 
            lblHideLabel.AutoSize = true;
            lblHideLabel.Location = new Point(10, 74);
            lblHideLabel.Name = "lblHideLabel";
            lblHideLabel.Size = new Size(29, 13);
            lblHideLabel.TabIndex = 11;
            lblHideLabel.Text = "Hide";
            // 
            // lblText
            // 
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblText.Location = new Point(88, 97);
            lblText.Name = "lblText";
            lblText.Size = new Size(314, 46);
            lblText.TabIndex = 14;
            lblText.Text = "Text goes here" + '\r' + '\n' + "Line 2" + '\r' + '\n' + "Line 3";
            lblText.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTextLabel
            // 
            lblTextLabel.AutoSize = true;
            lblTextLabel.Location = new Point(10, 97);
            lblTextLabel.Name = "lblTextLabel";
            lblTextLabel.Size = new Size(28, 13);
            lblTextLabel.TabIndex = 13;
            lblTextLabel.Text = "Text";
            // 
            // frmUnknownFormat
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(435, 330);
            Controls.Add(grpPreview);
            Controls.Add(cmbEncoding);
            Controls.Add(lblEncoding);
            Controls.Add(cmbSubFormat);
            Controls.Add(lblSubFormat);
            Controls.Add(lblExplanation);
            Controls.Add(TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUnknownFormat";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Unknown Format";
            TableLayoutPanel1.ResumeLayout(false);
            grpPreview.ResumeLayout(false);
            grpPreview.PerformLayout();
            Load += new EventHandler(frmUnknownFormat_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal TableLayoutPanel TableLayoutPanel1;
        internal Button btnOK;
        internal Button btnCancel;
        internal Label lblExplanation;
        internal Label lblSubFormat;
        internal ComboBox cmbSubFormat;
        internal ComboBox cmbEncoding;
        internal Label lblEncoding;
        internal GroupBox grpPreview;
        internal Label lblHide;
        internal Label lblHideLabel;
        internal Label lblShow;
        internal Label lblShowLabel;
        internal Label lblIndex;
        internal Label lblIndexLabel;
        internal Label lblText;
        internal Label lblTextLabel;

    }
}