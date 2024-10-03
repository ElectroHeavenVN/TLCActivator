﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using NativeSharp;

namespace TLCActivator.Injector
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        public static extern int AllocConsole();

        static void Main(string[] args)
        {
            AllocConsole();
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: TLCActivator.Injector.exe <executable path> <product name and version> <product type>");
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
                if (ExtremeDumper.Injecting.Injector.InjectManagedAndWait((uint)process.Id, Path.GetFullPath("Lib\\TLCActivator.LicenseCheckBypass.dll"), "TLCActivator.LicenseCheckBypass.Hook", "Initialize", string.Join("|", args[1], args[2]).Trim(), InjectionClrVersion.V4, out _))
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
