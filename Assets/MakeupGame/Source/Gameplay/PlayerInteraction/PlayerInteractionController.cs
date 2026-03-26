using System;
using UnityEngine;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public class PlayerInteractionController : MonoBehaviour
    {
        public InteractionState CurrentState { get; private set; } = InteractionState.Waiting;

        public event Action<InteractionState> OnStateChanged;

        /// <summary>Transitions to the given state and notifies subscribers.</summary>
        public void SetState(InteractionState newState)
        {
            if (CurrentState == newState) return;
            CurrentState = newState;
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}
