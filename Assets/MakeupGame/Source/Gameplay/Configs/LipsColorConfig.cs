using MakeupGame.Gameplay.Doll;
using System;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu(menuName = "Config/Gameplay/LipsConfig")]
    public class LipsColorConfig : ColorConfig<PomadeColor, LipsColorData> { }

    [Serializable]
    public class LipsColorData : ColorData<PomadeColor> { }
}
