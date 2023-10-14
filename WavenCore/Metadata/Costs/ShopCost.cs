using System;
using System.Collections.Generic;

namespace WavenCore.Metadata.Costs
{
    public class ShopCost
    {
        #region Fields and Enums

        private readonly List<ShopItem> _costs = new();

        #endregion

        #region Constructors

        public ShopCost() {
            var initialCost1 = 50;
            var initialCost2 = 100;
            var initialCost3 = 500;
            var initialCost4 = 1000;

            var augment1 = (int) Math.Round(initialCost1 * 0.2);
            var augment2 = (int) Math.Round(initialCost2 * 0.2);
            var augment3 = (int) Math.Round(initialCost3 * 0.2);
            var augment4 = (int) Math.Round(initialCost4 * 0.2);

            int cumulativeCost1 = initialCost1;
            int cumulativeCost2 = initialCost2;
            int cumulativeCost3 = initialCost3;
            int cumulativeCost4 = initialCost4;

            int previousCost1 = initialCost1;
            int previousCost2 = initialCost2;
            int previousCost3 = initialCost3;
            int previousCost4 = initialCost4;

            _costs.Add(new ShopItem(1, initialCost1, cumulativeCost1, initialCost2, cumulativeCost2, initialCost3, cumulativeCost3, initialCost4, cumulativeCost4));

            for (var i = 2; i < 50; i++) {
                int cost1 = previousCost1 + augment1 * (i - 1);
                int cost2 = previousCost2 + augment2 * (i - 1);
                int cost3 = previousCost3 + augment3 * (i - 1);
                int cost4 = previousCost4 + augment4 * (i - 1);

                previousCost1 = cost1;
                previousCost2 = cost2;
                previousCost3 = cost3;
                previousCost4 = cost4;

                cumulativeCost1 += cost1;
                cumulativeCost2 += cost2;
                cumulativeCost3 += cost3;
                cumulativeCost4 += cost4;

                _costs.Add(new ShopItem(i, cost1, cumulativeCost1, cost2, cumulativeCost2, cost3, cumulativeCost3, cost4, cumulativeCost4));
            }
        }

        #endregion

        #region Properties

        public IEnumerable<ShopItem> Costs => _costs;

        #endregion
    }

    public record ShopItem(int Level, int LevelUpCost, int CumulativeCost, int LevelUpCost2, int CumulativeCost2, int LevelUpCost3, int CumulativeCost3, int LevelUpCost4, int CumulativeCost4);
}