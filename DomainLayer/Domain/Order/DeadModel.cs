namespace Domain.Order
{
    public class DeadModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;
        public string Life { get; set; } = string.Empty;
        public string Death { get; set; } = string.Empty;

        public string GetDead()
        {
            if (Name != string.Empty && LastName != string.Empty && ThirdName != string.Empty)
                return Name + " " + LastName + " " + ThirdName + " " + Life + " " + Death + " ";
            else
                return "Не верно указано имя";
        }
    }
}
