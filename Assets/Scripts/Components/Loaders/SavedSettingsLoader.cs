using System.IO;
using Newtonsoft.Json;

public class SavedSettingsLoader
{
    public static SavedSettings Load(string path)
    {
        var json = File.ReadAllText(path);
        var settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public static void Save(string path)
    {
        var json = JsonConvert.SerializeObject(Assets.Instance.SavedSettings, Formatting.Indented);
        File.WriteAllText(GenericPaths.SettingsPath, json);
    }
}