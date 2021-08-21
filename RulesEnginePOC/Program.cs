using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RulesEngine.ExpressionBuilders;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using RulesEngine.Actions;
using RulesEnginePOC.Actions;
using static RulesEngine.Extensions.ListofRuleResultTreeExtension;

namespace RulesEnginePOC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // var basicInfo = "{\"name\": \"hello\",\"email\": \"abcy@xyz.com\",\"creditHistory\": \"good\",\"country\": \"canada\",\"loyalityFactor\": 3,\"totalPurchasesToDate\": 10000}";
            // var orderInfo = "{\"totalOrders\": 5,\"recurringItems\": 2}";
            // var telemetryInfo = "{\"noOfVisitsPerMonth\": 10,\"percentageOfBuyingToVisit\": 15}";
            //
            // var converter = new ExpandoObjectConverter();
            //
            // dynamic input1 = JsonConvert.DeserializeObject<ExpandoObject>(basicInfo, converter);
            // dynamic input2 = JsonConvert.DeserializeObject<ExpandoObject>(orderInfo, converter);
            // dynamic input3 = JsonConvert.DeserializeObject<ExpandoObject>(telemetryInfo, converter);
            //
            // var inputs = new dynamic[]
            // {
            //     input1,
            //     input2,
            //     input3
            // };
            //
            // var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "rules.json", SearchOption.AllDirectories);
            // if (files == null || files.Length == 0)
            //     throw new Exception("Rules not found.");
            //
            // var fileData = File.ReadAllText(files[0]);
            // var workflow = JsonConvert.DeserializeObject<List<RulesEngine.Models.WorkflowRules>>(fileData);

            // var bre = new RulesEngine.RulesEngine(workflow.ToArray(), null, new ReSettings
            // {
            //     CustomActions = new Dictionary<string, System.Func<RulesEngine.Actions.ActionBase>> 
            //     {
            //         { "OutputExpression", () => new OutputExpressionAction() }
            //     }
            // });

            //string discountOffered = "No discount offered.";

            //List<RuleResultTree> resultList = await bre.ExecuteAllRulesAsync("Discount", inputs);
                
            // resultList.OnSuccess(eventName =>
            // {
            //     Console.WriteLine("in here");
            // });

            // var bre1 = new RulesEngine.RulesEngine(workflow.ToArray(), null);
            // var result1 = await bre1.ExecuteActionWorkflowAsync("Discount", "MarcoTest", new RuleParameter[0]);
            // var outp = result1.Output;
            // result1.Results.OnSuccess(x =>
            // {
            //     Console.WriteLine("asdadasd");
            // });
            
            
            
            
            
            
            
            
            
            // var re = new RulesEngine.RulesEngine(workflow.ToArray(), null, reSettings: new ReSettings {
            //     CustomActions = new Dictionary<string, System.Func<ActionBase>> {
            //
            //         { "CustomExpression", () => new CustomExpressionAction() }
            //     }
            // });
            //
            //
            // var result = await re.ExecuteAllRulesAsync("Discount", true);
            
        }
    }
}