namespace ProcessPension.Models
{
    public class Pension
    {
        public int id { get; set; }
        public int Aadhaarcard { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? Pan { get; set; }

        public int Salaryearned { get; set; }
        public int Allowances { get; set; }
       
        public string? Pensiontype { get; set; }
        public int BankDetailId { get; set; }
        public virtual BankDetails BankDetails { get; set; }

    }
}
