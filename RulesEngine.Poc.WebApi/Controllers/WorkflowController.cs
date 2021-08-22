using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuleEngine.Poc.Public.Contracts.Configurations;
using RuleEngine.Poc.Public.Contracts.Services;
using RulesEngine.Poc.Configurations;
using RulesEngine.Poc.WebApi.DTOs;

namespace RulesEngine.Poc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IRulesEngineService _rulesEngineService;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController([NotNull] IRulesEngineService rulesEngineService, [NotNull] IMapper mapper,
            [NotNull] ILogger<WorkflowController> logger)
        {
            _rulesEngineService = rulesEngineService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IWidgetConfiguration> BuildConfiguration([FromQuery] string widgetType, [FromQuery] int categoryId,
            [FromQuery] string eventPhase,
            [FromQuery] Guid segmentGuid)
        {
            // validation for the sake of the POC
            if (!new[] {"CarouselWidget", "EventsTableWidget"}.Any(c =>
                string.Equals(c, widgetType, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidEnumArgumentException($"Widget Type provided is not allowed! Allowed values are: CarouselWidget, EventsTableWidget");
            }

            // Pull the config... this can be mem cache or whatever
            var widgetConfiguration = await _rulesEngineService.GetWidgetConfiguration(widgetType);

            var parameters = new Dictionary<string, object>
            {
                {
                    nameof(categoryId), categoryId
                },
                {
                    nameof(eventPhase), eventPhase
                },
                {
                    nameof(segmentGuid), segmentGuid
                }
            };

            var transformedConfiguration =
                await _rulesEngineService.TransformConfiguration(widgetConfiguration, parameters);

            return transformedConfiguration;
        }
    }
}