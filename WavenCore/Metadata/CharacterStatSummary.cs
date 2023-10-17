using System;
using System.Linq;
using WavenCore.Classes;
using WavenCore.Spells;

namespace WavenCore.Metadata
{
    public class CharacterStatSummary
    {
        #region Static Fields and Methods

        public static double ComputeStat(double baseStat, double multiplier) {
            return Math.Round(baseStat * (1 + multiplier / 100));
        }

        #endregion

        #region Fields and Enums

        private readonly Character   _character;
        private readonly StatSummary _stats;

        #endregion

        #region Constructors

        internal CharacterStatSummary(Character character, StatSummary stats) {
            _character = character;
            _stats     = stats;
        }

        #endregion

        #region Properties

        public double       BaseAttack     => _character.Attack;
        public double       Attack         => _stats.Attack;
        public double       AttackOnStat   => ComputeStat(BaseAttack, Attack);
        public double       BaseLife       => _character.Life;
        public int          Life           => _stats.Life;
        public double       LifeOnStat     => ComputeStat(BaseLife, Life);
        public int          AttackInBattle => _stats.AttackInBattle;
        public double       TotalAttack    => ComputeSpecialAttack();
        public int          LifeInBattle   => _stats.LifeInBattle;
        public double       TotalLife      => ComputeSpecialLife();
        public int          CriticalDamage => _stats.CriticalDamage;
        public double       AttackWithCrit => ComputeStat(TotalAttack, CriticalDamage);
        public int          CriticalChance => _stats.CriticalChance;
        public SpellSummary Spells         => _stats.Spells;

        #endregion

        private double ComputeSpecialAttack() {
            if (_character.SubClass != Voracius.ClassName) {
                return ComputeStat(AttackOnStat, AttackInBattle);
            }

            if (!_character.Passives.First(x => x.Name == PassiveConst.Voracius3).IsActive) {
                return ComputeStat(AttackOnStat, AttackInBattle);
            }

            double passiveAttack = Math.Round(TotalLife * 0.03);
            return ComputeStat(AttackOnStat + passiveAttack, AttackInBattle);
        }

        private double ComputeSpecialLife() {
            double lifeInBattle = ComputeStat(LifeOnStat, LifeInBattle);

            return ComputeStat(lifeInBattle, _stats.SiffLife);
        }

        public StatSummary GetStat() {
            return _stats;
        }
    }
}