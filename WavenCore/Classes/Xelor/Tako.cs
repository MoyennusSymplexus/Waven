namespace WavenCore.Classes
{
    public class Tako : Xelor
    {
        #region Static Fields and Methods

        public const string ClassName = "Tako";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Tako);
        public override double Attack   { get; init; } = 24;
        public override double Life     { get; init; } = 391;

        #endregion
    }
}