using AutoMapper;
using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
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

            CreateMap<CreateTakeExamCommand, TakeExam>();
            CreateMap<CreateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<UpdateTakeExamCommand, TakeExam>();
            
            CreateMap<UpdateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<ChangeStateTakeExamCommand, TakeExam>();
        }
    }
}
