using System.Collections.Generic;
using System.Text;
using Lee.NaiveAI0.AgentActions;
using Lee.NaiveAI0.Clustering;
using Lee.NaiveAI0.Clustering.Clusterers;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.Agents.BasicStringAgents
{
    /// <summary>
    /// Agent that does some basic clustering on string inputs.
    /// </summary>
    public class StringClusteringAgent1 : Agent
    {
        protected FuzzyClusterer _clusterer;

        public StringClusteringAgent1()
        {
            _clusterer = new FuzzyClusterer();
        }
        
        public override List<AgentAction> AgentFunction(List<Percept> percepts)
        {
            InitialiseActionsAndPercepts(percepts);

            foreach (Percept percept in _percepts)
            {
                if(percept is StringPercept)
                {
                    ProcessStringPercept(percept as StringPercept);   
                }
            }

            return _actions;
        }


        protected void ProcessStringPercept(StringPercept percept)
        {
            StringBuilder sb = new StringBuilder();

            
            List<ClusterMembership> clusterMemberships = _clusterer.GetClustersForElement(new ClusteringVector(percept.ClusteringProperties), false);

            foreach (ClusterMembership membership in clusterMemberships)
            {
                sb.Append(membership.ToString());
            }

            _actions.Add(new ConsoleOutputAction(sb.ToString()));                
        }


    }
}
