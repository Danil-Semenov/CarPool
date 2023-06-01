using Applications.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using CarPool.Filters;
using Applications.Interface;
using Applications.DB.Entities;

namespace CarPool.Controllers
{
    [ApiController]
    [Route("/api/v1/trip")]
    [BasicAuth]
    public class TripController : ControllerBase
    {
        private readonly ITripRequestService _tripRequestService;
        public TripController(ITripRequestService tripRequestService)
        {
            _tripRequestService = tripRequestService;
        }

        [HttpPost("add")]
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
                var result = await _tripRequestService.CreateTripAsync(trip);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("gettripsbyuserid")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(GetTripsByUserIdAsync),
            Summary = "Получение поездок по ссылке на Id пользователя.")]
        public async Task<IActionResult> GetTripsByUserIdAsync(long userId)
        {
            try
            {
                var result = await _tripRequestService.GetTripsByUserIdAsync(userId);
                return Ok(new { result = result });
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
        public async Task<IActionResult> FindTripsAsync(TripFilterDTO filer)
        {
            try
            {
                var result = await _tripRequestService.FindTripsAsync(filer);
                return Ok(new { result = result });
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
                var result = await _tripRequestService.EditTripAsync(trip,id);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                //Request.Body.Position = 0;
                //var rawRequestBody = await new StreamReader(Request.Body).ReadToEndAsync();
                //await _requestService.SetLogAsync(Request.Path.Value, rawRequestBody, ex.Message);
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("{id}/addpassenger")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(AddPassengers),
            Summary = "Добавить пассажира в поездку.")]
        public async Task<IActionResult> AddPassengers(int id, long passengerId)
        {
            try
            {
                var result = await _tripRequestService.AddPassengers(id, passengerId);
                return Ok(new { result = result });
            }
            catch (Exception ex)
            {
                //Request.Body.Position = 0;
                //var rawRequestBody = await new StreamReader(Request.Body).ReadToEndAsync();
                //await _requestService.SetLogAsync(Request.Path.Value, rawRequestBody, ex.Message);
                return BadRequest(new { status = 400, error = ex.Message });
            }
        }

        [HttpGet("{id}/deletepassenger")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            OperationId = nameof(DeletePassengers),
            Summary = "Удалить пассажира из поездки.")]
        public async Task<IActionResult> DeletePassengers(int id, long passengerId)
        {
            try
            {
                var result = await _tripRequestService.DeletePassengers(id, passengerId);
                return Ok(new { result = result });
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
        public async Task<IActionResult> CloseTrip(int id, long userId)
        {
            try
            {
                var result = await _tripRequestService.CloseTrip(id, userId);
                return Ok(new { result = result });
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
