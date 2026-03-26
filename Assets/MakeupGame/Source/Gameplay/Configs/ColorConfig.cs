using System;
using System.Collections.Generic;
using UnityEngine;

namespace MakeupGame.Gameplay.Configs
{
    public abstract class ColorConfig<TEnum, TData> : ScriptableObject
        where TEnum : Enum
        where TData : ColorData<TEnum>
    {
        [field: SerializeField] public List<TData> Entries { get; private set; }

        private Dictionary<TEnum, Sprite> _cache;

        private void OnEnable() => BuildCache();

        private void BuildCache()
        {
            _cache = new Dictionary<TEnum, Sprite>();
            if (Entries == null) return;

            foreach (var entry in Entries)
                _cache[entry.Color] = entry.Sprite;
        }

        /// <summary>Returns the sprite for the given color key. Returns false if not found.</summary>
        public bool TryGetSprite(TEnum color, out Sprite sprite)
            => _cache.TryGetValue(color, out sprite);
    }
}
