using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuleEnginePOCPublicContracts.Services;
using RulesEnginePOC.Configurations;
using RulesEnginePOCWebApi.DTOs;

namespace RulesEnginePOCWebApi.Controllers
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
        public async Task<EventsTableDto> BuildConfiguration([FromQuery] int categoryId, [FromQuery] string eventPhase, [FromQuery] Guid segmentGuid)
        {
            var config = new EventsTableConfiguration();
            
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
                await _rulesEngineService.TransformConfiguration(config, parameters);

            var eventsTableDto = _mapper.Map<EventsTableDto>(transformedConfiguration);
            
            return eventsTableDto;
        }
    }
}