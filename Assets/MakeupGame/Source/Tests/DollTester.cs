using MakeupGame.Gameplay.Doll;
using MakeupGame.Gameplay.PlayerInteraction.Tools;
using UnityEngine;

namespace MakeupGame.Tests
{
    public class DollTester : MonoBehaviour
    {
        [Header("Face")]
        [SerializeField] private Face _dollFace;

        [Header("Tools")]
        [SerializeField] private ShadowsBrush _shadowsBrush;
        [SerializeField] private BlushBrush _blushBrush;

        [Header("Test Colors")]
        [SerializeField] private PomadeColor _pomadeColor;
        [SerializeField] private ShadowsColor _eyeShadowsColor;
        [SerializeField] private BlushColor _blushColor;

        private IDollFace _face;

        private void Awake()
        {
            _face = _dollFace;
        }

        /// <summary>Passes the selected test color to the shadows brush.</summary>
        public void SetShadowsBrushColor()
            => _shadowsBrush.SetColor(_eyeShadowsColor);

        /// <summary>Passes the selected test color to the blush brush.</summary>
        public void SetBlushBrushColor()
            => _blushBrush.SetColor(_blushColor);

        public void ApplyShadows()
            => _face.ApplyEyeShadows(_eyeShadowsColor);

        public void ApplyBlush()
            => _face.ApplyBlush(_blushColor);

        public void ApplyCream()
            => _face.ApplyCream();

        public void ApplyPomade()
            => _face.ApplyPomade(_pomadeColor);

        public void ClearMakeUp()
            => _face.ClearMakeup();
    }
}
