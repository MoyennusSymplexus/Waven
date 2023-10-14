using System.Collections.Generic;
using WavenCore.Metadata;
using WavenCore.Spells;

namespace WavenCore.Classes
{
    public abstract class Character
    {
        #region Properties

        public abstract string              Class    { get; init; }
        public abstract string              SubClass { get; init; }
        public abstract double              Attack   { get; init; }
        public abstract double              Life     { get; init; }
        public          IEnumerable<Spell>? Spells   { get; private set; }
        public          List<Passive>       Passives { get; } = new();

        #endregion

        public Character SetSpells(Spells.Listing listing) {
            Spells = listing.GetSpellsFor(this);
            return this;
        }

        public IEnumerable<Passive> GetPassives(CharacterStatSummary summary) {
            foreach (Passive passive in Passives) {
                passive.SetSummary(summary);
                yield return passive;
            }
        }
    }
}