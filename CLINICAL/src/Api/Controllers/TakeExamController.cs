using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListTakeExams")]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator.Send(new GetTakeExamByIdQuery() { TakeExamId=takeExamId});
            return Ok(response);
        }
    }
}
