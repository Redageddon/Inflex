using System.IO;
using BeatMaps;
using Inflex.Rron;
using UnityEngine;

namespace Components
{
    using static Application;

    public class Assets : Singleton<Assets>
    {
        public BeatMap BeatMap { get; set; }

        public Skin Skin { get; private set; }

        public SavedSettings Settings { get; } = LoadSettings();

        private static SavedSettings LoadSettings()
        {
            if (File.Exists(GenericPaths.SettingsPath))
            {
                return RronConvert.DeserializeObjectFromFile<SavedSettings>(GenericPaths.SettingsPath);
            }

            SavedSettings settings = new SavedSettings("Default");
            RronConvert.SerializeObjectToFile(settings, GenericPaths.SettingsPath);
            return settings;
        }

        private void Awake() => this.Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.Settings.SkinName);
    }
}