using SceneLessLogic.Bases;
using Scenes.InGameEditor.Logic;

namespace Scenes.InGameEditor.Ui.InputFields
{
    public class Artist : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMapMeta.Artist;
            set => EditorInitializer.BeatMapMeta.Artist = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}