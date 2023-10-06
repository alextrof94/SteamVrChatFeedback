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
            {"SiteCantBeReached", new LocalizedString(
                "Сайт недоступен",
                "Site can't be reached")
            },
            {"NewVersion", new LocalizedString(
                "Доступна новая версия приложения. \r\nОткрыть браузер для скачивания?\r\nНовая версия:",
                "A new version of the application is available. \r\nOpen browser to download?\r\nNew version:")
            },
            {"AlreadyUpToDate", new LocalizedString(
                "У вас последняя версия приложения",
                "You have the latest version of the application")
            },
            {"Connect", new LocalizedString(
                "Подключить",
                "Connect")
            },
            {"Connection", new LocalizedString(
                "Подключение",
                "Connection")
            },
            {"Connected", new LocalizedString(
                "Подключено",
                "Connected")
            },
            {"Controllers", new LocalizedString(
                "Оба|Левый|Правый",
                "Both|Left|Right")
            },
            {"aaaaaaaaaaa", new LocalizedString(
                "aaaaaaaaaaa",
                "aaaaaaaaaaa")
            },
        };

        static CultureInfo cultureRu = new CultureInfo("ru-RU");

        public static string GetString(string key)
        {
            string res;
            if (Thread.CurrentThread.CurrentCulture.Equals(cultureRu))
                res = Strings.GetValueOrDefault(key, new LocalizedString()).ru;
            else
                res = Strings.GetValueOrDefault(key, new LocalizedString()).en;

            return res;
        }
    }

    public struct LocalizedString
    {
        public string ru { get; set; } = "Эта строка не переведена";
        public string en { get; set; } = "This line didn't translated";

        public LocalizedString() { }
        public LocalizedString(string ru, string en)
        {
            if (!string.IsNullOrEmpty(ru))
                this.ru = ru;
            if (!string.IsNullOrEmpty(en))
                this.en = en;
        }
    }
}
