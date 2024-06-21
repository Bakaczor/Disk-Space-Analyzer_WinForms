namespace FormsLab
{
    partial class MyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            selectButton = new Button();
            mainTreeView = new TreeView();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            lastchangeLabel = new Label();
            subdirsLabel = new Label();
            filesLabel = new Label();
            itemsLabel = new Label();
            sizeLabel = new Label();
            fullpathLabel = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            charts = new Charts();
            comboBox = new ComboBox();
            label7 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectToolStripMenuItem, toolStripMenuItem1, cancelToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            selectToolStripMenuItem.Size = new Size(150, 22);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += SelectForm_Show;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(147, 6);
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            cancelToolStripMenuItem.Size = new Size(150, 22);
            cancelToolStripMenuItem.Text = "Cancel";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(147, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(150, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(mainTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl);
            splitContainer1.Size = new Size(784, 387);
            splitContainer1.SplitterDistance = 205;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(selectButton, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new Size(205, 32);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // selectButton
            // 
            selectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            selectButton.Location = new Point(127, 3);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(75, 26);
            selectButton.TabIndex = 2;
            selectButton.Text = "Select...";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += SelectForm_Show;
            // 
            // mainTreeView
            // 
            mainTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTreeView.Location = new Point(3, 35);
            mainTreeView.Name = "mainTreeView";
            mainTreeView.Size = new Size(199, 327);
            mainTreeView.TabIndex = 0;
            mainTreeView.AfterCollapse += mainTreeView_AfterCollapse;
            mainTreeView.AfterExpand += mainTreeView_AfterExpand;
            mainTreeView.AfterSelect += mainTreeView_AfterSelect;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(575, 387);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lastchangeLabel);
            tabPage1.Controls.Add(subdirsLabel);
            tabPage1.Controls.Add(filesLabel);
            tabPage1.Controls.Add(itemsLabel);
            tabPage1.Controls.Add(sizeLabel);
            tabPage1.Controls.Add(fullpathLabel);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(567, 359);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Details";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lastchangeLabel
            // 
            lastchangeLabel.AutoSize = true;
            lastchangeLabel.Location = new Point(94, 136);
            lastchangeLabel.Name = "lastchangeLabel";
            lastchangeLabel.Size = new Size(0, 15);
            lastchangeLabel.TabIndex = 11;
            // 
            // subdirsLabel
            // 
            subdirsLabel.AutoSize = true;
            subdirsLabel.Location = new Point(94, 111);
            subdirsLabel.Name = "subdirsLabel";
            subdirsLabel.Size = new Size(0, 15);
            subdirsLabel.TabIndex = 10;
            // 
            // filesLabel
            // 
            filesLabel.AutoSize = true;
            filesLabel.Location = new Point(94, 86);
            filesLabel.Name = "filesLabel";
            filesLabel.Size = new Size(0, 15);
            filesLabel.TabIndex = 9;
            // 
            // itemsLabel
            // 
            itemsLabel.AutoSize = true;
            itemsLabel.Location = new Point(94, 61);
            itemsLabel.Name = "itemsLabel";
            itemsLabel.Size = new Size(0, 15);
            itemsLabel.TabIndex = 8;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(94, 36);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(0, 15);
            sizeLabel.TabIndex = 7;
            // 
            // fullpathLabel
            // 
            fullpathLabel.AutoSize = true;
            fullpathLabel.Location = new Point(94, 11);
            fullpathLabel.Name = "fullpathLabel";
            fullpathLabel.Size = new Size(0, 15);
            fullpathLabel.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 136);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 5;
            label6.Text = "Last change:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 111);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 4;
            label5.Text = "Subdirs";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 86);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 3;
            label4.Text = "Files:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 61);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Items:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 36);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Size:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 11);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Full path:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(charts);
            tabPage2.Controls.Add(comboBox);
            tabPage2.Controls.Add(label7);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(567, 359);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Charts";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // charts
            // 
            charts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            charts.BackColor = Color.White;
            charts.ChartType = EChartType.Pie;
            charts.Location = new Point(6, 40);
            charts.Name = "charts";
            charts.Size = new Size(555, 298);
            charts.TabIndex = 4;
            charts.Paint += charts_Paint;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Pie chart", "Bar chart", "Log bar chart" });
            comboBox.Location = new Point(77, 11);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 23);
            comboBox.TabIndex = 3;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 11);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 0;
            label7.Text = "Chart type:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar });
            statusStrip1.Location = new Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.ForeColor = Color.Chartreuse;
            toolStripProgressBar.MarqueeAnimationSpeed = 25;
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(200, 16);
            toolStripProgressBar.Step = 1;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += CountFilesAndDirectories;
            backgroundWorker.ProgressChanged += UpdateProgress;
            backgroundWorker.RunWorkerCompleted += CountingCompleted;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 450);
            Name = "MyForm";
            Text = "Disk Space Analyzer";
            Load += MyForm_Load;
            LocationChanged += MyForm_LocationChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private SplitContainer splitContainer1;
        private TreeView mainTreeView;
        private Button selectButton;
        private TableLayoutPanel tableLayoutPanel1;
        private StatusStrip statusStrip1;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lastchangeLabel;
        private Label subdirsLabel;
        private Label filesLabel;
        private Label itemsLabel;
        private Label sizeLabel;
        private Label fullpathLabel;
        private ToolStripProgressBar toolStripProgressBar;
        private Label label7;
        private ComboBox comboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Charts charts;
    }
}