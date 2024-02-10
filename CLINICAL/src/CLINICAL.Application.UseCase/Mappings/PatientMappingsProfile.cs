using AutoMapper;
using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.ChangePatientState;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Command.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    partial class PatientMappingsProfile: Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<UpdatePatientCommand, Patient>();

            CreateMap<ChangeStatePatientCommand, Patient>();
        }
    }
}
