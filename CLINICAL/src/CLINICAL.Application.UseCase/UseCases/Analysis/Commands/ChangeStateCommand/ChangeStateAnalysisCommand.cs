using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand: IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public int State { get; set; }
    }
}
