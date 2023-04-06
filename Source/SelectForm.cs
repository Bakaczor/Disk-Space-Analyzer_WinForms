namespace FormsLab
{
    public partial class SelectForm : Form
    {
        private TreeView _treeView;
        public SelectForm(ref TreeView treeView)
        {
            InitializeComponent();
            _treeView = treeView;
        }
        private void SelectForm_Load(object sender, EventArgs e)
        {
            int width = 66;
            int height = 14;
            ImageList imageList = new() { ImageSize = new Size(width, height), };
            listView.SmallImageList = imageList;

            DriveInfo[] dinfo = DriveInfo.GetDrives();
            int i = 0;
            foreach (DriveInfo d in dinfo)
            {
                int percent = (int)((d.TotalSize - d.TotalFreeSpace) * 100 / d.TotalSize);
                Bitmap bitmap = new(width, height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, width, height));
                    g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, percent * width / 100 - 1, height - 1);
                    g.FillRectangle(Brushes.RoyalBlue, new Rectangle(1, 1, percent * width / 100 - 2, height - 2));
                }
                imageList.Images.Add(bitmap);

                ListViewItem item = new(new[]
                {   d.Name,
                    d.Name,
                    Math.Round(d.TotalSize / Math.Pow(2, 30), 2).ToString() + "GB",
                    Math.Round(d.TotalFreeSpace / Math.Pow(2, 30), 2).ToString() + "GB",
                    percent.ToString() +"%"
                }, i++);
                listView.Items.Add(item);
            }
            listView.Columns[0].DisplayIndex = 3;
            foreach (ColumnHeader column in listView.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int contentWidth = column.Width;
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int headerWidth = column.Width;

                ColumnHeaderAutoResizeStyle style;
                if (contentWidth > headerWidth) style = ColumnHeaderAutoResizeStyle.ColumnContent;
                else style = ColumnHeaderAutoResizeStyle.HeaderSize;
                column.AutoResize(style);
            }

            pathTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pathTextBox.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            AFButton.Checked = true;
            FolderBrowserDialog fbd = new() { InitialDirectory = @"C:\" };
            fbd.ShowDialog();
            pathTextBox.Text = fbd.SelectedPath;
        }
        private void check_IDButton(object sender, EventArgs e)
        {
            IDButton.Checked = true;
        }
        private void check_AFButton(object sender, EventArgs e)
        {
            AFButton.Checked = true;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            _treeView.Nodes.Clear();
            (bool, string) loadFrom = (false, "");

            if (ALDButton.Checked)
            {
                loadFrom = (false, "");
            }
            else if (IDButton.Checked)
            {
                if (listView.SelectedItems.Count == 0) loadFrom = (true, "");
                else
                {
                    ListViewItem item = listView.SelectedItems[0];
                    loadFrom = (true, item.SubItems[0].Text);
                }
            }
            else if (AFButton.Checked)
            {
                loadFrom = (true, pathTextBox.Text);
            }

            if (loadFrom.Item1)
            {
                if (loadFrom.Item2 != "" && Directory.Exists(loadFrom.Item2))
                {
                    TreeNode node = new(loadFrom.Item2) { Tag = loadFrom.Item2 };
                    node.Nodes.Add("");
                    _treeView.Nodes.Add(node);
                }
            }
            else
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new(drive.Name) { Tag = drive.RootDirectory };
                    driveNode.Nodes.Add("");
                    _treeView.Nodes.Add(driveNode);
                }
            }
            Close();
        }
        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            string path = pathTextBox.Text;
            if (!Directory.Exists(path))
            {
                pathTextBox.ForeColor = Color.Red;
                return;
            }
            else if (path.EndsWith(@"\"))
            {
                DirectoryInfo directory = new(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                AutoCompleteStringCollection autoCompleteList = new();
                foreach (DirectoryInfo subDirectory in subDirectories)
                    autoCompleteList.Add(subDirectory.FullName);
                pathTextBox.AutoCompleteCustomSource = autoCompleteList;
            }
            pathTextBox.ForeColor = SystemColors.WindowText;
        }
        private void listView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (e.ColumnIndex == 0 && listView.SmallImageList != null)
            {
                int width = listView.Columns[0].Width;
                if (width > 256) width = 256;

                int height = 14;
                listView.SmallImageList.Dispose();
                ImageList imageList = new() { ImageSize = new Size(width, height), };
                listView.SmallImageList = imageList;

                DriveInfo[] dinfo = DriveInfo.GetDrives();
                foreach (DriveInfo d in dinfo)
                {
                    int percent = (int)((d.TotalSize - d.TotalFreeSpace) * 100 / d.TotalSize);
                    Bitmap bitmap = new(width, height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, width, height));
                        g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, percent * width / 100 - 1, height - 1);
                        g.FillRectangle(Brushes.RoyalBlue, new Rectangle(1, 1, percent * width / 100 - 2, height - 2));
                    }
                    imageList.Images.Add(bitmap);
                }
            }
        }
    }
}
