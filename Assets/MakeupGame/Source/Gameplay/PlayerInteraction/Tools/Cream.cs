using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class Cream : BaseTool
    {
        private static readonly float TiltAngle = 25f;
        private static readonly float TiltDuration = 0.45f;

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

            Sequence sequence = DOTween.Sequence();

            sequence.Append(
                transform.DORotate(new Vector3(0f, 0f, startZ - TiltAngle), TiltDuration)
                    .SetEase(Ease.InOutSine)
            );
            sequence.Append(
                transform.DORotate(new Vector3(0f, 0f, startZ), TiltDuration * 0.6f)
                    .SetEase(Ease.OutBack)
            );
            sequence.AppendCallback(() => { face.ApplyCream(); ReturnToOrigin(); });
        }
    }
}
