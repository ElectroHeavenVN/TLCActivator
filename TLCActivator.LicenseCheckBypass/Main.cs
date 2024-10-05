using System;
using System.IO;
using System.Reflection;
using System.Threading;
using HarmonyLib;

namespace TLCActivator.LicenseCheckBypass
{
    public static class Main
    {
        internal static string licenseKey = "";

        internal static string productNameAndVersion = "DRAGONBALL237";

        internal static string productType = "DBOPROTHANHLC";

        public static int Initialize(string arg)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            try { 
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            new Harmony("TLCActivator.LicenseCheckBypass").PatchAll(Assembly.GetExecutingAssembly());
            string[] args = arg.Split('|');
            productNameAndVersion = args[0];
            productType = args[1];
            licenseKey = DeviceInformation.GenerateLicense(productNameAndVersion);
            File.WriteAllText("Data\\QLTK\\key.ini", licenseKey);
            new Thread(TCLRichPresence.Run) { IsBackground = true }.Start();
            }
            catch (Exception ex)
            {
                File.WriteAllText("ex.txt", ex.ToString());
                return 1;
            }
            return 0;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText("ex.txt", e.ExceptionObject.ToString());
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
