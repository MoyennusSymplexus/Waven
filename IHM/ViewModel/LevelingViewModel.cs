using System.Collections.Generic;
using WavenCore.Metadata.Costs;

namespace IHM.ViewModel
{
    internal class LevelingViewModel : IPageViewModel
    {
        #region Fields and Enums

        private readonly LevelingCost _levelingCost;

        #endregion

        #region Constructors

        public LevelingViewModel() {
            _levelingCost = new LevelingCost();
        }

        #endregion

        #region Properties

        public IEnumerable<LevelingItem> ItemList => _levelingCost.Costs;

        #endregion

        #region IPageViewModel Members

        public string Name => "Leveling";

        #endregion
    }
}