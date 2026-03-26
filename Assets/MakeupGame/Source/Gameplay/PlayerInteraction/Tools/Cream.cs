using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class Cream : BaseTool, IPointerClickHandler
    {
        [SerializeField] private Hand _hand;
        [SerializeField] private Face _face;

        private static readonly float TiltDuration = 0.45f;
        private static readonly float MoveDuration = 0.5f;

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 destination = ((Vector2)_face.GetComponent<RectTransform>().position + (Vector2)transform.GetComponent<RectTransform>().position)/2;

            _hand.TryTakeTool(this, () =>
            {
                _hand.StartHoldingTool();
                transform.GetComponent<RectTransform>().DOMove(destination, MoveDuration);
            });
        }

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
            float startY = transform.position.y;

            DOTween.Sequence()
                .Append(transform.DOMoveY(startY - 100, TiltDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveY(startY, TiltDuration * 0.6f)
                    .SetEase(Ease.OutBack))
                .AppendCallback(() => face.ApplyCream())
                .AppendCallback(ReturnToOrigin);
        }
    }
}
