using System.ComponentModel;

namespace FormsLab
{
    public partial class MyForm : Form
    {
        private Dictionary<string, (int count, long size)> _filemap = new();
        private string _selectedDir = string.Empty;
        private bool _itWillRunEventually = false;
        public MyForm()
        {
            InitializeComponent();
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeNode driveNode = new(drive.Name) { Tag = drive.RootDirectory };
                driveNode.Nodes.Add("");
                mainTreeView.Nodes.Add(driveNode);
            }
        }
        private void SelectForm_Show(object sender, EventArgs e)
        {
            SelectForm form = new(ref mainTreeView);
            form.ShowDialog(this);
            form.Activate();
        }
        private void mainTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string? directoryPath = e.Node!.Tag.ToString();
            if (directoryPath == null) return;

            TreeNode? emptyNode = null;
            foreach (TreeNode node in e.Node.Nodes) if (node.Text == "") { emptyNode = node; break; }
            if (emptyNode != null) e.Node.Nodes.Remove(emptyNode);

            if (e.Node.Text == "<File>")
            {
                try
                {
                    string[] files = Directory.GetFiles(directoryPath);
                    foreach (string file in files)
                    {
                        TreeNode fileNode = new(Path.GetFileName(file)) { Tag = file };
                        e.Node.Nodes.Add(fileNode);
                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    string[] directories = Directory.GetDirectories(directoryPath);
                    foreach (string directory in directories)
                    {
                        TreeNode directoryNode = new(Path.GetFileName(directory)) { Tag = directory };
                        directoryNode.Nodes.Add(new TreeNode(""));
                        e.Node.Nodes.Add(directoryNode);
                    }
                    string[] files = Directory.GetFiles(directoryPath);
                    if (files.Length <= 3)
                    {
                        foreach (string file in files)
                        {
                            TreeNode fileNode = new(Path.GetFileName(file)) { Tag = file };
                            e.Node.Nodes.Add(fileNode);
                        }
                    }
                    else
                    {
                        TreeNode mainfileNode = new("<File>") { Tag = directoryPath };
                        mainfileNode.Nodes.Add(new TreeNode(""));
                        e.Node.Nodes.Add(mainfileNode);
                    }
                }
                catch (Exception) { }
            }
        }
        private void mainTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node!.Nodes.Clear();
            e.Node.Nodes.Add(new TreeNode(""));
        }
        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolStripProgressBar.Value = 0;
            if (backgroundWorker.IsBusy) backgroundWorker.CancelAsync();

            _filemap = new Dictionary<string, (int, long)>();

            string nodePath = e.Node!.FullPath;
            DateTime lastChange = default;
            string fullPath, size = "...", items = "...", files = "...", subdirs = "...";
            bool isDir = false;

            if (Directory.Exists(nodePath))
            {
                _selectedDir = nodePath;
                isDir = true;
                fullPath = nodePath;

                DirectoryInfo dinfo = new(fullPath);
                lastChange = dinfo.LastWriteTime;
                size = "...";
                items = "...";
                files = "...";
                subdirs = "...";
            }
            else
            {
                fullPath = nodePath.Replace(@"\<File>", "");
                if (File.Exists(fullPath))
                {
                    FileInfo finfo = new(fullPath);
                    lastChange = finfo.LastWriteTime;
                    size = SharedFunctions.FileSizeToString(finfo.Length);
                    items = "1";
                    files = "1";
                    subdirs = "0";
                }
            }

            fullpathLabel.Text = fullPath; fullpathLabel.Refresh();
            sizeLabel.Text = size; sizeLabel.Refresh();
            itemsLabel.Text = items; itemsLabel.Refresh();
            filesLabel.Text = files; filesLabel.Refresh();
            subdirsLabel.Text = subdirs; subdirsLabel.Refresh();
            lastchangeLabel.Text = lastChange.ToString(); lastchangeLabel.Refresh();

            if (isDir)
            {
                if (backgroundWorker.IsBusy) backgroundWorker.CancelAsync();
                if (!backgroundWorker.IsBusy) { backgroundWorker.RunWorkerAsync(); return; }
                else _itWillRunEventually = true;
            }
        }
        private void CountFilesAndDirectories(object sender, DoWorkEventArgs e)
        {
            _itWillRunEventually = false;
            long size = 0;
            int processedFiles = 0, processedDirectories = 0, sum = 0, i = 0;
            string[] directories;
            try
            {
                directories = Directory.GetDirectories(_selectedDir);
            }
            catch (Exception) { e.Cancel = true; return; }

            foreach (string directory in directories)
            {
                if (backgroundWorker.CancellationPending) { e.Cancel = true; return; }

                (long s, int pF, int pD) = CountAll(directory, e);
                size += s;
                processedFiles += pF;
                processedDirectories += 1 + pD;
                sum += pF + pD + 1;
                i++;

                int progressPercentage = (int)((float)i * 100 / directories.Length);
                backgroundWorker.ReportProgress(progressPercentage);
            }
            e.Result = new long[] { size, sum, processedFiles, processedDirectories + 1 };
        }
        private (long, int, int) CountAll(string path, DoWorkEventArgs e)
        {
            int processedDirectories = 0;
            int processedFiles = 0;
            long size = 0;
            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    if (backgroundWorker.CancellationPending) { e.Cancel = true; return (size, processedFiles, processedDirectories); }
                    try
                    {
                        string extension = Path.GetExtension(file);
                        FileInfo finfo = new(file);

                        if (_filemap.ContainsKey(extension)) _filemap[extension] = (_filemap[extension].count + 1, _filemap[extension].size + finfo.Length);
                        else _filemap.Add(extension, (1, finfo.Length));
                        processedFiles += 1;
                        size += finfo.Length;
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    if (backgroundWorker.CancellationPending) { e.Cancel = true; return (size, processedFiles, processedDirectories); }
                    try
                    {
                        Directory.GetDirectories(path);
                        (long s, int pF, int pD) = CountAll(directory, e);
                        size += s;
                        processedFiles += pF;
                        processedDirectories += 1 + pD;
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
            return (size, processedFiles, processedDirectories);
        }
        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage < 0) toolStripProgressBar.Value = 0;
            else
            {
                if (e.ProgressPercentage > 100) toolStripProgressBar.Value = 100;
                else toolStripProgressBar.Value = e.ProgressPercentage;
            }
            charts.Invalidate();
        }
        private void CountingCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripProgressBar.Value = 0;
                sizeLabel.Text = "counting interrupted";
                itemsLabel.Text = "counting interrupted";
                filesLabel.Text = "counting interrupted";
                subdirsLabel.Text = "counting interrupted";

                if (_itWillRunEventually)
                {
                    sizeLabel.Text = "...";
                    itemsLabel.Text = "...";
                    filesLabel.Text = "...";
                    subdirsLabel.Text = "...";
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                if (e.Result == null) return;

                long[] result = (long[])e.Result;
                sizeLabel.Text = SharedFunctions.FileSizeToString(result[0]);
                itemsLabel.Text = result[1].ToString();
                filesLabel.Text = result[2].ToString();
                subdirsLabel.Text = result[3].ToString();
            }
            sizeLabel.Refresh();
            itemsLabel.Refresh();
            filesLabel.Refresh();
            subdirsLabel.Refresh();
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                toolStripProgressBar.Value = 0;
                backgroundWorker.CancelAsync();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void charts_Paint(object sender, PaintEventArgs e)
        {
            if (_filemap.Count > 0 && comboBox.SelectedItem is string s)
            {
                SharedFunctions.SortAndGroupData(new Dictionary<string, (int count, long size)>(_filemap), out (string, long)[] _counts, out (string, long)[] _sizes);
                if (s == "Pie chart") charts.ChartType = EChartType.Pie;
                else
                {
                    if (s == "Bar chart") charts.ChartType = EChartType.Bar;
                    else charts.ChartType = EChartType.LogBar;
                }
                charts.DrawCharts(e.Graphics, e.ClipRectangle, _counts, _sizes);
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            charts.Invalidate();
        }

        private void MyForm_LocationChanged(object sender, EventArgs e)
        {
            //OPCJA ZE SKALOWANIEM WYKRESÓW, GDY KONTROLKA ZNAJDZIE SIÊ POZA EKRANEM
            //Rectangle controlRect = charts.RectangleToScreen(charts.ClientRectangle);
            //Rectangle screenRect = Screen.FromControl(charts).Bounds;
            //if (!screenRect.Contains(controlRect)) charts.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }
    }
    public static partial class SharedFunctions
    {
        public static string FileSizeToString(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = size;
            int i = 0;

            while (len >= 1024 && i++ < sizes.Length - 1) len /= 1024;
            return $"{len:f2}{sizes[i]}";
        }
    }
}