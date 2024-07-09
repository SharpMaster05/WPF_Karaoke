using Karaoke.Models;
using Newtonsoft.Json;
using System.IO;

namespace Karaoke.Services;

internal static class SettingService
{
    private static readonly string SettingFilePath = "appsettings.json";

    public static AppSettings LoadSettings()
    {
        if (!File.Exists(SettingFilePath))
        {
            return new AppSettings();
        }

        var json = File.ReadAllText(SettingFilePath);
        return JsonConvert.DeserializeObject<AppSettings>(json);
    }

    public static void SaveSettings(AppSettings settings)
    {
        var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
        File.WriteAllText(SettingFilePath, json);
    }
}
