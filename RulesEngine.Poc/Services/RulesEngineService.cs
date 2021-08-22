using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RuleEngine.Poc.Public.Contracts.Configurations;
using RuleEngine.Poc.Public.Contracts.Providers;
using RuleEngine.Poc.Public.Contracts.Services;
using RulesEngine.Interfaces;
using RulesEngine.Models;

namespace RulesEngine.Poc.Services
{
    public class RulesEngineService : IRulesEngineService
    {
        private readonly IRulesEngine _rulesEngine;
        private readonly IWorkflowProvider _workflowProvider;

        public RulesEngineService([NotNull] IRulesEngine rulesEngine, [NotNull] IWorkflowProvider workflowProvider)
        {
            _rulesEngine = rulesEngine;
            _workflowProvider = workflowProvider;
        }

        public async Task<IWidgetConfiguration> GetWidgetConfiguration(string widgetType)
        {
            var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\WidgetConfigurations",
                $"{widgetType}.json", SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                throw new Exception("No Widget Configuration File Found!");
            }

            var fileText = await File.ReadAllTextAsync(files[0]);
            var jObject = JObject.Parse(fileText);
            var configurationType = jObject["Type"]?.ToString() ?? throw new ArgumentNullException(nameof(widgetType),
                $"Cannot fetch Type from Widget Configuration with type {widgetType}");
            var configuration = jObject.ToObject(Type.GetType(configurationType)!) as IWidgetConfiguration;

            return configuration;
        }

        public async Task<TSource> TransformConfiguration<TSource>(TSource config, Dictionary<string, object> @params)
            where TSource : IWidgetConfiguration
        {
            var workflowName = _workflowProvider.GetWorkflowName(config.ConfigurationKey);
            
            //Do nothing cause there are not patched to apply, therefore return the config as is... 
            if (string.IsNullOrEmpty(workflowName))
            {
                return config;
            }
                
            var ruleParameters = new List<RuleParameter> {new(nameof(config), config)};

            foreach (var param in @params)
            {
                ruleParameters.Add(new(param.Key, param.Value));
            }

            var result = await _rulesEngine.ExecuteAllRulesAsync(workflowName, ruleParameters.ToArray());
            var actionResult = result.LastOrDefault();

            if (actionResult != null)
            {
                config = (TSource) await (ValueTask<object>) actionResult.ActionResult.Output ?? config;
            }

            return config;
        }
    }
}