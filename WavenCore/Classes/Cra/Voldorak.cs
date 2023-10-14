namespace WavenCore.Classes
{
    public class Voldorak : Cra
    {
        #region Static Fields and Methods

        public const string ClassName = "Voldorak";

        #endregion

        #region Constructors

        public Voldorak() {
            Passives.Add(new Passive(PassiveConst.Native,    PassiveConst.VoldorakDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Voldorak1, PassiveConst.VoldorakDesc1, null));
            Passives.Add(new Passive(PassiveConst.Voldorak2, PassiveConst.VoldorakDesc2, null));
            Passives.Add(new Passive(PassiveConst.Voldorak3, PassiveConst.VoldorakDesc3, null));
            Passives.Add(new Passive(PassiveConst.Voldorak4, PassiveConst.VoldorakDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Voldorak);
        public override double Attack   { get; init; } = 22;
        public override double Life     { get; init; } = 380;

        #endregion
    }
}