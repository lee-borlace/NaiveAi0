using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.Clustering
{
    /// <summary>
    /// Indicates how a vector is a member of which clusters.
    /// </summary>
    public class ClusterMembership
    {
        /// <summary>
        /// The cluster the vector is a member of.
        /// </summary>
        public Cluster Cluster { get; set; }

        /// <summary>
        /// Degree of membership to the cluster (0 to 1).
        /// </summary>
        public double DegreeOfMembership { get; set; }

        /// <summary>
        /// Distance from center of cluster.
        /// </summary>
        public ClusteringVector DistanceFromCenter { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append("Cluster:");
            sb.Append(Cluster.ToString());
            sb.Append(", DegreeOfMembership:");
            sb.Append(DegreeOfMembership);
            sb.Append(", DistanceFromCenter:");
            sb.Append(DistanceFromCenter.ToString());
            sb.Append("}");

            return sb.ToString();
        }

    }
}
