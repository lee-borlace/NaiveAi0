using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.NeuralNets
{
    public delegate double ActivationFunction(double input);

    public class NeuralNet
    {
        #region Core Properties

        public List<Neuron> AllNeurons { get; set; }

        public List<Neuron> Inputs { get; set; }

        public List<Neuron> Outputs { get; set; }

        public ActivationFunction ActivationFunction { get; set; }

        #endregion

        
        #region Constructors

        public NeuralNet()
        {
            AllNeurons = new List<Neuron>();
            Inputs = new List<Neuron>();
            Outputs = new List<Neuron>();
        }

        #endregion
        

        #region Network Creation Methods


        public void CreateMinorityFunction(bool randomiseWeights)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            ActivationFunction = x => x >= 0 ? 1 : 0;

            Neuron i_1 = new Neuron("i_1");
            AllNeurons.Add(i_1);
            Inputs.Add(i_1);

            Neuron i_2 = new Neuron("i_2");
            AllNeurons.Add(i_2);
            Inputs.Add(i_2);

            Neuron i_3 = new Neuron("i_3");
            AllNeurons.Add(i_3);
            Inputs.Add(i_3);

            Neuron o_1 = new Neuron("o_1");
            AllNeurons.Add(o_1);

            //If we're going straight to the known solution, weights are -1.5 (threshold), -1, -1, -1.

            //This is a special input with fixed activation level. Esentially sets the threshold for neuron to be -1.5
            if (randomiseWeights)
            {
                o_1.AddConnection(-1, GetRandomWeight(-1,1, rand));
            }
            else
            {
                o_1.AddConnectionToSimulateStepThreshold(-1.5);
            }

            o_1.AddConnection(i_1, randomiseWeights ? GetRandomWeight(-1, 1, rand) : -1);
            o_1.AddConnection(i_2, randomiseWeights ? GetRandomWeight(-1, 1, rand) : -1);
            o_1.AddConnection(i_3, randomiseWeights ? GetRandomWeight(-1, 1, rand) : -1);

            Outputs.Add(o_1);
        }



        private double GetRandomWeight(double min, double max, Random rand)
        {
            double range = max - min;

            double randomPointInRange = rand.NextDouble() * range;

            return randomPointInRange + min;
        }


        #endregion



        #region Training



        public void Train(List<TrainingExample> examples, int numberOfIterations, double marginOfError, double learningRate)
        {
            for (int iteration = 0; iteration < numberOfIterations; iteration++)
            {

                //Iterate through each training example.
                foreach (TrainingExample example in examples)
                {
                    //Set up inputs of net.
                    InitialiseInputs(example.Inputs);

                    //Run the net.
                    ProcessIteration();

                    //If the results don't match the example, need to adjust the net.
                    for (int i = 0; i < Outputs.Count; i++)
                    {
                        Neuron outputNeuron = Outputs[i];

                        //Get difference between actual and example value.
                        double error = example.Outputs[i] - outputNeuron.ActivationLevel;

                        //Doesn't match.
                        if (Math.Abs(error) > marginOfError)
                        {
                            //Iterate through node's inputs.
                            foreach(WeightedNeuronConnection connection in outputNeuron.Inputs)
                            {
                                double previousWeight = connection.Weight;

                                double weightDelta = learningRate * connection.GetActivationLevel() * error;

                                connection.Weight = previousWeight + weightDelta;
                            }
                        }
                    }

                }
            }
        }



        #endregion


        /// <summary>
        /// Check 2 vectors of doubles for equality.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public static bool DoubleVectorsEqual(List<double> input1, List<double> input2)
        {
            if (input1 == null && input2 != null)
            {
                return false;
            }
            if (input1 != null && input2 == null)
            {
                return false;
            }
            if (input1 == null && input2 == null)
            {
                return true;
            }
            if (input1.Count != input2.Count)
            {
                return false;
            }

            for (int i = 0; i < input1.Count; i++)
            {
                if (!input1[i].Equals(input2[i]))
                {
                    return false;
                }
            }

            return true;


        }


        /// <summary>
        /// Convert the activation levels of a vector of neurons into a vector of doubles.
        /// </summary>
        /// <param name="neurons"></param>
        /// <returns></returns>
        public static List<double> NeuronVectorToDoubleVector(List<Neuron> neurons)
        {
            List<double> retVal = new List<double>(neurons.Count);

            foreach (Neuron neuron in neurons)
            {
                retVal.Add(neuron.ActivationLevel);
            }

            return retVal;
        }


        /// <summary>
        /// Initialise input neurons based on a vector of doubles.
        /// </summary>
        /// <param name="inputVector"></param>
        public void InitialiseInputs(List<double> inputVector)
        {
            if (inputVector.Count > Inputs.Count)
            {
                throw new Exception("Cannot provide more inputs than there are input neurons.");
            }

            for (int i = 0; i < inputVector.Count; i++)
            {
                Inputs[i].ActivationLevel = inputVector[i];
            }
        }



        /// <summary>
        /// Get vector of output activation levels.
        /// </summary>
        /// <returns></returns>
        public List<double> GetOutputVector()
        {
            List<double> retVal = new List<double>(Outputs.Count);

            foreach (Neuron neuron in Outputs)
            {
                retVal.Add(neuron.ActivationLevel);
            }

            return retVal;
        }


        /// <summary>
        /// Process an iteration of the neural net.
        /// </summary>
        public void ProcessIteration()
        {
            int neuronCount = AllNeurons.Count;

            for (int i = 0; i < neuronCount; i++)
            {
                Neuron neuron = AllNeurons[i];

                neuron.ProcessInputs(ActivationFunction);
            }

            _iteration++;
        }



        public string VisualiseWeights()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{Weights: {");

            foreach(Neuron neuron in AllNeurons)
            {
                if (neuron.Inputs != null && neuron.Inputs.Count > 0)
                {
                    sb.Append("{");

                    
                    if (!string.IsNullOrEmpty(neuron.Name))
                    {
                        sb.Append(neuron.Name);
                        sb.Append(": ");
                    }

                    sb.Append("{");

                    foreach(WeightedNeuronConnection connection in neuron.Inputs)
                    {
                        sb.Append(connection.Weight.ToString("F"));

                        if (connection != neuron.Inputs.Last())
                        {
                            sb.Append(",");
                        }
                    }
                    
                    sb.Append("}");

                    sb.Append("}");

                    if (neuron != AllNeurons.Last())
                    {
                        sb.Append(",");
                    }
                }
            }
            
            sb.Append("}}");

            return sb.ToString();
        }


        /// <summary>
        /// Return a string visualisation of inputs.
        /// </summary>
        /// <returns></returns>
        public string VisualiseInput()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{input: {");

            foreach (Neuron neuron in Inputs)
            {
                sb.Append(neuron.ActivationLevel.ToString("F"));

                if (neuron != Inputs.Last())
                {
                    sb.Append(",");
                }
            }

            sb.Append("}}");

            return sb.ToString();
        }



        /// <summary>
        /// Return a string visualisation of outputs.
        /// </summary>
        /// <returns></returns>
        public string VisualiseOutput()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{output: {");

            foreach (Neuron neuron in Outputs)
            {
                sb.Append(neuron.ActivationLevel.ToString("F"));

                if (neuron != Outputs.Last())
                {
                    sb.Append(",");
                }
            }

            sb.Append("}}");

            return sb.ToString();
        }



    }
}
