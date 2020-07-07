using Logic.InGameEditor;

namespace Ui.InGameEditor.InputFields
{
    public class Title : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMap.Title;
            set => EditorInitializer.BeatMap.Title = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}