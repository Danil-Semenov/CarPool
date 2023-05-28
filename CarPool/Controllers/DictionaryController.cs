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
    [Route("/api/v1/dictionary")]
    [BasicAuth]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryRequestService _dictionaryRequestService;
        public DictionaryController(IDictionaryRequestService dictionaryRequestService)
        {
            _dictionaryRequestService = dictionaryRequestService;
        }

        [HttpGet("destination")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(GetAllDestinationAsync),
            Summary = "Получить словарь 'НАПРАВЛЕНИЯ ПОЕЗДКИ'.")]
        public async Task<IActionResult> GetAllDestinationAsync()
        {
            try
            {
                var result = await _dictionaryRequestService.GetAllDestinationAsync();
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("role")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
             OperationId = nameof(GetAllRoleAsync),
             Summary = "Получить словарь 'РОЛИ'.")]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            try
            {
                var result = await _dictionaryRequestService.GetAllRoleAsync();
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("status")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(GetAllStatusAsync),
            Summary = "Получить словарь 'СТАТУС ПОЕЗДКИ'.")]
        public async Task<IActionResult> GetAllStatusAsync()
        {
            try
            {
                var result = await _dictionaryRequestService.GetAllStatusAsync();
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }
    }
}
