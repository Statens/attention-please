using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Services;
using AttentionPlease.Spa.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace AttentionPlease.Spa.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelebrationsController : ControllerBase
    {
        private readonly ILogger<CelebrationsController> _logger;
        private readonly CelebrationService _celebrationService;

        private readonly IHubContext<SignalrHub, IHubClient> _signalrHub;

        public CelebrationsController(
            CelebrationService celebrationService,
            ILogger<CelebrationsController> logger,
            IHubContext<SignalrHub, IHubClient> signalrHub)
        {
            _celebrationService = celebrationService;
            _logger = logger;
            _signalrHub = signalrHub;
        }

        [HttpGet]
        public async Task<IEnumerable<Celebration>> Get()
        {
            await _signalrHub.Clients.All.BroadcastMessage(new MessageInstance
            {
                From = GetType().Name, 
                Message = "Called Get()", 
                Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });
            return _celebrationService.AllCelebrations();
        }
    }
}
