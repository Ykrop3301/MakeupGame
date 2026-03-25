using UnityEngine;

namespace MakeupGame.Gameplay.Doll
{
    public class Face : MonoBehaviour, IDollFace
    {
        [SerializeField] private Acne _acne;
        [SerializeField] private Lips _lips;
        [SerializeField] private EyeShadows _shadows;
        [SerializeField] private Blush _blush;

        public void ApplyBlush(BlushColor color)
        {
            _blush.SetColor(color);
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

        public void ClearMakeup()
        {
            _acne.Reset();
            _lips.Reset();
            _blush.Reset();
            _shadows.Reset();
        }
    }
}
