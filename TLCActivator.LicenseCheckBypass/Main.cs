using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using HarmonyLib;
using System.Diagnostics;
using System.Text;

namespace TLCActivator.LicenseCheckBypass
{
    public static class Main
    {
        internal static readonly string DEFAULT_PRODUCT_TYPE = "TLCActivator";
        internal static readonly string DEFAULT_PRODUCT_ID = "TLCACTIVATOR";

        internal static string productID = DEFAULT_PRODUCT_ID;
        internal static string productType = DEFAULT_PRODUCT_TYPE;
        internal static string licenseKey, cpuInfo, ramInfo, hwInfo, newProductID;
        internal static string uuid;
        internal static bool initialized = false;

        internal static bool _productIDUnknown = true;
        internal static bool _productTypeUnknown = true;

        internal static bool IsProductIDUnknown => _productIDUnknown;
        internal static bool IsProductTypeUnknown => _productTypeUnknown;

        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int nStdHandle);

        public static int Initialize(string arg)
        {
            if (AppDomain.CurrentDomain.GetAssemblies().Where(a => Path.GetExtension(a.Location) == ".exe").Any(a => a.Location.Contains("AppData\\Local\\Temp")))
            {
                MessageBox.Show("Please extract the file before running!", "TLCActivator.LicenseCheckBypass", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return 1;
            }
#if DEBUG
            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "TLCActivator Debug Console - " + Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
#endif
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            try
            {

                Console.WriteLine("Installing hooks...");
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                Harmony harmony = new Harmony("TLCActivator.LicenseCheckBypass");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                Console.WriteLine("Hooks installed.");
                string[] args = arg.Split('|');
                if (args[0] != "Unknown")
                {
                    productID = args[0];
                    _productIDUnknown = false;
                }
                if (args[1] != "Unknown")
                {
                    productType = args[1];
                    _productTypeUnknown = false;
                }
                Console.WriteLine("Product ID: " + productID);
                Console.WriteLine("Product type: " + productType);
                Console.WriteLine("Generating license key...");
                licenseKey = DeviceInformation.GenerateLicense(productID);
                Console.WriteLine("License key generated.");
                cpuInfo = DeviceInformation.GetCPUInformation();
                Console.WriteLine("CPU information: " + cpuInfo);
                ramInfo = DeviceInformation.GetRamInformation();
                Console.WriteLine("RAM information: " + ramInfo);
                hwInfo = DeviceInformation.GetHardwareInformation();
                Console.WriteLine("Hardware information: " + hwInfo);
                uuid = DeviceInformation.GenerateLicense("LCT:" + productID + '.' + licenseKey);
                Console.WriteLine("UUID: " + uuid);
                initialized = true;
#if !DEBUG
                new Thread(TCLRichPresence.Run) { IsBackground = true }.Start();
#endif
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        File.WriteAllText("Data\\QLTK\\key.ini", licenseKey);
                        File.WriteAllText("Data\\QLTK\\license.ini", licenseKey);
                        File.WriteAllText("Data\\QLTK\\uuid.ini", uuid);
                        break;
                    }
                    catch { }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("ex.txt", ex.ToString());
                MessageBox.Show("Error:\r\n" + ex, "TLCActivator.LicenseCheckBypass", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return 1;
            }
            return 0;
        }

        internal static void GenerateNewUUID()
        {
            uuid = DeviceInformation.GenerateLicense("LCT:" + newProductID + '.' + licenseKey);
            try
            {
                File.WriteAllText("Data\\QLTK\\uuid.ini", uuid);
            }
            catch { }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText("ex.txt", e.ExceptionObject.ToString());
            MessageBox.Show("Error:\r\n" + e.ExceptionObject, "TLCActivator.LicenseCheckBypass", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("0Harmony"))
                return Assembly.LoadFile(Path.GetDirectoryName(typeof(Hook).Assembly.Location) + "\\0Harmony.dll");
            if (args.Name.Contains("DiscordRPC"))
                return Assembly.LoadFile(Path.GetDirectoryName(typeof(Hook).Assembly.Location) + "\\DiscordRPC.dll");
            return null;
        }
    }
}
