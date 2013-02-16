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
        public const string KEY_LENGTH = "Key_StringPercept_Length";
        public const string KEY_STARTS_WITH = "Key_StringPercept_StartsWith";

        protected string _value;

        public StringPercept(string val):base(val)
        {
            _value = val;

            //Extract features from the percept.
            ExtractFeatures();
        }

        public override string PRIMARY_PROPERTY_KEY
        {
            get
            {
                return "PrimaryPropertyKey_StringPercept";
            }
        }

        protected override void ExtractFeatures()
        {
            ClusteringProperties[KEY_LENGTH] = _value.Length;
            ClusteringProperties[KEY_STARTS_WITH] = (!string.IsNullOrEmpty(_value) ? _value[0] : 0);
        }
    }
}
