using System;
using WavenCore.Metadata;

namespace WavenCore.Equipments.SpecificCalculator
{
    public static class LermiteCalculator
    {
        #region Static Fields and Methods

        public static double GetDamage(CharacterStatSummary? summary) {
            if (summary == null) {
                return 0;
            }

            return Math.Round(summary.TotalLife * 0.05);
        }

        public static double GetCriticalDamage(CharacterStatSummary? summary) {
            if (summary == null) {
                return 0;
            }

            return CharacterStatSummary.ComputeStat(GetDamage(summary), summary.CriticalDamage);
        }

        #endregion
    }
}