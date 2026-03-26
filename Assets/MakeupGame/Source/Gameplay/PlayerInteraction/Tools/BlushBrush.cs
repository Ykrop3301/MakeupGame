using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class BlushBrush : BaseTool
    {
        private static readonly float StrokeAngle = 15f;
        private static readonly float StrokeDuration = 0.25f;

        private BlushColor _color;

        /// <summary>Sets the color this brush will apply on the next use.</summary>
        public void SetColor(BlushColor color) => _color = color;

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (!TryGetFace(eventData, out IDollFace face))
            {
                ReturnToOrigin();
                return;
            }

            PlayApplyAnimation(face);
        }

        private void PlayApplyAnimation(IDollFace face)
        {
            float startZ = transform.eulerAngles.z;

            DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0f, 0f, startZ + StrokeAngle), StrokeDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DORotate(new Vector3(0f, 0f, startZ - StrokeAngle), StrokeDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DORotate(new Vector3(0f, 0f, startZ), StrokeDuration * 0.5f)
                    .SetEase(Ease.OutSine))
                .AppendCallback(() => { face.ApplyBlush(_color); ReturnToOrigin(); });
        }
    }
}
