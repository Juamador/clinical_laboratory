using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicCommand: IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
    }
}
