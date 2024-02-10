using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Domain.Entities
{
    public class Medic
    {
        public int MedicId {get;set;}
		public string? Names {get;set;}
		public string? LastName {get;set;}
		public string? MotherMaidenName {get;set;}
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber {get;set;}
        public int SpecialtyId { get; set; }
        public int State { get; set; }
		public DateTime? CreatedDate { get; set; }
    }
}
