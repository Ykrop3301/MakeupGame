using System.Collections.Generic;
using DG.Tweening;
using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public abstract class BaseTool : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private static readonly float ReturnDuration = 0.3f;

        private RectTransform _rectTransform;
        private RectTransform _canvasRectTransform;
        private GraphicRaycaster _graphicRaycaster;
        private Vector2 _offset;
        private Vector2 _originPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                _canvasRectTransform = canvas.GetComponent<RectTransform>();
                _graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
            }

            OnToolAwake();
        }

        /// <summary>Override to run initialization logic in subclasses instead of Awake.</summary>
        protected virtual void OnToolAwake() { }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_canvasRectTransform == null) return;

            _originPosition = _rectTransform.anchoredPosition;
            _offset = _rectTransform.anchoredPosition - GetMouseLocalPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_canvasRectTransform == null) return;

            _rectTransform.anchoredPosition = GetMouseLocalPosition(eventData) + _offset;
        }

        public abstract void OnEndDrag(PointerEventData eventData);

        /// <summary>Raycasts at drop position and returns the first IDollFace found, or null.</summary>
        protected bool TryGetFace(PointerEventData eventData, out IDollFace face)
        {
            face = null;
            if (_graphicRaycaster == null) return false;

            var results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(eventData, results);

            foreach (var result in results)
            {
                face = result.gameObject.GetComponent<IDollFace>();
                if (face != null) return true;
            }

            return false;
        }

        /// <summary>Smoothly moves the tool back to its position before dragging started.</summary>
        protected void ReturnToOrigin()
        {
            _rectTransform.DOAnchorPos(_originPosition, ReturnDuration)
                .SetEase(Ease.OutCubic);
        }

        private Vector2 GetMouseLocalPosition(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvasRectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint
            );
            return localPoint;
        }
    }
}
