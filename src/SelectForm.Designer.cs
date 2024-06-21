namespace FormsLab
{
    partial class SelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView = new ListView();
            columnChart = new ColumnHeader();
            columnName = new ColumnHeader();
            columnTotal = new ColumnHeader();
            columnFree = new ColumnHeader();
            columnUsed = new ColumnHeader();
            AFButton = new RadioButton();
            IDButton = new RadioButton();
            ALDButton = new RadioButton();
            pathTextBox = new TextBox();
            buttonCancel = new Button();
            buttonOK = new Button();
            buttonSearch = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            statusStrip1 = new StatusStrip();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnChart, columnName, columnTotal, columnFree, columnUsed });
            listView.FullRowSelect = true;
            listView.Location = new Point(3, 57);
            listView.Name = "listView";
            listView.Size = new Size(478, 89);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.ColumnWidthChanged += listView_ColumnWidthChanged;
            listView.Click += check_IDButton;
            // 
            // columnChart
            // 
            columnChart.Text = "Used/Total";
            // 
            // columnName
            // 
            columnName.Text = "Name";
            // 
            // columnTotal
            // 
            columnTotal.Text = "Total";
            // 
            // columnFree
            // 
            columnFree.Text = "Free";
            // 
            // columnUsed
            // 
            columnUsed.Text = "Used/Total";
            columnUsed.Width = 100;
            // 
            // AFButton
            // 
            AFButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AFButton.AutoSize = true;
            AFButton.Location = new Point(3, 152);
            AFButton.Name = "AFButton";
            AFButton.Size = new Size(69, 19);
            AFButton.TabIndex = 3;
            AFButton.TabStop = true;
            AFButton.Text = "A Folder";
            AFButton.UseVisualStyleBackColor = true;
            // 
            // IDButton
            // 
            IDButton.AutoSize = true;
            IDButton.Location = new Point(3, 32);
            IDButton.Name = "IDButton";
            IDButton.Size = new Size(112, 19);
            IDButton.TabIndex = 2;
            IDButton.TabStop = true;
            IDButton.Text = "Individual Drives";
            IDButton.UseVisualStyleBackColor = true;
            // 
            // ALDButton
            // 
            ALDButton.AutoSize = true;
            ALDButton.Location = new Point(3, 7);
            ALDButton.Name = "ALDButton";
            ALDButton.Size = new Size(105, 19);
            ALDButton.TabIndex = 1;
            ALDButton.TabStop = true;
            ALDButton.Text = "All Local Drives";
            ALDButton.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            pathTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pathTextBox.Location = new Point(3, 7);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(398, 23);
            pathTextBox.TabIndex = 7;
            pathTextBox.Click += check_AFButton;
            pathTextBox.TextChanged += pathTextBox_TextChanged;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(407, 40);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(74, 23);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(326, 40);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 5;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSearch.Location = new Point(407, 7);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(74, 23);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "...";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.Controls.Add(buttonCancel, 1, 1);
            tableLayoutPanel2.Controls.Add(buttonSearch, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonOK, 0, 1);
            tableLayoutPanel2.Controls.Add(pathTextBox, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 170);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(484, 66);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 239);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(484, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // SelectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(statusStrip1);
            Controls.Add(AFButton);
            Controls.Add(listView);
            Controls.Add(IDButton);
            Controls.Add(ALDButton);
            Controls.Add(tableLayoutPanel2);
            MaximizeBox = false;
            MaximumSize = new Size(600, 350);
            MinimizeBox = false;
            MinimumSize = new Size(500, 300);
            Name = "SelectForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Disk or Folder";
            Load += SelectForm_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView;
        private RadioButton AFButton;
        private RadioButton IDButton;
        private RadioButton ALDButton;
        private Button buttonCancel;
        private Button buttonOK;
        private Button buttonSearch;
        private TextBox pathTextBox;
        private ColumnHeader columnName;
        private ColumnHeader columnTotal;
        private ColumnHeader columnFree;
        private TableLayoutPanel tableLayoutPanel2;
        private StatusStrip statusStrip1;
        private ColumnHeader columnUsed;
        private ColumnHeader columnChart;
    }
}