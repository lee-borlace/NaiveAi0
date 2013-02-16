using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lee.NaiveAI0.Percepts;

namespace Lee.NaiveAI0.TestHarnesses
{
    /// <summary>
    /// Abstract base test harness class.
    /// </summary>
    public abstract class TestHarness
    {
        public abstract List<Percept> GetPercepts();
    }
}
