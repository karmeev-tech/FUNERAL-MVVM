namespace ORDCreator
{
    public class DordTransfer
    {
        public void CreateTransfer(string transferPath)
        {
            Zipper zipper = new();
            zipper.CreateDordFile(transferPath);
            Directory.Delete(transferPath, true);
        }
    }
}
