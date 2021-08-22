using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RuleEngine.Poc.Public.Contracts.Providers;
using RuleEngine.Poc.Public.Contracts.Services;
using RulesEngine.Actions;
using RulesEngine.Interfaces;
using RulesEngine.Models;
using RulesEngine.Poc.Actions;
using RulesEngine.Poc.Providers;
using RulesEngine.Poc.Services;

namespace RulesEngine.Poc.Extensions.Microsoft.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRulesEngine(this IServiceCollection services)
        {
            services.AddSingleton<IRulesEngine>(provider =>
            {
                var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Workflows", "*.json", SearchOption.AllDirectories);

                if (files.Length == 0)
                {
                    throw new Exception("No Workflow Rules Found!");   
                }

                var workflowRules = new List<WorkflowRules>();
                
                foreach (var file in files)
                {
                    var workflowData = File.ReadAllText(file);
                    var workflow = JsonConvert.DeserializeObject<List<WorkflowRules>>(workflowData);

                    if (workflow != null && workflow.Any())
                    {
                        workflowRules.AddRange(workflow);   
                    }
                }

                var logger = provider.GetRequiredService<ILogger<RulesEngine>>();
                return new RulesEngine(workflowRules.ToArray(), logger, new ReSettings
                {
                    CustomActions = new Dictionary<string, Func<ActionBase>>
                    {
                        {"MergeEventTableConfigurationAction", () => new MergeEventTableConfigurationAction()}
                    }
                });
            });
            
            services.AddSingleton<IRulesEngineService, RulesEngineService>();
            services.AddSingleton<IWorkflowProvider, WorkflowProvider>();
        }
    }
}