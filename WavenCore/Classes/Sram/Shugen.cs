namespace WavenCore.Classes
{
    public class Shugen : Sram
    {
        #region Static Fields and Methods

        public const string ClassName = "Shugen";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Shugen);
        public override double Attack   { get; init; } = 30;
        public override double Life     { get; init; } = 397;

        #endregion
    }
}