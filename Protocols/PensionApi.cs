namespace ProcessPension.Protocols
{
    public class PensionApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44305/");
            return client;
        }
    }

}
