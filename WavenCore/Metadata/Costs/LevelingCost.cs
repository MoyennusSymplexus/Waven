using System;
using System.Collections.Generic;

namespace WavenCore.Metadata.Costs
{
    public class LevelingCost
    {
        #region Static Fields and Methods

        private static int GetCost(double i) {
            return (int) (1 + Math.Floor((i + 1) / 10));
        }

        private static int GetCostInfinite(int i) {
            return i switch {
                       < 19 => 1,
                       < 39 => 2,
                       _    => 3
                   };
        }

        #endregion

        #region Fields and Enums

        private readonly List<LevelingItem> _costs = new();

        #endregion

        #region Constructors

        public LevelingCost() {
            const int maxCost                = 154;
            var       cumulativeCost         = 0;
            var       cumulativeCostInfinite = 0;

            for (var i = 1; i < 50; i++) {
                int cost        = GetCost(i);
                int costToFifty = maxCost - cumulativeCost;
                cumulativeCost += cost;

                int costInfinite = GetCostInfinite(i);
                cumulativeCostInfinite += costInfinite;

                _costs.Add(new LevelingItem(i, cost, cumulativeCost, costToFifty, costInfinite, cumulativeCostInfinite));
            }
        }

        #endregion

        #region Properties

        public IEnumerable<LevelingItem> Costs => _costs;

        #endregion
    }

    public record LevelingItem(int Level, int LevelUpCost, int CumulativeCost, int UpToFifty, int CostInfinite, int CumulativeCostInfinite);
}