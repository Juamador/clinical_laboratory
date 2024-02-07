namespace CLINICAL.Application.DTOs.Exam.Response
{
    public class GetExamByIdResponseDto
    {
        public int ExamId { get; set; }
        public string? Name {  get; set; }
        public int? AnalysisId { get; set; }
    }
}
