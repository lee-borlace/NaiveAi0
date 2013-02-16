using System.Collections.Generic;

namespace Lee.NaiveAI0.Clustering.Clusterers
{
    /// <summary>
    /// Base class for clustering.
    /// </summary>
    public abstract class Clusterer
    {
        /// <summary>
        /// Elements under consideration by the clusterer.
        /// </summary>
        protected List<ClusteringVector> Elements { get; set; }

        /// <summary>
        /// Determine the clusters a specified element belongs to.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="storeElement">Whether to store the element as a new data point.</param>
        /// <returns>Clusters element belongs to or null if doesn't belong to a cluster.</returns>
        public abstract List<ClusterMembership> GetClustersForElement(ClusteringVector element, bool storeElement);
    }
}
