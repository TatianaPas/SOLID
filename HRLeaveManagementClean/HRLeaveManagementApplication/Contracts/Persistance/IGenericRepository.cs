using HRLeaveManagementDomain.Common;

namespace HRLeaveManagementApplication.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }

}