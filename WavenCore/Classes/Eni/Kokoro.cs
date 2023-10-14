using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Kokoro : Eni
    {
        #region Static Fields and Methods

        private static string ComputeNative(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Gagne {value} AR";
        }

        private static string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.2);
            return $"Gagne {value} AR";
        }

        #endregion

        #region Constructors

        public Kokoro() {
            Passives.Add(new Passive(PassiveConst.Native,  PassiveConst.KokoroDesc0, ComputeNative, true));
            Passives.Add(new Passive(PassiveConst.Kokoro1, PassiveConst.KokoroDesc1, ComputeNative));
            Passives.Add(new Passive(PassiveConst.Kokoro2, PassiveConst.KokoroDesc2, null));
            Passives.Add(new Passive(PassiveConst.Kokoro3, PassiveConst.KokoroDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Kokoro4, PassiveConst.KokoroDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Kokoro);
        public override double Attack   { get; init; } = 24;
        public override double Life     { get; init; } = 398;

        #endregion
    }
}