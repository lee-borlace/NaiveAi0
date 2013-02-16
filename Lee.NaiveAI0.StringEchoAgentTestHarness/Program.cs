using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Agents;
using Lee.NaiveAI0.Percepts;
using Lee.NaiveAI0.TestHarnesses;

namespace Lee.NaiveAI0.StringEchoAgentTestHarness
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringEchoAgent agent = new StringEchoAgent();

            string lastInput = string.Empty;

            while(!lastInput.Equals("quit", StringComparison.OrdinalIgnoreCase) && !lastInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                List<Percept> percepts = GetPercepts();

                List<AgentAction> actions = agent.AgentFunction(percepts);

                foreach (AgentAction action in actions)
                {
                    action.Act();
                }

                lastInput = percepts[0].PrimaryProperty.ToString();
            }

            

        }

        public static List<Percept> GetPercepts()
        {
            Console.Write(">");

            List<Percept> retVal = new List<Percept>();

            retVal.Add(new StringPercept(Console.ReadLine()));

            return retVal;
        }
    }
}
