using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Bunelame : Cra
    {
        #region Static Fields and Methods

        private static string ComputeSecond(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.2);
            return $"Gagne {value} AT par sort";
        }

        #endregion

        #region Constructors

        public Bunelame() {
            Passives.Add(new Passive(PassiveConst.Native,    PassiveConst.BunelameDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Bunelame1, PassiveConst.BunelameDesc1, null));
            Passives.Add(new Passive(PassiveConst.Bunelame2, PassiveConst.BunelameDesc2, ComputeSecond));
            Passives.Add(new Passive(PassiveConst.Bunelame3, PassiveConst.BunelameDesc3, ComputeSecond));
            Passives.Add(new Passive(PassiveConst.Bunelame4, PassiveConst.BunelameDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Bunelame);
        public override double Attack   { get; init; } = 20;
        public override double Life     { get; init; } = 392;

        #endregion

        //public Class() {
        //    Passives.Add(new Passive(PassiveConst.Native, PassiveConst.ClassDesc0, null, true));
        //    Passives.Add(new Passive(PassiveConst.Class1, PassiveConst.ClassDesc1, null));
        //    Passives.Add(new Passive(PassiveConst.Class2, PassiveConst.ClassDesc2, null));
        //    Passives.Add(new Passive(PassiveConst.Class3, PassiveConst.ClassDesc3, ComputeThird));
        //    Passives.Add(new Passive(PassiveConst.Class4, PassiveConst.ClassDesc4, null));
        //}

        //private static string ComputeThird(CharacterStatSummary summary) {
        //    double value = Math.Round(summary.TotalAttack * 0.5);
        //    return $"Soigne {value} HP par adversaire";
        //}
    }
}