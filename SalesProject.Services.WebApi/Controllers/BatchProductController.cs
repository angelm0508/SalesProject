using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.batch;
using SalesProject.Application.Interface;
using SalesProject.Application.Main;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/batchProduct")]
    public class BatchProductController : ControllerBase
    {
        private readonly IBatchProductApplication _batchProductApplication;
        public BatchProductController(IBatchProductApplication batchProductApplication)
        {
            _batchProductApplication = batchProductApplication;
        }

        [HttpGet]
        public async Task<ActionResult<BuyDTO>> GetBySkuAndDistNumber([FromQuery] string sku, [FromQuery] string distNumber)
        {
            var batchNumber = await _batchProductApplication.GetBySkuAndDistNumber(sku, distNumber);

            if (!batchNumber.IsSuccess)
                return BadRequest(new ResponseError(batchNumber.Message));


            if (batchNumber.Data == null)
                return NotFound(new ResponseError("The batch product sku and distNumber was not found."));


            return Ok(batchNumber.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BuyDTO>> GetAll()
        {
            var batchProducts = await _batchProductApplication.GetAllAsync();

            if (!batchProducts.IsSuccess)
                return BadRequest(new ResponseError(batchProducts.Message));

            return Ok(batchProducts.Data);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BatchProductCreateDTO obj)
        {
            var insert = await _batchProductApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
                return BadRequest(new ResponseError(insert.Message));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromQuery] string sku, [FromQuery] int sysNumber, [FromBody] BatchProductUpdateDTO obj)
        {
            /*var batchNumberUpdate = await _batchProductApplication.UpdateAsync(sku, sysNumber, obj);

            if (batchNumberUpdate.Data == null)
                return NotFound(new ResponseError("The batch sku and sysnumber was not found."));*/

            var update = await _batchProductApplication.UpdateAsync(sku, sysNumber, obj);

            if (!update.IsSuccess)
                return BadRequest(new ResponseError(update.Message));

            return Ok();
        }


    }
}
