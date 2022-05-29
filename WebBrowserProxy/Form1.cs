using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserProxy
{
    public partial class Form1 : Form, IOleClientSite, IServiceProvider, IAuthenticate
    {
        public static Guid IID_IAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
        public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
        public const int S_OK = unchecked((int)0x00000000);

        private static string proxyUsername = "mtfmqqfn-1";
        private static string proxyPassword = "m70d8utsbhog";

        public Form1()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_url.Text))
            {
                return;
            }

            WinInetInterop.SetConnectionProxy("http://p.webshare.io:80");

            string oURL = "about:blank";
            webBrowser.Navigate(oURL);

            object obj = webBrowser.ActiveXInstance;
            IOleObject oc = obj as IOleObject;
            oc.SetClientSite(this as IOleClientSite);

            webBrowser.Navigate(txt_url.Text);

            //WinInetInterop.RestoreSystemProxy(); Restores the proxy settings

        }

        public void GetContainer(object ppContainer)
        {
            ppContainer = this;
        }

        public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            int nRet = guidService.CompareTo(IID_IAuthenticate);
            if (nRet == 0)
            {
                nRet = riid.CompareTo(IID_IAuthenticate);
                if (nRet == 0)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IAuthenticate));
                    return S_OK;
                }
            }
            ppvObject = new IntPtr();
            return INET_E_DEFAULT_ACTION;
        }

        public int Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername,
            ref IntPtr pszPassword)
        {
            IntPtr strUser = Marshal.StringToCoTaskMemAuto(proxyUsername);
            IntPtr strPassword = Marshal.StringToCoTaskMemAuto(proxyPassword);


            pszUsername = strUser;
            pszPassword = strPassword;
            return S_OK;
        }

    }
}
