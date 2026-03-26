using UnityEngine;
using UnityEngine.UI;

namespace MakeupGame.Gameplay.Doll
{
    /// <summary>Invisible graphic that participates in UI raycasting without rendering anything.</summary>
    public class RaycastArea : MaskableGraphic
    {
        protected override void OnPopulateMesh(VertexHelper vh) => vh.Clear();
    }
}
