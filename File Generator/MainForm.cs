using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Generator
{
    public partial class MainForm : Form
    {
        #region Const and Data

        const int RW_BLOCK_SIZE = 512;
        readonly string _defaultFileName = "Test1.txt";

        bool _creatingfile = false;
        int _targetsize;
        string _targetFileName;
        string _targetTemplate;

        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = ProductName + " v" + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                comboBoxFileSize.SelectedIndex = 0;
                comboBoxFileSizeUnit.SelectedIndex = 1;
                textBoxFileName.Text = _defaultFileName;
                var drive = DriveInfo.GetDrives().Last(d => d.DriveType <= DriveType.Fixed);
                textBoxFileName.Text = Path.Combine(drive.Name, _defaultFileName);
                labelStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Internal Method


        void UpdateStatus(int percent)
        {
            var status = string.Format("Writing {0}%", percent);
            Invoke(new Action(() =>
            {
                progressBar1.Value = percent;
                labelStatus.Text = status;
            }));
        }

        static IEnumerable<string> SplitToBlocks(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        void CreateFileHandler(string filename, string template, int targetfilesize)
        {
            var contentstr = new StringBuilder(targetfilesize);
            var appendcount = targetfilesize / template.Length;
            var remainigsize = targetfilesize % template.Length;
            for (int i = 0; i < appendcount; i++) contentstr.Append(template);
            if (remainigsize != 0) contentstr.Append(template.Substring(0, remainigsize));

            var prevpercent = 0;
            var blocksWritten = 0;
            var blocks = SplitToBlocks(contentstr.ToString(), RW_BLOCK_SIZE).ToList();
            using (var sw = new StreamWriter(filename))
            {
                foreach (var item in blocks)
                {
                    sw.Write(item);
                    var percent = (blocksWritten * 100) / blocks.Count;
                    if (percent > prevpercent)
                    {
                        UpdateStatus(percent);
                        prevpercent = percent;
                    }
                    blocksWritten++;
                }
                var remainigbytes = targetfilesize % RW_BLOCK_SIZE;
                if (remainigbytes != 0)
                {
                    var remainigstr = contentstr.ToString().Substring(blocksWritten * RW_BLOCK_SIZE, remainigbytes);
                    sw.Write(remainigstr);
                }
                UpdateStatus(100);
            }
        }

        void RunCreateFileThread()
        {
            Task.Factory.StartNew(new Action(() =>
            {
                _creatingfile = true;
                try
                {
                    CreateFileHandler(_targetFileName, _targetTemplate, _targetsize);
                    Invoke(new Action(() =>
                    {
                        labelStatus.ForeColor = Color.DarkGreen;
                        labelStatus.Text = "Success";
                        buttonCreate.Text = "Create";
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        labelStatus.ForeColor = Color.Red;
                        labelStatus.Text = "Failed";
                        buttonCreate.Text = "Create";
                        var msg = string.Format("{0}Destination: {1}", ex.Message, _targetFileName);
                        MessageBox.Show(msg, "File Creating Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                _creatingfile = false;
            }));
        }

        #endregion

        #region Form Events

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FileName = _defaultFileName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        textBoxFileName.Text = sfd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_creatingfile) return;
                _targetFileName = textBoxFileName.Text;
                _targetTemplate = textBoxFileContentTemp.Text;
                var targetsize = int.Parse(comboBoxFileSize.Text);
                var filesizeunit = comboBoxFileSizeUnit.SelectedIndex;
                if (filesizeunit == 1) targetsize *= 1024;
                else if (filesizeunit == 2) targetsize *= 1024 * 1024;
                _targetsize = targetsize;

                buttonCreate.Text = "Creating...";
                progressBar1.Value = 0;
                labelStatus.ForeColor = Color.Blue;
                labelStatus.Text = "Writing...";
                RunCreateFileThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
