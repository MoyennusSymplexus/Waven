namespace WavenCore.Classes
{
    public class Catalyseur : Xelor
    {
        #region Static Fields and Methods

        public const string ClassName = "Catalyseur";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Catalyseur);
        public override double Attack   { get; init; } = 28;
        public override double Life     { get; init; } = 392;

        #endregion
    }
}