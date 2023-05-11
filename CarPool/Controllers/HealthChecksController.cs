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
    [Route("/api/v1/health")]
    [BasicAuth]
    public class HealthChecksController : ControllerBase
    {
        private readonly IUserRequestService _userRequestService;
        public HealthChecksController(IUserRequestService userRequestService)
        {
            _userRequestService = userRequestService;
        }

        [HttpGet("start")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(StartAsync),
            Summary = "Проверка запуска приложения.")]
        public async Task<IActionResult> StartAsync()
        {
            try
            {
                return Ok(new { result = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("bd")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(DbAsync),
            Summary = "Проверка соединения с бд.")]
        public async Task<IActionResult> DbAsync()
        {
            try
            {
                var result = await _userRequestService.GetFirstAsync();
                return Ok(new { result = result != null });
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.ToString() });
            }
        }
    }
}
