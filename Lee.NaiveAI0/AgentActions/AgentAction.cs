using Lee.NaiveAI0.BaseUnits;

namespace Lee.NaiveAI0.AgentActions
{
    /// <summary>
    /// Action base class. Based on the properties of the baseunit, perform an action.
    /// </summary>
    public abstract class AgentAction : BaseUnit
    {
        /// <summary>
        /// Carry out the action.
        /// </summary>
        public abstract void Act();

        protected AgentAction()
            :base()
        {
        }

        protected AgentAction(object o)
            : base(o)
        {
        }
    }
}
