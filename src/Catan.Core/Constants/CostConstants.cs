using System.Resources;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Catan.Core.Constants
{
    public class CostConstants
    {
        public ImmutableDictionary<ResourceConstants, int> RoadResourceCost = new Dictionary<ResourceConstants, int>()
        {
            [ResourceConstants.Brick] = 1,
            [ResourceConstants.Lumber] = 1,
        }.ToImmutableDictionary<ResourceConstants, int>();

        public ImmutableDictionary<ResourceConstants, int> SettlementResourceCost = new Dictionary<ResourceConstants, int>()
        {
            [ResourceConstants.Brick] = 1,
            [ResourceConstants.Lumber] = 1,
            [ResourceConstants.Wool] = 1,
            [ResourceConstants.Grain] = 1,
        }.ToImmutableDictionary<ResourceConstants, int>();

        public ImmutableDictionary<ResourceConstants, int> CityResourceCost = new Dictionary<ResourceConstants, int>()
        {
            [ResourceConstants.Ore] = 3,
            [ResourceConstants.Grain] = 2,
        }.ToImmutableDictionary<ResourceConstants, int>();

        public ImmutableDictionary<ResourceConstants, int> DevelopmentCardCost = new Dictionary<ResourceConstants, int>()
        {
            [ResourceConstants.Ore] = 1,
            [ResourceConstants.Wool] = 1,
            [ResourceConstants.Grain] = 1,
        }.ToImmutableDictionary<ResourceConstants, int>();
    }
}