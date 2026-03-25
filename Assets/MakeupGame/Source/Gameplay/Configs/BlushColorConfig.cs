using MakeupGame.Gameplay.Doll;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu(menuName ="Config/Gameplay/BlushConfig")]
    public class BlushColorConfig : ScriptableObject
    {
        [field: SerializeField] public List<BlushColorData> BlushColorDatas;
    }

    [Serializable]
    public class BlushColorData
    {
        [field: SerializeField] public BlushColor BlushColor { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
