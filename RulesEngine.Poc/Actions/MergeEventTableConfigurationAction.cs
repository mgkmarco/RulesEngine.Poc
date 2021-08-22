using System;
using System.Linq;
using System.Threading.Tasks;
using RulesEngine.Actions;
using RulesEngine.Models;
using RulesEngine.Poc.Configurations;
using RulesEngine.Poc.Extensions;

namespace RulesEngine.Poc.Actions
{
    public class MergeEventTableConfigurationAction : ActionBase
    {
        public override async ValueTask<object> Run(ActionContext context, RuleParameter[] ruleParameters)
        {
            var configuration = (EventsTableConfiguration) ruleParameters.ToList().FirstOrDefault(x =>
                string.Equals("config", x.Name, StringComparison.InvariantCultureIgnoreCase))?.Value ?? new EventsTableConfiguration();

            var marketTemplateIds =
                context.GetValueOrFallback(nameof(EventsTableConfiguration.MarketTemplateIds), configuration.MarketTemplateIds);
            var pageSize = context.GetValueOrFallback(nameof(EventsTableConfiguration.PageSize), configuration.PageSize);
            var lastPageOverflowThreshold = context.GetValueOrFallback(nameof(EventsTableConfiguration.LastPageOverflowThreshold), configuration.LastPageOverflowThreshold);
            var maximumNumberOfSelections = context.GetValueOrFallback(nameof(EventsTableConfiguration.MaximumNumberOfSelections), configuration.MaximumNumberOfSelections);
            var cacheTime = context.GetValueOrFallback(nameof(EventsTableConfiguration.CacheTime), configuration.CacheTime);
            var style = context.GetValueOrFallback(nameof(EventsTableConfiguration.Style), configuration.Style);

            configuration.MarketTemplateIds = marketTemplateIds;
            configuration.PageSize = pageSize;
            configuration.LastPageOverflowThreshold = lastPageOverflowThreshold;
            configuration.MaximumNumberOfSelections = maximumNumberOfSelections;
            configuration.CacheTime = cacheTime;
            configuration.Style = style;
            
            return new ValueTask<object>(configuration);
        }
    }
}