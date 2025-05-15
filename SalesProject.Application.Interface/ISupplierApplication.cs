using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Interface
{
    public interface ISupplierApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SupplierCreateDTO obj);
        Task<Response<bool>> UpdateAsync(string code, SupplierUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string code);
        Task<Response<SupplierDTO>> GetByCodeAsync(string code);
        Task<Response<SupplierDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<SupplierDTO>>> GetAllAsync();
        Task<Response<PagedList<SupplierDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        Task<Response<IEnumerable<SupplierDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<SupplierDTO>>> GetAllTthatContainsNitAsync(string nit);
        #endregion
    }
}
