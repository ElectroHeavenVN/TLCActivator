using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HarmonyLib;

namespace TLCActivator.LicenseCheckBypass
{
    static class Hook
    {
        [HarmonyPatch(typeof(HttpClient), nameof(HttpClient.GetAsync), typeof(string))]
        public class GetAsyncHook
        {
            static bool Prefix(string requestUri, ref Task<HttpResponseMessage> __result)
            {
                if (!requestUri.Contains("1ht_P2kqVZgMuAfHEtSMEGOmS1IloohmjoY6Gbp5EvlI"))
                    return true;
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                string activatedOptions = "";
                for (int i = 0; i < 10; i++)
                    activatedOptions += $"[Option{i + 1}:T]-";
                activatedOptions = activatedOptions.TrimEnd('-');
                //string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string version = "999.0";
                httpResponseMessage.Content = new StringContent($"{Main.licenseKey}|{Main.productType}|{activatedOptions}|9999-12-31|thanhloncho|hoantat|{version}|endkey|");
                __result = Task.FromResult(httpResponseMessage);
                return false;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Concat), typeof(string[]))]
        public class StringConcatHook
        {
            static bool Prefix(string[] values, ref string __result)
            {
                if (values.Length > 1 && values[0] == "[thanhlc.com] [HSD: ")
                {
                    __result = $"TLC - {Main.productNameAndVersion} [Activated by TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator]";
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Concat), typeof(string), typeof(string))]
        public class StringConcat2Hook
        {
            static bool Prefix(string str0, string str1, ref string __result)
            {
                if (str1 == "thanhloncho")
                {
                    __result = $"Activated by TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator";
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Concat), typeof(string), typeof(string), typeof(string))]
        public class StringConcat3Hook
        {
            static bool Prefix(string str0, string str1, string str2, ref string __result)
            {
                if (str0 == "\ud835\udcd3\ud835\udc93\ud835\udc82\ud835\udc88\ud835\udc90\ud835\udc8f \ud835\udcd1\ud835\udc82\ud835\udc8d\ud835\udc8d \ud835\udcdf\ud835\udc93\ud835\udc90 \ud835\udfd0.\ud835\udfd1.\ud835\udfd5 [\ud835\udc95\ud835\udc89\ud835\udc82\ud835\udc8f\ud835\udc89\ud835\udc8d\ud835\udc84.\ud835\udc84\ud835\udc90\ud835\udc8e - \ud835\udc6a\ud835\udc8d\ud835\udc8a\ud835\udc86\ud835\udc8f\ud835\udc95: ")
                {
                    __result = $"TLC - {Main.productNameAndVersion} [Activated by TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator]";
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Contains), typeof(string))]
        public class StringContainsHook
        {
            static bool Prefix(string __instance, string value, ref bool __result)
            {
                if (value == "windows server")
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Application), nameof(Application.Exit), new Type[0])]
        public class ApplicationExitHook
        {
            static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(File), nameof(File.Exists))]
        public class FileExistsHook
        {
            static bool Prefix(string path, ref bool __result)
            {
                if (path.Contains("QLTK/key.ini"))
                {
                    while (string.IsNullOrEmpty(Main.licenseKey))
                        Thread.Sleep(250);
                    __result = true;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(File), nameof(File.ReadAllText), typeof(string))]
        public class FileReadAllTextHook
        {
            static bool Prefix(string path, ref string __result)
            {
                if (path.Contains("QLTK/key.ini"))
                {
                    while (string.IsNullOrEmpty(Main.licenseKey))
                        Thread.Sleep(250);
                    __result = Main.licenseKey;
                    return false;
                }
                return true;
            }
        }
    }
}
