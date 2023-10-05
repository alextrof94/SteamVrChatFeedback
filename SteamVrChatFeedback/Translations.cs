using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamVrChatFeedback
{
    public static class Translations
    {
        public static Dictionary<string, LocalizedString> Strings = new Dictionary<string, LocalizedString>{
            {"ShaderError", new LocalizedString(
                "Ошибка компиляции шейдера",
                "Shader compilation failed")
            },
        };

        static CultureInfo cultureRu = new CultureInfo("ru-RU");

        public static string GetString(string key)
        {
            if (Thread.CurrentThread.CurrentCulture.Equals(cultureRu))
                return Strings.GetValueOrDefault(key).ru;
            return Strings.GetValueOrDefault(key).en;
        }
    }

    public struct LocalizedString
    {
        public string ru = "Эта строка не переведена";
        public string en = "This line didn't translated";
        public LocalizedString(string ru, string en)
        {
            if (!string.IsNullOrEmpty(ru))
                this.ru = ru;
            if (!string.IsNullOrEmpty(en))
                this.en = en;
        }
    }
}
