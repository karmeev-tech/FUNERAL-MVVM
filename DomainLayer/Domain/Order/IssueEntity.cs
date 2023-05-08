namespace Domain.Order
{
    public class IssueEntity
    {
        public IssueEntity(string personFIO,
                           string personData,
                           DateTime hireDate,
                           DateTime manufactureDate,
                           string status)
        {
            PersonFIO = personFIO;
            PersonData = personData;
            HireDate = hireDate;
            ManufactureDate = manufactureDate;
            Status = status;
        }

        public string PersonFIO { get; set; } = null!;
        public string PersonData { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Status { get; set; } = null!;
    }
}
