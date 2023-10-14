namespace WavenCore.Classes
{
    public class Kasai : Iop
    {
        #region Static Fields and Methods

        public const string ClassName = "Kasai";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Kasai);
        public override double Attack   { get; init; } = 32;
        public override double Life     { get; init; } = 399;

        #endregion
    }
}