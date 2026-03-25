using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public abstract class BaseTool : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _rectTransform;
        private RectTransform _canvasRectTransform;
        private Vector3 _offset;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                _canvasRectTransform = canvas.GetComponent<RectTransform>();
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_canvasRectTransform == null) return;

            Vector2 mouseLocalPos = GetMouseLocalPosition(eventData);

            _offset = _rectTransform.anchoredPosition - mouseLocalPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_canvasRectTransform == null) return;

            Vector3 mouseLocalPos = GetMouseLocalPosition(eventData);

            _rectTransform.anchoredPosition = mouseLocalPos + _offset;
        }

        private Vector3 GetMouseLocalPosition(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvasRectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint
            );
            return localPoint;
        }

        public abstract void OnEndDrag(PointerEventData eventData);
    }
}
