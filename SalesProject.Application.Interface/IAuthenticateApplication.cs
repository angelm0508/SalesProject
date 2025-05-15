using SalesProject.Application.DTO.authentication;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;
using System.Text;

namespace SalesProject.Application.Interface
{
    public interface IAuthenticateApplication
    {
        #region async methods
        Task<Response<bool>> RegisterAsync(AuthenticateCreateDTO obj);
        Task<Response<string>> AuthenticateAsync(AuthenticateDTO obj);
        Task<Response<bool>> UpdateAsync(string code, AuthenticateUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string code);
        Task<Response<AuthenticateDTO>> GetByCodeAsync(string code);
        Task<Response<AuthenticateDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<AuthenticateDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<AuthenticateDTO>>> GetAllAsync();
        Task<Response<PagedList<AuthenticateDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParameters);
        #endregion
    }
}
