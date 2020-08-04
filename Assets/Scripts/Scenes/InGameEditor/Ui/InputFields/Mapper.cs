using SceneLessLogic.Bases;
using Scenes.InGameEditor.Logic;

namespace Scenes.InGameEditor.Ui.InputFields
{
    public class Mapper : InputFieldBase
    {
        protected override string Input
        {
            get => EditorInitializer.BeatMapMeta.Mapper;
            set => EditorInitializer.BeatMapMeta.Mapper = value;
        }

        protected override void OnInputChange(string input) => this.Input = input;
    }
}