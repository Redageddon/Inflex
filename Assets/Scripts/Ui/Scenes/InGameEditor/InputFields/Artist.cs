using Components.InGameEditor;

namespace Ui.Scenes.InGameEditor.InputFields
{
    public class Artist : InputFieldBase
    {
        protected override string Input
        {
            get => EditorConstructor.BeatMap.Artist;
            set => EditorConstructor.BeatMap.Artist = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}