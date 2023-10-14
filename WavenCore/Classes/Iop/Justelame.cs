namespace WavenCore.Classes
{
    public class Justelame : Iop
    {
        #region Static Fields and Methods

        public const string ClassName = "Justelame";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Justelame);
        public override double Attack   { get; init; } = 32;
        public override double Life     { get; init; } = 387;

        #endregion
    }
}