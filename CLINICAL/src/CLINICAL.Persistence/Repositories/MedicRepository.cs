using CLINICAL.Application.DTOs.Medic;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure)
        {
            var connection = _context.createConnection;
            var medics = await connection.QueryAsync<GetAllMedicResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return medics;
        }
    }
}
