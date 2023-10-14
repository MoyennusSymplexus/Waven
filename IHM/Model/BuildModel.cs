using System.Collections.Generic;
using System.Linq;
using WavenCore.Classes;
using WavenCore.Equipments;
using WavenCore.Metadata;
using WavenCore.Nodes;
using WavenCore.Spells;

namespace IHM.Model
{
    public class BuildModel
    {
        #region Fields and Enums

        private readonly Build _build;

        #endregion

        #region Constructors

        public BuildModel() {
            _build = new Build();
        }

        #endregion

        #region Properties

        public Character              Character => _build.Character;
        public IEnumerable<Node>      Nodes     => _build.Nodes;
        public IEnumerable<Equipment> Equipment => _build.Equipments;

        #endregion

        public void SetCharacter(Character character) {
            _build.SetCharacter(character);
        }

        public void Remove(Equipment equipment) {
            _build.Equipments.Remove(equipment);
        }

        public void AddRing(Equipment equipment) {
            if (_build.Equipments.Contains(equipment)) {
                return;
            }

            _build.Equipments.Add(equipment);
        }

        public bool CanAddRing() {
            return _build.Equipments.Count(x => x.Type == EquipmentType.Ring) < 4;
        }

        public CharacterStatSummary GetSummary() {
            return _build.GetSummary();
        }

        public void AddCuff(Equipment equipment) {
            if (_build.Equipments.Contains(equipment)) {
                return;
            }

            Equipment? cuff = _build.Equipments.FirstOrDefault(x => x.Type == EquipmentType.Cuff);

            if (cuff != null) {
                _build.Equipments.Remove(cuff);
            }

            _build.Equipments.Add(equipment);
        }

        public void MaxAll() {
            _build.Equipments.ForEach(
                                      x => {
                                          x.Runes.ForEach(y => y.IsActive = true);
                                          x.SetLevel(50);
                                      }
                                     );
        }

        public IEnumerable<SpellWithSummary> GetSpellsSummary() {
            CharacterStatSummary summary = _build.GetSummary();
            return _build.Character.Spells.Select(spell => new SpellWithSummary(spell, summary));
        }

        public IEnumerable<Passive> GetPassives() {
            CharacterStatSummary summary = _build.GetSummary();
            return _build.Character.GetPassives(summary);
        }

        public bool ToungIsOn() {
            return _build.Equipments.Any(x => x.Name == "Toung");
        }

        public bool LermiteIsOn() {
            return _build.Equipments.Any(x => x.Name == "Lermite");
        }
    }
}