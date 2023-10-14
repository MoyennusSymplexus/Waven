namespace WavenCore.Classes
{
    public class Orishi : Sram
    {
        #region Static Fields and Methods

        public const string ClassName = "Orishi";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Orishi);
        public override double Attack   { get; init; } = 24;
        public override double Life     { get; init; } = 398;

        #endregion
    }
}