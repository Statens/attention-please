using System;
using System.Collections.Generic;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Repositories;
using AttentionPlease.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttentionPlease.Spa.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly CelebrationService _celebrationService;
        private readonly ILogger<CalendarController> _logger;

        public CalendarController(
            CelebrationService celebrationService,
            ILogger<CalendarController> logger)
        {
            _celebrationService = celebrationService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Calendar> List()
        {
            _logger.LogDebug(GetType().Name);

            return _celebrationService.Calendars();

        }
    }
}