using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using WavenCore.Equipments.RuneAndEffect;

namespace WavenCore.Spells
{
    [Serializable]
    public class Spell
    {
        #region Properties

        public        string?           Name     { get; init; }
        public        List<SpellEffect> Effects  { get; } = new();
        public        List<Rune>        Runes    { get; } = new(3);
        public static int               MaxLevel => 50;
        [XmlIgnore]
        public int Level { get; private set; } = 1;

        #endregion

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
    }
}