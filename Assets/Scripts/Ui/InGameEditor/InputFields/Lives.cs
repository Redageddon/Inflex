using Logic.InGameEditor;

namespace Ui.InGameEditor.InputFields
{
    public class Lives : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMap.Lives == 0 ? null : EditorInitializer.BeatMap.Lives.ToString();
            set
            {
                int.TryParse(value, out int val);
                EditorInitializer.BeatMap.Lives = val;
            }
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}