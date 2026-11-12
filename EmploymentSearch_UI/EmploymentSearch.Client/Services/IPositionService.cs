using BlazorBootstrap;
using EmploymentSearch_DataModel.Models.Entities;
using System.Net.NetworkInformation;

namespace EmploymentSearch.Client.Services
{
    public interface IPositionService
    {
        Task<List<JobPosition>> GetAllPositionsForCompany(int companyId);
        //Task<List<Company>> GetPosition(int pageNumber, int pageSize);
        Task<JobPosition> GetPosition(int id);
        Task<HttpResponseMessage> AddPosition(int positionId, JobPosition position);
        Task<HttpResponseMessage> UpdatePosition(JobPosition position);
        Task<HttpResponseMessage> UpdatePositionStatus(int positionId, string status);
        Task<HttpResponseMessage> DeletePosition(int id);
    }
}
