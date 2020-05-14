using Components.InGameEditor;

namespace Ui.Scenes.InGameEditor.InputFields
{
    public class Lives : InputFieldBase
    {
        protected override string Input
        {
            get => EditorConstructor.BeatMap.Lives == 0 ? null : EditorConstructor.BeatMap.Lives.ToString();
            set
            {
                int.TryParse(value, out int val);
                EditorConstructor.BeatMap.Lives = val;
            }
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}