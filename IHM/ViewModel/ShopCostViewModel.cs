using System.Collections.Generic;
using WavenCore.Metadata.Costs;

namespace IHM.ViewModel
{
    internal class ShopCostViewModel : IPageViewModel
    {
        #region Fields and Enums

        private readonly ShopCost _shopCost;

        #endregion

        #region Constructors

        public ShopCostViewModel() {
            _shopCost = new ShopCost();
        }

        #endregion

        #region Properties

        public IEnumerable<ShopItem> ItemList => _shopCost.Costs;

        #endregion

        #region IPageViewModel Members

        public string Name => "Shop cost";

        #endregion
    }
}