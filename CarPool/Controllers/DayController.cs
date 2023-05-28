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
    [Route("/api/v1/day")]
    [BasicAuth]
    public class DayController : ControllerBase
    {
        private readonly IDayRequestService _dayRequestService;
        public DayController(IDayRequestService dayRequestService)
        {
            _dayRequestService = dayRequestService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateDayAsync),
            Summary = "Добавить день.")]
        public async Task<IActionResult> CreateDayAsync(DayDTO day)
        {
            try
            {
                var result = await _dayRequestService.CreateDayAsync(day);
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
            OperationId = nameof(GetDayByIdAsync),
            Summary = "Получить день по id.")]
        public async Task<IActionResult> GetDayByIdAsync(int id)
        {
            try
            {
                var result = await _dayRequestService.GetDayByIdAsync(id);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("getbyuserid")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
           OperationId = nameof(GetDayByUserIdAsync),
           Summary = "Получить дня по Id пользователя.")]
        public async Task<IActionResult> GetDayByUserIdAsync(int userId)
        {
            try
            {
                var result = await _dayRequestService.GetDayByUserIdAsync(userId);
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
            OperationId = nameof(GetAllDayAsync),
            Summary = "Получить все дни.")]
        public async Task<IActionResult> GetAllDayAsync()
        {
            try
            {
                var result = await _dayRequestService.GetAllDayAsync();
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }
    }
}
