using AutoMapper;
using SalesProject.Application.DTO.product.batch;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class BatchProductApplication : IBatchProductApplication
    {
        #region private members
        private readonly IBatchProductDomain _batchProductDomain;
        private readonly IMapper _mapper;

        #endregion

        public BatchProductApplication(IBatchProductDomain batchProductDomain, IMapper mapper)
        {
            _batchProductDomain = batchProductDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(BatchProductCreateDTO obj)
        {
            var response = new Response<bool>();

            try
            {
                var batchProduct = _mapper.Map<BatchProduct>(obj);
                response.Data = await _batchProductDomain.InsertAsync(batchProduct);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(string sku, int sysNumber, BatchProductUpdateDTO obj)
        {
            var response = new Response<bool>();

            try
            {
                var batchProduct = _mapper.Map<BatchProduct>(obj);
                response.Data = await _batchProductDomain.UpdateAsync(sku, sysNumber, batchProduct);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string sku, int sysNumber)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = await _batchProductDomain.DeleteAsync(sku, sysNumber);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<BatchProductDTO>> GetBySkuAndDistNumber(string sku, string distNumber)
        {
            var response = new Response<BatchProductDTO>();

            try
            {
                var batchProduct = await _batchProductDomain.GetBySkuAndDistNumber(sku, distNumber);
                response.Data = _mapper.Map<BatchProductDTO>(batchProduct);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Query successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<BatchProductDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BatchProductDTO>>();

            try
            {
                var batchProducts = await _batchProductDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<BatchProductDTO>>(batchProducts);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Query successfully";
                }
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
