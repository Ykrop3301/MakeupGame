using MakeupGame.Gameplay.PlayerInteraction;
using UnityEngine;

namespace MakeupGame.Gameplay.Palette
{
    public interface IPaletteCell
    {
        /// <summary>World position of this cell. Used by Hand as the fly-to target.</summary>
        Vector3 WorldPosition { get; }

        /// <summary>The tool this cell corresponds to.</summary>
        BaseTool CorrespondingTool { get; }

        /// <summary>Applies this cell's color to the corresponding tool.</summary>
        void ApplyColorToTool();
    }
}
