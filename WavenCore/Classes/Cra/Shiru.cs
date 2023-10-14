using System;
using WavenCore.Metadata;

namespace WavenCore.Classes
{
    public class Shiru : Cra
    {
        #region Static Fields and Methods

        private static string ComputeSecond(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalLife * 0.05);
            return $"Inflige {value} dégâts";
        }

        private static string ComputeThird(CharacterStatSummary? summary) {
            if (summary is null) {
                throw new InvalidOperationException();
            }

            double value = Math.Round(summary.TotalLife * 0.05);
            return $"Soigne {value} HP";
        }

        #endregion

        #region Constructors

        public Shiru() {
            Passives.Add(new Passive(PassiveConst.Native, PassiveConst.ShiruDesc0, null, true));
            Passives.Add(new Passive(PassiveConst.Shiru1, PassiveConst.ShiruDesc1, null));
            Passives.Add(new Passive(PassiveConst.Shiru2, PassiveConst.ShiruDesc2, ComputeSecond));
            Passives.Add(new Passive(PassiveConst.Shiru3, PassiveConst.ShiruDesc3, ComputeThird));
            Passives.Add(new Passive(PassiveConst.Shiru4, PassiveConst.ShiruDesc4, null));
        }

        #endregion

        #region Properties

        public override string SubClass { get; init; } = nameof(Shiru);
        public override double Attack   { get; init; } = 22;
        public override double Life     { get; init; } = 383;

        #endregion
    }
}