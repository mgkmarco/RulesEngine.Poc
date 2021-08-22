using System.Collections.Generic;
using System.Threading.Tasks;
using RuleEngine.Poc.Public.Contracts.Configurations;

namespace RuleEngine.Poc.Public.Contracts.Services
{
    public interface IRulesEngineService
    {
        Task<IWidgetConfiguration> GetWidgetConfiguration(string widgetType);

        Task<TSource> TransformConfiguration<TSource>(TSource config, Dictionary<string, object> @params)
            where TSource : IWidgetConfiguration;
    }
}