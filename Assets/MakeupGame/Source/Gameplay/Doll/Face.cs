using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Face : MonoBehaviour, IDollFace
    {
        [SerializeField] private Acne _acne;
        [SerializeField] private Lips _lips;
        [SerializeField] private EyeShadows _shadows;

        public void ApplyBlush(BlushColor color)
        {
            Debug.Log($"Color {color} applied");
        }

        public void ApplyCream()
        {
            _acne.Remove();   
        }

        public void ApplyEyeShadows(ShadowsColor color)
        {
            _shadows.SetColor(color);
        }

        public void ApplyPomade(PomadeColor color)
        {
            _lips.SetColor(color);
        }

        public void ClearMakeUp()
        {
            Debug.Log($"Makeup cleared");
        }
    }
}
