using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using RuleEnginePOCPublicContracts.Services;
using RulesEngine.Interfaces;
using RulesEngine.Models;

namespace RulesEnginePOC.Services
{
    public class RulesEngineService : IRulesEngineService
    {
        private readonly IRulesEngine _rulesEngine;
        
        public RulesEngineService([NotNull] IRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }
        
        public async Task<TSource> TransformConfiguration<TSource>(TSource config, Dictionary<string, object> @params)
        {
            var ruleParameters = new List<RuleParameter> {new(nameof(config), config)};
            
            foreach (var param in @params)
            {
                ruleParameters.Add(new (param.Key, param.Value));   
            }
            
            var result = await _rulesEngine.ExecuteAllRulesAsync("EventsTableWorkflow", ruleParameters.ToArray());
            var actionResult = result.LastOrDefault();
            
            if (actionResult != null)
            {
                config = (TSource) await (ValueTask<object>) actionResult.ActionResult.Output ?? config;
            }

            return config;
        }
    }
}