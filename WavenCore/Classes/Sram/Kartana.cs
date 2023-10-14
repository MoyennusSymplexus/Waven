namespace WavenCore.Classes
{
    public class Kartana : Sram
    {
        #region Static Fields and Methods

        public const string ClassName = "Kartana";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Kartana);
        public override double Attack   { get; init; } = 22;
        public override double Life     { get; init; } = 392;

        #endregion
    }
}