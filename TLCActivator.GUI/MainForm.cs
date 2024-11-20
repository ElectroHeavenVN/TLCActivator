using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TLCActivator.GUI
{
    public partial class MainForm : Form
    {
        Random r = new Random();

        int imgIndex;

        public MainForm()
        {
            InitializeComponent();
            comboBoxType.Items.AddRange(Constants.PRODUCT_IDS);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            buttonSaveShortcut.Font = new Font(buttonSaveShortcut.Font.FontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            pictureBox.Image = Properties.Resources.TCLMeme;
            imgIndex = 3;
            CheckInjectorExists();
        }

        void textBoxExePath_TextChanged(object sender, EventArgs e)
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

        void buttonBrowseExeFile_Click(object sender, EventArgs e)
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

        void pictureBox_Click(object sender, EventArgs e)
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
                case 3:
                    Process.Start("https://phamgiang.net/");
                    Process.Start("https://tiennvo.net/");
                    Process.Start("https://shopwibu.net/");
                    Process.Start("https://vpsz.net/");
                    break;
                case 4:
                    Process.Start("https://phamgiang.net/");
                    Process.Start("https://tiennvo.net/");
                    Process.Start("https://dsc.gg/ehvnandfriends");
                    break;
            }
            switch (imgIndex = r.Next(0, 5))
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
                case 3:
                    pictureBox.Image = Properties.Resources.TCLMeme;
                    break;
                case 4:
                    pictureBox.Image = Properties.Resources.TCLMeme2;
                    break;
            }
        }

        void buttonRun_Click(object sender, EventArgs e)
        {
            if (!CheckInjectorExists(true))
                return;
            if (!CheckMonoDLL())
                return;
            Process.Start(Path.GetDirectoryName(typeof(MainForm).Assembly.Location) + "\\TLCActivator.Injector.exe", $"\"{textBoxExePath.Text}\" {comboBoxType.SelectedItem} {Constants.PRODUCT_TYPES[comboBoxType.SelectedIndex]}");
        }

        void textBoxExePath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        void textBoxExePath_DragDrop(object sender, DragEventArgs e)
        {
            textBoxExePath.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        void buttonSaveShortcut_Click(object sender, EventArgs e)
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

        bool CheckInjectorExists(bool dontExit = false)
        {
            if (!File.Exists(Path.GetDirectoryName(typeof(MainForm).Assembly.Location) + "\\TLCActivator.Injector.exe"))
            {
                MessageBox.Show(this, "TLCActivator.Injector.exe not found!\r\nYour antivirus may have removed it.\r\nDisable the aitivirus before re-downloading TLCActivator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                if (!dontExit)
                    Environment.Exit(1);
                return false;
            }
            return true;
        }

        bool CheckMonoDLL()
        {
            if (File.Exists(textBoxExePath.Text))
            {
                string path = Path.GetDirectoryName(textBoxExePath.Text);
                DirectoryInfo directoryInfo = new DirectoryInfo(path).GetDirectories().FirstOrDefault(x => x.Name.EndsWith("_Data"));
                if (directoryInfo == null)
                    return true;
                FileInfo monoDLL = new FileInfo(directoryInfo.FullName + "\\Mono\\mono.dll");
                if (!monoDLL.Exists)
                {
                    MessageBox.Show(this, "mono.dll not found! Your antivirus may have removed it.\r\nDisable the antivirus before re-downloading clean files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                    return false;
                }
                return true;
            }
            MessageBox.Show(this, "File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
            return false;
        }
    }
}
