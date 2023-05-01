using Ionic.Zip;

namespace Model.Issue
{
    public class FormatCreator
    {
        public bool CreateOrdFile(string[] files, string basePath)
        {
            try
            {
                AddZip();

                using (ZipFile zip = ZipFile.Read(basePath))
                {
                    zip.AddFiles(files);
                    zip.Save();
                }

                FileInfo file = new FileInfo(basePath);
                file.MoveTo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.ord");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void AddZip()
        {
            string startPath = @".docs\issue";
            string zipPath = @".docs\issue\issue.zip";

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(startPath);
                zip.Save(zipPath);
            }
        }
    }
}
