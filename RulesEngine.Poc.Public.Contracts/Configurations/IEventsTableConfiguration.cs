namespace RuleEngine.Poc.Public.Contracts.Configurations
{
    public interface IEventsTableConfiguration : IWidgetConfiguration
    {
        string[] MarketTemplateIds { get; set; }
        int PageSize { get; set; }
        int LastPageOverflowThreshold { get; set; }
        int MaximumNumberOfSelections { get; set; }
        int Style { get; set; }
    }
}