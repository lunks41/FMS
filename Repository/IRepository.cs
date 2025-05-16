using FMS.Models;

namespace FMS.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T, P>(string spName, P Parameters);

        Task<IEnumerable<T>> GetByIdAsync<T, P>(string spName, P Parameters);

        Task<IncomeReponce> UpsertAsync<T>(string spName, T Parameters);
    }
}