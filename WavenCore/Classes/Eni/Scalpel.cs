using System;
using System.Linq;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Scalpel : Eni
    {
        #region Static Fields and Methods

        private static string ComputeNative(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.35);
            return $"Inflige {value} dégâts";
        }

        private static string ComputeFirst(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.25);
            return $"Soigne {value} HP";
        }

        private static string ComputeFourth(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalLife * 0.02);
            return $"Gagne {value} AR";
        }

        #endregion

        #region Constructors

        public Scalpel() {
            Passives.Add(new Passive(PassiveConst.Native,   PassiveConst.ScalpelDesc0, ComputeNative, true));
            Passives.Add(new Passive(PassiveConst.Scalpel1, PassiveConst.ScalpelDesc1, ComputeFirst));
            Passives.Add(new Passive(PassiveConst.Scalpel2, PassiveConst.ScalpelDesc2, ComputeNative));
            Passives.Add(new Passive(PassiveConst.Scalpel3, PassiveConst.ScalpelDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Scalpel4, PassiveConst.ScalpelDesc4, ComputeFourth));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Scalpel);
        public override double Attack   { get; init; } = 22;
        public override double Life     { get; init; } = 396;

        #endregion

        private string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.35);

            if (Passives.First(x => x.Name == PassiveConst.Scalpel2).IsActive) {
                value *= 2;
            }

            return $"Inflige {value} dégâts";
        }
    }
}