using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.Agents
{
    /// <summary>
    /// Trivial agent that repeats back an input string.
    /// </summary>
    public class StringEchoAgent : IAgent
    {
        public StringEchoAgent()
        {
        }

        public List<AgentAction> AgentFunction(List<Percept> percepts)
        {
            List<AgentAction> actions = new List<AgentAction>();

            foreach (Percept percept in percepts)
            {
                if(percept is StringPercept)
                {
                    StringPercept stringPercept = percept as StringPercept;
                    actions.Add(new ConsoleOutputAction(stringPercept.PrimaryProperty.ToString()));
                }

                
            }

            return actions;
        }
    }
}
