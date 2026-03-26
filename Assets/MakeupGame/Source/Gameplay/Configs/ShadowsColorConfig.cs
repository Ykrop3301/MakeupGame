using MakeupGame.Gameplay.Doll;
using System;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu(menuName = "Config/Gameplay/ShadowsConfig")]
    public class ShadowsColorConfig : ColorConfig<ShadowsColor, ShadowsColorData> { }

    [Serializable]
    public class ShadowsColorData : ColorData<ShadowsColor> { }
}
