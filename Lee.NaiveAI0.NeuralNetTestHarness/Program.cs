using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.NeuralNets;

namespace Lee.NaiveAI0.NeuralNetTestHarness
{
    class Program
    {
        private static NeuralNet _neuralNet;

        const int TIMES_TO_RUN_SIMULATION = 20;

        const bool RUN_TRAINING = true;

        const int NUMBER_OF_TRAINING_EXAMPLES = 3;

        const int NUMBER_OF_TRAINING_ITERATIONS = 10000;

        const double TRAINING_MARGIN_OF_ERROR = 0.1;

        const double LEARNING_RATE = 0.1;
        
        static void Main(string[] args)
        {
            for (int i = 0; i < TIMES_TO_RUN_SIMULATION; i++)
            {
                _neuralNet = new NeuralNet();

                _neuralNet.CreateMinorityFunction(RUN_TRAINING);

                //Train.
                if (RUN_TRAINING)
                {
                    _neuralNet.Train(GetExamples(), NUMBER_OF_TRAINING_ITERATIONS, TRAINING_MARGIN_OF_ERROR, LEARNING_RATE);
                }

                //Run net on non-trained examples.
                RunNetOnInputs();
            }

        }

        

        static List<TrainingExample> GetExamples()
        {
            List<TrainingExample> allExamples = new List<TrainingExample>();

            TrainingExample example = new TrainingExample();
            example.Inputs = new List<double>() { 0, 0, 0 };
            example.Outputs = new List<double>() { 1 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 0, 0, 1 };
            example.Outputs = new List<double>() { 1 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 0, 1, 0 };
            example.Outputs = new List<double>() { 1 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 0, 1, 1 };
            example.Outputs = new List<double>() { 0 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 1, 0, 0 };
            example.Outputs = new List<double>() { 1 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 1, 0, 1 };
            example.Outputs = new List<double>() { 0 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 1, 1, 0 };
            example.Outputs = new List<double>() { 0 };
            allExamples.Add(example);

            example = new TrainingExample();
            example.Inputs = new List<double>() { 1, 1, 1 };
            example.Outputs = new List<double>() { 0 };
            allExamples.Add(example);

            if (NUMBER_OF_TRAINING_EXAMPLES > allExamples.Count)
            {
                throw new Exception("Tried to run training on more examples than were present.");
            }

            Random rand = new Random((int)DateTime.Now.Ticks);

            List<TrainingExample> retVal = new List<TrainingExample>();

            //Choose NUMBER_OF_TRAINING_EXAMPLES distinct examples.
            for(int i=0 ; i< NUMBER_OF_TRAINING_EXAMPLES ; i++)
            {
                TrainingExample randomExample = null;

                do
                {
                    int exampleIndex = rand.Next(0, allExamples.Count);
                    randomExample = allExamples[exampleIndex];
                }
                while (retVal.Contains(randomExample));

                retVal.Add(randomExample);
                
            }

            return retVal;

        }
        

        static void RunNetOnInputs()
        {
            int correctCount = 0;
            int totalCount = 0;

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        _neuralNet.InitialiseInputs(new List<double>() { i, j, k });

                        _neuralNet.ProcessIteration();

                        //Console.WriteLine(_neuralNet.VisualiseInput());
                        //Console.WriteLine(_neuralNet.VisualiseOutput());

                        List<double> expectedResult =
                            GetExpectedResultForInput(NeuralNet.NeuronVectorToDoubleVector(_neuralNet.Inputs));

                        List<double> actualResult = _neuralNet.GetOutputVector();

                        if (NeuralNet.DoubleVectorsEqual(expectedResult, actualResult))
                        {
                            //Console.WriteLine("Correct");
                            correctCount++;
                        }
                        else
                        {
                            //Console.WriteLine("Incorrect");
                        }

                        totalCount++;

                        //Console.WriteLine();
                    }
                }
            }

            //Console.WriteLine("Correctness level = " + ((double)correctCount / (double)totalCount * 100) + " %. Weights : " + _neuralNet.VisualiseWeights());
            Console.WriteLine("Correctness level = " + ((double)correctCount / (double)totalCount * 100) + " %.");

        }



        static List<double> GetExpectedResultForInput(List<double> inputs)
        {
            return (inputs.Count(i => i.Equals(0)) > inputs.Count(i => i.Equals(1)))
                       ? new List<double>() { 1 }
                       : new List<double>() { 0 };
        }







    }
}
