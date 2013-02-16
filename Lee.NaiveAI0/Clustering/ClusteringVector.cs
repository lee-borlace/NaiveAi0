using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.Clustering
{
    /// <summary>
    /// A data point in a cluster. It is really an n-tuple of double points, i.e. a multi-dimensional vector.
    /// </summary>
    public class ClusteringVector
    {
        /// <summary>
        /// Components of the vector.
        /// </summary>
        public Dictionary<string, decimal> Components { get; set; }

        public ClusteringVector()
        {
            Components = new Dictionary<string, decimal>();
        }

        public ClusteringVector(Dictionary<string, decimal> featureDictionary)
        {
            Components = featureDictionary;
        }

        /// <summary>
        /// Dimension of the vector.
        /// </summary>
        public int Dimension
        {
            get
            {
                return Components.Count;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");

            int i = 0;

            foreach (string key in Components.Keys)
            {
                sb.Append(Components[key]);

                if (i < Components.Keys.Count - 1)
                {
                    sb.Append(",");
                }

                i++;
            }

            sb.Append("}");

            return sb.ToString();
        }

    }
}
