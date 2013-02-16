using System.Collections.Generic;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.Agents.BasicStringAgents
{
    /// <summary>
    /// Trivial agent that repeats back an input string.
    /// </summary>
    public class StringEchoAgent : Agent
    {
        public override List<AgentAction> AgentFunction(List<Percept> percepts)
        {
            InitialiseActionsAndPercepts(percepts);
            
            //Iterate through percepts, echoing each back as an action.
            foreach (Percept percept in _percepts)
            {
                if(percept is StringPercept)
                {
                    StringPercept stringPercept = percept as StringPercept;
                    _actions.Add(new ConsoleOutputAction(stringPercept.PrimaryProperty.ToString()));
                }
            }

            return _actions;
        }
    }
}
