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
        internal static readonly string PRODUCT_LICENSE_NAME = "[ThanhLc] Product License";
        internal static readonly string[] GAME_EXECUTABLE_NAMES = new string[] 
        {
            "Dragonboy_vn_v231",
            "Dragon ball_237b",
            "Nro_244",
        };
    }
}
