using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Commonds.Bases
{
    public class BaseGenericResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
        public string? Message { get; set; }
    }
}
