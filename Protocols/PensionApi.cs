namespace ProcessPension.Protocols
{
    public class PensionApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://20.219.224.84/");
            return client;
        }
    }

}
