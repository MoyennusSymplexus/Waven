namespace WavenCore.Classes
{
    public class Spectral : Iop
    {
        #region Static Fields and Methods

        public const string ClassName = "Spectral";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Spectral);
        public override double Attack   { get; init; } = 26;
        public override double Life     { get; init; } = 396;

        #endregion
    }
}