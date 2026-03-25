using MakeupGame.Gameplay.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.Doll
{
    public class Lips : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private LipsColorConfig _colorConfig;

        public void SetColor(PomadeColor color)
        {
            Sprite sprite = _colorConfig.LipsColorDatas.Find(x => x.PomadeColor == color).Sprite;
            if (sprite != null )
            {
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
