﻿namespace CLINICAL.Domain.Entities
{
    public class TakeExam
    {
        public int? TakeExamId { get; set; }
        public int? PatientId { get; set; }
        public int? MedicId { get; set; }
        public int? State { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<TakeExamDetail> TakeExamDetail { get; set; } = null!;
    }
}
