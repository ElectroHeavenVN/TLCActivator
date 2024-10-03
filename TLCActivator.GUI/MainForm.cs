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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
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
                buttonRun.BackColor = Color.FromArgb(255, 128, 128);
                buttonRun.Enabled = false;
            }
            else
            {
                buttonRun.BackColor = Color.FromArgb(255, 255, 192);
                buttonRun.Enabled = true;
            }

            if (textBoxExePath.Text.Contains("[ThanhLc] QLTK Dragon Ball Pro.exe"))
                comboBoxType.SelectedIndex = 0;
            else if (textBoxExePath.Text.Contains("[ThanhLc] Tool hỗ trợ up đệ tử.exe"))
                comboBoxType.SelectedIndex = 1;
            else if (textBoxExePath.Text.Contains("[ThanhLc] Tool up set kích hoạt.exe"))
                comboBoxType.SelectedIndex = 2;
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
            Process.Start(Path.GetDirectoryName(typeof(MainForm).Assembly.Location) + "\\TLCActivator.Injector.exe", $"\"{textBoxExePath.Text}\" {comboBoxType.SelectedItem} {GetProductType((string)comboBoxType.SelectedItem)}");
        }

        private string GetProductType(string selectedItem)
        {
            switch (selectedItem)
            {
                case "DRAGONBALLPRO237":
                    return "thanhlcpropc";
                case "AUTOPET237":
                    return "tooldetupro";
                case "TOOLUPSKH":
                    return "toolupskh";
                default:
                    return "";
            }
        }

        private void textBoxExePath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBoxExePath_DragDrop(object sender, DragEventArgs e)
        {
            textBoxExePath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }
    }
}
