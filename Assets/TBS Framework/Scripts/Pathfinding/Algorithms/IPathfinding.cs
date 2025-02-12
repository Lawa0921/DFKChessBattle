﻿using System.Collections.Generic;
using System.Linq;
using TbsFramework.Pathfinding.DataStructs;

namespace TbsFramework.Pathfinding.Algorithms
{
    public abstract class IPathfinding
    {
        /// <summary>
        /// Method finds path between two nodes in a graph.
        /// </summary>
        /// <param name="edges">
        /// Graph edges represented as nested dictionaries. Outer dictionary contains all nodes in the graph, inner dictionary contains 
        /// its neighbouring nodes with edge weight.
        /// </param>
        /// <returns>
        /// If a path exist, method returns list of nodes that the path consists of. Otherwise, empty list is returned.
        /// </returns>
        public abstract List<T> FindPath<T>(Dictionary<T, Dictionary<T, float>> edges, T originNode, T destinationNode) where T : IGraphNode;

        protected IEnumerable<T> GetNeigbours<T>(Dictionary<T, Dictionary<T, float>> edges, T node) where T : IGraphNode
        {
            if (!edges.ContainsKey(node))
            {
                return Enumerable.Empty<T>();
            }
            return edges[node].Keys;
        }
    }
}