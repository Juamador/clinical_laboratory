using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand
{
    public class UpdateExamCommand: IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}
