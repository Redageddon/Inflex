using Logic.InGameEditor;
using Ui.Settings.Bases;

namespace Ui.InGameEditor.InputFields
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