using System.Threading.Tasks;

namespace AttentionPlease.Spa.SignalR
{
    public interface IHubClient
    {
        Task BroadcastMessage(MessageInstance msg);
    }
}
