using System;
using System.Collections.Generic;
using System.Linq;
using AttentionPlease.Spa.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttentionPlease.Spa.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelebrationsController : ControllerBase
    {
        private readonly ILogger<CelebrationsController> _logger;

        public CelebrationsController(ILogger<CelebrationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Celebration> Get()
        {
            return new[]
            {
                new Celebration
                {
                    Date = DateTime.Parse("2015-02-22T22:11:00.000Z"),
                    Title = "Signe´s birthday", 
                    CelebrationType = CelebrationType.BirthDay
                },
                new Celebration
                {
                    Date = DateTime.Parse("2009-04-04T03:42:00.000Z"),
                    Title = "Desmond´s birthday", 
                    CelebrationType = CelebrationType.BirthDay
                },
                new Celebration
                {
                    Date = DateTime.Parse("2005-07-03T18:15:00.000Z"),
                    Title = "J+J first date", 
                    CelebrationType = CelebrationType.FirstDate
                },
                new Celebration
                {
                    Date = DateTime.Parse("2011-11-05T18:00:00.000Z"),
                    Title = "J+J wedding day",
                    CelebrationType = CelebrationType.WeddingDay
                },
                new Celebration
                {
                    Date = DateTime.Parse("1980-06-01T08:00:00.000Z"),
                    Title = "Jenny´s birthday",
                    CelebrationType = CelebrationType.BirthDay
                },
                new Celebration
                {
                    Date = DateTime.Parse("1980-05-16T12:00:00.000Z"),
                    Title = "Jonas´s birthday", 
                    CelebrationType = CelebrationType.BirthDay
                }
            };
        }
    }
}
