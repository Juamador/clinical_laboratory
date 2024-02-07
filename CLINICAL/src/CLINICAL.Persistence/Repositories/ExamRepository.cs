using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetallExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connection = _context.createConnection;
            var exams = await connection.QueryAsync<GetallExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            
            return exams;
        }
    }
}
