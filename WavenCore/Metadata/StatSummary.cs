using WavenCore.Spells;

namespace WavenCore.Metadata
{
    public class StatSummary
    {
        #region Static Fields and Methods

        public static readonly StatSummary Empty = new(0, 0, 0, 0, 50, 5, SpellSummary.Empty, 0);

        #endregion

        #region Constructors

        internal StatSummary(int attack, int life, int attackInBattle, int lifeInBattle, int criticalDamage, int criticalChance, SpellSummary spellSummary, int siffLife) {
            Attack         = attack;
            Life           = life;
            AttackInBattle = attackInBattle;
            LifeInBattle   = lifeInBattle;
            CriticalDamage = criticalDamage;
            CriticalChance = criticalChance;
            Spells         = spellSummary;
            SiffLife       = siffLife;
        }

        #endregion

        #region Properties

        public int          Attack         { get; }
        public int          Life           { get; }
        public int          AttackInBattle { get; }
        public int          LifeInBattle   { get; }
        public int          CriticalDamage { get; }
        public int          CriticalChance { get; }
        public SpellSummary Spells         { get; }
        public int          SiffLife       { get; }

        #endregion

        public StatSummary Combine(StatSummary other) {
            int          newAttack         = Attack         + other.Attack;
            int          newLife           = Life           + other.Life;
            int          newAttackInBattle = AttackInBattle + other.AttackInBattle;
            int          newLifeInBattle   = LifeInBattle   + other.LifeInBattle;
            int          newCriticalDamage = CriticalDamage + other.CriticalDamage;
            int          newCriticalChance = CriticalChance + other.CriticalChance;
            SpellSummary spellSummary      = Spells.Combine(other.Spells);
            int          newSiffLife       = SiffLife + other.SiffLife;

            return new StatSummary(newAttack, newLife, newAttackInBattle, newLifeInBattle, newCriticalDamage, newCriticalChance, spellSummary, newSiffLife);
        }
    }
}