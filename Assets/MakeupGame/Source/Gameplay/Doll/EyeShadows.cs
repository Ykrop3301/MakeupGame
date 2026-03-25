using MakeupGame.Gameplay.Configs;
using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class EyeShadows : MonoBehaviour 
    {
        [SerializeField] private SpriteRenderer _leftShadow;
        [SerializeField] private SpriteRenderer _rightShadow;
        [SerializeField] private ShadowsColorConfig _colorConfig;

        public void SetColor(ShadowsColor color)
        {
            Sprite sprite = _colorConfig.ShadowsColorDatas.Find(x => x.ShadowsColor == color).Sprite;
            if (sprite != null)
            {
                _leftShadow.sprite = _rightShadow.sprite = sprite;
            }
        }

        public void Reset()
        {
            _leftShadow.sprite = _rightShadow.sprite = null;
        }
    }
}
