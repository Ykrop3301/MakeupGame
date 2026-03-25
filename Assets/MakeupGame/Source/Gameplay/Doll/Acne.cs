using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.Doll
{
    public class Acne : MonoBehaviour
    {
        [SerializeField] private Image _acne;
        [SerializeField] private float _removeDuration;

        public void Remove()
        {
            Color color = _acne.color;
            if (color.a > 0)
            {
                color.a = 0;
                _acne.DOColor(color, _removeDuration);
            }
        }

        public void Reset()
        {
            Color color = _acne.color;
            color.a = 1;
            _acne.color = color;
        }
    }
}
