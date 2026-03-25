using MakeupGame.Gameplay.Configs;
using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Blush : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BlushColorConfig _colorConfig;

        public void SetColor(BlushColor color)
        {
            Sprite sprite = _colorConfig.BlushColorDatas.Find(x => x.BlushColor == color).Sprite;
            if (sprite != null)
            {
                _spriteRenderer.sprite = sprite;
            }
        }

        public void Reset()
        {
            _spriteRenderer.sprite = null;
        }
    }
}
