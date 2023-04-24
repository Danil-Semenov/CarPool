using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Applications.DTOs;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using CarPool.Filters;

namespace CarPool.Controllers
{
    [ApiController]
    [Route("/api/v1/user")]
    [BasicAuth]
    public class UserController : ControllerBase
    {
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
               // var result = await _userRequestService.CreateProfileAsync(profile);
                return Ok(/*new { result = result }*/);
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
        public async Task<IActionResult> EditProfileAsync(UserDTO profile, int id)
        {
            try
            {
                //var result = await _userRequestService.EditProfileAsync(profile, id);
                return Ok(/*new { result = result }*/);
            }
            catch (Exception ex)
            {
                //Request.Body.Position = 0;
                //var rawRequestBody = await new StreamReader(Request.Body).ReadToEndAsync();
                //await _requestService.SetLogAsync(Request.Path.Value, rawRequestBody, ex.Message);
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("getrolebytglink")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(EditProfileAsync),
            Summary = "Получить роль пользователя по профилю ТГ.")]
        public async Task<IActionResult> GetRoleByTgLinkAsync(string tglink)
        {
            try
            {
                //var result = await _userRequestService.EditProfileAsync(profile, id);
                return Ok(/*new { result = result }*/);
            }
            catch (Exception ex)
            {
                //Request.Body.Position = 0;
                //var rawRequestBody = await new StreamReader(Request.Body).ReadToEndAsync();
                //await _requestService.SetLogAsync(Request.Path.Value, rawRequestBody, ex.Message);
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }
    }
}
