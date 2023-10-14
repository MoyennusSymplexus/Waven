using System;

namespace WavenCore.Metadata
{
    [Flags]
    public enum EffectType
    {
        NotComputable       = 0,
        LifeInBattle        = 1,
        Life                = 2,
        ScalingLife         = 4,
        AttackInBattle      = 8,
        Attack              = 16,
        ScalingAttack       = 32,
        SpellDamage         = 64,
        SpellDamageInBattle = 128,
        AirDamage           = 256,
        FireDamage          = 512,
        WaterDamage         = 1024,
        EarthDamage         = 2048,
        CollisionDamage     = 4096,
        ElementalDamage     = 8192,
        CriticalChance      = 16384,
        CriticalDamage      = 32768,
        RuneDamage          = 65536,
        ScalingSpellDamage  = RuneDamage         * 2,
        SiffLife            = ScalingSpellDamage * 2,
        ScalingAirDamage    = SiffLife           * 2,
        ScalingFireDamage   = ScalingAirDamage   * 2,
        ScalingWaterDamage  = ScalingFireDamage  * 2,
        ScalingEarthDamage  = ScalingWaterDamage * 2,
        Heal                = ScalingEarthDamage * 2,
        Armor               = Heal               * 2,

        ScalingType = ScalingLife | ScalingAttack | ScalingSpellDamage | ScalingAirDamage | ScalingFireDamage | ScalingWaterDamage | ScalingEarthDamage,
        AttackType  = Attack      | ScalingAttack,
        LifeType    = Life        | ScalingLife,
        SpellType   = SpellDamage | ScalingSpellDamage,
        AirType     = AirDamage   | ScalingAirDamage,
        FireType    = FireDamage  | ScalingFireDamage,
        WaterType   = WaterDamage | ScalingWaterDamage,
        EarthType   = EarthDamage | ScalingEarthDamage
    }
}