using Components.InGameEditor;

namespace Ui.Scenes.InGameEditor.InputFields
{
    public class Title : InputFieldBase
    {
        protected override string Input
        {
            get => EditorConstructor.BeatMap.Title;
            set => EditorConstructor.BeatMap.Title = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}