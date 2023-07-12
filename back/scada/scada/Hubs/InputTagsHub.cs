using Microsoft.AspNetCore.SignalR;

namespace scada.Hubs
{
    public class InputTagsHub : Hub<IINputTagHubClient>
    {

        public async Task Send(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

    }
}