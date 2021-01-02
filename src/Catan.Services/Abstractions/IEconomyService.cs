using System.Collections.Immutable;
using Catan.Core;
using Catan.Core.Constants;

namespace Catan.Services.Abstractions
{
    public interface IEconomyService
    {
        bool CanAffordCost(Player player, ImmutableDictionary<ResourceConstants, int> cost);
    }
}