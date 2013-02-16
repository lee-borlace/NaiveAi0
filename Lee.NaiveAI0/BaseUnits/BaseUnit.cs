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
        public abstract string PrimaryPropertyKey { get; }

        /// <summary>
        /// The properties of the unit.
        /// </summary>
        protected Dictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Shorthand for accessing primary property.
        /// </summary>
        public object PrimaryProperty
        {
            get
            {
                return Properties[PrimaryPropertyKey];
            }
            set
            {
                Properties[PrimaryPropertyKey] = value;
            }
        }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        protected BaseUnit()
        {
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Constructor which initialises primary property.
        /// </summary>
        /// <param name="o"></param>
        protected BaseUnit(object o)
        {
            Properties = new Dictionary<string, object>();

            PrimaryProperty = o;
        }

       



    }
}
