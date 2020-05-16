using Logic.InGameEditor;

namespace Ui.Scenes.InGameEditor.InputFields
{
    public class Artist : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMap.Artist;
            set => EditorInitializer.BeatMap.Artist = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}