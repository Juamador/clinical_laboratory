namespace CLINICAL.Application.DTOs.TakeExam.Response
{
    public class GetTakeExamDetailByTakeExamIdResponseDto
    {
        public int TakeExamDetailId { get; set; }
        public int TakeExamId { get; set; }
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
