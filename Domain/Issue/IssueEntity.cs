namespace Domain.Issue
{
    public class IssueEntity
    {
        public int Payment { get; set; }
        public int Prepayment { get; set; }
        public string ScanPath { get; set; } = string.Empty;
        public string DockPath { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
    }
}
