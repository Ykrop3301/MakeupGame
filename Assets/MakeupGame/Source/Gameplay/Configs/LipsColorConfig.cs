using MakeupGame.Gameplay.Doll;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [CreateAssetMenu]
    public class LipsColorConfig : ScriptableObject
    {
        [field: SerializeField] public List<LipsColorData> LipsColorDatas;
    }

    [Serializable]
    public class LipsColorData
    {
        [field: SerializeField] public PomadeColor PomadeColor { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
