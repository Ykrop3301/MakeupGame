using MakeupGame.Gameplay.Doll;
using UnityEngine;

namespace MakeupGame.Tests
{
    public class DollTester : MonoBehaviour
    {
        [SerializeField] private Face _dollFace;
        [SerializeField] private PomadeColor _pomadeColor;
        private IDollFace _face;

        private void Awake()
        {
            _face = _dollFace;
        }

        public void ApplyBlush()
            => _face.ApplyBlush(BlushColor.Red);

        public void ApplyCream()
            => _face.ApplyCream();

        public void ApplyPomade()
            => _face.ApplyPomade(_pomadeColor);

        public void ClearMakeUp()
            => _face.ClearMakeUp();
    }
}
