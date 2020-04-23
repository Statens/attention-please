using System;

namespace AttentionPlease.Domain.Models
{
    public class Celebration
    {
        public Guid Id { get; internal set; }

        public DateTime Date { get; internal set; }

        public string Title { get; internal set; }

        public CelebrationType CelebrationType { get; internal set; }

        public Celebration()
        {
        }

        public Celebration(DateTime date, string title, CelebrationType celebrationType)
        {
            Id = Guid.NewGuid();
            Date = date;
            Title = title;
            CelebrationType = celebrationType;
        }

        public static Celebration Birthday(DateTime birthday, string name) 
            => new Celebration(birthday, name, CelebrationType.Birthday);
    }
}
