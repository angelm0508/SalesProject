using AutoMapper;
using SalesProject.Application.DTO.supplier.category;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Main
{
    public class SupplierCatApplication : ISupplierCatApplication
    {
        private readonly ISupplierCatDomain _supplierCatDomain;
        private readonly IMapper _mapper;

        public SupplierCatApplication(ISupplierCatDomain supplierCatDomain, IMapper mapper)
        {
            _supplierCatDomain = supplierCatDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(SupplierCatCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var supplier = _mapper.Map<SupplierCategory>(obj);
                response.Data = await _supplierCatDomain.InsertAsync(supplier);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(int id, SupplierCatUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var category = _mapper.Map<SupplierCategory>(obj);
                response.Data = await _supplierCatDomain.UpdateAsync(id, category);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully.";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _supplierCatDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.";
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<SupplierCatDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SupplierCatDTO>();
            try
            {
                var category = await _supplierCatDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SupplierCatDTO>(category);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<SupplierCatDTO>> GetByNameAsync(string name)
        {
            var response = new Response<SupplierCatDTO>();
            try
            {
                var category = await _supplierCatDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<SupplierCatDTO>(category);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<SupplierCatDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SupplierCatDTO>>();
            try
            {
                var categories = await _supplierCatDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SupplierCatDTO>>(categories);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message}";
            }
            return response;
        }

        public async Task<Response<IEnumerable<SupplierCatDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<SupplierCatDTO>>();
            try
            {
                var categories = await _supplierCatDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<SupplierCatDTO>>(categories);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
