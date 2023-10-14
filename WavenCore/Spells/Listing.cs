using System.Collections.Generic;
using System.Linq;
using WavenCore.Classes;

namespace WavenCore.Spells
{
    public class Listing
    {
        #region Fields and Enums

        private readonly Dictionary<string, List<Spell>> _list = new();

        #endregion

        #region Constructors

        public Listing() {
            LoadValues();
        }

        #endregion

        private void LoadValues() {
            LoadCra();
            LoadEni();
            LoadIop();
            LoadSram();
            LoadXelor();
        }

        private void LoadCra() {
            var list = new List<Character> {new Bunelame(), new Expingole(), new Piven(), new Shiru(), new Voldorak()};

            Load(list);
        }

        private void LoadEni() {
            var list = new List<Character> {new Gemme(), new Kokoro(), new Scalpel(), new Tamashi(), new Voracius()};

            Load(list);
        }

        private void LoadIop() {
            var list = new List<Character> {new Justelame(), new Kasai(), new Orok(), new Spectral(), new Stalaktoss()};

            Load(list);
        }

        private void LoadSram() {
            var list = new List<Character> {new Kartana(), new Orishi(), new Ourai(), new Shugen(), new Surin()};

            Load(list);
        }

        private void LoadXelor() {
            var list = new List<Character> {new Catalyseur(), new Gurpapa(), new Jikan(), new Pikuxala(), new Tako()};

            Load(list);
        }

        private void Load(List<Character> list) {
            List<Spell> generic = DeserializeSpells.DeserializeGeneric(list[0]);
            _list.Add(list[0].Class, generic);

            foreach (Character character in list) {
                List<Spell> specific = DeserializeSpells.DeserializeSpecific(character);
                _list.Add(character.SubClass, specific);
            }
        }

        public IEnumerable<Spell> GetSpellsFor(Character character) {
            List<Spell> generic  = _list[character.Class];
            List<Spell> specific = _list[character.SubClass];

            return generic.Concat(specific);
        }
    }
}