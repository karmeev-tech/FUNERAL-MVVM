using Ionic.Zip;

namespace ORDCreator
{
    public class Zipper
    {

        public static void CreateDordFile(string basePath, string dordName, string savePath)
        {
            try
            {
                AddZip(basePath, @"\" + dordName + ".zip", savePath);
                FileInfo file = new(savePath);
                file.MoveTo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\send.dord", true);
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void AddZip(string basePath, string name, string savePath)
        {
            string startPath = basePath;

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(startPath);
                zip.Save(savePath);
            }
        }

        public static void UnZip(string basePath, string workPath)
        {
            File.Copy(basePath, workPath + "\\send.zip");
            using (ZipFile zip = ZipFile.Read(workPath + "\\send.zip"))
            {
                //var set = zip.Where(x => x.FileName.EndsWith(".docx")).Zip();
                zip.ExtractAll(workPath);
            }
            File.Delete(workPath + "\\send.zip");
        }
    }
}