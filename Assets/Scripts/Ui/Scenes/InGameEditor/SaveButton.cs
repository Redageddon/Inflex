using System.IO;
using BeatMaps;
using Components.InGameEditor;
using Inflex.Rron;

namespace Ui.Scenes.InGameEditor
{
    public class SaveButton : ButtonBase
    {
        protected override void Left()
        {
            BeatMap beatMap = EditorConstructor.BeatMap;
            string path = Path.Combine(GenericPaths.BeatMapsPath, beatMap.Title);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            File.Copy(beatMap.SongFile, Path.Combine(path, Path.GetFileName(beatMap.SongFile)));
            File.Copy(beatMap.Background, Path.Combine(path, Path.GetFileName(beatMap.Background)));
            
            beatMap.SongFile = Path.GetFileName(beatMap.SongFile);
            beatMap.Background = Path.GetFileName(beatMap.Background);
            beatMap.Icon = beatMap.Background;

            RronConvert.SerializeObjectToFile(beatMap,
                                              Path.Combine(GenericPaths.BeatMapsPath, beatMap.Title, 
                                                           Path.Combine(path, "data.rron")), new[] {nameof(BeatMap.Id), nameof(BeatMap.Path)});
        }
    }
}