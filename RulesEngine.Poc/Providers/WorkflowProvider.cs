using RuleEngine.Poc.Public.Contracts.Providers;

namespace RulesEngine.Poc.Providers
{
    public class WorkflowProvider : IWorkflowProvider
    {
        public string GetWorkflowName(string widgetType)
        {
            switch (widgetType)
            {
                case "EventsTable-v1":
                case "EventsTable-v2":
                case "BannerWidget-v1":
                {
                    return "EventsTableWorkflow";
                }
                case "MarketList-v1":
                {
                    return "MarketListWorkflow";
                }
            }

            return null;
        }
    }
}