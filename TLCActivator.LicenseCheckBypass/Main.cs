using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using HarmonyLib;

namespace TLCActivator.LicenseCheckBypass
{
    public static class Main
    {
        internal static string licenseKey = "";

        internal static string productID = "DRAGONBALL237";

        internal static string productType = "thanhlcpropc";

        public static int Initialize(string arg)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            try { 
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            new Harmony("TLCActivator.LicenseCheckBypass").PatchAll(Assembly.GetExecutingAssembly());
            string[] args = arg.Split('|');
            productID = args[0];
            productType = args[1];
            licenseKey = DeviceInformation.GenerateLicense(productID);
            File.WriteAllText("Data\\QLTK\\key.ini", licenseKey);
            new Thread(TCLRichPresence.Run) { IsBackground = true }.Start();
            }
            catch (Exception ex)
            {
                File.WriteAllText("ex.txt", ex.ToString());
                MessageBox.Show("Error:\r\n" + ex, "TLCActivator.LicenseCheckBypass", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return 1;
            }
            return 0;
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
