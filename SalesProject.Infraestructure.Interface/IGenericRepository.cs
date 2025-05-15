namespace SalesProject.Infraestructure.Interface
{
    public interface IGenericRepository<T1>
    {
        #region async methods
        Task<bool> InsertAsync(T1 obj);
        Task<bool> UpdateAsync(int id, T1 obj);
        Task<bool> CancelAsync(int id);
        Task<T1> GetByIdAsync(int id);
        Task<IQueryable<T1>> GetAllAsync();
        #endregion
    }

    public interface IGenericRepositoryTwo<T1>
    {
        #region async methods
        Task<bool> InsertAsync(T1 obj);
        Task<bool> UpdateAsync(string code, T1 obj);
        Task<bool> DeleteAsync(string code);
        Task<T1> GetByCodeAsync(string code);
        Task<IQueryable<T1>> GetAllAsync();
        #endregion
    }

    public interface IGenericRepositoryThree<T1>
    {
        #region async methods
        Task<bool> InsertAsync(T1 obj);
        Task<bool> UpdateAsync(int id, T1 obj);
        Task<bool> DeleteAsync(int id);
        Task<T1> GetByIdAsync(int id);
        Task<IQueryable<T1>> GetAllAsync();
        #endregion
    }

    public interface IBatchGenericRepository<T1>
    {
        #region async methods
        Task<bool> InsertAsync(T1 obj);
        Task<bool> UpdateAsync(string sku, int sysNumber, T1 obj);
        Task<bool> DeleteAsync(string sku, int sysNumber);
        Task<T1> GetBySkuAndDistNumber(string sku, string distNumber);
        Task<IQueryable<T1>> GetAllAsync();
        #endregion
    }

}
