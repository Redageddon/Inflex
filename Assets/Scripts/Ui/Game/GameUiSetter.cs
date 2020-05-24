using Components;
using Logic.Loaders;
using Ui.Game;
using UnityEngine;

namespace Ui.Scenes.Game
{
    public class GameUiSetter : MonoBehaviour
    {
        [SerializeField] private Background background;
        [SerializeField] private Center center;
        [SerializeField] private CurrentKey currentKey;
        [SerializeField] private HitObject hitObject;
        [SerializeField] private Pointer pointer;

        private void Awake()
        {
            this.SetBackground();
            this.SetCenter();
            this.SetCurrentKey();
            this.SetHitObject();
            this.SetPointer();
        }

        private void SetBackground() =>
            this.background.SetNewTexture(FileLoader.LoadTexture2D($"{Assets.Instance.BeatMap.Path}/{Assets.Instance.BeatMap.Background}"));

        private void SetCenter() =>
            this.center.SetSize(new Vector2(Assets.Instance.Settings.ElementsSize * 4.2f, Assets.Instance.Settings.ElementsSize * 4.2f));

        private void SetCurrentKey() =>
            this.currentKey.SetSize(new Vector2(-this.currentKey.Sprites[0].rect.xMax, -this.currentKey.Sprites[0].rect.yMax));

        private void SetHitObject() =>
            this.hitObject.SetSize(new Vector2(Assets.Instance.Settings.ElementsSize * 2, Assets.Instance.Settings.ElementsSize * 2));

        private void SetPointer()
        {
            float centerSize = Assets.Instance.Settings.ElementsSize;
            this.pointer.SetSize(new Vector2(centerSize * 5.6f, centerSize * 5.6f));
            this.pointer.EdgeCollider2D.points = new[]
            {
                new Vector2(centerSize * -0.37f, centerSize * 2.27f),
                new Vector2(0, centerSize * 2.8f),
                new Vector2(centerSize * 0.37f, centerSize * 2.27f)
            };
        }
    }
}