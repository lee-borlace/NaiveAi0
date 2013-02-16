using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.Agents
{
    public interface IAgent
    {
        /// <summary>
        /// Take a list of percepts and act on them.
        /// </summary>
        /// <param name="percepts"></param>
        /// <returns></returns>
        List<AgentAction> AgentFunction(List<Percept> percepts);
    }
}
