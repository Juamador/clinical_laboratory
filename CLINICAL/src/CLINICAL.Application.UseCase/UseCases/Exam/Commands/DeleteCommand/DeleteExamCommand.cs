using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.DeleteCommand
{
    public class DeleteExamCommand: IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
    }
}
