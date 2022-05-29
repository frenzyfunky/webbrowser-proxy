using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserProxy
{
    [ComImport, GuidAttribute("79EAC9D0-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown),
    ComVisible(false)]
    public interface IAuthenticate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Authenticate(ref IntPtr phwnd,
        ref IntPtr pszUsername,
        ref IntPtr pszPassword
        );
    }
}
