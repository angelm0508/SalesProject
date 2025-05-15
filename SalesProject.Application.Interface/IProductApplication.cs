using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.product;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Interface
{
    public interface IProductApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductCreateDTO obj);
        Task<Response<bool>> UpdateAsync(string sku, ProductUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string sku);
        Task<Response<ProductDTO>> GetByNameAsync(string name);
        Task<Response<ProductDTO>> GetBySkuAsync(string sku);
        Task<Response<IEnumerable<ProductDTO>>> GetAllAsync();
        Task<Response<PagedList<ProductDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        Task<Response<IEnumerable<ProductDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<ProductDTO>>> GetAllThatContainsSkuAsync(string sku);
        #endregion
    }
}
