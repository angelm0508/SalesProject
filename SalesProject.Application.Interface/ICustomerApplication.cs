using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ICustomerApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CustomerCreateDTO obj);
        Task<Response<bool>> UpdateAsync(string code, CustomerUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string code);
        Task<Response<CustomerDTO>> GetByCodeAsync(string code);
        Task<Response<CustomerDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        Task<Response<PagedList<CustomerDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParameters);
        #endregion
    }
}
