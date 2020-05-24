using UnityEngine;

namespace Ui.Game
{
    public class Center : VisibleElement
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        public CircleCollider2D CircleCollider2D => this.circleCollider2D;
        
    }
}