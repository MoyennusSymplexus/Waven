using System;
using System.Collections.Generic;
using System.Linq;
using WavenCore.Equipments.RuneAndEffect;
using WavenCore.Metadata;

namespace WavenCore.Spells
{
    public class SpecificSpellEffectSummary
    {
        #region Static Fields and Methods

        private static double ComputeStat(double baseStat, double multiplier) {
            return Math.Round(baseStat * (1 + multiplier / 100));
        }

        #endregion

        #region Fields and Enums

        private readonly CharacterStatSummary _characterStatSummary;
        private readonly Rune?                _rune;
        private readonly SpellEffect          _spell;
        private readonly int                  _spellLevel;

        #endregion

        #region Constructors

        public SpecificSpellEffectSummary(SpellEffect spell, IEnumerable<Rune> runes, int spellLevel, CharacterStatSummary characterStatSummary) {
            _spell                = spell;
            _rune                 = runes.FirstOrDefault(x => x.Type == EffectType.RuneDamage);
            _spellLevel           = spellLevel;
            _characterStatSummary = characterStatSummary;
        }

        #endregion

        #region Properties

        public double BaseDamage           => _spell.Value;
        public double ScalingDamage        => ComputeScalingDamage();
        public double DamageOnStat         => ComputeStat(BaseDamage + ScalingDamage, _characterStatSummary.Spells.GetMultiplierFor(_spell.SpellType));
        public double DamageOnStatWithRune => ComputeStat(DamageOnStat,               _rune is not null && _rune.IsActive ? _rune.Value : 0);
        public double DamageInBattle       => ComputeStat(DamageOnStatWithRune,       _characterStatSummary.Spells.SpellDamageInBattle);
        public double CriticalDamage       => ComputeStat(DamageInBattle,             50);
        public string Description          => $"Inflige {DamageInBattle} ({CriticalDamage}) dégâts.";

        #endregion

        private double ComputeScalingDamage() {
            return BaseDamage * (_spellLevel - 1) * 0.05;
        }
    }
}