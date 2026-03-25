using MakeupGame.Gameplay.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.Doll
{
    public class Blush : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private BlushColorConfig _colorConfig;

        public void SetColor(BlushColor color)
        {
            Sprite sprite = _colorConfig.BlushColorDatas.Find(x => x.BlushColor == color).Sprite;
            if (sprite != null)
            {
                _image.sprite = sprite;
                Color alpha = _image.color;
                alpha.a = 1f;
                _image.color = alpha;
            }
        }

        public void Reset()
        {
            Color alpha = _image.color;
            alpha.a = 0f;
            _image.color = alpha;
        }
    }
}
