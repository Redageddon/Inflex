using SceneLessLogic.Bases;
using Scenes.InGameEditor.Logic;

namespace Scenes.InGameEditor.Ui.InputFields
{
    public class Lives : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMapMeta.Lives == 0 
                ? null 
                : EditorInitializer.BeatMapMeta.Lives.ToString();
            set
            {
                int.TryParse(value, out int val);
                EditorInitializer.BeatMapMeta.Lives = val;
            }
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}