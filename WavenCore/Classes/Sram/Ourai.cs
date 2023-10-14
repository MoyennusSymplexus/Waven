namespace WavenCore.Classes
{
    public class Ourai : Sram
    {
        #region Static Fields and Methods

        public const string ClassName = "Ourai";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Ourai);
        public override double Attack   { get; init; } = 24;
        public override double Life     { get; init; } = 374;

        #endregion
    }
}