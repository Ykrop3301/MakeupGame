using MakeupGame.Gameplay.Doll;
using MakeupGame.Gameplay.PlayerInteraction;
using MakeupGame.Gameplay.PlayerInteraction.Tools;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.Palette
{
    public class ShadowsPaletteCell : MonoBehaviour, IPaletteCell, IPointerClickHandler
    {
        [SerializeField] private ShadowsColor _color;
        [SerializeField] private ShadowsBrush _brush;
        [SerializeField] private Hand _hand;

        public Vector3 WorldPosition => transform.position;
        public BaseTool CorrespondingTool => _brush;

        public void ApplyColorToTool() => _brush.SetColor(_color);

        public void OnPointerClick(PointerEventData eventData) => _hand.OnPaletteCellClicked(this);
    }
}
