namespace ORDCreator
{
    public class XordTransfer
    {
        public void CreateTransfer(string transferPath, string basePath)
        {
            Zipper zipper = new();
            zipper.CreateXordFile(transferPath, basePath);
            Directory.Delete(transferPath, true);
        }
    }
}
