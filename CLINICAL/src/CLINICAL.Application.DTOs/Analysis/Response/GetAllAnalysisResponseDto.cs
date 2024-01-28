namespace CLINICAL.Application.DTOs.Analysis.Response
{
    public class GetAllAnalysisResponseDto
    {

        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? StateAnalysis { get; set; }
    }
    
}
