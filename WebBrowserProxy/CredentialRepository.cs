using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserProxy
{
    public class CredentialRepository
    {
        public static void SavePassword(string username, string password, string passwordName)
        {
            using (var cred = new Credential())
            {
                cred.Password = password;
                cred.Username = username;
                cred.Target = passwordName;
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.LocalComputer;
                cred.Save();
            }
        }

        public static Credential GetPassword(string passwordName)
        {
            using (var cred = new Credential())
            {
                cred.Target = passwordName;
                cred.Load();
                return cred;
            }
        }
    }
}
