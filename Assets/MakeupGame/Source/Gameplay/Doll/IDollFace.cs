namespace MakeupGame.Gameplay.Doll
{
    public interface IDollFace
    {
        void ApplyBlush(BlushColor color);
        void ApplyPomade(PomadeColor color);
        void ApplyEyeShadows(ShadowsColor color);
        void ApplyCream();
        void ClearMakeup();
    }
}
