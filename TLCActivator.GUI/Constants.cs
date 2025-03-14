using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace TLCActivator.GUI
{
    internal static class Constants
    {
        static string DecryptStr(string encryptedStr)
        {
            DynamicMethod decryptStr = new DynamicMethod("DecryptStrDynamic", typeof(string), new Type[] { typeof(string) }, typeof(Constants));
            ILGenerator il = decryptStr.GetILGenerator();
            #region Local varaibles
            LocalBuilder v0 = il.DeclareLocal(typeof(byte[]));
            LocalBuilder v1 = il.DeclareLocal(typeof(byte[]));
            LocalBuilder v2 = il.DeclareLocal(typeof(byte[]));
            LocalBuilder v3 = il.DeclareLocal(typeof(byte[]));
            LocalBuilder v4 = il.DeclareLocal(typeof(byte[]));
            LocalBuilder v5 = il.DeclareLocal(typeof(int));
            LocalBuilder v6 = il.DeclareLocal(typeof(int));
            #endregion
            #region Labels
            Label l_27 = il.DefineLabel();
            Label l_42 = il.DefineLabel();
            Label l_55 = il.DefineLabel();
            Label l_70 = il.DefineLabel();
            #endregion
            #region IL code
            il.Emit(OpCodes.Ldtoken, typeof(Constants));
            il.Emit(OpCodes.Call, typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle)));
            il.Emit(OpCodes.Callvirt, typeof(Type).GetProperty(nameof(Type.Assembly)).GetGetMethod());
            il.Emit(OpCodes.Callvirt, typeof(Assembly).GetMethod(nameof(Assembly.GetName), new Type[0]));
            il.Emit(OpCodes.Callvirt, typeof(AssemblyName).GetMethod(nameof(AssemblyName.GetPublicKey)));
            il.Emit(OpCodes.Stloc, v0);
            il.Emit(OpCodes.Ldc_I4, 32);
            il.Emit(OpCodes.Newarr, typeof(byte));
			il.Emit(OpCodes.Stloc, v1);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Stloc, v5);
            il.Emit(OpCodes.Br, l_42);
            il.MarkLabel(l_27);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Ldelema, typeof(byte));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldind_U1);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Rem);
            il.Emit(OpCodes.Ldelem_U1);
            il.Emit(OpCodes.Xor);
            il.Emit(OpCodes.Conv_U1);
            il.Emit(OpCodes.Stind_I1);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v5);
            il.MarkLabel(l_42);
            il.Emit(OpCodes.Ldloc, v5);
            il.Emit(OpCodes.Ldc_I4, 32);
            il.Emit(OpCodes.Blt, l_27);
            il.Emit(OpCodes.Ldc_I4, 16);
            il.Emit(OpCodes.Newarr, typeof(byte));
            il.Emit(OpCodes.Stloc, v2);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Stloc, v6);
            il.Emit(OpCodes.Br, l_70);
            il.MarkLabel(l_55);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldelema, typeof(byte));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldind_U1);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldloc, v0);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Rem);
            il.Emit(OpCodes.Ldelem_U1);
            il.Emit(OpCodes.Xor);
            il.Emit(OpCodes.Conv_U1);
            il.Emit(OpCodes.Stind_I1);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldc_I4, 1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc, v6);
            il.MarkLabel(l_70);
            il.Emit(OpCodes.Ldloc, v6);
            il.Emit(OpCodes.Ldc_I4, 16);
            il.Emit(OpCodes.Blt, l_55);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, typeof(Convert).GetMethod(nameof(Convert.FromBase64String)));
            il.Emit(OpCodes.Stloc, v3);
            il.Emit(OpCodes.Call, typeof(Aes).GetMethod(nameof(Aes.Create), new Type[0]));
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldloc, v1);
            il.Emit(OpCodes.Callvirt, typeof(SymmetricAlgorithm).GetProperty(nameof(SymmetricAlgorithm.Key)).GetSetMethod());
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldloc, v2);
            il.Emit(OpCodes.Callvirt, typeof(SymmetricAlgorithm).GetProperty(nameof(SymmetricAlgorithm.IV)).GetSetMethod());
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldc_I4, (int)CipherMode.CBC);
            il.Emit(OpCodes.Callvirt, typeof(SymmetricAlgorithm).GetProperty(nameof(SymmetricAlgorithm.Mode)).GetSetMethod());
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Ldc_I4, (int)PaddingMode.Zeros);
            il.Emit(OpCodes.Callvirt, typeof(SymmetricAlgorithm).GetProperty(nameof(SymmetricAlgorithm.Padding)).GetSetMethod());
            il.Emit(OpCodes.Callvirt, typeof(SymmetricAlgorithm).GetMethod(nameof(SymmetricAlgorithm.CreateDecryptor), new Type[0]));
            il.Emit(OpCodes.Ldloc, v3);
            il.Emit(OpCodes.Ldc_I4, 0);
            il.Emit(OpCodes.Ldloc, v3);
            il.Emit(OpCodes.Ldlen);
            il.Emit(OpCodes.Conv_I4);
            il.Emit(OpCodes.Callvirt, typeof(ICryptoTransform).GetMethod(nameof(ICryptoTransform.TransformFinalBlock)));
            il.Emit(OpCodes.Stloc, v4);
            il.Emit(OpCodes.Call, typeof(Encoding).GetProperty(nameof(Encoding.UTF8)).GetGetMethod());
            il.Emit(OpCodes.Ldloc, v4);
            il.Emit(OpCodes.Callvirt, typeof(Encoding).GetMethod(nameof(Encoding.GetString), new Type[] { typeof(byte[]) }));
            il.Emit(OpCodes.Ret);
            #endregion
            return (string)decryptStr.Invoke(null, new object[] { encryptedStr });
        }

        internal static readonly string WEBHOOK_LINK = DecryptStr("lCnWEI+dl9JHkCrnFO0888Bdts2RwYoK9YM81exH72tLUDURU3PcurmyG30FGqOTzFxBvK34DIv636/iGKxc16OoX5xjvSCulaabVrNTUOrueZl6TKRYpHLSJfr2FnhEqGF8r73dOgFqzMhUsOf6m240auDWmkmyvdRhtzFCA8g=").Trim('\0');  

        internal static readonly string[] PRODUCT_IDS = new string[]
        {
            "DRAGONBALLPRO237",
            "AUTOPET225",
            "AUTOPET237",
            "TOOLUPSKH",
            "TRAINSKILL9",
            "AUTONVBM",
            "PORATASHARP237",
            "GODZILLAANDKONG",
            "TREOGTL",
            "ULTRA_PRO_244_20/2/2024",
            "TOOLTRAINQUAIV1",
            "AUTONVBM", //new ver
        };

        internal static readonly string[] PRODUCT_TYPES = new string[]
        {
            "thanhlcpropc",
            "toolpet",
            "tooldetupro",
            "toolupskh",
            "tooltrainskill",
            "toolnvhangngaypro",
            "toolmvbt",
            "toolgodzillaandkong",
            "TOOL_TRAIN_SUIT_TIME",
            "ULTRA_PRO_244",
            "TOOL_FARM_MOB",
            "TOOL_BORA_DAILY_TASK", //new ver

            "Unknown"
        };

        internal static readonly string[] EXECUTABLE_NAMES = new string[]
        {
            "[ThanhLc] QLTK Dragon Ball Pro",
            "[ThanhLc] Tool hỗ trợ up đệ tử thường",
            "[ThanhLc] Tool hỗ trợ up đệ tử",
            "[ThanhLc] Tool up set kích hoạt",
            "[ThanhLc] Tool train tuyệt kỹ",
            "[ThanhLc] Tool nhiệm vụ bò mộng",
            "[ThanhLc] Tool up mảnh vỡ bông tai",
            "[ThanhLc] Tool Godzilla và Kong",
            "[ThanhLc] Tool treo giáp tập luyện",
            "[LCT] QLTK Ultra Pro 244",
            "[ThanhLc] Tool train quái",
            "[ThanhLc] Tool nhiệm vụ bò mộng",  //new ver
        };

        internal static readonly string PRODUCT_LICENSE_NAME = "[ThanhLc] Product License";
        internal static readonly string[] GAME_EXECUTABLE_NAMES = new string[] 
        {
            "Dragonboy_vn_v231",
            "Dragon ball_237b",
            "Nro_244",
        };

        internal static readonly string[] EXECUTABLE_HASHES = new string[]
        {
            "BB2017027BD16886E8B18C0E18F83EF5B4B1A4EE327AB6F273C54252B0BB3BF4",
            "D335BAAD5BA814DE163FA46530AB2B0196BD7907188F6FB7EE05BDA540799A33",
            "DED795B8785EF0F3BC3C4D41AC679738595EE70E10599256D9A0CF363E0EBCAE",
            "4DB339DDA0FA261DF3779ACB62E90006E347DE6A75885F91BDE218290CF20CCD",
            "AA6BB9C92E0FFDB16DC06E606B34B6C44D32F41057C7FC8C531A8A4C84D36AC3",
            "1B0F244595BCEC8261B462D4DDF62B82325554BCD0B68F03EC1B534174584B97",
            "FE675CDA901DCA913FC88FF7353219AA51BF782A7722FCB8ABAA76DED05B1FCE",
            "E2E9893F50A4EF354C830DE599035F74EDAFD6064D9AA7D98C4627302E4035D4",
            "4628FD78ECE9CE8F11453BC9F1EE6E4CB1611FF1616AB500B55BFCAD0604F3D5", "E9735F94AB6A8F06C7D95A078AEFDD91AB115A655614A476ACB4C10AB8CCA2B2",
            "885D8A01404489C0EFDDB42B345830C4FEAE72DA3C3D142E26C2D0FB71CD4003",
            "22F9425AE7D5140638A5C49D86E41820E99AF7A60E6E1D41C2EED62AB0E27D72",
            "181EAF2BD5F0951BE242A9BF2C7E63F3B562A42FFEB8212FA270B4963270EC2E",
            "8FF61F47F73D1D30436599D42F5F32D65C1535120B53DEDF40D9004296879941",
            "885D8A01404489C0EFDDB42B345830C4FEAE72DA3C3D142E26C2D0FB71CD4003",
            "BEF01C4485F4389A74620097928052A2396DC680A859F0D1D487789ED368F521",
        };

        internal static readonly string[] ASSEMBLY_CSHARP_HASHES = new string[]
        {
            "6F901FA6CE32AEAB438F29EEF7F631523EF50CE8B0B7D824293CE766F07A4BF2",
            "858090296A0827CD9C9D02605C31EE29A00ADEC3B73F9C8998D3E4E4312A4858", // DragonPro225.jar
            "78A91B2860218EBE36B69BCE4B85CB763DBE111E7BA9C1E6E6C298EEB4D77ADE", "C9A25573412549B6F3D6D4F3750B5F042C259C08CEC233881C782C9F9989A8AC",
            "7151AAD00F42CB07A4E70E2F6E3E30A83378917094D4F984A8AF38821CD252F8",
            "85782F2B9464FDAA5928F32717A973E168D54C25B0CCBFFBCF9E0DAEAA5F6C1A",
            "F2BDD8C88B44041159BEA2844AC6E05B9E184573F856A0A3BD1EA8039C997FEF",
            "BE60311F1253A53FFC5E1D0CF288C84943066F740105204BAC46177FB3B73AB0",
            "8ECD74A494C577B1868CEF746CB9FA430947E09648EB8B333C738999D934B868",
            "C76A791E4A86487EAB7D42D527B6481C5068DC806B304509177506CE7A7236BC",
            "3430ECC1F737B28CCB2884E9B4D5542F7C7BB03A5044EBBFD027523B55FC65C9",
            "181EAF2BD5F0951BE242A9BF2C7E63F3B562A42FFEB8212FA270B4963270EC2E",
        };
    }
}
