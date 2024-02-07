using AutoMapper;
using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    partial class PatientMappingsProfile: Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();
        }
    }
}
