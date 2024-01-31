using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.createConnection;
            return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T?> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.createConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
                
        }

        public async Task<bool> ExcecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.createConnection;
            var objParam = new DynamicParameters(parameters);
            var recordAffecteds = await connection.ExecuteAsync(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffecteds > 0;
        }
    }
}
