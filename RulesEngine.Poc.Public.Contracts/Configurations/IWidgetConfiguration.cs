namespace RuleEngine.Poc.Public.Contracts.Configurations
{
    public interface IWidgetConfiguration
    {
        public string ConfigurationKey { get; set; }
        public int CacheTime { get; set; }
    }
}