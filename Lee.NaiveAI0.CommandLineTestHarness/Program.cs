using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.Agents;
using Lee.NaiveAI0.Agents.BasicStringAgents;

namespace Lee.NaiveAI0.CommandLineTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            //var agent = new StringEchoAgent();
            var agent = new StringClusteringAgent1();

            var testHarness = new TestHarnesses.CommandLineTestHarness();

            testHarness.ProcessCommandLine(agent);

        }
    }
}
