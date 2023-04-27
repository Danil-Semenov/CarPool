using Applications.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using CarPool.Filters;

namespace CarPool.Controllers
{
    [ApiController]
    [Route("/api/v1/trip")]
    [BasicAuth]
    public class TripController : ControllerBase
    {
        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CreateTripAsync),
            Summary = "Создание поездки.")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateTripAsync(TripDTO trip)
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

        [HttpGet("gettripsbytglink")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(GetTripsByTgLinkAsync),
            Summary = "Получение поездок по ссылке на профиль.")]
        public async Task<IActionResult> GetTripsByTgLinkAsync(string tglink)
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

        [HttpPost("findtrips")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(FindTripsAsync),
            Summary = "Найти поездку.")]
        public async Task<IActionResult> FindTripsAsync(TripDTO trip)
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

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(EditTripAsync),
            Summary = "Редактировать поездку.")]
        public async Task<IActionResult> EditTripAsync(TripDTO trip, int id)
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

        [HttpPost("{id}/passenger")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(AddPassengers),
            Summary = "Добавить пассажира в поездку.")]
        public async Task<IActionResult> AddPassengers(int id, UserDTO passenger)
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

        [HttpGet("{id}/close")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(CloseTrip),
            Summary = "Завершить поездку.")]
        public async Task<IActionResult> CloseTrip(int id)
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
