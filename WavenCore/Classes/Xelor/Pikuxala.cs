namespace WavenCore.Classes
{
    public class Pikuxala : Xelor
    {
        #region Static Fields and Methods

        public const string ClassName = "Pikuxala";

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Pikuxala);
        public override double Attack   { get; init; } = 28;
        public override double Life     { get; init; } = 394;

        #endregion
    }
}