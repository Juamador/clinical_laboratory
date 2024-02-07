namespace CLINICAL.Application.DTOs.Patient.Response
{
    public class GetAllPatientResponseDTo
    {
        public int? PatientId{get;set;}
        public string? Names{get;set;}
        public string? LastName{get;set;}
        public string? SurNames{get;set;}
        public string? DocumentType{get;set;}
        public string? DocumentNumber{get;set;}
        public string? Phone{get;set;}
        public string? Age{get;set;}
        public string? Gender{get;set;}
        public string? StatePatient{get;set;}
        public DateTime? CreatedDate { get; set; }
    }
}
