using System.IO;
using Beatmaps;
using Inflex.Rron;
using Logic.InGameEditor;
using UnityEngine;

namespace Ui.InGameEditor
{
    public class SaveButton : MouseNavigationControl
    {
        private readonly         BeatMapMeta beatMapMeta = EditorInitializer.BeatMapMeta;
        [SerializeField] private GameObject  editorHolder;

        protected override void LeftClick()
        {
            string path = Path.Combine(GenericPaths.BeatMapsPath, this.beatMapMeta.Title);
            Directory.CreateDirectory(path);
            this.CopyFiles(path);
            this.RenamePaths(path);
            this.SaveNewBeatMap();
            this.editorHolder.SetActive(false);
            this.gameObject.GetComponent<EditorConstructor>().Fill(this.beatMapMeta);
        }

        private void CopyFiles(string path)
        {
            File.Copy(this.beatMapMeta.SongFile,   Path.Combine(path, Path.GetFileName(this.beatMapMeta.SongFile)));
            File.Copy(this.beatMapMeta.Background, Path.Combine(path, Path.GetFileName(this.beatMapMeta.Background)));
        }

        private void RenamePaths(string path)
        {
            this.beatMapMeta.SongFile   = Path.GetFileName(this.beatMapMeta.SongFile);
            this.beatMapMeta.Background = Path.GetFileName(this.beatMapMeta.Background);
            this.beatMapMeta.Icon       = this.beatMapMeta.Background;
            this.beatMapMeta.Path       = Path.Combine(GenericPaths.BeatMapsPath, this.beatMapMeta.Title, Path.Combine(path, "data.rron"));
        }

        private void SaveNewBeatMap() =>
            RronConvert.SerializeObjectToFile(this.beatMapMeta, this.beatMapMeta.Path, new[] {nameof(BeatMapMeta.Id), nameof(BeatMapMeta.Path)});
    }
}