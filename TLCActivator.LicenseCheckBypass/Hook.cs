using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HarmonyLib;

namespace TLCActivator.LicenseCheckBypass
{
    static class Hook
    {
        static bool isFormTitleSet;

        static bool StringEquals(string a, string b)
        {
            if (a is null || b is null)
                return false;
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        static bool StringContains(string a, string b)
        {
            if (a is null || b is null)
                return false;
            return a.IndexOf(b, StringComparison.Ordinal) >= 0;
        }

        [HarmonyPatch(typeof(HttpClient), nameof(HttpClient.GetAsync), typeof(string))]
        public class HttpClientGetAsyncHook
        {
            static bool Prefix(string requestUri, ref Task<HttpResponseMessage> __result)
            {
                Console.WriteLine(requestUri);
                if (!requestUri.Contains("1ht_P2kqVZgMuAfHEtSMEGOmS1IloohmjoY6Gbp5EvlI"))
                    return true;
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                string activatedOptions = "";
                if (StringEquals(Main.productType, "thanhlcpropc") || StringEquals(Main.productType, "modnrsd"))    //RB9APK and K32KIOS is not available as they are meant for Android and iOS devices
                {
                    for (int i = 0; i < 10; i++)
                        activatedOptions += $"[Option{i + 1}:T]-";
                    activatedOptions = activatedOptions.TrimEnd('-');
                }
                else
                    activatedOptions = "1";
                string version = "0.0";
                httpResponseMessage.Content = new StringContent($"{Main.licenseKey}|{Main.productType}|{activatedOptions}|9999-12-31|thanhloncho|hoantat|{version}|endkey|");
                __result = Task.FromResult(httpResponseMessage);
                return false;
            }
        }
        
        [HarmonyPatch(typeof(HttpClient), nameof(HttpClient.GetStringAsync), typeof(string))]
        public class HttpClientGetStringAsyncHook
        {
            static bool Prefix(string requestUri, ref Task<string> __result)
            {
                Console.WriteLine(requestUri);
                if (!requestUri.Contains("1ht_P2kqVZgMuAfHEtSMEGOmS1IloohmjoY6Gbp5EvlI"))
                    return true;
                string activatedOptions = "";
                if (StringEquals(Main.productType, "thanhlcpropc") || StringEquals(Main.productType, "modnrsd"))    //RB9APK and K32KIOS is not available as they are meant for Android and iOS devices
                {
                    for (int i = 0; i < 10; i++)
                        activatedOptions += $"[Option{i + 1}:T]-";
                    activatedOptions = activatedOptions.TrimEnd('-');
                }
                else
                    activatedOptions = "1";
                string version = "0.0";
                string licenseString = $"{Main.licenseKey}|{Main.productType}|{activatedOptions}|9999-12-31|thanhloncho|hoantat|{version}|endkey|";
                __result = Task.FromResult($"<head></head><body><table class=\"waffle\"><tbody><tr><td class=\"s1\">StartLicense</td></tr><tr><td class=\"s1\">{licenseString}</td></tr><tr><td class=\"s2\">EndLicense</td></tr></tbody></table></body>");
                return false;
            }
        }

        [HarmonyPatch(typeof(Control), nameof(Control.Text), MethodType.Setter)]
        public class ControlTextHook
        {
            static bool Prefix(Control __instance, ref string value)
            {
                if (string.IsNullOrEmpty(value))
                    return true;
                if ((value.StartsWith("[thanhlc.com] [HSD:") || value.StartsWith("[thanhlc.com] HSD:") || value.StartsWith("\ud835\udcd3\ud835\udc93\ud835\udc82\ud835\udc88\ud835\udc90\ud835\udc8f \ud835\udcd1\ud835\udc82\ud835\udc8d\ud835\udc8d \ud835\udcdf\ud835\udc93\ud835\udc90 \ud835\udfd0.\ud835\udfd1.\ud835\udfd5") || value.StartsWith("Dragon Boy Ultra Pro")) && __instance is Form)
                {
                    string productID = Main.productID;
                    if (Main.IsProductIDUnknown)
                        productID = Main.newProductID;
                    value = $"TLC - {productID} [{Main.productType}] [Activated by TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator]";
                    if (!isFormTitleSet && Main.IsProductIDUnknown)
                    {
                        isFormTitleSet = true;
                        MessageBox.Show($"Product ID: {Main.newProductID}\r\nProduct type: {Main.productType}", "TLCActivator - Information", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x00040000);
                    }
                }
                else if (value.Contains("thanhloncho"))
                {
                    if (Main.productID.StartsWith("DRAGONBALLPRO") && __instance is Label)
                        value = $"Activated by TLCActivator - https://github.com/ElectroHeavenVN/TLCActivator";
                    else
                        value = value.Replace("thanhloncho", "admin");
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Concat), typeof(string[]))]
        public class StringConcatMultipleHook
        {
            static bool Prefix(string[] values, ref string __result)
            {
                if (values.Contains(Main.cpuInfo) && values.Contains(Main.ramInfo) && values.Contains(Main.hwInfo) && Main.IsProductIDUnknown && !StringEquals(values[0], Main.productID))
                {
                    if (!StringEquals(Main.newProductID, values[0]))
                        Main.newProductID = values[0];
                    values[0] = Main.productID;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Contains), typeof(string))]
        public class StringContainsHook
        {
            static bool Prefix(string __instance, string value, ref bool __result)
            {
                if (StringEquals(value, "windows server"))
                {
                    __result = false;
                    return false;
                }
                if (Main.IsProductTypeUnknown && StringEquals(__instance, Main.productType) && !StringContains(Main.productType, value))
                {
                    Main.productType = value;
                    __result = true;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(string), nameof(string.Equals), typeof(string), typeof(string))]
        public class StringEqualsHook
        {
            static bool Prefix(string a, string b, ref bool __result)
            {
                if (!Main.IsProductTypeUnknown)
                    return true;
                if (StringEquals(a, Main.productType) && !StringEquals(b, Main.productType))
                {
                    Main.productType = b;
                    __result = true;
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
                Console.WriteLine("Account Manager try to exit");
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

        [HarmonyPatch(typeof(Dns), nameof(Dns.GetHostEntry), typeof(string))]
        public class DnsGetHostEntryHook
        {
            static bool Prefix(string hostNameOrAddress, ref IPHostEntry __result)
            {
                if (StringEquals(hostNameOrAddress, "www.google.com"))
                {
                    __result = new IPHostEntry();
                    return false;
                }
                return true;
            }
        }
    }
}
