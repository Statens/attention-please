namespace AttentionPlease.Domain.Models
{
    public class CalendarSubscription
    {
        public virtual int Id { get; set; }

        public virtual Calendar Calendar { get; set; }

        //public virtual Guid CalendarId { get; set; }

        public virtual string UserId { get; set; }
    }
}