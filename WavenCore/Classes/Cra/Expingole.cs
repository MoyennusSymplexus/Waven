namespace WavenCore.Classes
{
    public class Expingole : Cra
    {
        #region Static Fields and Methods

        public const string ClassName = "Expingole";

        #endregion

        #region Constructors

        public Expingole() {
            Passives.Add(new Passive(PassiveConst.Native,     PassiveConst.ExpingoleDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Expingole1, PassiveConst.ExpingoleDesc1, null));
            Passives.Add(new Passive(PassiveConst.Expingole2, PassiveConst.ExpingoleDesc2, null));
            Passives.Add(new Passive(PassiveConst.Expingole3, PassiveConst.ExpingoleDesc3, null));
            Passives.Add(new Passive(PassiveConst.Expingole4, PassiveConst.ExpingoleDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Expingole);
        public override double Attack   { get; init; } = 24;
        public override double Life     { get; init; } = 385;

        #endregion
    }
}