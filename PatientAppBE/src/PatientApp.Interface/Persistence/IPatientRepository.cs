using PatientApp.Domain.Entities;

namespace PatientApp.Interface.Persistence
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<int> CountAsync();
        Task<IEnumerable<Patient>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}