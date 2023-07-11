using Microsoft.AspNetCore.SignalR;

namespace scada.Hubs
{
    public class AlarmsHub : Hub<IAlarmHubClient>
    {
        public async Task Send(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }

}

