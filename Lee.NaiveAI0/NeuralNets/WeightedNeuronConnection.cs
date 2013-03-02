using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.NeuralNets
{
    public class WeightedNeuronConnection
    {
        public double Weight { get; set; }

        public Neuron Neuron { get; set; }

        public double FixedActivationLevel { get; set; }
        
        /// <summary>
        /// Create connection based on a neuron.
        /// </summary>
        /// <param name="connectedNeuron"></param>
        /// <param name="weight"></param>
        public WeightedNeuronConnection(Neuron connectedNeuron, double weight)
        {
            Neuron = connectedNeuron;
            Weight = weight;
        }


        /// <summary>
        /// Create connection with fixed activation level.
        /// </summary>
        /// <param name="fixedActivationLevel"></param>
        /// <param name="weight"></param>
        public WeightedNeuronConnection(double fixedActivationLevel, double weight)
        {
            Neuron = null;
            FixedActivationLevel = fixedActivationLevel;
            Weight = weight;
        }




        /// <summary>
        /// Get effective activation level. If neuron is present use its activation level, else fixed activation level.
        /// </summary>
        /// <returns></returns>
        public double GetActivationLevel()
        {
            return Neuron != null ? Neuron.ActivationLevel : FixedActivationLevel;
        }

    }
}
