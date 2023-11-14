namespace HRLeaveManagementApplication.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }

}