using System.ComponentModel.DataAnnotations;

namespace BusinessService.Model
{
    public class LoanDetail
    {
        public Guid? id { get; set; }
        public string? AccountNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public Source? Source { get; set; }
        public Purpose? LoanPurpose { get; set; }
        public SalariedRecived? SalariedRecived { get; set; }
        public Location? PropertyLocation { get; set; }
        public DateTime? DOB { get; set; }
        public string? WorkingCompany { get; set; }
        public int? GrossSalary { get; set; }
        public DateTime? CreatedON { get; set; }
        public DateTime? ModifiedON { get; set; }
        public User? CreatedBy { get; set; }
        public User? ModifiedBy { get; set; }
        public Guid? PropertyLocationid { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModifiedById { get; set; }
    }

}