using EmploymentSearch_DataModel.Models.Entities;
using System.Net.Http.Json;

namespace EmploymentSearch.Client.Services
{
    public partial class PositionService() : IPositionService
    {
        //[Inject]
        private readonly HttpClient _httpClient;

        public PositionService(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddPosition(int positionId, JobPosition position)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<JobPosition>("Position", position);
            return response;
        }
        public async Task<HttpResponseMessage> UpdatePosition(JobPosition position)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync<JobPosition>("Position", position);
            return response;
        }
        public async Task<HttpResponseMessage> UpdatePositionStatus(int positionId, string status)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"Position/{positionId}/{status}", null);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating position status: {ex.Message}");
                throw;
            }
        }
        public async Task<HttpResponseMessage> DeletePosition(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Position/" + id.ToString().Trim());
            return response;
        }

        public async Task<JobPosition> GetPosition(int id)
        {
            if (id >= 0)
            {
                JobPosition position = await _httpClient.GetFromJsonAsync<JobPosition>("Position/GetByPositionId?id=" + id.ToString().Trim());

                if (position == null)
                {
                    throw new Exception("Failed to load position");
                }
                else
                {
                    return position;
                }

            }
            else
            {
                throw new Exception("Invalid position id");
            }
        }


        public async Task<List<JobPosition>> GetAllPositionsForCompany(int companyId)
        {
            List<JobPosition> positionList = await _httpClient.GetFromJsonAsync<List<JobPosition>>("Position/GetByCompanyId?companyId=" + companyId.ToString().Trim());

            if (positionList == null)
            {
                throw new Exception("Failed to load Positions for Company with id: " + companyId);
            }
            else
            {
                return positionList;
            }
        }
    }
}
