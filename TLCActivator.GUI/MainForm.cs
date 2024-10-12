using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TLCActivator.GUI
{
    public partial class MainForm : Form
    {
        Random r = new Random();

        int imgIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            comboBoxType.Items.AddRange(Constants.PRODUCT_IDS);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            buttonSaveShortcut.Font = new Font(buttonSaveShortcut.Font.FontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            switch (imgIndex = r.Next(0, 3))
            {
                case 0:
                    pictureBox.Image = Properties.Resources.TCLDie;
                    break;
                case 1:
                    pictureBox.Image = Properties.Resources.TCLSmoke;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources.TCLOnAltar;
                    break;
            }
        }

        private void textBoxExePath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxExePath.Text) || Path.GetExtension(textBoxExePath.Text) != ".exe")
            {
                buttonRun.BackColor = buttonSaveShortcut.BackColor = Color.FromArgb(255, 128, 128);
                buttonRun.Enabled = buttonSaveShortcut.Enabled = false;
            }
            else
            {
                buttonRun.BackColor = Color.FromArgb(255, 255, 192);
                buttonSaveShortcut.BackColor = Color.White;
                buttonRun.Enabled = buttonSaveShortcut.Enabled = true;
            }

            int index = Array.FindIndex(Constants.EXECUTABLE_NAMES, x => textBoxExePath.Text.Contains(x));
            if (index != -1)
                comboBoxType.SelectedIndex = index;
        }

        private void buttonBrowseExeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select Account manager file",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };
            if (File.Exists(textBoxExePath.Text))
                openFileDialog.InitialDirectory = Path.GetDirectoryName(textBoxExePath.Text);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxExePath.Text = openFileDialog.FileName;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            switch (imgIndex)
            {
                case 0:
                    Process.Start("https://youtu.be/-52s3-7zPBo");
                    break;
                case 1:
                    Process.Start("https://youtu.be/kX43iLe1BQ4?t=111");
                    break;
                case 2:
                    Process.Start("https://youtu.be/12O_du5Okcg");
                    break;
            }
            switch (imgIndex = r.Next(0, 3))
            {
                case 0:
                    pictureBox.Image = Properties.Resources.TCLDie;
                    break;
                case 1:
                    pictureBox.Image = Properties.Resources.TCLSmoke;
                    break;
                case 2:
                    pictureBox.Image = Properties.Resources.TCLOnAltar;
                    break;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(typeof(MainForm).Assembly.Location) + "\\TLCActivator.Injector.exe", $"\"{textBoxExePath.Text}\" {comboBoxType.SelectedItem} {Constants.PRODUCT_TYPES[comboBoxType.SelectedIndex]}");
        }

        private void textBoxExePath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBoxExePath_DragDrop(object sender, DragEventArgs e)
        {
            textBoxExePath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void buttonSaveShortcut_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".lnk",
                Filter = "Shortcut files (*.lnk)|*.lnk",
                Title = "Save shortcut file",
                FileName = Path.GetFileNameWithoutExtension(textBoxExePath.Text) + ".lnk",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Shortcut.CreateShortcut(saveFileDialog.FileName, Path.GetDirectoryName(typeof(MainForm).Assembly.Location) + "\\TLCActivator.Injector.exe", $"\"{textBoxExePath.Text}\" {comboBoxType.SelectedItem} {Constants.PRODUCT_TYPES[comboBoxType.SelectedIndex]}");
            }
        }
    }
}
