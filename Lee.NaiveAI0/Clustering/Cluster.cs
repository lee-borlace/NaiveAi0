using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.Clustering
{
    /// <summary>
    /// A cluster.
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// Cluster's ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Cluster's center.
        /// </summary>
        public ClusteringVector Center { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{Id:");
            sb.Append(Id);
            sb.Append(", Center:");
            sb.Append(Center.ToString());
            sb.Append("}");

            return sb.ToString();
        }

    }
}
