using MakeupGame.Gameplay.Doll;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public class Sponge : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Face _face;

        public void OnPointerClick(PointerEventData eventData)
            => _face.ClearMakeup();
    }
}
