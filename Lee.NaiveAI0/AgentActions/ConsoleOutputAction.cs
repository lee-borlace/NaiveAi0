using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee.NaiveAI0.AgentActions
{
    /// <summary>
    /// An action which outputs a string to the console.
    /// </summary>
    public class ConsoleOutputAction : AgentAction
    {
        public override string PrimaryPropertyKey
        {
            get
            {
                return "PrimaryPropertyKey_ConsoleOutputAction";
            }
        }
        
        public override void Act()
        {
            Console.WriteLine(PrimaryProperty);                            
        }

        public ConsoleOutputAction():base()
        {
        }

        public ConsoleOutputAction(string val)
            : base(val)
        {
        }

    }
}
