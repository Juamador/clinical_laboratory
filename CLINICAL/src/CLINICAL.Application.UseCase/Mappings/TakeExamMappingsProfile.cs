using AutoMapper;
using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class TakeExamMappingsProfile: Profile
    {
        public TakeExamMappingsProfile()
        {
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>()
                .ReverseMap();

            CreateMap<GetTakeExamDetailByTakeExamIdResponseDto, TakeExamDetail>()
                .ReverseMap();
        }
    }
}
