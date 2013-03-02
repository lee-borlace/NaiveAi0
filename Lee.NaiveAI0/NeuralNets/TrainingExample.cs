using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.NeuralNets
{
    public class TrainingExample
    {
        /// <summary>
        /// Vector of inputs for the example.
        /// </summary>
        public List<double> Inputs { get; set; }

        /// <summary>
        /// Vector of outputs for the example.
        /// </summary>
        public List<double> Outputs { get; set; }
    }
}
