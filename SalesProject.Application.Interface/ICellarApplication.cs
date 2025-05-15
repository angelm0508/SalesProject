using SalesProject.Application.DTO.cellar;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ICellarApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CellarCreateDTO obj);
        Task<Response<bool>> UpdateAsync(string code, CellarUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string code);
        Task<Response<CellarDTO>> GetByCodeAsync(string code);
        Task<Response<CellarDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CellarDTO>>> GetAllAsync();
        #endregion
    }
}
