namespace LoanManagement.ViewModels
{
    public class LoanListDto
    {
        public long Id { get; set; }
        public string Borrower { get; set; }
        public string FileName { get; set; }
        public string LoanStatus { get; set; }
        public string StatusDate { get; set; }
        public string EstClose { get; set; }
        public string RateLoc { get; set; }
        public string Processor { get; set; }
        public string Originator { get; set; }
        public string Contact { get; set; }
    }
}
