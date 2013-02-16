using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.Agents
{
    public abstract class Agent
    {
        /// <summary>
        /// Percepts for a particular call of the agent function.
        /// </summary>
        protected List<Percept> _percepts;

        /// <summary>
        /// Actions to take for a particular call of the agent function.
        /// </summary>
        protected List<AgentAction> _actions;
        
        /// <summary>
        /// Take a list of percepts and act on them.
        /// </summary>
        /// <param name="percepts"></param>
        /// <returns></returns>
        public void InitialiseActionsAndPercepts(List<Percept> percepts)
        {
            _actions = new List<AgentAction>();
            _percepts = percepts;
        }

        public abstract List<AgentAction> AgentFunction(List<Percept> percepts);
    }
}
