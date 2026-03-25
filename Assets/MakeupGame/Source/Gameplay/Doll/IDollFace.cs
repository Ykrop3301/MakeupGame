namespace MakeupGame.Gameplay.Doll
{
    interface IDollFace
    {
        void ApplyBlush(BlushColor color);
        void ApplyPomade(PomadeColor color);
        void ApplyCream();
        void ClearMakeUp();
    }
}
