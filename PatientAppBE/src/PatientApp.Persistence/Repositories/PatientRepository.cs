using System.Data;
using Dapper;
using PatientApp.Domain.Entities;
using PatientApp.Interface.Persistence;
using PatientApp.Persistence.Contexts;

namespace PatientApp.Persistence.Repositories
{
    public class PatientRepository(DapperContext applicationContext) : IPatientRepository
    {
        private readonly DapperContext _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));

        #region Queries
        /*Queries*/
        public async Task<int> CountAsync()
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "Select Count(*) From Patient";

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientsList";

            var patients = await connection.QueryAsync<Patient>(query, commandType: CommandType.StoredProcedure);
            return patients;
        }

        public async Task<IEnumerable<Patient>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientsListWithPagination";

            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var patients = await connection.QueryAsync<Patient>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return patients;
        }

        public async Task<Patient> GetAsync(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientGetById";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var patient = await connection.QuerySingleOrDefaultAsync<Patient>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return patient;
        }
        #endregion

        #region Commands
        /*Commands*/

        public async Task<bool> InsertAsync(Patient entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientInsert";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("Gender", entity.Gender);
            parameters.Add("Address", entity.Address);
            parameters.Add("PhoneNumber", entity.PhoneNumber);
            parameters.Add("Email", entity.Email);
            parameters.Add("InsuranceProvider", entity.InsuranceProvider);
            parameters.Add("InsurancePolicyNumber", entity.InsurancePolicyNumber);


            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;
        }

        public async Task<bool> UpdateAsync(Patient entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientUpdate";

            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("Gender", entity.Gender);
            parameters.Add("Address", entity.Address);
            parameters.Add("PhoneNumber", entity.PhoneNumber);
            parameters.Add("Email", entity.Email);
            parameters.Add("InsuranceProvider", entity.InsuranceProvider);
            parameters.Add("InsurancePolicyNumber", entity.InsurancePolicyNumber);

            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "PatientDelete";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;
        }
        #endregion
    }
}
