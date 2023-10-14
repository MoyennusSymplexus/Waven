using System;
using System.Linq;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Piven : Cra
    {
        #region Static Fields and Methods

        private static string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.3);
            return $"Gagne {value} AT par MIRE";
        }

        private static string ComputeNative(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Inflige {value} dégâts";
        }

        #endregion

        #region Constructors

        public Piven() {
            Passives.Add(new Passive(PassiveConst.Native, PassiveConst.PivenDesc0, ComputeNative, true));
            Passives.Add(new Passive(PassiveConst.Piven1, PassiveConst.PivenDesc1, ComputeNative));
            Passives.Add(new Passive(PassiveConst.Piven2, PassiveConst.PivenDesc2, ComputeSecond));
            Passives.Add(new Passive(PassiveConst.Piven3, PassiveConst.PivenDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Piven4, PassiveConst.PivenDesc4, ComputeSecond));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Piven);
        public override double Attack   { get; init; } = 20;
        public override double Life     { get; init; } = 385;

        #endregion

        private string ComputeSecond(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);

            if (Passives.First(x => x.Name == PassiveConst.Piven1).IsActive) {
                value *= 2;
            }

            return $"Inflige {value} dégâts";
        }
    }
}