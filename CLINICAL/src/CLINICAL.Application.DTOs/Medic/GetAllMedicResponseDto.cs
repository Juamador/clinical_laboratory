﻿namespace CLINICAL.Application.DTOs.Medic
{
    public class GetAllMedicResponseDto
    {
        public int MedicId { get; set; }
        public string? Names { get; set; }
        public string? Surnames { get; set; }
        public string? Specialty { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? StateMedic { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
