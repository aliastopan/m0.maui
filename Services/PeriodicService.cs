using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;
using System.Text.Json;

namespace m0.maui.Services
{
    public class PeriodicService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
        private readonly HttpClient _httpClient;

        public PeriodicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(await _timer.WaitForNextTickAsync(stoppingToken)
                && !stoppingToken.IsCancellationRequested)
            {
                await GetRealtimeAsync();
            }
        }

        private async Task GetRealtimeAsync()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://mthrowaway488-001-site1.dtempurl.com/api/read/realtime"),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Accept", "*/*");
            var response = await _httpClient.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Singleton.PPM = int.Parse(content);
            }
        }
    }
}