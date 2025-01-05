using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NativeSharp;

namespace TLCActivator.Injector
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        public static extern int AllocConsole();

        static void Main(string[] args)
        {
            var clrStrongName = (IClrStrongName)RuntimeEnvironment.GetRuntimeInterfaceAsObject(new Guid("B79B0ACD-F5CD-409b-B5A5-A16244610B92"), new Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D"));
            int result = clrStrongName.StrongNameSignatureVerificationEx(typeof(Program).Assembly.Location, true, out bool verified);
            if (result != 0 || !verified)
            {
                MessageBox.Show("This program has been modified, please download the original version!\r\nChương trình này đã bị chỉnh sửa! Vui lòng tải phiên bản gốc!", "TLCActivator", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return;
            }
            if (Environment.CurrentDirectory.Contains("AppData\\Local\\Temp"))
            {
                MessageBox.Show("Please extract the file before running!\r\nVui lòng giải nén file trước!", "TLCActivator.Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return;
            }
            AllocConsole();
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: TLCActivator.Injector.exe <executable path> <product id> <product type>");
                Console.ReadLine();
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Executable file not found.");
                Console.ReadLine();
                return;
            }
            try
            {
                Console.WriteLine("Injecting TLCActivator.LicenseCheckBypass.dll...");
                if (!File.Exists(Path.GetDirectoryName(args[0]) + "\\Data\\QLTK\\key.ini"))
                    File.Create(Path.GetDirectoryName(args[0]) + "\\Data\\QLTK\\key.ini");
                ProcessStartInfo processStartInfo = new ProcessStartInfo(args[0])
                {
                    WorkingDirectory = Path.GetDirectoryName(args[0]),
                };
                Process process = Process.Start(processStartInfo);
                bool hasCLRJIT = false;
                int count = 0;
                do
                {
                    foreach (ProcessModule processModule in process.Modules)
                    {
                        if (processModule.ModuleName == "clrjit.dll")
                        {
                            hasCLRJIT = true;
                            break;
                        }
                        count++;
                    }
                }
                while (!hasCLRJIT && count < 10);
                Thread.Sleep(100);
                if (ExtremeDumper.Injecting.Injector.InjectManagedAndWait((uint)process.Id, Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\Lib\\TLCActivator.LicenseCheckBypass.dll", "TLCActivator.LicenseCheckBypass.Main", "Initialize", string.Join("|", args[1], args[2]).Trim(), InjectionClrVersion.V4, out _))
                    Console.WriteLine("Injection succeeded.");
                else
                    Console.WriteLine("Injection failed.");
                Console.WriteLine("Exit after 3 seconds...");
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
