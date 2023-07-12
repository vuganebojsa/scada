namespace scada.Hubs
{
    public interface IINputTagHubClient
    {
        Task ReceiveMessage(string message);

    }
}
