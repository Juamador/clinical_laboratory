using CLINICAL.Application.DTOs.Medic;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdQuery: IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
