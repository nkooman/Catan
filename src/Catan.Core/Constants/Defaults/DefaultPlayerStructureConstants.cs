using System.Collections.Generic;
using System.Collections.Immutable;

namespace Catan.Core.Constants.Defaults
{
    public class DefaultPlayerStructureConstants
    {
        public static ImmutableDictionary<StructureConstants, int> Structures = new Dictionary<StructureConstants, int>()
        {
            [StructureConstants.Settlement] = 5,
            [StructureConstants.City] = 4,
            [StructureConstants.Road] = 15
        }.ToImmutableDictionary<StructureConstants, int>();
    }
}