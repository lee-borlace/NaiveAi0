using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.BaseUnits;

namespace Lee.NaiveAI0.Percepts
{
    /// <summary>
    /// Percept base class.
    /// </summary>
    public abstract class Percept : BaseUnit
    {
        /// <summary>
        /// Sub-percepts contained in this percept.
        /// </summary>
        public List<Percept> Percepts { get; set; }

        protected Percept()
            :base()
        {
        }


        protected Percept(object o)
            :base(o)
        {
        }


    }
}
