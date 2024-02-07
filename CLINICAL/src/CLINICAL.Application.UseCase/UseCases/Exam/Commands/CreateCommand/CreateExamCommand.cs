using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamCommand: IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public int? AnalysisId { get; set; }
    }
}
