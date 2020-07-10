using Logic.InGameEditor;
using Ui.Settings.Bases;

namespace Ui.InGameEditor.InputFields
{
    public class Mapper : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMap.Mapper;
            set => EditorInitializer.BeatMap.Mapper = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}