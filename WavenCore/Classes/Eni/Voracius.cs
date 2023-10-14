using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Voracius : Eni
    {
        #region Static Fields and Methods

        public const string ClassName = "Voracius";

        private static string ComputeNative(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Gain de {value} HP à chaque attaque";
        }

        private static string ComputeFirst(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Inflige {value} dégâts";
        }

        private static string ComputeFourth(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.AttackOnStat * 0.2);
            return $"Gain de {value} AT par stack (approx.)";
        }

        #endregion

        #region Constructors

        public Voracius() {
            Passives.Add(new Passive(PassiveConst.Native,    PassiveConst.VoraciusDesc0, ComputeNative, true));
            Passives.Add(new Passive(PassiveConst.Voracius1, PassiveConst.VoraciusDesc1, ComputeFirst));
            Passives.Add(new Passive(PassiveConst.Voracius2, PassiveConst.VoraciusDesc2, null));
            Passives.Add(new Passive(PassiveConst.Voracius3, PassiveConst.VoraciusDesc3, null));
            Passives.Add(new Passive(PassiveConst.Voracius4, PassiveConst.VoraciusDesc4, ComputeFourth));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Voracius);
        public override double Attack   { get; init; } = 22;
        public override double Life     { get; init; } = 380;

        #endregion
    }
}