﻿using System.Collections.Generic;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttentionPlease.Spa.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelebrationsController : ControllerBase
    {
        private readonly ILogger<CelebrationsController> _logger;
        private readonly CelebrationService _celebrationService;

        public CelebrationsController(
            CelebrationService celebrationService,
            ILogger<CelebrationsController> logger)
        {
            _celebrationService = celebrationService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Celebration> Get()
        {
            return _celebrationService.AllCelebrations();
        }
    }
}
