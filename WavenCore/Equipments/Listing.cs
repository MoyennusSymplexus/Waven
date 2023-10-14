using System.Collections.Generic;

namespace WavenCore.Equipments
{
    public class Listing
    {
        #region Fields and Enums

        private readonly List<Equipment> _cuffList = new();

        private readonly List<Equipment> _ringList = new();

        #endregion

        #region Constructors

        public Listing() {
            (List<Ring> rings, List<Cuff> cuffs) = DeserializeEquipment.Deserialize();

            _ringList = new List<Equipment>(rings);
            _cuffList = new List<Equipment>(cuffs);
        }

        #endregion

        public IEnumerable<Equipment> GetRings() {
            return _ringList;
        }

        public IEnumerable<Equipment> GetCuffs() {
            return _cuffList;
        }
    }
}