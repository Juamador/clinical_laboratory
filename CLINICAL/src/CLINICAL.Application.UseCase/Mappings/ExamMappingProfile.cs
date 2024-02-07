using AutoMapper;
using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile: Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamCommand, Exam>();

            CreateMap<UpdateExamCommand, Exam>();

            CreateMap<ChangeExamStateCommand, Exam>();
        }
    }
}
