using Microsoft.Win32;

namespace Homework_SysPr_8
{
    class Program
    {
        static void Main()
        {
            string keyPath = @"Software\Homework_SysPr_8";

            string defaultUserName = "Guest";
            int defaultFontSize = 12;

            string userName = ReadRegistryValue(keyPath, "UserName", defaultUserName);
            int fontSize = ReadRegistryValue(keyPath, "FontSize", defaultFontSize);

            Console.WriteLine("Текуцие настройки: ");
            Console.WriteLine("Имя пользователя: " + userName);
            Console.WriteLine("Размер шрифта: " + fontSize);

            userName = "John";
            fontSize = 16;

            WriteRegistryValue(keyPath, "UserName", userName);
            WriteRegistryValue(keyPath, "FontSize", fontSize);

            Console.WriteLine("\nНастройки успешно обновлены.");
        }

        static T ReadRegistryValue<T>(string keyPath, string valueName, T defaultValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value != null)
                    {
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                }
            }
            return defaultValue;
        }

        static void WriteRegistryValue<T>(string keyPath, string valueName, T value)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
            }
        }
    }
}
