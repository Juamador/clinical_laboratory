using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.DTOs.Exam.Response
{
    public class GetallExamResponseDto
    {
        public int? ExamId { get; set; }
        public string? Name { get; set; }
        public string? Analysis { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? StateExam { get; set; }
    }
}
