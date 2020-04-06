using System.IO;
using Newtonsoft.Json;

public class SavedSettingsLoader : Singleton<SavedSettingsLoader>, ILoader<SavedSettings>
{
    public SavedSettings Load(string path)
    {
        var json = File.ReadAllText(path);
        var settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public void Save(string path)
    {
        var json = JsonConvert.SerializeObject(Assets.Instance.SavedSettings, (Formatting) 1);
        File.WriteAllText(GenericPaths.SettingsPath, json);
    }
}