using System;
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
        private static readonly float FlyDuration = 0.4f;

        [SerializeField] private RectTransform _anchorPoint;

        private RectTransform _rectTransform;
        private RectTransform _canvasRectTransform;
        private GraphicRaycaster _graphicRaycaster;
        private Vector2 _offset;
        private Vector3 _originWorldPosition;
        private bool _isDragging;

        public Vector3 HomeWorldPosition { get; private set; }

        public RectTransform RectTransform => _rectTransform;

        public bool IsLocked { get; set; }

        public event Action OnToolReturned;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            HomeWorldPosition = _rectTransform.position;
            _originWorldPosition = _rectTransform.position;
            IsLocked = true;

            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                _canvasRectTransform = canvas.GetComponent<RectTransform>();
                _graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
            }

            OnToolAwake();
        }

        protected virtual void OnToolAwake() {  }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (IsLocked || _canvasRectTransform == null) return;

            _isDragging = true;
            _offset = _rectTransform.anchoredPosition - GetMouseLocalPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDragging || _canvasRectTransform == null) return;

            _rectTransform.anchoredPosition = GetMouseLocalPosition(eventData) + _offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_isDragging) return;
            _isDragging = false;
            IsLocked = true;
            HandleEndDrag(eventData);
        }

        protected abstract void HandleEndDrag(PointerEventData eventData);

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

        protected void FlyToAnchorAndPlay(Action onArrived)
        {
            if (_anchorPoint == null)
            {
                onArrived?.Invoke();
                return;
            }

            _rectTransform.DOMove(_anchorPoint.position, FlyDuration)
                .SetEase(Ease.InOutQuad)
                .OnComplete(() => onArrived?.Invoke());
        }

        protected void ReturnToOrigin()
        {
            _rectTransform.DOMove(_originWorldPosition, ReturnDuration)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => OnToolReturned?.Invoke());
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

        public void KeepOriginPosition()
        {
            _originWorldPosition = _rectTransform.position;
            HomeWorldPosition = _originWorldPosition;
        }
    }
}
