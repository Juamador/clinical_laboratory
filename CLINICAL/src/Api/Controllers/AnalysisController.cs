using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AnalysisList()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());
            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId});

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AnalysisRegister([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> AnalysisEdit([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("remove/{AnalysisId:int}*")]
        public async Task<IActionResult> RemoveAnalysis(int AnalysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = AnalysisId});

            return Ok(response);
        }

    }
}
