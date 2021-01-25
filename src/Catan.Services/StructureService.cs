using System.Collections.Generic;
using Catan.Core;
using Catan.Core.Constants;
using Catan.Services.Abstractions;

namespace Catan.Services
{
    public class StructureService
    {

        public bool CreateRoad(ref Player player, ref BoardEdge edge, bool isStartupPhase)
        {
            if (edge.Type != EdgeTypeConstants.Empty) return false;
            // if (isStartupPhase != true && economyService.CanAffordCost(player, CostConstants.RoadResourceCost)) return false;
            if (player.Structures[StructureConstants.Road] == 0) return false;

            edge.Type = EdgeTypeConstants.Road;
            edge.PlayerOwner = player;
            player.Structures[StructureConstants.Road] = player.Structures[StructureConstants.Road] - 1;

            return true;
        }

        public bool CreateSettlement(ref Player player, ref BoardVertex vertex, bool isStartupPhase)
        {
            if (vertex.Type != VertexTypeConstants.Empty) return false;
            // if (isStartupPhase != true && economyService.CanAffordCost(player, CostConstants.SettlementResourceCost)) return false;
            if (player.Structures[StructureConstants.Settlement] == 0) return false;

            //TODO: Add check to make sure there are no adjacent settlements.
            //TODO: Add check to make sure settlements are being place on a road owned by the player.

            vertex.Type = VertexTypeConstants.Settlement;
            vertex.PlayerOwner = player;
            player.Structures[StructureConstants.Settlement] = player.Structures[StructureConstants.Settlement] - 1;

            return true;
        }
    }
}