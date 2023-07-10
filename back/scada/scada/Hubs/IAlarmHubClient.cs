namespace scada.Hubs
{
    public interface IAlarmHubClient
    {

        Task ReceiveMessage(string message);
    }
}
