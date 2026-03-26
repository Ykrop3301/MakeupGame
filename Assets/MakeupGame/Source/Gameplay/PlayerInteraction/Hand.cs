using DG.Tweening;
using MakeupGame.Gameplay.Palette;
using System;
using UnityEngine;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public class Hand : MonoBehaviour
    {
        private enum HandState
        {
            Idle,
            FlyingToTool,
            FlyingToPalette,
            ApplyingColor,
            HoldingTool,      
            ReturningTool,
            ReturningHome,
        }

        private static readonly float FlyDuration = 0.5f;
        private static readonly float ApplyAnimDuration = 0.3f;

        [SerializeField] private Vector2 _holdingOffset;

        private RectTransform _rectTransform;
        private Vector3 _homeWorldPosition;

        private HandState _state = HandState.Idle;
        private IPaletteCell _currentCell;
        private BaseTool _currentTool;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _homeWorldPosition = transform.position;
        }

        private void Update()
        {
            if (_state == HandState.HoldingTool && _currentTool != null)
                _rectTransform.position = _currentTool.RectTransform.position + (Vector3)_holdingOffset;
        }

        public void OnPaletteCellClicked(IPaletteCell cell)
        {
            if (_state != HandState.Idle) return;

            if (TryTakeTool(cell.CorrespondingTool, FlyToPalette))
            {
                _currentCell = cell;
            }
        }

        public bool TryTakeTool(BaseTool tool, Action onFlyComplete)
        {
            if (_state != HandState.Idle) return false;

            _currentTool = tool;
            _currentTool.IsLocked = true;
            FlyToTool(onFlyComplete);
            return true;
        }

        private void FlyToTool(Action onComplete)
        {
            _state = HandState.FlyingToTool;
            _homeWorldPosition = _rectTransform.position;
            Vector3 holdTarget = _currentTool.RectTransform.position + (Vector3)_holdingOffset;

            _rectTransform.DOMove(holdTarget, FlyDuration)
                .SetEase(Ease.InOutSine)
                .OnComplete(() => 
                {
                    _currentTool.KeepOriginPosition();
                    onComplete();
                });
        }

        private void FlyToPalette()
        {
            _state = HandState.FlyingToPalette;

            Vector3 palettePos = _currentCell.WorldPosition + (new Vector3(0, -150));

            _currentTool.RectTransform.DOMove(palettePos, FlyDuration).SetEase(Ease.InOutQuad);

            _rectTransform.DOMove(palettePos + (Vector3)_holdingOffset, FlyDuration)
                .SetEase(Ease.InOutQuad)
                .OnComplete(PlayApplyColorAnimation);
        }

        private void PlayApplyColorAnimation()
        {
            _state = HandState.ApplyingColor;

            var rectTransform = _currentTool.RectTransform;
            float startX = transform.position.x;
            var previousParent = rectTransform.parent;
            _currentTool.transform.SetParent(transform);
            DOTween.Sequence()
                .Append(transform.DOMoveX(startX + 100, ApplyAnimDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX - 100, ApplyAnimDuration)
                    .SetEase(Ease.InOutSine))
                .Append(transform.DOMoveX(startX, ApplyAnimDuration * 0.5f)
                    .SetEase(Ease.OutSine))
                .AppendCallback(() =>
                {
                    _currentCell.ApplyColorToTool();
                    _currentTool.transform.SetParent(previousParent);
                    StartHoldingTool();
                });
        }

        public void StartHoldingTool()
        {
            _state = HandState.HoldingTool;
            _currentTool.IsLocked = false;
            _currentTool.OnToolReturned += OnToolReturnedByPlayer;
        }

        private void OnToolReturnedByPlayer()
        {
            _currentTool.OnToolReturned -= OnToolReturnedByPlayer;
            ReturnTool();
        }

        private void ReturnTool()
        {
            _state = HandState.ReturningTool;

            _currentTool.RectTransform.DOKill();

            Vector3 toolHome = _currentTool.HomeWorldPosition;

            DOTween.Sequence()
                .Append(_currentTool.RectTransform.DOMove(toolHome, FlyDuration).SetEase(Ease.InOutQuad))
                .Join(_rectTransform.DOMove(toolHome + (Vector3)_holdingOffset, FlyDuration).SetEase(Ease.InOutQuad))
                .OnComplete(() => { ReturnHome();  });
        }

        private void ReturnHome()
        {
            _state = HandState.ReturningHome;

            _rectTransform.DOMove(_homeWorldPosition, FlyDuration * 0.7f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() =>
                {
                    _state = HandState.Idle;
                    _currentTool = null;
                    _currentCell = null;
                });
        }
    }
}
