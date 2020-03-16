using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TTLChanger_WPF.Commands
{
    class RegisterCommands
    {
        public static string ReadRegistryKey()
        {
            try
            {
                RegistryKey LocalKey = Registry.LocalMachine;
                RegistryKey Key = LocalKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters");

                string TTLvalue = Key.GetValue("DefaultTTL").ToString();
                Key.Close();

                return TTLvalue;
            }
            catch
            {
                return "No TTL";
            }
        }

        public static string CreateTTLKey(int value)
        {
            try
            {
                RegistryKey LocalKey = Registry.LocalMachine;

                RegistryKey Key = LocalKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);

                Key.SetValue("DefaultTTL", value);

                Key.Close();

                return value.ToString();
            }
            catch
            {
                return "Запустите от имени администратора";
            }

        }

        public static string DeleteTTLKey()
        {
            try
            {
                RegistryKey LocalKey = Registry.LocalMachine;
                RegistryKey Key = LocalKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);
                Key.DeleteValue("DefaultTTL");

                Key.Close();
                return "TTL удален";
            }
            catch (System.Security.SecurityException)
            {
                return "Запустите от имени администратора";
            }
            catch (System.ArgumentException)
            {
                return "TTL удален";
            }
        }
    }
}
