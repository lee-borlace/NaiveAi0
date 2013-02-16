using System.Collections.Generic;

namespace Lee.NaiveAI0.BaseUnits
{
    /// <summary>
    /// A base unit. Contains a name value dictionary representing the properties of an entity. Percepts and actions are both types of base unit.
    /// </summary>
    abstract public class BaseUnit
    {
        /// <summary>
        /// Key into properties representing the primary value of the unit.
        /// </summary>
        public abstract string PRIMARY_PROPERTY_KEY { get; }

        private Dictionary<string, object> _genericProperties;

        /// <summary>
        /// The generic properties of the unit. The values can be any object.
        /// </summary>
        public Dictionary<string, object> GenericProperties
        {
            get
            {
                if(_genericProperties == null)
                {
                    _genericProperties = new Dictionary<string, object>();
                }

                return _genericProperties;
            }
        }

        private Dictionary<string, decimal> _clusteringProperties;

        /// <summary>
        /// Clustering properties. Used for clustering.
        /// </summary>
        public Dictionary<string, decimal> ClusteringProperties
        {
            get
            {
                if (_clusteringProperties == null)
                {
                    _clusteringProperties = new Dictionary<string, decimal>();
                }

                return _clusteringProperties;
            }
        }

        /// <summary>
        /// Shorthand for accessing primary property.
        /// </summary>
        public object PrimaryProperty
        {
            get
            {
                return GenericProperties[PRIMARY_PROPERTY_KEY];
            }
            set
            {
                GenericProperties[PRIMARY_PROPERTY_KEY] = value;
            }
        }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        protected BaseUnit()
        {
        }

        /// <summary>
        /// Constructor which initialises primary property.
        /// </summary>
        /// <param name="o"></param>
        protected BaseUnit(object o)
        {
            PrimaryProperty = o;
        }

       



    }
}
