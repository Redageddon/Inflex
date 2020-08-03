using System.IO;
using Beatmaps;
using Inflex.Rron;
using UnityEngine;

namespace Logic
{
    using static Application;

    public class Assets : Singleton<Assets>
    {
        public BeatMapMeta BeatMapMeta { get; set; }

        public Skin Skin { get; private set; }

        public SavedSettings Settings { get; } = LoadSettings();

        private static SavedSettings LoadSettings()
        {
            if (File.Exists(GenericPaths.SettingsPath) && !string.IsNullOrEmpty(File.ReadAllText(GenericPaths.SettingsPath)))
            {
                return RronConvert.DeserializeObjectFromFile<SavedSettings>(GenericPaths.SettingsPath);
            }

            return CreateNewSettingsFile();
        }

        private static SavedSettings CreateNewSettingsFile()
        {
            SavedSettings settings = new SavedSettings("Default");
            RronConvert.SerializeObjectToFile(settings, GenericPaths.SettingsPath);
            return settings;
        }

        private void Awake() => this.Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.Settings.SkinName);
    }
}