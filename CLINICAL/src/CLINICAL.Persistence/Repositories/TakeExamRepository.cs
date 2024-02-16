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

        public async Task<TakeExam> RegisterTakeExam(TakeExam takeExam)
        {
            using var connection = _context.createConnection;
            var sql = @"INSERT INTO dbo.TakeExam(PatientId, MedicId)
                      VALUES(@PatientId, @MedicId)
                       SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);

            var takeExamId = await connection.QuerySingleOrDefaultAsync<int>(sql, param:parameters);
            takeExam.TakeExamId = takeExamId;

            return takeExam;
        }

        public async Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            using var connection = _context.createConnection;
            var sql = @"INSERT INTO dbo.TakeExamDetail(TakeExamId, ExamId, AnalysisId, MedicId)
                      VALUES(@TakeExamId, @ExamId, @AnalysisId, @MedicId)
                       SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamDetail.TakeExamId);
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);
            parameters.Add("MedicId", takeExamDetail.MedicId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditTakeExam(TakeExam takeExam)
        {
            using var connection = _context.createConnection;
            var sql = @"UPDATE dbo.TakeExam
                      SET PatientId = @PatientId,
                          MedicId = @MedicId
                      WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            using var connection = _context.createConnection;
            var sql = @"UPDATE dbo.TakeExamDetail
                      SET ExamId = @ExamId,
                          AnalysisId = @AnalysisId
                      WHERE TakeExamDetailId = @TakeExamDetailId";

            var parameters = new DynamicParameters();
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);
            parameters.Add("TakeExamDetailId", takeExamDetail.TakeExamDetailId);

            await connection.ExecuteAsync(sql, param: parameters);
        }

        public async Task<bool> ChangeStateTakeExam(TakeExam takeExam)
        {
            using var connection = _context.createConnection;
            var sql = @"UPDATE dbo.TakeExam
                        SET State = @State
                        WHERE TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();
            parameters.Add("State", takeExam.State);
            parameters.Add("TakeExamId", takeExam.TakeExamId);

            var recordAffected = await connection.ExecuteAsync(sql, param: parameters);
            return recordAffected > 0;
        }
    }
}
