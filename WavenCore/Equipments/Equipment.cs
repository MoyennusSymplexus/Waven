using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using WavenCore.Equipments.RuneAndEffect;
using WavenCore.Metadata;
using WavenCore.Spells;

namespace WavenCore.Equipments
{
    [Serializable]
    public abstract class Equipment
    {
        #region Properties

        public abstract string        Name      { get; init; }
        public abstract Effect        Effect    { get; init; }
        public abstract Effect        BaseStat1 { get; init; }
        public          List<Rune>    Runes     { get; } = new(7);
        public abstract EquipmentType Type      { get; init; }
        public static   int           MaxLevel  => 50;

        [XmlElement(IsNullable = true)]
        public abstract Effect? Effect2 { get; init; }
        [XmlElement(IsNullable = true)]
        public abstract Effect? BaseStat2 { get; init; }
        [XmlIgnore]
        public int Level { get; set; } = 1;

        #endregion

        public override string ToString() {
            return Name;
        }

        public void AddLevel() {
            if (Level < MaxLevel) {
                Level++;
            }
        }

        public void RemoveLevel() {
            if (Level > 1) {
                Level--;
            }
        }

        public void SetLevel(int level) {
            if (level < 0) {
                Level = 1;
            } else if (level > MaxLevel) {
                Level = MaxLevel;
            } else {
                Level = level;
            }
        }

        public StatSummary GetSummary() {
            int          attack         = GetStat(EffectType.AttackType);
            int          life           = GetStat(EffectType.LifeType);
            int          attackInBattle = GetStat(EffectType.AttackInBattle);
            int          lifeInBattle   = GetStat(EffectType.LifeInBattle);
            int          criticalDamage = GetStat(EffectType.CriticalDamage);
            int          criticalChance = GetStat(EffectType.CriticalChance);
            SpellSummary spellSummary   = GetSpellSummary();
            int          siffLife       = GetStat(EffectType.SiffLife);

            return new StatSummary(attack, life, attackInBattle, lifeInBattle, criticalDamage, criticalChance, spellSummary, siffLife);
        }

        private SpellSummary GetSpellSummary() {
            int spellDamage         = GetStat(EffectType.SpellType);
            int spellDamageInBattle = GetStat(EffectType.SpellDamageInBattle);
            int airDamage           = GetStat(EffectType.AirType);
            int fireDamage          = GetStat(EffectType.FireType);
            int waterDamage         = GetStat(EffectType.WaterType);
            int earthDamage         = GetStat(EffectType.EarthType);
            int collisionDamage     = GetStat(EffectType.CollisionDamage);
            int elementDamage       = GetStat(EffectType.ElementalDamage);
            int heal                = GetStat(EffectType.Heal);
            int armor               = GetStat(EffectType.Armor);

            return new SpellSummary(spellDamage, spellDamageInBattle, airDamage, fireDamage, waterDamage, earthDamage, collisionDamage, elementDamage, heal, armor);
        }

        private int GetStat(EffectType type) {
            var stat = 0;
            stat += GetStatOf(Effect,    type);
            stat += GetStatOf(Effect2,   type);
            stat += GetStatOf(BaseStat1, type);
            stat += GetStatOf(BaseStat2, type);

            stat += Runes.Sum(rune => GetStatOf(rune, type));

            return stat;
        }

        private int GetStatOf(Rune rune, EffectType type) {
            const int stat = 0;

            return !rune.IsActive ? stat : GetStatOf(rune as Effect, type);
        }

        private int GetStatOf(Effect? effect, EffectType type) {
            var stat = 0;

            if (effect == null) {
                return stat;
            }

            if ((effect.Type & type) == 0) {
                return stat;
            }

            if ((effect.Type & EffectType.ScalingType) != 0) {
                stat += effect.Value * Level;
            } else {
                stat += effect.Value;
            }

            return stat;
        }
    }
}