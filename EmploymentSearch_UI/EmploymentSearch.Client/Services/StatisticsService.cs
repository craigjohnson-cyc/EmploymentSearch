using EmploymentSearch_DataModel.Models.Entities;
using System.Net.Http.Json;

namespace EmploymentSearch.Client.Services
{
    public partial class StatisticsService() : IStatisticsService
    {
        private readonly HttpClient _httpClient;
        public StatisticsService(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
        }

        public async Task<List<Statistics>> GetStatistics()
        {
            List<Statistics> statList = await _httpClient.GetFromJsonAsync<List<Statistics>>("Statistics/");

            if (statList == null)
            {
                throw new Exception("Failed to load Statistics");
            }
            else
            {
                return statList;
            }
        }

    }
}
