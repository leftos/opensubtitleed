using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Translator
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmTranslator : Form
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
            components = new System.ComponentModel.Container();
            dgvLines = new DataGridView();
            dgvLines.CellEndEdit += new DataGridViewCellEventHandler(dgvLines_CellEndEdit);
            stringName = new DataGridViewTextBoxColumn();
            stringText = new DataGridViewTextBoxColumn();
            stringTranslation = new DataGridViewTextBoxColumn();
            ContextMenuStrip1 = new ContextMenuStrip(components);
            OpenOriginalToolStripMenuItem = new ToolStripMenuItem();
            OpenOriginalToolStripMenuItem.Click += new EventHandler(OpenOriginalToolStripMenuItem_Click);
            OpenTranslationToolStripMenuItem = new ToolStripMenuItem();
            OpenTranslationToolStripMenuItem.Click += new EventHandler(OpenTranslationToolStripMenuItem_Click);
            SaveTranslationToolStripMenuItem = new ToolStripMenuItem();
            SaveTranslationToolStripMenuItem.Click += new EventHandler(SaveTranslationToolStripMenuItem_Click);
            dlgOpen = new OpenFileDialog();
            dlgSave = new SaveFileDialog();
            StatusStrip1 = new StatusStrip();
            StatusStrip1.DoubleClick += new EventHandler(StatusStrip1_DoubleClick);
            lblStatus = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvLines).BeginInit();
            ContextMenuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLines
            // 
            dgvLines.AllowUserToAddRows = false;
            dgvLines.AllowUserToDeleteRows = false;
            dgvLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLines.Columns.AddRange(new DataGridViewColumn[] { stringName, stringText, stringTranslation });
            dgvLines.ContextMenuStrip = ContextMenuStrip1;
            dgvLines.Location = new Point(0, 0);
            dgvLines.Name = "dgvLines";
            dgvLines.Size = new Size(780, 576);
            dgvLines.TabIndex = 0;
            // 
            // stringName
            // 
            stringName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            stringName.FillWeight = 20.0f;
            stringName.HeaderText = "Name";
            stringName.Name = "stringName";
            stringName.ReadOnly = true;
            stringName.Width = 5;
            // 
            // stringText
            // 
            stringText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            stringText.FillWeight = 45.0f;
            stringText.HeaderText = "Original Text";
            stringText.Name = "stringText";
            stringText.ReadOnly = true;
            // 
            // stringTranslation
            // 
            stringTranslation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            stringTranslation.FillWeight = 45.0f;
            stringTranslation.HeaderText = "Translation";
            stringTranslation.Name = "stringTranslation";
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { OpenOriginalToolStripMenuItem, OpenTranslationToolStripMenuItem, SaveTranslationToolStripMenuItem });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(180, 70);
            // 
            // OpenOriginalToolStripMenuItem
            // 
            OpenOriginalToolStripMenuItem.Name = "OpenOriginalToolStripMenuItem";
            OpenOriginalToolStripMenuItem.Size = new Size(179, 22);
            OpenOriginalToolStripMenuItem.Text = "Open Original...";
            // 
            // OpenTranslationToolStripMenuItem
            // 
            OpenTranslationToolStripMenuItem.Name = "OpenTranslationToolStripMenuItem";
            OpenTranslationToolStripMenuItem.Size = new Size(179, 22);
            OpenTranslationToolStripMenuItem.Text = "Open Translation...";
            // 
            // SaveTranslationToolStripMenuItem
            // 
            SaveTranslationToolStripMenuItem.Name = "SaveTranslationToolStripMenuItem";
            SaveTranslationToolStripMenuItem.Size = new Size(179, 22);
            SaveTranslationToolStripMenuItem.Text = "Save Translation...";
            // 
            // dlgOpen
            // 
            dlgOpen.FileName = "OpenFileDialog1";
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            StatusStrip1.Location = new Point(0, 579);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(780, 22);
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(224, 17);
            lblStatus.Text = "Ready (Right-click to show Open/Save menu)";
            // 
            // frmTranslator
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 601);
            Controls.Add(StatusStrip1);
            Controls.Add(dgvLines);
            Name = "frmTranslator";
            Text = "Interface Translator for Open Subtitle Editor";
            ((System.ComponentModel.ISupportInitialize)dgvLines).EndInit();
            ContextMenuStrip1.ResumeLayout(false);
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(frmTranslator_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal DataGridView dgvLines;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem OpenOriginalToolStripMenuItem;
        internal ToolStripMenuItem OpenTranslationToolStripMenuItem;
        internal ToolStripMenuItem SaveTranslationToolStripMenuItem;
        internal OpenFileDialog dlgOpen;
        internal SaveFileDialog dlgSave;
        internal DataGridViewTextBoxColumn stringName;
        internal DataGridViewTextBoxColumn stringText;
        internal DataGridViewTextBoxColumn stringTranslation;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel lblStatus;

    }
}