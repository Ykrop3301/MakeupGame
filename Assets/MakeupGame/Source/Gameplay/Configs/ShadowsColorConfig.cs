using MakeupGame.Gameplay.Doll;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu(menuName = "Config/Gameplay/ShadowsConfig")]
    public class ShadowsColorConfig : ScriptableObject
    {
        [field: SerializeField] public List<ShadowsColorData> ShadowsColorDatas;
    }

    [Serializable]
    public class ShadowsColorData
    {
        [field: SerializeField] public ShadowsColor ShadowsColor { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
