namespace WavenCore.Classes
{
    public class Surin : Sram
    {
        #region Static Fields and Methods

        public const string ClassName = "Surin";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Surin);
        public override double Attack   { get; init; } = 28;
        public override double Life     { get; init; } = 398;

        #endregion
    }
}