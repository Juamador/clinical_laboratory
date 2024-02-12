using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class TakeExamRepository: GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly ApplicationDbContext _context;

        public TakeExamRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExam(string storedProcedure, object parameter)
        {
            using var connection = _context.createConnection;
            var objParam = new DynamicParameters(parameter);
            var takeExams = await connection.QueryAsync<GetAllTakeExamResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return takeExams;
        }

        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            using var connection = _context.createConnection;
            var sql = @"SELECT TakeExamId, PatientId, MedicId FROM dbo.TakeExam WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);
            return takeExam!;    
        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            using var connection = _context.createConnection;
            var sql = @"SELECT TakeExamDetailId, TakeExamId, AnalysisId FROM dbo.TakeExamDetail WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);
            return takeExamDetail!;
        }
    }
}
