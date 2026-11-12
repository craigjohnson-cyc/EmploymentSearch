using EmploymentSearch_DataModel.Models.Entities;

namespace EmploymentSearch.Client.Services
{

    public interface IStatisticsService
    {
        Task<List<Statistics>> GetStatistics();
    }
}