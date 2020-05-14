using Components.InGameEditor;

namespace Ui.Scenes.InGameEditor.InputFields
{
    public class Mapper : InputFieldBase
    {
        protected override string Input
        {
            get => EditorConstructor.BeatMap.Mapper;
            set => EditorConstructor.BeatMap.Mapper = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}