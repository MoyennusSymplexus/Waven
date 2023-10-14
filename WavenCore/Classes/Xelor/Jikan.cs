namespace WavenCore.Classes
{
    public class Jikan : Xelor
    {
        #region Static Fields and Methods

        public const string ClassName = "Jikan";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Jikan);
        public override double Attack   { get; init; } = 28;
        public override double Life     { get; init; } = 392;

        #endregion
    }
}