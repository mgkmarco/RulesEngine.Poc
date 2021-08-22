namespace RulesEngine.Poc.WebApi.DTOs
{
    public class CarouselDto
    {
        public string ConfigurationKey { get; set; }
        public int EventCount { get; set; } = 3;
        public int[] CarouselEventType { get; set; } = System.Array.Empty<int>();
        public int[] CarouselMarketType { get; set; } = System.Array.Empty<int>();
        public string[] MarketTemplateIds { get; set; } = System.Array.Empty<string>();
        public string[] OutrightMarketTemplateIds { get; set; } = System.Array.Empty<string>();
        public string[] PlayerMarketTemplateIds { get; set; } = System.Array.Empty<string>();
        public int CacheTime { get; set; } = 30;
    }
}