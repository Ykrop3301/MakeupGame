using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class BlushBrush : BaseTool
    {
        private static readonly float StrokeDuration = 0.25f;

        private BlushColor _color;

        public void SetColor(BlushColor color) => _color = color;

        protected override void HandleEndDrag(PointerEventData eventData)
        {
            if (!TryGetFace(eventData, out IDollFace face))
            {
                ReturnToOrigin();
                return;
            }

            FlyToAnchorAndPlay(() => PlayApplyAnimation(face));
        }

        private void PlayApplyAnimation(IDollFace face)
        {
            float startX = transform.position.x;

            DOTween.Sequence()
                .Append(transform.DOMoveX(startX + 100, StrokeDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX - 100, StrokeDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX, StrokeDuration * 0.5f)
                    .SetEase(Ease.OutSine))
                .AppendCallback(() => face.ApplyBlush(_color))
                .AppendCallback(ReturnToOrigin);
        }
    }
}
