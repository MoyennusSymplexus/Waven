using System.Collections.Generic;
using System.Linq;
using WavenCore.Classes;
using WavenCore.Equipments;
using WavenCore.Nodes;
using Listing = WavenCore.Nodes.Listing;

namespace WavenCore.Metadata
{
    public class Build
    {
        #region Fields and Enums

        private readonly Listing _listing;

        #endregion

        #region Constructors

        public Build() {
            _listing = new Listing();
        }

        #endregion

        #region Properties

        public Character         Character  { get; private set; } = new Bunelame();
        public List<Equipment>   Equipments { get; }              = new(5);
        public IEnumerable<Node> Nodes      => _listing.Nodes;

        #endregion

        public void SetCharacter(Character value) {
            Character = value;
        }

        public CharacterStatSummary GetSummary() {
            StatSummary result = Equipments.Aggregate(StatSummary.Empty, (current, equipment) => current.Combine(equipment.GetSummary()));

            return new CharacterStatSummary(Character, result.Combine(_listing.GetSummary()));
        }
    }
}