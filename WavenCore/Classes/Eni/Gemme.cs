using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Gemme : Eni
    {
        #region Static Fields and Methods

        private static string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalAttack * 0.5);
            return $"Soigne {value} HP par adversaire";
        }

        #endregion

        #region Constructors

        public Gemme() {
            Passives.Add(new Passive(PassiveConst.Native, PassiveConst.GemmeDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Gemme1, PassiveConst.GemmeDesc1, null));
            Passives.Add(new Passive(PassiveConst.Gemme2, PassiveConst.GemmeDesc2, null));
            Passives.Add(new Passive(PassiveConst.Gemme3, PassiveConst.GemmeDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Gemme4, PassiveConst.GemmeDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Gemme);
        public override double Attack   { get; init; } = 18;
        public override double Life     { get; init; } = 401;

        #endregion
    }
}