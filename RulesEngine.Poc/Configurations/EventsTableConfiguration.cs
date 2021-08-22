using System;
using RuleEngine.Poc.Public.Contracts.Configurations;

namespace RulesEngine.Poc.Configurations
{
    public class EventsTableConfiguration : IEventsTableConfiguration
    {
        public string ConfigurationKey { get; set; }
        public string[] MarketTemplateIds { get; set; } = Array.Empty<string>();
        public int PageSize { get; set; } = 0;
        public int LastPageOverflowThreshold { get; set; } = 5;
        public int MaximumNumberOfSelections { get; set; } = 3;
        public int Style { get; set; }
        public int CacheTime { get; set; } = 30;
    }
}