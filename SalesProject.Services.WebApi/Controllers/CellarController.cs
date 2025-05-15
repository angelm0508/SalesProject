using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/cellar")]
    public class CellarController : ControllerBase
    {
        private readonly ICellarApplication _cellarApplication;

        public CellarController(ICellarApplication cellarApplication)
        {
            _cellarApplication = cellarApplication;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<CellarDTO>> GetByCode([FromRoute]string code)
        {
            var cellar = await _cellarApplication.GetByCodeAsync(code);

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar code was not found"));
            }

            return Ok(cellar.Data);
        }

        [HttpGet("byName/{name}")]
        public async Task<ActionResult<CellarDTO>> GetByName([FromRoute]string name)
        {
            var cellar = await _cellarApplication.GetByNameAsync(name);

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar name was not found"));
            }

            return Ok(cellar.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CellarDTO>>> GetAll()
        {
            var cellar = await _cellarApplication.GetAllAsync();

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            return Ok(cellar.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]CellarCreateDTO obj)
        {
            var insert = await _cellarApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{code}")]
        public async Task<ActionResult> Update([FromRoute]string code, [FromBody] CellarUpdateDTO obj)
        {
            var cellar = await _cellarApplication.GetByCodeAsync(code);

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar code was not found."));
            }

            var update = await _cellarApplication.UpdateAsync(code, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete([FromRoute] string code)
        {
            var cellar = await _cellarApplication.GetByCodeAsync(code);

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar code was not found."));
            }

            var delete = await _cellarApplication.DeleteAsync(code);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }
    }
}
