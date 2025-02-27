namespace PatientApp.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        #region Commands
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        #endregion

        #region Queries 
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        #endregion
    }
}
