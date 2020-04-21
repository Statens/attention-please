using System;

namespace AttentionPlease.Spa.Domain.Models
{
    public class Celebration
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public CelebrationType CelebrationType { get; set; }    
    }
}
