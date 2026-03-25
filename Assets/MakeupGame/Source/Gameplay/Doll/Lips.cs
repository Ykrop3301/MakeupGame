using MakeupGame.Gameplay.Configs;
using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Lips : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private LipsColorConfig _colorConfig;

        public void SetColor(PomadeColor color)
        {
            Sprite sprite = _colorConfig.LipsColorDatas.Find(x => x.PomadeColor == color).Sprite;
            if (sprite != null )
            {
                _spriteRenderer.sprite = sprite;
            }
        }
    }
}
