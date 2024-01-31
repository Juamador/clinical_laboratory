using CLINICAL.Application.UseCase.Commonds.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Commonds.Exceptions
{
    public class ValidationException: Exception
    {
        public IEnumerable<BaseError>? Errors { get; }

        public ValidationException(): base() 
        {
            Errors = new List<BaseError>();
        }

        public ValidationException(IEnumerable<BaseError>? errors): this() 
        {
            Errors = errors;
        }
    }
}
