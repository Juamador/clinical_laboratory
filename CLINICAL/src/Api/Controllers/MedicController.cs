using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListMedics")]
        public async Task<IActionResult> ListMedics()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());

            return Ok(response);
        }
    }
}
