using MakeupGame.Gameplay.Doll;
using System;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu(menuName = "Config/Gameplay/BlushConfig")]
    public class BlushColorConfig : ColorConfig<BlushColor, BlushColorData> { }

    [Serializable]
    public class BlushColorData : ColorData<BlushColor> { }
}
