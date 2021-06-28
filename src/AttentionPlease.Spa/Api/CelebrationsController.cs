using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Services;
using AttentionPlease.Spa.Presentation.PresentationModels;
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

        [HttpPost]
        public async Task SendMessage()
        {
            await _signalrHub.Clients.All.BroadcastMessage(new MessageInstance
            {
                From = GetType().Name,
                Message = "Called SendMessage()",
                Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });
        }

        [HttpGet]
        public async Task<IEnumerable<CelebrationViewModel>> Get()
        {
            await _signalrHub.Clients.All.BroadcastMessage(new MessageInstance
            {
                From = GetType().Name,
                Message = "Called Get()",
                Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });
            var now = DateTime.Now;
            return _celebrationService.AllCelebrations()
            .Select(c =>
            {
                var next = CalculateNext(c.Date);
                return new CelebrationViewModel
                {
                    Title = c.Title, 
                    NextOccurrence = next.ToString(),
                    NextOccurrenceCountDown = next.Date.Subtract(DateTime.Now.Date).TotalDays.ToString()
                };
            }).OrderBy(x => x.NextOccurrence);
        }

        private DateTime CalculateNext(DateTime date)
        {
            var next = date;
            while (next < DateTime.Now)
            {
                next = next.AddYears(1);
            }
            return next;
        }
    }
}
