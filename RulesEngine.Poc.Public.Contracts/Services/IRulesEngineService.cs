using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuleEngine.Poc.Public.Contracts.Services
{
    public interface IRulesEngineService
    {
        Task<TSource> TransformConfiguration<TSource>(TSource config, Dictionary<string, object> @params);
    }
}