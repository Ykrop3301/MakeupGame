using System;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    [Serializable]
    public abstract class ColorData<TEnum> where TEnum : Enum
    {
        [field: SerializeField] public TEnum Color { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
