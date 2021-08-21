using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuleEnginePOCPublicContracts.Services
{
    public interface IRulesEngineService
    {
        Task<TSource> TransformConfiguration<TSource>(TSource config, Dictionary<string, object> @params);
    }
}