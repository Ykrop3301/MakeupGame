using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction.Tools
{
    public class Lipstick : BaseTool, IPointerClickHandler
    {
        private static readonly float MoveDuration = 0.5f;

        [SerializeField] private PomadeColor _color;
        [SerializeField] private Hand _hand;

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
                .Append(transform.DOMoveX(startX + 50, MoveDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX - 50, MoveDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX, MoveDuration * 0.5f)
                    .SetEase(Ease.OutSine))
                .AppendCallback(() => face.ApplyPomade(_color))
                .AppendCallback(ReturnToOrigin);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 destination = transform.position;
            destination.y += 100;

            _hand.TryTakeTool(this, () =>
            {
                _hand.StartHoldingTool();
                transform.GetComponent<RectTransform>().DOMove(destination, MoveDuration).SetEase(Ease.InOutSine);
            });
        }
    }
}
