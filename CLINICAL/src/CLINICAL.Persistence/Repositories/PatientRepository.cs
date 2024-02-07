using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext  _context;

        public PatientRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDTo>> GetAllPatients(string storeProcedure)
        {
            var connection = _context.createConnection;
            var patients = await connection.QueryAsync<GetAllPatientResponseDTo>(storeProcedure, commandType: CommandType.StoredProcedure);

            return patients;
        }
    }
}
