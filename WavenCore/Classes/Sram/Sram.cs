namespace WavenCore.Classes
{
    public abstract class Sram : Character
    {
        #region Properties

        public override string Class { get; init; } = nameof(Sram);

        #endregion
    }
}