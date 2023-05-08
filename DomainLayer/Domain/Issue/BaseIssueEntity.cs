namespace Domain.Issue
{
    public class BaseIssueEntity
    {
        public int Payment { get; set; }
        public int Prepayment { get; set; }
        public string ScanPath { get; set; } = string.Empty;
        public string DockPath { get; set; } = string.Empty;
        public string Dock2Path { get; set; } = string.Empty;
        public string OrdPath { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
    }
}
