using System;

namespace WavenCore.Spells
{
    public class SpellSummary
    {
        #region Static Fields and Methods

        public static readonly SpellSummary Empty = new(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        #endregion

        #region Constructors

        internal SpellSummary(int spellDamage, int spellDamageInBattle, int airDamage, int fireDamage, int waterDamage, int earthDamage, int collisionDamage, int elementDamage, int heal, int armor) {
            SpellDamage         = spellDamage;
            SpellDamageInBattle = spellDamageInBattle;
            AirDamage           = airDamage;
            FireDamage          = fireDamage;
            WaterDamage         = waterDamage;
            EarthDamage         = earthDamage;
            CollisionDamage     = collisionDamage;
            ElementalDamage     = elementDamage;
            Heal                = heal;
            Armor               = armor;
        }

        #endregion

        #region Properties

        public int    SpellDamage         { get; }
        public int    SpellDamageInBattle { get; }
        public int    AirDamage           { get; }
        public int    FireDamage          { get; }
        public int    WaterDamage         { get; }
        public int    EarthDamage         { get; }
        public int    CollisionDamage     { get; }
        public int    ElementalDamage     { get; }
        public int    Heal                { get; }
        public int    Armor               { get; }
        public double AirTypeDamage       => SpellDamage + AirDamage   + ElementalDamage;
        public double FireTypeDamage      => SpellDamage + FireDamage  + ElementalDamage;
        public double WaterTypeDamage     => SpellDamage + WaterDamage + ElementalDamage;
        public double EarthTypeDamage     => SpellDamage + EarthDamage + ElementalDamage;

        #endregion

        public SpellSummary Combine(SpellSummary other) {
            int spellDamage         = SpellDamage         + other.SpellDamage;
            int spellDamageInBattle = SpellDamageInBattle + other.SpellDamageInBattle;
            int airDamage           = AirDamage           + other.AirDamage;
            int fireDamage          = FireDamage          + other.FireDamage;
            int waterDamage         = WaterDamage         + other.WaterDamage;
            int earthDamage         = EarthDamage         + other.EarthDamage;
            int collisionDamage     = CollisionDamage     + other.CollisionDamage;
            int elementDamage       = ElementalDamage     + other.ElementalDamage;
            int heal                = Heal                + other.Heal;
            int armor               = Armor               + other.Armor;

            return new SpellSummary(spellDamage, spellDamageInBattle, airDamage, fireDamage, waterDamage, earthDamage, collisionDamage, elementDamage, heal, armor);
        }

        public double GetMultiplierFor(SpellType spellSpellType) {
            return spellSpellType switch {
                       SpellType.Air       => AirTypeDamage,
                       SpellType.Fire      => FireTypeDamage,
                       SpellType.Water     => WaterTypeDamage,
                       SpellType.Earth     => EarthTypeDamage,
                       SpellType.None      => 0,
                       SpellType.Collision => 0,
                       SpellType.Attack    => 0,
                       SpellType.Heal      => 0,
                       SpellType.ArmorUp   => 0,
                       _                   => throw new ArgumentOutOfRangeException(nameof(spellSpellType), spellSpellType, null)
                   };
        }
    }
}