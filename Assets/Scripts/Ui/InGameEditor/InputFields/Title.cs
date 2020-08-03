using Logic.InGameEditor;
using Ui.Settings.Bases;

namespace Ui.InGameEditor.InputFields
{
    public class Title : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMapMeta.Title;
            set => EditorInitializer.BeatMapMeta.Title = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}