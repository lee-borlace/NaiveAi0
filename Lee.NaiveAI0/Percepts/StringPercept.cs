using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.Percepts
{
    /// <summary>
    /// A percept representing a text string.
    /// </summary>
    public class StringPercept : Percept
    {
        public StringPercept(string val):base(val)
        {
        }

        public override string PrimaryPropertyKey
        {
            get
            {
                return "PrimaryPropertyKey_StringPercept";
            }
        }
    }
}
