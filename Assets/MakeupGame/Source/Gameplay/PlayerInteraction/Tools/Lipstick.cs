using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class Lipstick : BaseTool
    {
        private static readonly float TiltAngle = 20f;
        private static readonly float TiltDuration = 0.35f;

        [SerializeField] private PomadeColor _color;

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
                .Append(transform.DORotate(new Vector3(0f, 0f, startZ - TiltAngle), TiltDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DORotate(new Vector3(0f, 0f, startZ), TiltDuration * 0.6f)
                    .SetEase(Ease.OutBack))
                .AppendCallback(() => { face.ApplyPomade(_color); ReturnToOrigin(); });
        }
    }
}
