using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Face : MonoBehaviour, IDollFace
    {


        public void ApplyBlush(BlushColor color)
        {
            Debug.Log($"Color {color} applied");
        }

        public void ApplyCream()
        {
            Debug.Log($"Cream applied");
        }

        public void ApplyPomade(PomadeColor color)
        {
            Debug.Log($"Color {color} applied");
        }

        public void ClearMakeUp()
        {
            Debug.Log($"Makeup cleared");
        }
    }
}
