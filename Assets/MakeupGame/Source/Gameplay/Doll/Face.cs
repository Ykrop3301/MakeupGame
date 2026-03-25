using DG.Tweening;
using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Face : MonoBehaviour, IDollFace
    {
        [SerializeField] private SpriteRenderer _acne;
        [SerializeField] private Lips _lips;

        public void ApplyBlush(BlushColor color)
        {
            Debug.Log($"Color {color} applied");
        }

        public void ApplyCream()
        {
            Color color = _acne.color;
            color.a = 0;
            _acne.DOColor(color, 0.8f);
        }

        public void ApplyPomade(PomadeColor color)
        {
            _lips.SetColor(color);
        }

        public void ClearMakeUp()
        {
            Debug.Log($"Makeup cleared");
        }
    }
}
