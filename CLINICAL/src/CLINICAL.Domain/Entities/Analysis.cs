namespace CLINICAL.Domain.Entities
{
    public class Analysis
    {
        public int? AnalysisId { get; set; }
        public string? Name { get; set; }
        public int? State { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
