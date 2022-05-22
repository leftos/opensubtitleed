using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
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

using Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn;

namespace OpenSubtitleEditor
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMain : Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.SubtitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnCurrentMoviePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnNextLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.StartSelectedOnCurrentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndSelectedOnCurrentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.DelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyCurrentConstantDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyCustomDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.FPSConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetCurrentFPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PALNTSCFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.CurFPS23976ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurFPS25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem21 = new System.Windows.Forms.ToolStripSeparator();
            this.ComputerUsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem22 = new System.Windows.Forms.ToolStripSeparator();
            this.CurFPS15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurFPS20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurFPS24ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurFPS2997ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurFPS30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.ConvertToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PALNTSCFormatsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.ToFPS23976ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToFPS25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.ComputerUsedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.ToFPS15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToFPS20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToFPS24ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toFPS2997ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToFPS30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckForOverlappingSubtitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MovieOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RewindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.VolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.MuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playRateUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playRateDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviewSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BrazilianPortugueseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GreekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HebrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItalianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpanishAlternativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSubSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgSubOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgMovOpen = new System.Windows.Forms.OpenFileDialog();
            this.TimerSub = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSubPrev = new System.Windows.Forms.TabPage();
            this.pnlVideoPlayer = new System.Windows.Forms.Panel();
            this.lblShowSub = new System.Windows.Forms.Label();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.chkPauseAfterQuick = new System.Windows.Forms.CheckBox();
            this.btnQuickAdd = new System.Windows.Forms.Button();
            this.btnQuickEdit = new System.Windows.Forms.Button();
            this.lblVolume = new System.Windows.Forms.Label();
            this.sldPosition = new System.Windows.Forms.TrackBar();
            this.lblCurPos = new System.Windows.Forms.Label();
            this.sldVolume = new System.Windows.Forms.TrackBar();
            this.cmbFRorFFby = new System.Windows.Forms.ComboBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblPlayRate = new System.Windows.Forms.Label();
            this.lblPlayRateLabel = new System.Windows.Forms.Label();
            this.lblConstantDelay = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblConstantDelayLabel = new System.Windows.Forms.Label();
            this.pnlTimerOnly = new System.Windows.Forms.Panel();
            this.lblEndAfter = new System.Windows.Forms.Label();
            this.lblEndAfterLabel = new System.Windows.Forms.Label();
            this.lblStartBefore = new System.Windows.Forms.Label();
            this.lblStartBeforeLabel = new System.Windows.Forms.Label();
            this.btnFF = new System.Windows.Forms.Button();
            this.btnFR = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.lstDebug = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrDebug = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cxmDebug = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlLocks = new System.Windows.Forms.Panel();
            this.rbtLockHide = new System.Windows.Forms.RadioButton();
            this.rbtLockDuration = new System.Windows.Forms.RadioButton();
            this.rbtLockShow = new System.Windows.Forms.RadioButton();
            this.mtbDuration = new System.Windows.Forms.MaskedTextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.mtbHide = new System.Windows.Forms.MaskedTextBox();
            this.mtbShow = new System.Windows.Forms.MaskedTextBox();
            this.lblHide = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.Label();
            this.nudDuration = new CoolSoft.UI.NumericUpDownEx();
            this.nudHide = new CoolSoft.UI.NumericUpDownEx();
            this.nudShow = new CoolSoft.UI.NumericUpDownEx();
            this.rtbSubtitle = new System.Windows.Forms.RichTextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnShowHidePanel = new System.Windows.Forms.Button();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.dgvSubtitles = new System.Windows.Forms.DataGridView();
            this.subIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subShow = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.subHide = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.subText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subProperties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnsMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSubPrev.SuspendLayout();
            this.pnlVideoPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldVolume)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.pnlTimerOnly.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cxmDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.pnlLocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShow)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubtitles)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 20;
            this.Timer.Tick += new System.EventHandler(this.CheckIfMovieShouldStop);
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubtitleToolStripMenuItem,
            this.EditToolStripMenuItem1,
            this.MovieToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.HelpToolStripMenuItem,
            this.LanguageToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(924, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "MenuStrip1";
            // 
            // SubtitleToolStripMenuItem
            // 
            this.SubtitleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.SubtitleToolStripMenuItem.Name = "SubtitleToolStripMenuItem";
            this.SubtitleToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.SubtitleToolStripMenuItem.Text = "&Subtitle";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.OpenToolStripMenuItem.Text = "&Open...";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.SaveToolStripMenuItem.Text = "&Save...";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ExitToolStripMenuItem.Text = "&Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem1
            // 
            this.EditToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.ToolStripMenuItem8,
            this.StartSelectedOnCurrentPositionToolStripMenuItem,
            this.EndSelectedOnCurrentPositionToolStripMenuItem,
            this.ToolStripMenuItem9,
            this.DelayToolStripMenuItem,
            this.ToolStripMenuItem10,
            this.FPSConversionToolStripMenuItem,
            this.ToolStripMenuItem16,
            this.CheckForOverlappingSubtitlesToolStripMenuItem,
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem});
            this.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1";
            this.EditToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem1.Text = "Edit";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnCurrentMoviePositionToolStripMenuItem,
            this.OnNextLineToolStripMenuItem});
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.AddToolStripMenuItem.Text = "Add";
            // 
            // OnCurrentMoviePositionToolStripMenuItem
            // 
            this.OnCurrentMoviePositionToolStripMenuItem.Name = "OnCurrentMoviePositionToolStripMenuItem";
            this.OnCurrentMoviePositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.OnCurrentMoviePositionToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.OnCurrentMoviePositionToolStripMenuItem.Text = "On current video position";
            this.OnCurrentMoviePositionToolStripMenuItem.Click += new System.EventHandler(this.OnCurrentMoviePositionToolStripMenuItem_Click);
            // 
            // OnNextLineToolStripMenuItem
            // 
            this.OnNextLineToolStripMenuItem.Name = "OnNextLineToolStripMenuItem";
            this.OnNextLineToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.OnNextLineToolStripMenuItem.Text = "Blank line";
            this.OnNextLineToolStripMenuItem.Click += new System.EventHandler(this.OnNextLineToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem8
            // 
            this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            this.ToolStripMenuItem8.Size = new System.Drawing.Size(291, 6);
            // 
            // StartSelectedOnCurrentPositionToolStripMenuItem
            // 
            this.StartSelectedOnCurrentPositionToolStripMenuItem.Name = "StartSelectedOnCurrentPositionToolStripMenuItem";
            this.StartSelectedOnCurrentPositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.StartSelectedOnCurrentPositionToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.StartSelectedOnCurrentPositionToolStripMenuItem.Text = "Show Selected On Current Position";
            this.StartSelectedOnCurrentPositionToolStripMenuItem.Click += new System.EventHandler(this.StartSelectedOnCurrentPositionToolStripMenuItem_Click);
            // 
            // EndSelectedOnCurrentPositionToolStripMenuItem
            // 
            this.EndSelectedOnCurrentPositionToolStripMenuItem.Name = "EndSelectedOnCurrentPositionToolStripMenuItem";
            this.EndSelectedOnCurrentPositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.EndSelectedOnCurrentPositionToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.EndSelectedOnCurrentPositionToolStripMenuItem.Text = "End Selected On Current Position";
            this.EndSelectedOnCurrentPositionToolStripMenuItem.Click += new System.EventHandler(this.EndSelectedOnCurrentPositionToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem9
            // 
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            this.ToolStripMenuItem9.Size = new System.Drawing.Size(291, 6);
            // 
            // DelayToolStripMenuItem
            // 
            this.DelayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplyCurrentConstantDelayToolStripMenuItem,
            this.ApplyCustomDelayToolStripMenuItem});
            this.DelayToolStripMenuItem.Name = "DelayToolStripMenuItem";
            this.DelayToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.DelayToolStripMenuItem.Text = "Delay";
            // 
            // ApplyCurrentConstantDelayToolStripMenuItem
            // 
            this.ApplyCurrentConstantDelayToolStripMenuItem.Name = "ApplyCurrentConstantDelayToolStripMenuItem";
            this.ApplyCurrentConstantDelayToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ApplyCurrentConstantDelayToolStripMenuItem.Text = "Apply current constant delay";
            this.ApplyCurrentConstantDelayToolStripMenuItem.Click += new System.EventHandler(this.ApplyCurrentConstantDelayToolStripMenuItem_Click);
            // 
            // ApplyCustomDelayToolStripMenuItem
            // 
            this.ApplyCustomDelayToolStripMenuItem.Name = "ApplyCustomDelayToolStripMenuItem";
            this.ApplyCustomDelayToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ApplyCustomDelayToolStripMenuItem.Text = "Apply custom delay...";
            this.ApplyCustomDelayToolStripMenuItem.Click += new System.EventHandler(this.ApplyCustomDelayToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem10
            // 
            this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            this.ToolStripMenuItem10.Size = new System.Drawing.Size(291, 6);
            // 
            // FPSConversionToolStripMenuItem
            // 
            this.FPSConversionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetCurrentFPSToolStripMenuItem,
            this.ToolStripMenuItem11,
            this.ConvertToToolStripMenuItem});
            this.FPSConversionToolStripMenuItem.Name = "FPSConversionToolStripMenuItem";
            this.FPSConversionToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.FPSConversionToolStripMenuItem.Text = "FPS Conversion";
            // 
            // SetCurrentFPSToolStripMenuItem
            // 
            this.SetCurrentFPSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PALNTSCFormatsToolStripMenuItem,
            this.ToolStripMenuItem12,
            this.CurFPS23976ToolStripMenuItem,
            this.CurFPS25ToolStripMenuItem,
            this.ToolStripMenuItem21,
            this.ComputerUsedToolStripMenuItem,
            this.ToolStripMenuItem22,
            this.CurFPS15ToolStripMenuItem,
            this.CurFPS20ToolStripMenuItem,
            this.CurFPS24ToolStripMenuItem,
            this.CurFPS2997ToolStripMenuItem,
            this.CurFPS30ToolStripMenuItem});
            this.SetCurrentFPSToolStripMenuItem.Name = "SetCurrentFPSToolStripMenuItem";
            this.SetCurrentFPSToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.SetCurrentFPSToolStripMenuItem.Text = "Set Current FPS";
            // 
            // PALNTSCFormatsToolStripMenuItem
            // 
            this.PALNTSCFormatsToolStripMenuItem.Enabled = false;
            this.PALNTSCFormatsToolStripMenuItem.Name = "PALNTSCFormatsToolStripMenuItem";
            this.PALNTSCFormatsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.PALNTSCFormatsToolStripMenuItem.Text = "PAL/NTSC Formats";
            // 
            // ToolStripMenuItem12
            // 
            this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
            this.ToolStripMenuItem12.Size = new System.Drawing.Size(171, 6);
            // 
            // CurFPS23976ToolStripMenuItem
            // 
            this.CurFPS23976ToolStripMenuItem.CheckOnClick = true;
            this.CurFPS23976ToolStripMenuItem.Name = "CurFPS23976ToolStripMenuItem";
            this.CurFPS23976ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS23976ToolStripMenuItem.Text = "23,976";
            this.CurFPS23976ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS23976ToolStripMenuItem_Click);
            // 
            // CurFPS25ToolStripMenuItem
            // 
            this.CurFPS25ToolStripMenuItem.CheckOnClick = true;
            this.CurFPS25ToolStripMenuItem.Name = "CurFPS25ToolStripMenuItem";
            this.CurFPS25ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS25ToolStripMenuItem.Text = "25";
            this.CurFPS25ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS25ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem21
            // 
            this.ToolStripMenuItem21.Name = "ToolStripMenuItem21";
            this.ToolStripMenuItem21.Size = new System.Drawing.Size(171, 6);
            // 
            // ComputerUsedToolStripMenuItem
            // 
            this.ComputerUsedToolStripMenuItem.Enabled = false;
            this.ComputerUsedToolStripMenuItem.Name = "ComputerUsedToolStripMenuItem";
            this.ComputerUsedToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ComputerUsedToolStripMenuItem.Text = "Other";
            // 
            // ToolStripMenuItem22
            // 
            this.ToolStripMenuItem22.Name = "ToolStripMenuItem22";
            this.ToolStripMenuItem22.Size = new System.Drawing.Size(171, 6);
            // 
            // CurFPS15ToolStripMenuItem
            // 
            this.CurFPS15ToolStripMenuItem.Name = "CurFPS15ToolStripMenuItem";
            this.CurFPS15ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS15ToolStripMenuItem.Text = "15";
            this.CurFPS15ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS15ToolStripMenuItem_Click);
            // 
            // CurFPS20ToolStripMenuItem
            // 
            this.CurFPS20ToolStripMenuItem.Name = "CurFPS20ToolStripMenuItem";
            this.CurFPS20ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS20ToolStripMenuItem.Text = "20";
            this.CurFPS20ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS20ToolStripMenuItem_Click);
            // 
            // CurFPS24ToolStripMenuItem
            // 
            this.CurFPS24ToolStripMenuItem.Name = "CurFPS24ToolStripMenuItem";
            this.CurFPS24ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS24ToolStripMenuItem.Text = "24";
            this.CurFPS24ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS24ToolStripMenuItem_Click);
            // 
            // CurFPS2997ToolStripMenuItem
            // 
            this.CurFPS2997ToolStripMenuItem.Name = "CurFPS2997ToolStripMenuItem";
            this.CurFPS2997ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS2997ToolStripMenuItem.Text = "29,97";
            this.CurFPS2997ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS2997ToolStripMenuItem_Click);
            // 
            // CurFPS30ToolStripMenuItem
            // 
            this.CurFPS30ToolStripMenuItem.Name = "CurFPS30ToolStripMenuItem";
            this.CurFPS30ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CurFPS30ToolStripMenuItem.Text = "30";
            this.CurFPS30ToolStripMenuItem.Click += new System.EventHandler(this.CurFPS30ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem11
            // 
            this.ToolStripMenuItem11.Name = "ToolStripMenuItem11";
            this.ToolStripMenuItem11.Size = new System.Drawing.Size(152, 6);
            // 
            // ConvertToToolStripMenuItem
            // 
            this.ConvertToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PALNTSCFormatsToolStripMenuItem1,
            this.ToolStripMenuItem13,
            this.ToFPS23976ToolStripMenuItem,
            this.ToFPS25ToolStripMenuItem,
            this.ToolStripMenuItem14,
            this.ComputerUsedToolStripMenuItem1,
            this.ToolStripMenuItem15,
            this.ToFPS15ToolStripMenuItem,
            this.ToFPS20ToolStripMenuItem,
            this.ToFPS24ToolStripMenuItem,
            this.toFPS2997ToolStripMenuItem,
            this.ToFPS30ToolStripMenuItem});
            this.ConvertToToolStripMenuItem.Name = "ConvertToToolStripMenuItem";
            this.ConvertToToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ConvertToToolStripMenuItem.Text = "Convert To";
            // 
            // PALNTSCFormatsToolStripMenuItem1
            // 
            this.PALNTSCFormatsToolStripMenuItem1.Enabled = false;
            this.PALNTSCFormatsToolStripMenuItem1.Name = "PALNTSCFormatsToolStripMenuItem1";
            this.PALNTSCFormatsToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.PALNTSCFormatsToolStripMenuItem1.Text = "PAL/NTSC Formats";
            // 
            // ToolStripMenuItem13
            // 
            this.ToolStripMenuItem13.Name = "ToolStripMenuItem13";
            this.ToolStripMenuItem13.Size = new System.Drawing.Size(171, 6);
            // 
            // ToFPS23976ToolStripMenuItem
            // 
            this.ToFPS23976ToolStripMenuItem.Name = "ToFPS23976ToolStripMenuItem";
            this.ToFPS23976ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS23976ToolStripMenuItem.Text = "23,976";
            this.ToFPS23976ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS23976ToolStripMenuItem_Click);
            // 
            // ToFPS25ToolStripMenuItem
            // 
            this.ToFPS25ToolStripMenuItem.Name = "ToFPS25ToolStripMenuItem";
            this.ToFPS25ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS25ToolStripMenuItem.Text = "25";
            this.ToFPS25ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS25ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem14
            // 
            this.ToolStripMenuItem14.Name = "ToolStripMenuItem14";
            this.ToolStripMenuItem14.Size = new System.Drawing.Size(171, 6);
            // 
            // ComputerUsedToolStripMenuItem1
            // 
            this.ComputerUsedToolStripMenuItem1.Enabled = false;
            this.ComputerUsedToolStripMenuItem1.Name = "ComputerUsedToolStripMenuItem1";
            this.ComputerUsedToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.ComputerUsedToolStripMenuItem1.Text = "Other";
            // 
            // ToolStripMenuItem15
            // 
            this.ToolStripMenuItem15.Name = "ToolStripMenuItem15";
            this.ToolStripMenuItem15.Size = new System.Drawing.Size(171, 6);
            // 
            // ToFPS15ToolStripMenuItem
            // 
            this.ToFPS15ToolStripMenuItem.Name = "ToFPS15ToolStripMenuItem";
            this.ToFPS15ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS15ToolStripMenuItem.Text = "15";
            this.ToFPS15ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS15ToolStripMenuItem_Click);
            // 
            // ToFPS20ToolStripMenuItem
            // 
            this.ToFPS20ToolStripMenuItem.Name = "ToFPS20ToolStripMenuItem";
            this.ToFPS20ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS20ToolStripMenuItem.Text = "20";
            this.ToFPS20ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS20ToolStripMenuItem_Click);
            // 
            // ToFPS24ToolStripMenuItem
            // 
            this.ToFPS24ToolStripMenuItem.Name = "ToFPS24ToolStripMenuItem";
            this.ToFPS24ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS24ToolStripMenuItem.Text = "24";
            this.ToFPS24ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS24ToolStripMenuItem_Click);
            // 
            // toFPS2997ToolStripMenuItem
            // 
            this.toFPS2997ToolStripMenuItem.Name = "toFPS2997ToolStripMenuItem";
            this.toFPS2997ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.toFPS2997ToolStripMenuItem.Text = "29,97";
            this.toFPS2997ToolStripMenuItem.Click += new System.EventHandler(this.toFPS2997ToolStripMenuItem_Click);
            // 
            // ToFPS30ToolStripMenuItem
            // 
            this.ToFPS30ToolStripMenuItem.Name = "ToFPS30ToolStripMenuItem";
            this.ToFPS30ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ToFPS30ToolStripMenuItem.Text = "30";
            this.ToFPS30ToolStripMenuItem.Click += new System.EventHandler(this.ToFPS30ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem16
            // 
            this.ToolStripMenuItem16.Name = "ToolStripMenuItem16";
            this.ToolStripMenuItem16.Size = new System.Drawing.Size(291, 6);
            // 
            // CheckForOverlappingSubtitlesToolStripMenuItem
            // 
            this.CheckForOverlappingSubtitlesToolStripMenuItem.Name = "CheckForOverlappingSubtitlesToolStripMenuItem";
            this.CheckForOverlappingSubtitlesToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.CheckForOverlappingSubtitlesToolStripMenuItem.Text = "Check For Overlapping Subtitles";
            this.CheckForOverlappingSubtitlesToolStripMenuItem.Click += new System.EventHandler(this.CheckForOverlappingSubtitles);
            // 
            // SortSubtitlesBasedOnShowTimingToolStripMenuItem
            // 
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem.Name = "SortSubtitlesBasedOnShowTimingToolStripMenuItem";
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem.Text = "Sort Subtitles Based On Show Timing";
            this.SortSubtitlesBasedOnShowTimingToolStripMenuItem.Click += new System.EventHandler(this.SortSubtitlesBasedOnShowTimingToolStripMenuItem_Click);
            // 
            // MovieToolStripMenuItem
            // 
            this.MovieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MovieOpenToolStripMenuItem,
            this.ToolStripMenuItem3,
            this.PlayToolStripMenuItem,
            this.ForwardToolStripMenuItem,
            this.RewindToolStripMenuItem,
            this.ToolStripMenuItem4,
            this.VolumeToolStripMenuItem,
            this.ToolStripMenuItem6,
            this.PlayRateToolStripMenuItem});
            this.MovieToolStripMenuItem.Name = "MovieToolStripMenuItem";
            this.MovieToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.MovieToolStripMenuItem.Text = "&Movie";
            // 
            // MovieOpenToolStripMenuItem
            // 
            this.MovieOpenToolStripMenuItem.Name = "MovieOpenToolStripMenuItem";
            this.MovieOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.MovieOpenToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.MovieOpenToolStripMenuItem.Text = "Open...";
            this.MovieOpenToolStripMenuItem.Click += new System.EventHandler(this.MovieOpenToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(175, 6);
            // 
            // PlayToolStripMenuItem
            // 
            this.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem";
            this.PlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PlayToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.PlayToolStripMenuItem.Text = "Play/Pause";
            this.PlayToolStripMenuItem.Click += new System.EventHandler(this.PlayToolStripMenuItem_Click);
            // 
            // ForwardToolStripMenuItem
            // 
            this.ForwardToolStripMenuItem.Name = "ForwardToolStripMenuItem";
            this.ForwardToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+.";
            this.ForwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.ForwardToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ForwardToolStripMenuItem.Text = "Forward";
            this.ForwardToolStripMenuItem.Click += new System.EventHandler(this.ForwardToolStripMenuItem_Click);
            // 
            // RewindToolStripMenuItem
            // 
            this.RewindToolStripMenuItem.Name = "RewindToolStripMenuItem";
            this.RewindToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+,";
            this.RewindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemcomma)));
            this.RewindToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.RewindToolStripMenuItem.Text = "Rewind";
            this.RewindToolStripMenuItem.Click += new System.EventHandler(this.RewindToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(175, 6);
            // 
            // VolumeToolStripMenuItem
            // 
            this.VolumeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volumeUpToolStripMenuItem,
            this.volumeDownToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.MuteToolStripMenuItem,
            this.MaxToolStripMenuItem});
            this.VolumeToolStripMenuItem.Name = "VolumeToolStripMenuItem";
            this.VolumeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.VolumeToolStripMenuItem.Text = "Volume";
            // 
            // volumeUpToolStripMenuItem
            // 
            this.volumeUpToolStripMenuItem.Name = "volumeUpToolStripMenuItem";
            this.volumeUpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl++";
            this.volumeUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.volumeUpToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.volumeUpToolStripMenuItem.Text = "Up";
            this.volumeUpToolStripMenuItem.Click += new System.EventHandler(this.volumeUpToolStripMenuItem_Click);
            // 
            // volumeDownToolStripMenuItem
            // 
            this.volumeDownToolStripMenuItem.Name = "volumeDownToolStripMenuItem";
            this.volumeDownToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            this.volumeDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.volumeDownToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.volumeDownToolStripMenuItem.Text = "Down";
            this.volumeDownToolStripMenuItem.Click += new System.EventHandler(this.volumeDownToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(141, 6);
            // 
            // MuteToolStripMenuItem
            // 
            this.MuteToolStripMenuItem.Name = "MuteToolStripMenuItem";
            this.MuteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.MuteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.MuteToolStripMenuItem.Text = "Mute";
            this.MuteToolStripMenuItem.Click += new System.EventHandler(this.MuteToolStripMenuItem_Click);
            // 
            // MaxToolStripMenuItem
            // 
            this.MaxToolStripMenuItem.Name = "MaxToolStripMenuItem";
            this.MaxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.MaxToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.MaxToolStripMenuItem.Text = "Max";
            this.MaxToolStripMenuItem.Click += new System.EventHandler(this.MaxToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(175, 6);
            // 
            // PlayRateToolStripMenuItem
            // 
            this.PlayRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playRateUpToolStripMenuItem,
            this.playRateDownToolStripMenuItem,
            this.ToolStripMenuItem7,
            this.ResetToolStripMenuItem});
            this.PlayRateToolStripMenuItem.Name = "PlayRateToolStripMenuItem";
            this.PlayRateToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.PlayRateToolStripMenuItem.Text = "Play Rate";
            // 
            // playRateUpToolStripMenuItem
            // 
            this.playRateUpToolStripMenuItem.Name = "playRateUpToolStripMenuItem";
            this.playRateUpToolStripMenuItem.ShortcutKeyDisplayString = "Alt++";
            this.playRateUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Oemplus)));
            this.playRateUpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.playRateUpToolStripMenuItem.Text = "Up";
            this.playRateUpToolStripMenuItem.Click += new System.EventHandler(this.playRateUpToolStripMenuItem_Click);
            // 
            // playRateDownToolStripMenuItem
            // 
            this.playRateDownToolStripMenuItem.Name = "playRateDownToolStripMenuItem";
            this.playRateDownToolStripMenuItem.ShortcutKeyDisplayString = "Alt+-";
            this.playRateDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.OemMinus)));
            this.playRateDownToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.playRateDownToolStripMenuItem.Text = "Down";
            this.playRateDownToolStripMenuItem.Click += new System.EventHandler(this.playRateDownToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem7
            // 
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            this.ToolStripMenuItem7.Size = new System.Drawing.Size(137, 6);
            // 
            // ResetToolStripMenuItem
            // 
            this.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem";
            this.ResetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.ResetToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ResetToolStripMenuItem.Text = "Reset";
            this.ResetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreviewSettingsToolStripMenuItem,
            this.ToolStripMenuItem17,
            this.ViewTabsToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.EditToolStripMenuItem.Text = "Preferences";
            // 
            // PreviewSettingsToolStripMenuItem
            // 
            this.PreviewSettingsToolStripMenuItem.Name = "PreviewSettingsToolStripMenuItem";
            this.PreviewSettingsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.PreviewSettingsToolStripMenuItem.Text = "Preview Settings...";
            this.PreviewSettingsToolStripMenuItem.Click += new System.EventHandler(this.PreviewSettingsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem17
            // 
            this.ToolStripMenuItem17.Name = "ToolStripMenuItem17";
            this.ToolStripMenuItem17.Size = new System.Drawing.Size(166, 6);
            // 
            // ViewTabsToolStripMenuItem
            // 
            this.ViewTabsToolStripMenuItem.Checked = true;
            this.ViewTabsToolStripMenuItem.CheckOnClick = true;
            this.ViewTabsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewTabsToolStripMenuItem.Name = "ViewTabsToolStripMenuItem";
            this.ViewTabsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ViewTabsToolStripMenuItem.Text = "Show Video";
            this.ViewTabsToolStripMenuItem.Click += new System.EventHandler(this.ViewTabsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.AboutToolStripMenuItem.Text = "About...";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadTranslationToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.EnglishToolStripMenuItem,
            this.ToolStripSeparator1,
            this.BrazilianPortugueseToolStripMenuItem,
            this.FrenchToolStripMenuItem,
            this.GreekToolStripMenuItem,
            this.HebrewToolStripMenuItem,
            this.ItalianoToolStripMenuItem,
            this.PolishToolStripMenuItem,
            this.SpanishToolStripMenuItem,
            this.SpanishAlternativeToolStripMenuItem});
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.LanguageToolStripMenuItem.Text = "Language";
            // 
            // LoadTranslationToolStripMenuItem
            // 
            this.LoadTranslationToolStripMenuItem.Name = "LoadTranslationToolStripMenuItem";
            this.LoadTranslationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.LoadTranslationToolStripMenuItem.Text = "Load Translation...";
            this.LoadTranslationToolStripMenuItem.Click += new System.EventHandler(this.LoadTranslationToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(180, 6);
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.EnglishToolStripMenuItem.Text = "English";
            this.EnglishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // BrazilianPortugueseToolStripMenuItem
            // 
            this.BrazilianPortugueseToolStripMenuItem.Name = "BrazilianPortugueseToolStripMenuItem";
            this.BrazilianPortugueseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.BrazilianPortugueseToolStripMenuItem.Text = "Brazilian Portuguese";
            // 
            // FrenchToolStripMenuItem
            // 
            this.FrenchToolStripMenuItem.Name = "FrenchToolStripMenuItem";
            this.FrenchToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.FrenchToolStripMenuItem.Text = "French";
            // 
            // GreekToolStripMenuItem
            // 
            this.GreekToolStripMenuItem.Name = "GreekToolStripMenuItem";
            this.GreekToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.GreekToolStripMenuItem.Text = "Greek";
            this.GreekToolStripMenuItem.Visible = false;
            this.GreekToolStripMenuItem.Click += new System.EventHandler(this.GreekToolStripMenuItem_Click);
            // 
            // HebrewToolStripMenuItem
            // 
            this.HebrewToolStripMenuItem.Name = "HebrewToolStripMenuItem";
            this.HebrewToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.HebrewToolStripMenuItem.Text = "Hebrew";
            // 
            // ItalianoToolStripMenuItem
            // 
            this.ItalianoToolStripMenuItem.Name = "ItalianoToolStripMenuItem";
            this.ItalianoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ItalianoToolStripMenuItem.Text = "Italiano";
            // 
            // PolishToolStripMenuItem
            // 
            this.PolishToolStripMenuItem.Name = "PolishToolStripMenuItem";
            this.PolishToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.PolishToolStripMenuItem.Text = "Polish";
            // 
            // SpanishToolStripMenuItem
            // 
            this.SpanishToolStripMenuItem.Name = "SpanishToolStripMenuItem";
            this.SpanishToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SpanishToolStripMenuItem.Text = "Spanish";
            // 
            // SpanishAlternativeToolStripMenuItem
            // 
            this.SpanishAlternativeToolStripMenuItem.Name = "SpanishAlternativeToolStripMenuItem";
            this.SpanishAlternativeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.SpanishAlternativeToolStripMenuItem.Text = "Spanish (Alternative)";
            // 
            // TimerSub
            // 
            this.TimerSub.Interval = 20;
            this.TimerSub.Tick += new System.EventHandler(this.TimerSub_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSubPrev);
            this.tabControl.Controls.Add(this.tabDebug);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(924, 299);
            this.tabControl.TabIndex = 1;
            // 
            // tabSubPrev
            // 
            this.tabSubPrev.Controls.Add(this.pnlVideoPlayer);
            this.tabSubPrev.Location = new System.Drawing.Point(4, 22);
            this.tabSubPrev.Name = "tabSubPrev";
            this.tabSubPrev.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubPrev.Size = new System.Drawing.Size(916, 273);
            this.tabSubPrev.TabIndex = 0;
            this.tabSubPrev.Text = "Subtitle & Preview";
            this.tabSubPrev.UseVisualStyleBackColor = true;
            // 
            // pnlVideoPlayer
            // 
            this.pnlVideoPlayer.Controls.Add(this.lblShowSub);
            this.pnlVideoPlayer.Controls.Add(this.mPlayer);
            this.pnlVideoPlayer.Controls.Add(this.chkPauseAfterQuick);
            this.pnlVideoPlayer.Controls.Add(this.btnQuickAdd);
            this.pnlVideoPlayer.Controls.Add(this.btnQuickEdit);
            this.pnlVideoPlayer.Controls.Add(this.lblVolume);
            this.pnlVideoPlayer.Controls.Add(this.sldPosition);
            this.pnlVideoPlayer.Controls.Add(this.lblCurPos);
            this.pnlVideoPlayer.Controls.Add(this.sldVolume);
            this.pnlVideoPlayer.Controls.Add(this.cmbFRorFFby);
            this.pnlVideoPlayer.Controls.Add(this.grpStatus);
            this.pnlVideoPlayer.Controls.Add(this.btnFF);
            this.pnlVideoPlayer.Controls.Add(this.btnFR);
            this.pnlVideoPlayer.Controls.Add(this.btnPlay);
            this.pnlVideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideoPlayer.Location = new System.Drawing.Point(3, 3);
            this.pnlVideoPlayer.Name = "pnlVideoPlayer";
            this.pnlVideoPlayer.Size = new System.Drawing.Size(910, 267);
            this.pnlVideoPlayer.TabIndex = 32;
            // 
            // lblShowSub
            // 
            this.lblShowSub.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblShowSub.Font = new System.Drawing.Font("Tahoma", 10.01739F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblShowSub.Location = new System.Drawing.Point(278, 153);
            this.lblShowSub.Name = "lblShowSub";
            this.lblShowSub.Size = new System.Drawing.Size(349, 40);
            this.lblShowSub.TabIndex = 38;
            this.lblShowSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShowSub.Visible = false;
            // 
            // mPlayer
            // 
            this.mPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(278, 9);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(349, 196);
            this.mPlayer.TabIndex = 62;
            this.mPlayer.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.mPlayer_OpenStateChange);
            this.mPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.mPlayer_PlayStateChange);
            // 
            // chkPauseAfterQuick
            // 
            this.chkPauseAfterQuick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPauseAfterQuick.AutoSize = true;
            this.chkPauseAfterQuick.Location = new System.Drawing.Point(833, 247);
            this.chkPauseAfterQuick.Name = "chkPauseAfterQuick";
            this.chkPauseAfterQuick.Size = new System.Drawing.Size(77, 17);
            this.chkPauseAfterQuick.TabIndex = 61;
            this.chkPauseAfterQuick.Text = "and Pause";
            this.chkPauseAfterQuick.UseVisualStyleBackColor = true;
            // 
            // btnQuickAdd
            // 
            this.btnQuickAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickAdd.Location = new System.Drawing.Point(820, 175);
            this.btnQuickAdd.Name = "btnQuickAdd";
            this.btnQuickAdd.Size = new System.Drawing.Size(90, 30);
            this.btnQuickAdd.TabIndex = 60;
            this.btnQuickAdd.Text = "Quick Add";
            this.btnQuickAdd.UseVisualStyleBackColor = true;
            this.btnQuickAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnQuickAdd_MouseDown);
            this.btnQuickAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQuickAdd_MouseUp);
            // 
            // btnQuickEdit
            // 
            this.btnQuickEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickEdit.Enabled = false;
            this.btnQuickEdit.Location = new System.Drawing.Point(820, 211);
            this.btnQuickEdit.Name = "btnQuickEdit";
            this.btnQuickEdit.Size = new System.Drawing.Size(90, 30);
            this.btnQuickEdit.TabIndex = 59;
            this.btnQuickEdit.Text = "Quick Edit";
            this.btnQuickEdit.UseVisualStyleBackColor = true;
            this.btnQuickEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnQuickEdit_MouseDown);
            this.btnQuickEdit.MouseHover += new System.EventHandler(this.btnQuickEdit_MouseHover);
            this.btnQuickEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQuickEdit_MouseUp);
            // 
            // lblVolume
            // 
            this.lblVolume.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(513, 234);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 39;
            this.lblVolume.Text = "Volume";
            // 
            // sldPosition
            // 
            this.sldPosition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sldPosition.AutoSize = false;
            this.sldPosition.BackColor = System.Drawing.SystemColors.Window;
            this.sldPosition.LargeChange = 100;
            this.sldPosition.Location = new System.Drawing.Point(277, 211);
            this.sldPosition.Maximum = 100;
            this.sldPosition.Name = "sldPosition";
            this.sldPosition.Size = new System.Drawing.Size(350, 15);
            this.sldPosition.SmallChange = 5;
            this.sldPosition.TabIndex = 41;
            this.sldPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sldPosition.Scroll += new System.EventHandler(this.sldPosition_Scroll);
            this.sldPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sldPosition_MouseDown);
            this.sldPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sldPosition_MouseUp);
            // 
            // lblCurPos
            // 
            this.lblCurPos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCurPos.Location = new System.Drawing.Point(633, 211);
            this.lblCurPos.Name = "lblCurPos";
            this.lblCurPos.Size = new System.Drawing.Size(72, 13);
            this.lblCurPos.TabIndex = 43;
            this.lblCurPos.Text = "00:00:00.000";
            this.lblCurPos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sldVolume
            // 
            this.sldVolume.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sldVolume.AutoSize = false;
            this.sldVolume.BackColor = System.Drawing.SystemColors.Window;
            this.sldVolume.LargeChange = 10;
            this.sldVolume.Location = new System.Drawing.Point(560, 232);
            this.sldVolume.Maximum = 100;
            this.sldVolume.Name = "sldVolume";
            this.sldVolume.Size = new System.Drawing.Size(67, 24);
            this.sldVolume.SmallChange = 5;
            this.sldVolume.TabIndex = 40;
            this.sldVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sldVolume.Value = 80;
            this.sldVolume.Scroll += new System.EventHandler(this.sldVolume_Scroll);
            // 
            // cmbFRorFFby
            // 
            this.cmbFRorFFby.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbFRorFFby.FormattingEnabled = true;
            this.cmbFRorFFby.Items.AddRange(new object[] {
            "1 ms",
            "5 ms",
            "10 ms",
            "20 ms",
            "50 ms",
            "100 ms",
            "200 ms",
            "500 ms",
            "1000 ms (0:01)",
            "2000 ms",
            "5000 ms (0:05)",
            "10000 ms (0:10)",
            "20000 ms",
            "30000 ms (0:30)",
            "60000 ms (1:00)",
            "120000 ms (2:00)",
            "300000 ms (5:00)",
            "600000 ms (10:00)"});
            this.cmbFRorFFby.Location = new System.Drawing.Point(354, 231);
            this.cmbFRorFFby.Name = "cmbFRorFFby";
            this.cmbFRorFFby.Size = new System.Drawing.Size(114, 21);
            this.cmbFRorFFby.TabIndex = 35;
            this.cmbFRorFFby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFRorFFby_KeyPress);
            // 
            // grpStatus
            // 
            this.grpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatus.Controls.Add(this.lblPlayRate);
            this.grpStatus.Controls.Add(this.lblPlayRateLabel);
            this.grpStatus.Controls.Add(this.lblConstantDelay);
            this.grpStatus.Controls.Add(this.Label2);
            this.grpStatus.Controls.Add(this.lblConstantDelayLabel);
            this.grpStatus.Controls.Add(this.pnlTimerOnly);
            this.grpStatus.Location = new System.Drawing.Point(687, 9);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(218, 163);
            this.grpStatus.TabIndex = 42;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Current Options";
            // 
            // lblPlayRate
            // 
            this.lblPlayRate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPlayRate.Location = new System.Drawing.Point(111, 144);
            this.lblPlayRate.Name = "lblPlayRate";
            this.lblPlayRate.Size = new System.Drawing.Size(101, 13);
            this.lblPlayRate.TabIndex = 13;
            this.lblPlayRate.Text = "1x";
            this.lblPlayRate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPlayRateLabel
            // 
            this.lblPlayRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPlayRateLabel.AutoSize = true;
            this.lblPlayRateLabel.Location = new System.Drawing.Point(6, 130);
            this.lblPlayRateLabel.Name = "lblPlayRateLabel";
            this.lblPlayRateLabel.Size = new System.Drawing.Size(53, 13);
            this.lblPlayRateLabel.TabIndex = 12;
            this.lblPlayRateLabel.Text = "Play Rate";
            // 
            // lblConstantDelay
            // 
            this.lblConstantDelay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblConstantDelay.Location = new System.Drawing.Point(113, 111);
            this.lblConstantDelay.Name = "lblConstantDelay";
            this.lblConstantDelay.Size = new System.Drawing.Size(101, 13);
            this.lblConstantDelay.TabIndex = 2;
            this.lblConstantDelay.Text = "0 ms";
            this.lblConstantDelay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 13);
            this.Label2.TabIndex = 1;
            // 
            // lblConstantDelayLabel
            // 
            this.lblConstantDelayLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblConstantDelayLabel.AutoSize = true;
            this.lblConstantDelayLabel.Location = new System.Drawing.Point(6, 92);
            this.lblConstantDelayLabel.Name = "lblConstantDelayLabel";
            this.lblConstantDelayLabel.Size = new System.Drawing.Size(79, 13);
            this.lblConstantDelayLabel.TabIndex = 0;
            this.lblConstantDelayLabel.Text = "Constant Delay";
            // 
            // pnlTimerOnly
            // 
            this.pnlTimerOnly.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlTimerOnly.Controls.Add(this.lblEndAfter);
            this.pnlTimerOnly.Controls.Add(this.lblEndAfterLabel);
            this.pnlTimerOnly.Controls.Add(this.lblStartBefore);
            this.pnlTimerOnly.Controls.Add(this.lblStartBeforeLabel);
            this.pnlTimerOnly.Location = new System.Drawing.Point(6, 21);
            this.pnlTimerOnly.Name = "pnlTimerOnly";
            this.pnlTimerOnly.Size = new System.Drawing.Size(206, 61);
            this.pnlTimerOnly.TabIndex = 9;
            // 
            // lblEndAfter
            // 
            this.lblEndAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndAfter.Location = new System.Drawing.Point(107, 48);
            this.lblEndAfter.Name = "lblEndAfter";
            this.lblEndAfter.Size = new System.Drawing.Size(101, 13);
            this.lblEndAfter.TabIndex = 12;
            this.lblEndAfter.Text = "0 ms";
            this.lblEndAfter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEndAfterLabel
            // 
            this.lblEndAfterLabel.AutoSize = true;
            this.lblEndAfterLabel.Location = new System.Drawing.Point(-1, 35);
            this.lblEndAfterLabel.Name = "lblEndAfterLabel";
            this.lblEndAfterLabel.Size = new System.Drawing.Size(92, 13);
            this.lblEndAfterLabel.TabIndex = 11;
            this.lblEndAfterLabel.Text = "End Preview After";
            // 
            // lblStartBefore
            // 
            this.lblStartBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartBefore.Location = new System.Drawing.Point(107, 13);
            this.lblStartBefore.Name = "lblStartBefore";
            this.lblStartBefore.Size = new System.Drawing.Size(101, 13);
            this.lblStartBefore.TabIndex = 10;
            this.lblStartBefore.Text = "0 ms";
            this.lblStartBefore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStartBeforeLabel
            // 
            this.lblStartBeforeLabel.AutoSize = true;
            this.lblStartBeforeLabel.Location = new System.Drawing.Point(-1, 0);
            this.lblStartBeforeLabel.Name = "lblStartBeforeLabel";
            this.lblStartBeforeLabel.Size = new System.Drawing.Size(104, 13);
            this.lblStartBeforeLabel.TabIndex = 9;
            this.lblStartBeforeLabel.Text = "Start Preview Before";
            // 
            // btnFF
            // 
            this.btnFF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFF.BackgroundImage")));
            this.btnFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFF.Location = new System.Drawing.Point(473, 231);
            this.btnFF.Name = "btnFF";
            this.btnFF.Size = new System.Drawing.Size(32, 32);
            this.btnFF.TabIndex = 34;
            this.btnFF.UseVisualStyleBackColor = true;
            this.btnFF.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // btnFR
            // 
            this.btnFR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFR.BackgroundImage")));
            this.btnFR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFR.Location = new System.Drawing.Point(316, 231);
            this.btnFR.Name = "btnFR";
            this.btnFR.Size = new System.Drawing.Size(32, 32);
            this.btnFR.TabIndex = 33;
            this.btnFR.UseVisualStyleBackColor = true;
            this.btnFR.Click += new System.EventHandler(this.btnFR_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.Location = new System.Drawing.Point(278, 231);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(32, 32);
            this.btnPlay.TabIndex = 32;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.lstDebug);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(916, 273);
            this.tabDebug.TabIndex = 1;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            this.tabDebug.Enter += new System.EventHandler(this.tabDebug_Enter);
            // 
            // lstDebug
            // 
            this.lstDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDebug.FormattingEnabled = true;
            this.lstDebug.HorizontalScrollbar = true;
            this.lstDebug.Location = new System.Drawing.Point(3, 3);
            this.lstDebug.Name = "lstDebug";
            this.lstDebug.Size = new System.Drawing.Size(910, 267);
            this.lstDebug.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 630);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(924, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 30;
            this.statusStrip.Text = "StatusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tmrDebug
            // 
            this.tmrDebug.Tick += new System.EventHandler(this.tmrDebug_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // cxmDebug
            // 
            this.cxmDebug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToClipboardToolStripMenuItem});
            this.cxmDebug.Name = "cxmDebug";
            this.cxmDebug.Size = new System.Drawing.Size(172, 26);
            // 
            // CopyToClipboardToolStripMenuItem
            // 
            this.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem";
            this.CopyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer.IsSplitterFixed = true;
            this.SplitContainer.Location = new System.Drawing.Point(0, 323);
            this.SplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.SplitContainer1);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.dgvSubtitles);
            this.SplitContainer.Size = new System.Drawing.Size(924, 307);
            this.SplitContainer.SplitterDistance = 118;
            this.SplitContainer.SplitterWidth = 1;
            this.SplitContainer.TabIndex = 33;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.pnlLocks);
            this.SplitContainer1.Panel1.Controls.Add(this.mtbDuration);
            this.SplitContainer1.Panel1.Controls.Add(this.lblDuration);
            this.SplitContainer1.Panel1.Controls.Add(this.mtbHide);
            this.SplitContainer1.Panel1.Controls.Add(this.mtbShow);
            this.SplitContainer1.Panel1.Controls.Add(this.lblHide);
            this.SplitContainer1.Panel1.Controls.Add(this.lblShow);
            this.SplitContainer1.Panel1.Controls.Add(this.nudDuration);
            this.SplitContainer1.Panel1.Controls.Add(this.nudHide);
            this.SplitContainer1.Panel1.Controls.Add(this.nudShow);
            this.SplitContainer1.Panel1MinSize = 0;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.rtbSubtitle);
            this.SplitContainer1.Panel2.Controls.Add(this.Panel1);
            this.SplitContainer1.Size = new System.Drawing.Size(924, 118);
            this.SplitContainer1.SplitterDistance = 251;
            this.SplitContainer1.SplitterIncrement = 320;
            this.SplitContainer1.SplitterWidth = 1;
            this.SplitContainer1.TabIndex = 58;
            // 
            // pnlLocks
            // 
            this.pnlLocks.Controls.Add(this.rbtLockHide);
            this.pnlLocks.Controls.Add(this.rbtLockDuration);
            this.pnlLocks.Controls.Add(this.rbtLockShow);
            this.pnlLocks.Location = new System.Drawing.Point(200, 8);
            this.pnlLocks.Name = "pnlLocks";
            this.pnlLocks.Size = new System.Drawing.Size(26, 84);
            this.pnlLocks.TabIndex = 65;
            // 
            // rbtLockHide
            // 
            this.rbtLockHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtLockHide.BackgroundImage = global::OpenSubtitleEditor.My.Resources.Resources._lock;
            this.rbtLockHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbtLockHide.Location = new System.Drawing.Point(3, 30);
            this.rbtLockHide.Name = "rbtLockHide";
            this.rbtLockHide.Size = new System.Drawing.Size(19, 20);
            this.rbtLockHide.TabIndex = 1;
            this.rbtLockHide.UseVisualStyleBackColor = true;
            // 
            // rbtLockDuration
            // 
            this.rbtLockDuration.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtLockDuration.BackgroundImage = global::OpenSubtitleEditor.My.Resources.Resources._lock;
            this.rbtLockDuration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbtLockDuration.Location = new System.Drawing.Point(3, 56);
            this.rbtLockDuration.Name = "rbtLockDuration";
            this.rbtLockDuration.Size = new System.Drawing.Size(19, 20);
            this.rbtLockDuration.TabIndex = 2;
            this.rbtLockDuration.UseVisualStyleBackColor = true;
            // 
            // rbtLockShow
            // 
            this.rbtLockShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtLockShow.BackgroundImage = global::OpenSubtitleEditor.My.Resources.Resources._lock;
            this.rbtLockShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbtLockShow.Checked = true;
            this.rbtLockShow.Location = new System.Drawing.Point(4, 4);
            this.rbtLockShow.Name = "rbtLockShow";
            this.rbtLockShow.Size = new System.Drawing.Size(19, 20);
            this.rbtLockShow.TabIndex = 0;
            this.rbtLockShow.TabStop = true;
            this.rbtLockShow.UseVisualStyleBackColor = true;
            // 
            // mtbDuration
            // 
            this.mtbDuration.Location = new System.Drawing.Point(70, 64);
            this.mtbDuration.Mask = "00:00:00.000";
            this.mtbDuration.Name = "mtbDuration";
            this.mtbDuration.Size = new System.Drawing.Size(100, 20);
            this.mtbDuration.TabIndex = 60;
            this.mtbDuration.TextChanged += new System.EventHandler(this.mtbDuration_TextChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(4, 67);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 64;
            this.lblDuration.Text = "Duration:";
            // 
            // mtbHide
            // 
            this.mtbHide.Location = new System.Drawing.Point(70, 37);
            this.mtbHide.Mask = "00:00:00.000";
            this.mtbHide.Name = "mtbHide";
            this.mtbHide.Size = new System.Drawing.Size(100, 20);
            this.mtbHide.TabIndex = 58;
            this.mtbHide.TextChanged += new System.EventHandler(this.mtbHide_TextChanged);
            // 
            // mtbShow
            // 
            this.mtbShow.Location = new System.Drawing.Point(70, 12);
            this.mtbShow.Mask = "00:00:00.000";
            this.mtbShow.Name = "mtbShow";
            this.mtbShow.Size = new System.Drawing.Size(100, 20);
            this.mtbShow.TabIndex = 56;
            this.mtbShow.TextChanged += new System.EventHandler(this.mtbShow_TextChanged);
            // 
            // lblHide
            // 
            this.lblHide.AutoSize = true;
            this.lblHide.Location = new System.Drawing.Point(4, 42);
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size(32, 13);
            this.lblHide.TabIndex = 63;
            this.lblHide.Text = "Hide:";
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(4, 16);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(37, 13);
            this.lblShow.TabIndex = 62;
            this.lblShow.Text = "Show:";
            // 
            // nudDuration
            // 
            this.nudDuration.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDuration.Location = new System.Drawing.Point(176, 64);
            this.nudDuration.Maximum = new decimal(new int[] {
            72000000,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(18, 20);
            this.nudDuration.TabIndex = 61;
            this.nudDuration.DownButtonClick += new CoolSoft.UI.NumericUpDownEx.DownButtonClickEventHandler(this.nudDuration_UpDownButtonClick);
            this.nudDuration.UpButtonClick += new CoolSoft.UI.NumericUpDownEx.UpButtonClickEventHandler(this.nudDuration_UpDownButtonClick);
            // 
            // nudHide
            // 
            this.nudHide.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHide.Location = new System.Drawing.Point(176, 37);
            this.nudHide.Maximum = new decimal(new int[] {
            72000000,
            0,
            0,
            0});
            this.nudHide.Name = "nudHide";
            this.nudHide.Size = new System.Drawing.Size(18, 20);
            this.nudHide.TabIndex = 59;
            this.nudHide.DownButtonClick += new CoolSoft.UI.NumericUpDownEx.DownButtonClickEventHandler(this.nudHide_UpDownButtonClick);
            this.nudHide.UpButtonClick += new CoolSoft.UI.NumericUpDownEx.UpButtonClickEventHandler(this.nudHide_UpDownButtonClick);
            // 
            // nudShow
            // 
            this.nudShow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudShow.Location = new System.Drawing.Point(176, 13);
            this.nudShow.Maximum = new decimal(new int[] {
            72000000,
            0,
            0,
            0});
            this.nudShow.Name = "nudShow";
            this.nudShow.Size = new System.Drawing.Size(18, 20);
            this.nudShow.TabIndex = 57;
            this.nudShow.DownButtonClick += new CoolSoft.UI.NumericUpDownEx.DownButtonClickEventHandler(this.nudShow_upDownButtonClick);
            this.nudShow.UpButtonClick += new CoolSoft.UI.NumericUpDownEx.UpButtonClickEventHandler(this.nudShow_upDownButtonClick);
            // 
            // rtbSubtitle
            // 
            this.rtbSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSubtitle.DetectUrls = false;
            this.rtbSubtitle.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.rtbSubtitle.Location = new System.Drawing.Point(87, 0);
            this.rtbSubtitle.Name = "rtbSubtitle";
            this.rtbSubtitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbSubtitle.Size = new System.Drawing.Size(586, 113);
            this.rtbSubtitle.TabIndex = 56;
            this.rtbSubtitle.Text = "";
            this.rtbSubtitle.TextChanged += new System.EventHandler(this.rtbSubtitle_TextChanged);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.btnShowHidePanel);
            this.Panel1.Controls.Add(this.chkItalic);
            this.Panel1.Controls.Add(this.chkBold);
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(90, 118);
            this.Panel1.TabIndex = 58;
            // 
            // btnShowHidePanel
            // 
            this.btnShowHidePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowHidePanel.BackgroundImage")));
            this.btnShowHidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowHidePanel.Location = new System.Drawing.Point(3, 42);
            this.btnShowHidePanel.Name = "btnShowHidePanel";
            this.btnShowHidePanel.Size = new System.Drawing.Size(26, 27);
            this.btnShowHidePanel.TabIndex = 59;
            this.btnShowHidePanel.UseVisualStyleBackColor = true;
            this.btnShowHidePanel.Click += new System.EventHandler(this.btnShowHidePanel_Click);
            // 
            // chkItalic
            // 
            this.chkItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalic.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkItalic.Location = new System.Drawing.Point(48, 42);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(29, 27);
            this.chkItalic.TabIndex = 57;
            this.chkItalic.Text = "I";
            this.chkItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBold.Location = new System.Drawing.Point(48, 11);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(29, 27);
            this.chkBold.TabIndex = 56;
            this.chkBold.Text = "B";
            this.chkBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // dgvSubtitles
            // 
            this.dgvSubtitles.AllowUserToAddRows = false;
            this.dgvSubtitles.AllowUserToResizeColumns = false;
            this.dgvSubtitles.AllowUserToResizeRows = false;
            this.dgvSubtitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubtitles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subIndex,
            this.subShow,
            this.subHide,
            this.subText,
            this.subProperties,
            this.hiddenShow});
            this.dgvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubtitles.Location = new System.Drawing.Point(0, 0);
            this.dgvSubtitles.Name = "dgvSubtitles";
            this.dgvSubtitles.RowTemplate.Height = 24;
            this.dgvSubtitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubtitles.Size = new System.Drawing.Size(924, 188);
            this.dgvSubtitles.TabIndex = 32;
            this.dgvSubtitles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubtitles_CellEndEdit);
            this.dgvSubtitles.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSubtitles_RowHeaderMouseClick);
            this.dgvSubtitles.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.StartMovieOnStartSubtitle);
            this.dgvSubtitles.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSubtitles_RowsAdded);
            this.dgvSubtitles.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSubtitles_RowsRemoved);
            this.dgvSubtitles.SelectionChanged += new System.EventHandler(this.dgvSubtitles_SelectionChanged);
            // 
            // subIndex
            // 
            this.subIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.subIndex.FillWeight = 5F;
            this.subIndex.HeaderText = "#";
            this.subIndex.Name = "subIndex";
            this.subIndex.ReadOnly = true;
            this.subIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subIndex.Width = 20;
            // 
            // subShow
            // 
            this.subShow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.subShow.FillWeight = 10F;
            this.subShow.HeaderText = "Show";
            this.subShow.IncludeLiterals = false;
            this.subShow.IncludePrompt = false;
            this.subShow.Mask = null;
            this.subShow.Name = "subShow";
            this.subShow.PromptChar = '\0';
            this.subShow.ValidatingType = null;
            this.subShow.Width = 40;
            // 
            // subHide
            // 
            this.subHide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.subHide.FillWeight = 10F;
            this.subHide.HeaderText = "Hide";
            this.subHide.IncludeLiterals = false;
            this.subHide.IncludePrompt = false;
            this.subHide.Mask = null;
            this.subHide.Name = "subHide";
            this.subHide.PromptChar = '\0';
            this.subHide.ValidatingType = null;
            this.subHide.Width = 35;
            // 
            // subText
            // 
            this.subText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subText.FillWeight = 80F;
            this.subText.HeaderText = "Subtitle";
            this.subText.Name = "subText";
            this.subText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // subProperties
            // 
            this.subProperties.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.subProperties.HeaderText = "Properties";
            this.subProperties.Name = "subProperties";
            this.subProperties.ReadOnly = true;
            this.subProperties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subProperties.Width = 60;
            // 
            // hiddenShow
            // 
            this.hiddenShow.HeaderText = "Column1";
            this.hiddenShow.Name = "hiddenShow";
            this.hiddenShow.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 652);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.MinimumSize = new System.Drawing.Size(641, 567);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabSubPrev.ResumeLayout(false);
            this.pnlVideoPlayer.ResumeLayout(false);
            this.pnlVideoPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldVolume)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.pnlTimerOnly.ResumeLayout(false);
            this.pnlTimerOnly.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cxmDebug.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.pnlLocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShow)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubtitles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Timer Timer;
        internal MenuStrip mnsMain;
        internal ToolStripMenuItem SubtitleToolStripMenuItem;
        internal ToolStripMenuItem OpenToolStripMenuItem;
        internal ToolStripMenuItem MovieToolStripMenuItem;
        internal ToolStripMenuItem EditToolStripMenuItem;
        internal ToolStripMenuItem SaveToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem ExitToolStripMenuItem;
        internal ToolStripMenuItem LanguageToolStripMenuItem;
        internal ToolStripMenuItem LoadTranslationToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem EnglishToolStripMenuItem;
        internal OpenFileDialog dlgOpen;
        internal SaveFileDialog dlgSubSave;
        internal ToolStripMenuItem PreviewSettingsToolStripMenuItem;
        internal OpenFileDialog dlgSubOpen;
        internal OpenFileDialog dlgMovOpen;
        internal ToolStripMenuItem MovieOpenToolStripMenuItem;
        internal Timer TimerSub;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal ToolStripMenuItem PlayToolStripMenuItem;
        internal ToolStripMenuItem ForwardToolStripMenuItem;
        internal ToolStripMenuItem RewindToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem4;
        internal ToolStripMenuItem VolumeToolStripMenuItem;
        internal ToolStripMenuItem volumeUpToolStripMenuItem;
        internal ToolStripMenuItem volumeDownToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem5;
        internal ToolStripMenuItem MuteToolStripMenuItem;
        internal ToolStripMenuItem MaxToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem6;
        internal ToolStripMenuItem PlayRateToolStripMenuItem;
        internal ToolStripMenuItem playRateUpToolStripMenuItem;
        internal ToolStripMenuItem playRateDownToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem7;
        internal ToolStripMenuItem ResetToolStripMenuItem;
        internal ToolStripMenuItem EditToolStripMenuItem1;
        internal ToolStripMenuItem AddToolStripMenuItem;
        internal ToolStripMenuItem OnCurrentMoviePositionToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem8;
        internal ToolStripMenuItem StartSelectedOnCurrentPositionToolStripMenuItem;
        internal ToolStripMenuItem EndSelectedOnCurrentPositionToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem9;
        internal ToolStripMenuItem DelayToolStripMenuItem;
        internal ToolStripMenuItem ApplyCurrentConstantDelayToolStripMenuItem;
        internal ToolStripMenuItem ApplyCustomDelayToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem10;
        internal ToolStripMenuItem FPSConversionToolStripMenuItem;
        internal ToolStripMenuItem SetCurrentFPSToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem11;
        internal ToolStripMenuItem ConvertToToolStripMenuItem;
        internal ToolStripMenuItem CurFPS23976ToolStripMenuItem;
        internal ToolStripMenuItem CurFPS25ToolStripMenuItem;
        internal ToolStripMenuItem ToFPS23976ToolStripMenuItem;
        internal ToolStripMenuItem ToFPS25ToolStripMenuItem;
        internal ToolStripMenuItem NewToolStripMenuItem;
        internal ToolStripMenuItem CurFPS24ToolStripMenuItem;
        internal ToolStripMenuItem CurFPS30ToolStripMenuItem;
        internal ToolStripMenuItem CurFPS15ToolStripMenuItem;
        internal ToolStripMenuItem CurFPS20ToolStripMenuItem;
        internal ToolStripMenuItem PALNTSCFormatsToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem12;
        internal ToolStripSeparator ToolStripMenuItem21;
        internal ToolStripMenuItem ComputerUsedToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem22;
        internal ToolStripMenuItem PALNTSCFormatsToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem13;
        internal ToolStripSeparator ToolStripMenuItem14;
        internal ToolStripMenuItem ComputerUsedToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem15;
        internal ToolStripMenuItem ToFPS15ToolStripMenuItem;
        internal ToolStripMenuItem ToFPS20ToolStripMenuItem;
        internal ToolStripMenuItem ToFPS24ToolStripMenuItem;
        internal ToolStripMenuItem ToFPS30ToolStripMenuItem;
        internal ToolStripMenuItem CurFPS2997ToolStripMenuItem;
        internal ToolStripMenuItem toFPS2997ToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem16;
        internal ToolStripMenuItem CheckForOverlappingSubtitlesToolStripMenuItem;
        internal ToolStripMenuItem HelpToolStripMenuItem;
        internal ToolStripMenuItem AboutToolStripMenuItem;
        internal ToolStripMenuItem GreekToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem17;
        internal TabControl tabControl;
        internal TabPage tabSubPrev;
        internal StatusStrip statusStrip;
        internal ToolStripStatusLabel lblStatus;
        internal Timer tmrDebug;
        internal ToolStripMenuItem SortSubtitlesBasedOnShowTimingToolStripMenuItem;
        internal ToolTip toolTip;
        internal Panel pnlVideoPlayer;
        internal Label lblVolume;
        internal TrackBar sldPosition;
        internal Label lblCurPos;
        internal TrackBar sldVolume;
        internal ComboBox cmbFRorFFby;
        internal GroupBox grpStatus;
        internal Label lblPlayRate;
        internal Label lblPlayRateLabel;
        internal Label lblConstantDelay;
        internal Label Label2;
        internal Label lblConstantDelayLabel;
        internal Panel pnlTimerOnly;
        internal Label lblEndAfter;
        internal Label lblEndAfterLabel;
        internal Label lblStartBefore;
        internal Label lblStartBeforeLabel;
        internal Label lblShowSub;
        internal Button btnFF;
        internal Button btnFR;
        internal Button btnPlay;
        internal TabPage tabDebug;
        internal ListBox lstDebug;
        internal ContextMenuStrip cxmDebug;
        internal ToolStripMenuItem CopyToClipboardToolStripMenuItem;
        internal ToolStripMenuItem ViewTabsToolStripMenuItem;
        internal SplitContainer SplitContainer;
        internal DataGridView dgvSubtitles;
        internal CheckBox chkPauseAfterQuick;
        internal Button btnQuickAdd;
        internal Button btnQuickEdit;
        internal DataGridViewTextBoxColumn subIndex;
        internal MaskedTextBoxColumn subShow;
        internal MaskedTextBoxColumn subHide;
        internal DataGridViewTextBoxColumn subText;
        internal DataGridViewTextBoxColumn subProperties;
        internal DataGridViewTextBoxColumn hiddenShow;
        internal ToolStripMenuItem OnNextLineToolStripMenuItem;
        internal SplitContainer SplitContainer1;
        internal Panel pnlLocks;
        internal RadioButton rbtLockHide;
        internal RadioButton rbtLockDuration;
        internal RadioButton rbtLockShow;
        internal MaskedTextBox mtbDuration;
        internal Label lblDuration;
        internal MaskedTextBox mtbHide;
        internal MaskedTextBox mtbShow;
        internal Label lblHide;
        internal Label lblShow;
        internal CoolSoft.UI.NumericUpDownEx nudDuration;
        internal CoolSoft.UI.NumericUpDownEx nudHide;
        internal CoolSoft.UI.NumericUpDownEx nudShow;
        internal Panel Panel1;
        internal CheckBox chkItalic;
        internal CheckBox chkBold;
        internal RichTextBox rtbSubtitle;
        internal Button btnShowHidePanel;
        internal AxWMPLib.AxWindowsMediaPlayer mPlayer;
        internal ToolStripMenuItem BrazilianPortugueseToolStripMenuItem;
        internal ToolStripMenuItem FrenchToolStripMenuItem;
        internal ToolStripMenuItem ItalianoToolStripMenuItem;
        internal ToolStripMenuItem HebrewToolStripMenuItem;
        internal ToolStripMenuItem PolishToolStripMenuItem;
        internal ToolStripMenuItem SpanishToolStripMenuItem;
        internal ToolStripMenuItem SpanishAlternativeToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator1;

    }
}