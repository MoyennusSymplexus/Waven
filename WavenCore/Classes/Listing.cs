using System.Collections.Generic;
using System.Linq;

namespace WavenCore.Classes
{
    public class Listing
    {
        #region Fields and Enums

        private readonly List<Character> _list = new();

        #endregion

        #region Constructors

        public Listing() {
            Spells.Listing listing = new();

            _list.Add(new Bunelame().SetSpells(listing));
            _list.Add(new Expingole().SetSpells(listing));
            _list.Add(new Piven().SetSpells(listing));
            _list.Add(new Shiru().SetSpells(listing));
            _list.Add(new Voldorak().SetSpells(listing));

            _list.Add(new Gemme().SetSpells(listing));
            _list.Add(new Kokoro().SetSpells(listing));
            _list.Add(new Scalpel().SetSpells(listing));
            _list.Add(new Tamashi().SetSpells(listing));
            _list.Add(new Voracius().SetSpells(listing));

            _list.Add(new Justelame().SetSpells(listing));
            _list.Add(new Kasai().SetSpells(listing));
            _list.Add(new Orok().SetSpells(listing));
            _list.Add(new Spectral().SetSpells(listing));
            _list.Add(new Stalaktoss().SetSpells(listing));

            _list.Add(new Kartana().SetSpells(listing));
            _list.Add(new Orishi().SetSpells(listing));
            _list.Add(new Ourai().SetSpells(listing));
            _list.Add(new Shugen().SetSpells(listing));
            _list.Add(new Surin().SetSpells(listing));

            _list.Add(new Catalyseur().SetSpells(listing));
            _list.Add(new Gurpapa().SetSpells(listing));
            _list.Add(new Jikan().SetSpells(listing));
            _list.Add(new Pikuxala().SetSpells(listing));
            _list.Add(new Tako().SetSpells(listing));
        }

        #endregion

        public IEnumerable<string> GetClasses() {
            return _list.Select(x => x.Class).Distinct();
        }

        public IEnumerable<string> GetSubClasses(string @class) {
            return _list.Where(x => x.Class == @class).Select(x => x.SubClass);
        }

        public Character GetCharacter(string subClass) {
            return _list.First(x => x.SubClass == subClass);
        }

        public Character GetCharacterFromClass(string @class) {
            return _list.First(x => x.Class == @class);
        }
    }
}