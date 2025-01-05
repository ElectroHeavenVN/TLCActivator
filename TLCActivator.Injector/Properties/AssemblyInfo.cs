using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TLCActivator.Injector")]
[assembly: AssemblyDescription("Command-line injector for TLCActivator; inject TLCActivator.LicenseCheckBypass into the target Account Manager.")]
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
[assembly: Guid("8b81225d-fc7a-43bb-9c2b-580c3031cd45")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.2")]
[assembly: AssemblyFileVersion("1.0.0.2")]
[assembly: AssemblyKeyFile("../TLCActivator.snk")]
