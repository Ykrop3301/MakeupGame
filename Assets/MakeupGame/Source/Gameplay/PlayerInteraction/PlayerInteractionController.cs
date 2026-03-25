using UnityEngine;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public class PlayerInteractionController : MonoBehaviour
    {
        public InteractionState InteractionState { get; set; }
    }

    public enum InteractionState
    {
        Selecting,
        Taking,
        Interacting,
        Waiting,
    }
}
