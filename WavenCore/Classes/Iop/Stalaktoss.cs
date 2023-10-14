namespace WavenCore.Classes
{
    public class Stalaktoss : Iop
    {
        #region Static Fields and Methods

        public const string ClassName = "Stalaktoss";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Stalaktoss);
        public override double Attack   { get; init; } = 32;
        public override double Life     { get; init; } = 401;

        #endregion
    }
}