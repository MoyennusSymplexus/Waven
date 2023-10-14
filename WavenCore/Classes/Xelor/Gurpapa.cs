namespace WavenCore.Classes
{
    public class Gurpapa : Xelor
    {
        #region Static Fields and Methods

        public const string ClassName = "Gurpapa";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Gurpapa);
        public override double Attack   { get; init; } = 26;
        public override double Life     { get; init; } = 389;

        #endregion
    }
}