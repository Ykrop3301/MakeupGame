using MakeupGame.Gameplay.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.Doll
{
    public class EyeShadows : MonoBehaviour 
    {
        [SerializeField] private Image _leftShadow;
        [SerializeField] private Image _rightShadow;
        [SerializeField] private ShadowsColorConfig _colorConfig;

        public void SetColor(ShadowsColor color)
        {
            Sprite sprite = _colorConfig.ShadowsColorDatas.Find(x => x.ShadowsColor == color).Sprite;
            if (sprite != null)
            {
                _leftShadow.sprite = _rightShadow.sprite = sprite;
                Color alpha = _leftShadow.color;
                alpha.a = 1f;
                _leftShadow.color = _rightShadow.color = alpha;
            }
        }

        public void Reset()
        {
            Color alpha = _leftShadow.color;
            alpha.a = 0f;
            _leftShadow.color = _rightShadow.color = alpha;
        }
    }
}
