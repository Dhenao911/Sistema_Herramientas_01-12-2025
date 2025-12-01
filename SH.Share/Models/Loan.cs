namespace SH.Share.Models
{
    public class Loan : AuditBase
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}