using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class ShadowsBrush : BaseTool
    {
        private static readonly float StrokeDuration = 0.25f;

        private ShadowsColor _color;

        public void SetColor(ShadowsColor color) => _color = color;

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
                .AppendCallback(() => face.ApplyEyeShadows(_color))
                .AppendCallback(ReturnToOrigin);
        }
    }
}
