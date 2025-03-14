using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TLCActivator.LicenseCheckBypass")]
[assembly: AssemblyDescription("Module to be injected into ThanhLC's Account Manager to activate it.")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/ElectroHeavenVN/TLCActivator/")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("ElectroHeavenVN")]
[assembly: AssemblyProduct("TLCActivator.LicenseCheckBypass")]
[assembly: AssemblyCopyright("Copyright © ElectroHeavenVN 2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ea38e8d9-c34f-428b-ae7f-82e742c83481")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("2.0.1.2")]
[assembly: AssemblyFileVersion("2.0.1.2")]
[assembly: AssemblyKeyFile("../TLCActivator.snk")]
