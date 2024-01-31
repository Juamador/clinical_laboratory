using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }
        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
