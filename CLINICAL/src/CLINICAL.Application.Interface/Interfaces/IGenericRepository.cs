namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure);
        Task<IEnumerable<T>> GetAllWithPagination(string storedProcedure, object parameter);
        Task<T?> GetByIdAsync(string storedProcedure, object parameter);
        Task<bool> ExcecAsync(string storedProcedure, object parameters);
        Task<int> CountAsync(string tableName);
    }
}
