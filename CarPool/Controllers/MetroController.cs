using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Applications.DTOs;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using CarPool.Filters;
using Applications.Interface;

namespace CarPool.Controllers
{
    [ApiController]
    [Route("/api/v1/metro")]
    [BasicAuth]
    public class MetroController : ControllerBase
    {
        private readonly IMetroRequestService _metroRequestService;
        public MetroController(IMetroRequestService metroRequestService)
        {
            _metroRequestService = metroRequestService;
        }

        [HttpGet("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateMetroAsync),
            Summary = "Добавить метро.")]
        public async Task<IActionResult> CreateMetroAsync(string name)
        {
            try
            {
                var result = await _metroRequestService.CreateMetroAsync(name);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateMetroAsync),
            Summary = "Получить метро по id.")]
        public async Task<IActionResult> GetMetroByIdAsync(int id)
        {
            try
            {
                var result = await _metroRequestService.GetMetroByIdAsync(id);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("getbyname")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
           OperationId = nameof(GetMetroByNameAsync),
           Summary = "Получить метро по имени.")]
        public async Task<IActionResult> GetMetroByNameAsync(string name)
        {
            try
            {
                var result = await _metroRequestService.GetMetroByNameAsync(name);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("getall")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateMetroAsync),
            Summary = "Получить все метро.")]
        public async Task<IActionResult> GetAllMetroAsync()
        {
            try
            {
                var result = await _metroRequestService.GetAllMetroAsync();
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }
    }
}
