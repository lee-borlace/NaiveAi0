using System.Collections.Generic;

namespace Lee.NaiveAI0.Clustering.Clusterers
{
    public class FuzzyClusterer : Clusterer
    {
        /// <summary>
        /// Clusters calculated so far.
        /// </summary>
        protected List<Cluster> _clusters;

        protected int NextClusterId;

        public FuzzyClusterer()
        {
            _clusters = new List<Cluster>();

            NextClusterId = 0;
        }

        public override List<ClusterMembership> GetClustersForElement(ClusteringVector element, bool storeElement)
        {
            //TODO.
            
            if(storeElement)
            {
                Elements.Add(element);
            }

            Cluster cluster = new Cluster() { Id = NextClusterId, Center = element };

            _clusters.Add(new Cluster());

            NextClusterId++;
            
            List<ClusterMembership> retVal = new List<ClusterMembership>();

            ClusterMembership membership = new ClusterMembership();

            membership.Cluster = cluster;

            membership.DegreeOfMembership = 1;
            
            membership.DistanceFromCenter = new ClusteringVector();
            foreach(string key in element.Components.Keys)
            {
                membership.DistanceFromCenter.Components[key] = 0;
            }

            retVal.Add(membership);

            return retVal;
        }
    }
}
