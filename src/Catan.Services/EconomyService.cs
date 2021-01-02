using System.Collections.Generic;
using Catan.Core;
using Catan.Core.Constants;
using Catan.Services.Abstractions;

namespace Catan.Services
{
    public class EconomyService : IEconomyService
    {
        public bool CanAffordCost(Player player, Dictionary<ResourceConstants, int> cost)
        {
            foreach (KeyValuePair<ResourceConstants, int> resourceCost in cost)
            {
                player.Resources.TryGetValue(resourceCost.Key, out int resourceCount);

                if (resourceCount < resourceCost.Value) return false;
            }

            return true;
        }
    }
}