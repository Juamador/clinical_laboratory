using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System.Net.Http.Headers;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public class CreateTakeExamCommand: IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int? MedicId { get; set; }
        public IEnumerable<CreateTakeExamDetailCommand> TakeExamDetails { get; set; } = null!;
    }

    public class CreateTakeExamDetailCommand
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
