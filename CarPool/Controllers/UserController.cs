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
    [Route("/api/v1/user")]
    [BasicAuth]
    public class UserController : ControllerBase
    {
        private readonly IUserRequestService _userRequestService;
        public UserController(IUserRequestService userRequestService)
        {
            _userRequestService = userRequestService;
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateProfileAsync),
            Summary = "Создать пользователя.")]
        public async Task<IActionResult> CreateProfileAsync(UserDTO profile)
        {
            try
            {
                var result = await _userRequestService.CreateProfileAsync(profile);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(EditProfileAsync),
            Summary = "Редактировать пользователя.")]
        public async Task<IActionResult> EditProfileAsync(UserDTO profile, long id)
        {
            try
            {
                var result = await _userRequestService.EditProfileAsync(profile, id);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("getrolebyid")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(GetRoleByIdAsync),
            Summary = "Получить роль пользователя по ID.")]
        public async Task<IActionResult> GetRoleByIdAsync(long id)
        {
            try
            {
                var result = await _userRequestService.GetRoleByIdAsync(id);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }
    }
}
