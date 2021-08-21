namespace RulesEngine.Poc.WebApi.DTOs
{
    public class EventsTableDto
    {
        public string[] MarketTemplateIds { get; set; } = System.Array.Empty<string>();
        public int PageSize { get; set; } = 0;
        public int LastPageOverflowThreshold { get; set; } = 5;
        public int MaximumNumberOfSelections { get; set; } = 3;
        public int CacheTime { get; set; } = 30;
    }
}