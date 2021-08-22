namespace RuleEngine.Poc.Public.Contracts.Configurations
{
    public interface ICarouselConfiguration : IWidgetConfiguration
    {
        public int EventCount { get; set; }
        public int[] CarouselEventType { get; set; }
        public int[] CarouselMarketType { get; set; }
        public string[] MarketTemplateIds { get; set; }
        public string[] OutrightMarketTemplateIds { get; set; }
        public string[] PlayerMarketTemplateIds { get; set; }
    }
}