namespace WavenCore.Classes
{
    public class Orok : Iop
    {
        #region Static Fields and Methods

        public const string ClassName = "Orok";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Orok);
        public override double Attack   { get; init; } = 30;
        public override double Life     { get; init; } = 401;

        #endregion
    }
}