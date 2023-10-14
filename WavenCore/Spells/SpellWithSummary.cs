using System.Collections.Generic;
using System.Linq;
using WavenCore.Equipments.RuneAndEffect;
using WavenCore.Metadata;

namespace WavenCore.Spells
{
    public class SpellWithSummary
    {
        #region Fields and Enums

        private readonly CharacterStatSummary _characterStatSummary;
        private readonly Spell                _spell;

        #endregion

        #region Constructors

        public SpellWithSummary(Spell spell, CharacterStatSummary characterStatSummary) {
            _spell                = spell;
            _characterStatSummary = characterStatSummary;
        }

        #endregion

        #region Properties

        public string?                                 Name    => _spell.Name;
        public IEnumerable<SpecificSpellEffectSummary> Effects => GetSpellsSummary();
        public List<Rune>                              Runes   => _spell.Runes;
        public int                                     Level   => _spell.Level;

        #endregion

        private IEnumerable<SpecificSpellEffectSummary> GetSpellsSummary() {
            return _spell.Effects.Select(spellEffect => new SpecificSpellEffectSummary(spellEffect, Runes, Level, _characterStatSummary));
        }

        public void AddLevel() {
            _spell.AddLevel();
        }

        public void RemoveLevel() {
            _spell.RemoveLevel();
        }
    }
}