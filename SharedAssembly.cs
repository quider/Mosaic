using System.Reflection;
using System.Runtime.InteropServices;

#if WIN64
    [assembly: AssemblyProduct("Mosaic Platform x64- Mosaic")]    
#else
    [assembly: AssemblyProduct("Mosaic - mosaic maker")]
#endif

[assembly: AssemblyVersion("0.5.*")]
[assembly: AssemblyCompany("Adrian Kozłowski")]
[assembly: AssemblyCopyright("Copyright © 2015")]
[assembly: AssemblyTrademark("Adrian Kozłowski")]
[assembly: AssemblyDescription("Mosaic maker. Makes mosaic from small pictures. Big photo is replaced by small pictures.")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]