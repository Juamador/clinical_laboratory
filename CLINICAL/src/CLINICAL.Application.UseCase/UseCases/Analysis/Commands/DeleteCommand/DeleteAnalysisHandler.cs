using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _UnitOfWork;

        public DeleteAnalysisHandler(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.Data = await _UnitOfWork.Analysis.ExcecAsync("dbo.SP_ANALYSIS_REMOVE", new { request.AnalysisId });
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Record successfully deleted!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
