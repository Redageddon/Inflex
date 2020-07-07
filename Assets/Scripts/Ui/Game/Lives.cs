using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game
{
    public class Lives : VisibleElement
    {
        [SerializeField] private Text lives;
        
        private void Update() => this.lives.text = $"Lives: {ScoreBar.Score}";
    }
}