namespace scada.Data
{
    public class Global
    {
        public static SemaphoreSlim _semaphore = new SemaphoreSlim(1);
    }
}
