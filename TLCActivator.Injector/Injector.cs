//Source: https://github.com/wwh1004/ExtremeDumper/blob/master/ExtremeDumper/Injecting/Injector.cs
using NativeSharp;

namespace ExtremeDumper.Injecting
{
    /// <summary>
    /// Assembly and dll injector
    /// </summary>
    static class Injector
    {
        /// <summary>
        /// Inject managed DLL
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="assemblyPath">The path of the assembly to be injected</param>
        /// <param name="typeName">The type name (namespace + type name, e.g., NamespaceA.ClassB)</param>
        /// <param name="methodName">The method name (e.g., MethodC), the method must have the signature <code>static int MethodName(string)</code>, e.g., <code>private static int InjectingMain(string argument)</code></param>
        /// <param name="argument">The argument, can be passed as null</param>
        /// <param name="clrVersion">The CLR version to use</param>
        /// <returns></returns>
        public static bool InjectManaged(uint processId, string assemblyPath, string typeName, string methodName, string argument, InjectionClrVersion clrVersion)
        {
            using (NativeProcess process = NativeProcess.Open(processId))
            {
                if (process.IsInvalid)
                    return false;
                return process.InjectManaged(assemblyPath, typeName, methodName, argument, clrVersion);
            }
        }

        /// <summary>
        /// Inject managed DLL and get the return value of the called method (Warning: The return value can only be obtained after the called method returns. The injector method will wait until the called method returns. If you only need to inject the assembly without getting the return value, please use <see cref="InjectManaged(uint, string, string, string, string, InjectionClrVersion)"/>).
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="assemblyPath">The path of the assembly to be injected</param>
        /// <param name="typeName">The type name (namespace + type name, e.g., NamespaceA.ClassB)</param>
        /// <param name="methodName">The method name (e.g., MethodC), the method must have the signature <code>static int MethodName(string)</code>, e.g., <code>private static int InjectingMain(string argument)</code></param>
        /// <param name="argument">The argument, can be passed as null</param>
        /// <param name="clrVersion">The CLR version to use</param>
        /// <param name="returnValue">The integer value returned by the called method</param>
        /// <returns></returns>
        public static bool InjectManagedAndWait(uint processId, string assemblyPath, string typeName, string methodName, string argument, InjectionClrVersion clrVersion, out int returnValue)
        {
            returnValue = 0;
            using (NativeProcess process = NativeProcess.Open(processId))
            {
                if (process.IsInvalid)
                    return false;
                return process.InjectManaged(assemblyPath, typeName, methodName, argument, clrVersion, out returnValue);
            }
        }

        /// <summary>
        /// Inject unmanaged DLL
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="dllPath">The path of the DLL to be injected</param>
        /// <returns></returns>
        public static bool InjectUnmanaged(uint processId, string dllPath)
        {
            using (NativeProcess process = NativeProcess.Open(processId))
            {
                if (process.IsInvalid)
                    return false;
                return process.InjectUnmanaged(dllPath);
            }
        }
    }

}