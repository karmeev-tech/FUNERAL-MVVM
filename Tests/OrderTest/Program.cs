// See https://aka.ms/new-console-template for more information
using OrderManager;

OrderCreator orderCreator = new();
orderCreator.Workspace = @"E:\WORK\projects\funeral2\KarmeevTech\Funeral\.programWorkspace";
List<Domain.Order.DeadModel> deadModels = new();
deadModels.Add(new Domain.Order.DeadModel() { Name = "Антон", LastName = "Краснов", ThirdName = "Акакиевич", Death = "25.12.2001", Life = "19.12.1890" });
deadModels.Add(new Domain.Order.DeadModel() { Name = "Антон", LastName = "Краснов", ThirdName = "Акакиевич", Death = "25.12.2001", Life = "19.12.1890" });
deadModels.Add(new Domain.Order.DeadModel() { Name = "Антон", LastName = "Краснов", ThirdName = "Акакиевич", Death = "25.12.2001", Life = "19.12.1890" });
deadModels.Add(new Domain.Order.DeadModel() { Name = "Антон", LastName = "Краснов", ThirdName = "Акакиевич", Death = "25.12.2001", Life = "19.12.1890" });
orderCreator.CreateBlank
    (
    4,
    deadModels,
    "plates",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "25.12.2001",
    "25.12.2001",
    "h u i",
    "11",
    "12",
    "13",
    "14",
    "15",
    "16",
    "17",
    "18",
    "19",
    "20"
    );
