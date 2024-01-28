using CLINICAL.Application.Interface;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            var connection = _context.createConnection;

            var query = "dbo.SP_GET_ANALYSIS_LIST";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

            return analysis;
        }
        public async Task<Analysis> AnalysisById(int analysisId)
        {
            using var connection = _context.createConnection;

            var query = "dbo.SP_GET_ANALYSIS_LIST_BY_ID";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection
                .QuerySingleOrDefaultAsync<Analysis>(query, param: parameters, commandType: CommandType.StoredProcedure);

            return analysis;
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.createConnection;

            var query = "dbo.SP_ANALYSIS_REGISTER";
            var parameters = new DynamicParameters();
            
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("CreatedDate", DateTime.Now);

            var recordsAffected = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connecton = _context.createConnection;

            var query = "dbo.SP_ANALYSIS_EDIT";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);

            var recordsAffected = await connecton.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}
