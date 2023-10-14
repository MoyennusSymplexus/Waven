using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Tamashi : Eni
    {
        #region Static Fields and Methods

        private static string ComputeFirst(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.75);
            return $"Inflige {value} dégâts";
        }

        private static string ComputeSecond(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Inflige {value} dégâts";
        }

        private static string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.AttackOnStat * 0.5);
            return $"Gagne {value} AT";
        }

        private static string ComputeFourth(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.AttackOnStat * 0.1);
            return $"Gagne {value} AT par aura";
        }

        #endregion

        #region Constructors

        public Tamashi() {
            Passives.Add(new Passive(PassiveConst.Native,   PassiveConst.TamashiDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Tamashi1, PassiveConst.TamashiDesc1, ComputeFirst));
            Passives.Add(new Passive(PassiveConst.Tamashi2, PassiveConst.TamashiDesc2, ComputeSecond));
            Passives.Add(new Passive(PassiveConst.Tamashi3, PassiveConst.TamashiDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Tamashi4, PassiveConst.TamashiDesc4, ComputeFourth));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Tamashi);
        public override double Attack   { get; init; } = 18;
        public override double Life     { get; init; } = 388;

        #endregion
    }
}