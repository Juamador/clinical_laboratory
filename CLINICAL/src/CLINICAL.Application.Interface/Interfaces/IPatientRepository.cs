using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDTo>> GetAllPatients(string storeProcedure, object parameter);
    }
}
