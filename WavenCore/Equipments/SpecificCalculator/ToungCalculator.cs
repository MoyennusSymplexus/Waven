using System;
using System.Collections.Generic;
using WavenCore.Metadata;

namespace WavenCore.Equipments.SpecificCalculator
{
    public static class ToungCalculator
    {
        #region Static Fields and Methods

        public static IEnumerable<ToungEffect> GetEffects(CharacterStatSummary summary) {
            for (var i = 0; i <= 100; i += 10) {
                yield return new ToungEffect(summary.AttackOnStat, summary.AttackInBattle, i);
            }
        }

        #endregion
    }

    public class ToungEffect
    {
        #region Constructors

        public ToungEffect(double attackOnStat, double attackInBattle, int attackBonus) {
            AttackBonus = attackBonus;
            TotalAttack = Math.Round(attackOnStat * (1 + (attackInBattle + attackBonus) / 100));
        }

        #endregion

        #region Properties

        public int    AttackBonus { get; }
        public double TotalAttack { get; }

        #endregion
    }
}