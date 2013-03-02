using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.NeuralNets
{
    public class Neuron
    {
        public List<WeightedNeuronConnection> Inputs { get; set; }
        
        public double ActivationLevel { get; set; }

        public string Name { get; set; }

        public Neuron()
        {
            Inputs = new List<WeightedNeuronConnection>();
            ActivationLevel = 0;
            Name = null;
        }

        public Neuron(string name)
        {
            Inputs = new List<WeightedNeuronConnection>();
            ActivationLevel = 0;
            Name = name;
        }
        

        public void AddConnection(Neuron neuron, double weight)
        {
            Inputs.Add(new WeightedNeuronConnection(neuron, weight));
        }


        public void AddConnection(double fixedActivationLevel, double weight)
        {
            Inputs.Add(new WeightedNeuronConnection(fixedActivationLevel, weight));
        }


        /// <summary>
        /// Add special connection to simulate step function threshold for the neuron. A fixed activation level of -1 is used with threshold
        /// used as weight.
        /// </summary>
        /// <param name="fixedActivationLevel"></param>
        /// <param name="weight"></param>
        public void AddConnectionToSimulateStepThreshold(double threshold)
        {
            Inputs.Add(new WeightedNeuronConnection(-1, threshold));
        }




        public void ProcessInputs(ActivationFunction activationFunction)
        {
            if (Inputs.Count > 0)
            {
                double functionInput = 0;

                foreach (WeightedNeuronConnection connection in Inputs)
                {
                    functionInput += connection.Weight * connection.GetActivationLevel();
                }

                ActivationLevel = activationFunction(functionInput);
               
            }
        }

       

    }
}
