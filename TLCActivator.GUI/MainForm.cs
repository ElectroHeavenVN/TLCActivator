using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
            comboBoxType.Items.Add("Unknown");
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            Text = $"TLCActivator v{typeof(MainForm).Assembly.GetName().Version} - https://github.com/ElectroHeavenVN/TLCActivator";
            comboBoxType.SelectedIndex = 0;
            buttonSaveShortcut.Font = new Font(buttonSaveShortcut.Font.FontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            //pictureBox.Image = Properties.Resources.TCLMeme;
            imgIndex = 3;
            CheckInjectorExists();
        }

        void textBoxExePath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxExePath.Text) || Path.GetExtension(textBoxExePath.Text) != ".exe" || Path.GetFileName(textBoxExePath.Text).Contains(Constants.PRODUCT_LICENSE_NAME) || Path.GetFileName(textBoxExePath.Text).Contains("TLCActivator") || Constants.GAME_EXECUTABLE_NAMES.Any(x => Path.GetFileName(textBoxExePath.Text).Contains(x)))
            {
                buttonRun.BackColor = buttonSaveShortcut.BackColor = Color.FromArgb(255, 128, 128);
                buttonRun.Enabled = buttonSaveShortcut.Enabled = false;
                comboBoxType.SelectedIndex = comboBoxType.Items.Count - 1;
            }
            else
            {
                buttonRun.BackColor = Color.FromArgb(255, 255, 192);
                buttonSaveShortcut.BackColor = Color.White;
                buttonRun.Enabled = buttonSaveShortcut.Enabled = true;
                UpdateSelectedType(out _);
            }
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
            int rnd;
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
                    rnd = r.Next(0, 4);
                    switch (rnd)
                    {
                        case 0:
                            Process.Start("https://phamgiang.net/");
                            break;
                        case 1:
                            Process.Start("https://tiennvo.net/");
                            break;
                        case 2:
                            Process.Start("https://shopwibu.net/");
                            break;
                        case 3:
                            Process.Start("https://vpsz.net/");
                            break;
                    }
                    break;
                case 4:
                    rnd = r.Next(0, 2);
                    switch (rnd)
                    {
                        case 0:
                            Process.Start("https://phamgiang.net/");
                            break;
                        case 1:
                            Process.Start("https://tiennvo.net/");
                            break;
                    }
                    break;
            }
            Process.Start("https://dsc.gg/ehvnandfriends");
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
            TryShowShareFileDialog();
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

        void UpdateSelectedType(out int index)
        {
            index = Array.FindIndex(Constants.EXECUTABLE_NAMES, x => Path.GetFileName(textBoxExePath.Text).Contains(x));
            if (index != -1)
            {
                comboBoxType.SelectedIndex = index;
                if (Constants.EXECUTABLE_NAMES[index] == "[ThanhLc] Tool nhiệm vụ bò mộng" && File.Exists(Path.Combine(Path.GetDirectoryName(textBoxExePath.Text), "HtmlAgilityPack.dll")))
                    comboBoxType.SelectedIndex = index = Array.FindLastIndex(Constants.EXECUTABLE_NAMES, x => Path.GetFileName(textBoxExePath.Text).Contains(x));
            }
            else
                comboBoxType.SelectedIndex = index = comboBoxType.Items.Count - 1;
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

        void TryShowShareFileDialog()
        {
            UpdateSelectedType(out int index);
            string ignoredFileHashesPath = Path.GetDirectoryName(typeof(MainForm).Assembly.Location).TrimEnd('\\') + "\\hashes.txt";
            if (!File.Exists(ignoredFileHashesPath))
                File.Create(ignoredFileHashesPath).Close();
            List<string> gameAssemblyPaths = new List<string>();
            string accountManagerPath = textBoxExePath.Text;
            DirectoryInfo directoryInfo;
            if (comboBoxType.SelectedItem.ToString() == "AUTOPET225")
            {
                directoryInfo = new DirectoryInfo(Path.Combine(Path.GetDirectoryName(textBoxExePath.Text), "lib"));
                gameAssemblyPaths.Add(directoryInfo.FullName.TrimEnd('\\') + "\\DragonPro225.jar");
            }
            else
            {
                directoryInfo = new DirectoryInfo(Path.GetDirectoryName(textBoxExePath.Text)).GetDirectories().FirstOrDefault(x => x.Name.EndsWith("_Data"));
                if (directoryInfo != null)
                    gameAssemblyPaths.Add(directoryInfo.FullName.TrimEnd('\\') + "\\Managed\\Assembly-CSharp.dll");
                directoryInfo = new DirectoryInfo(Path.GetDirectoryName(textBoxExePath.Text));
                foreach (var file in directoryInfo.GetFiles("*.jar", SearchOption.AllDirectories).Where(f => !f.FullName.Contains("jre\\lib\\"))) 
                    gameAssemblyPaths.Add(file.FullName);
            }
            string[] ignoredFileHashes = File.ReadAllLines(ignoredFileHashesPath);
            List<string> hashSHA256_GameAssemblies = new List<string>();
            string hashSHA256_accountManager = "";
            using (SHA256 sha256 = SHA256.Create())
            {
                for (int i = gameAssemblyPaths.Count - 1; i >= 0; i--)
                {
                    string gameAssemblyPath = gameAssemblyPaths[i];
                    if (CheckSignature(gameAssemblyPath))
                    {
                        gameAssemblyPaths.RemoveAt(i);
                        continue;
                    }
                    using (FileStream fileStream = File.OpenRead(gameAssemblyPath))
                    {
                        hashSHA256_GameAssemblies.Add(BitConverter.ToString(sha256.ComputeHash(fileStream)).Replace("-", ""));
                    }
                }
                using (FileStream fileStream = File.OpenRead(accountManagerPath))
                {
                    hashSHA256_accountManager = BitConverter.ToString(sha256.ComputeHash(fileStream)).Replace("-", "");
                }
            }
            if (hashSHA256_GameAssemblies.All(fileHash => ignoredFileHashes.Contains(fileHash)) && ignoredFileHashes.Contains(hashSHA256_accountManager))
                return;
            if (hashSHA256_GameAssemblies.All(fileHash => Constants.ASSEMBLY_CSHARP_HASHES.Contains(fileHash)) && Constants.EXECUTABLE_HASHES.Contains(hashSHA256_accountManager))
                return;
            File.AppendAllText(ignoredFileHashesPath, hashSHA256_accountManager + Environment.NewLine);
            File.AppendAllLines(ignoredFileHashesPath, hashSHA256_GameAssemblies);
            string message = "It seems like this tool is not officially supported. TLCActivator will try its best to activate the tool. Would you like to send this tool to ElectroHeavenVN?\r\n\r\nCó vẻ như tool này không được hỗ trợ chính thức. TLCActivator sẽ cố gắng hết sức để kích hoạt tool này. Bạn có muốn gửi file tool cho ElectroHeavenVN không?";
            if (index != -1)
            {
                message = $"It seems like you are using an updated version of \"{comboBoxType.SelectedItem}\", which may have been modified to protect itself from TLCActivator. TLCActivator will try its best to activate the tool. Would you like to send this tool to ElectroHeavenVN?\r\n\r\nCó vẻ như bạn đang sử dụng phiên bản mới của \"{comboBoxType.SelectedItem}\". Phiên bản này có thể đã được sửa đổi để chống lại TLCActivator. TLCActivator sẽ cố gắng hết sức để kích hoạt tool này. Bạn có muốn gửi file tool cho ElectroHeavenVN không?";
            }
            if (MessageBox.Show(this, message, "Share binaries - Sharing is caring", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000) != DialogResult.Yes)
                return;
            List<string> filePaths = new List<string> { accountManagerPath };
            filePaths.AddRange(gameAssemblyPaths);
            SendFile(filePaths);
        }

        bool CheckSignature(string filePath)
        {
            if (filePath.EndsWith(".jar"))
                return false;
            byte[] data = File.ReadAllBytes(filePath);
            string dosSigStr = Encoding.ASCII.GetString(data, 78, 38);
            return dosSigStr.Contains("ElectroHeavenVN");
        }

        void SendFile(List<string> filePaths)
        {
            new Thread(async () =>
            {
                int count = filePaths.Count;
                bool error = false;
                while (filePaths.Count > 0)
                {
                    try
                    {
                        using (HttpClient httpClient = new HttpClient())
                        {
                            MultipartFormDataContent form = new MultipartFormDataContent();
                            int totalSize = 0;
                            while (totalSize < 1024 * 1024 * 15 && filePaths.Count > 0)
                            {
                                if (string.IsNullOrEmpty(filePaths.Last()) || !File.Exists(filePaths.Last()))
                                {
                                    filePaths.RemoveAt(filePaths.Count - 1);
                                    continue;
                                }
                                byte[] content = File.ReadAllBytes(filePaths.Last());
                                if (content.Length + totalSize > 1024 * 1024 * 15)
                                {
                                    filePaths.RemoveAt(filePaths.Count - 1);
                                    break;
                                }
                                form.Add(new ByteArrayContent(content), "file" + (count - filePaths.Count + 1), Path.GetFileName(filePaths.Last()));
                                totalSize += content.Length;
                                filePaths.RemoveAt(filePaths.Count - 1);
                            }
                            var result = await httpClient.PostAsync(Constants.WEBHOOK_LINK, form);
                            string s = await result.Content.ReadAsStringAsync();
                            result.EnsureSuccessStatusCode();
                            Thread.Sleep(3000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(new MethodInvoker(() => MessageBox.Show(this, "An error occured:\r\n" + ex, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000)));
                        error = true;
                    }
                }
                if (!error)
                    Invoke(new MethodInvoker(() => MessageBox.Show(this, "Send files successfully!\r\nGửi file thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000)));
            }).Start();
        }
    }
}
