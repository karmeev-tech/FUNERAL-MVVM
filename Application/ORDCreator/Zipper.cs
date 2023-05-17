using Ionic.Zip;

namespace ORDCreator
{
    public class Zipper
    {
        public bool CreateOrdFile(string[] files, string basePath)
        {
            try
            {
                AddZip(basePath, @"\issue.zip");

                //using (ZipFile zip = ZipFile.Read(basePath))
                //{
                //    zip.AddFiles(files);
                //    zip.Save();
                //}

                FileInfo file = new(basePath + @"\issue.zip");
                file.MoveTo(basePath + "\\issue.ord");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateXordFile(string transferPath, string basePath)
        {
            try
            {
                AddZip(transferPath, @"\issue.zip");

                //using (ZipFile zip = ZipFile.Read(basePath))
                //{
                //    zip.AddFiles(files);
                //    zip.Save();
                //}

                int modif = DateTime.Now.Millisecond + DateTime.Now.Hour + DateTime.Now.Minute + new Random().Next(1,10000);

                Directory.CreateDirectory(basePath + "\\xord");
                FileInfo file = new(transferPath + @"\issue.zip");
                file.MoveTo(basePath +"\\xord" + "\\issue" + modif.ToString() + ".xord");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateDordFile(string basePath)
        {
            try
            {
                AddZip(basePath, @"\send.zip");
                FileInfo file = new(basePath + @"\send.zip");
                file.MoveTo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\send.dord");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void AddZip(string basePath, string name)
        {
            string startPath = basePath;
            string zipPath = basePath + name;

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(startPath);
                zip.Save(zipPath);
            }
        }

        public void UnZip(string basePath, string workPath)
        {
            File.Move(basePath, workPath + "\\send.zip");
            using (ZipFile zip = ZipFile.Read(workPath + "\\send.zip"))
            {
                zip.ExtractAll(workPath);
            }
            File.Delete(workPath + "\\send.zip");
        }

        public static void UnZipXord(string basePath, string workspacePath, 
                              string randomName)
        {
            File.Move(basePath, workspacePath + @"\" + randomName + ".zip");
            using (ZipFile zip = ZipFile.Read(workspacePath + @"\" + randomName + ".zip"))
            {
                zip.ExtractAll(workspacePath);
            }
            File.Delete(workspacePath + @"\" + randomName + ".zip");
        }

        public static void UnZipOrd(string basePath, string workspacePath)
        {
            File.Move(basePath, workspacePath + @"\meta.zip");

            try
            {
                using (ZipFile zip = ZipFile.Read(workspacePath + "\\meta.zip"))
                {
                    zip.ExtractAll(workspacePath);
                }
            }
            catch
            {
                File.Delete(workspacePath + @"\meta.zip");
                return;
            }
        }
    }
}