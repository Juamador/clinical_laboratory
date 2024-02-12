using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.DTOs.TakeExam.Response
{
    public class GetTakeExamByIdResponseDto
    {
        public int TakeExamId { get; set; }
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<GetTakeExamDetailByTakeExamIdResponseDto>? TakeExamDetails {  get; set; }
    }
}
