using Domain.Dord;
using Domain.Shop;
using ORDCreator;
using System.Text.Json;

namespace BossInstruments
{
    public class XordFormalizer
    {
        private static void CreateTemporaryWorkspace(string path)
        {
            Directory.CreateDirectory(path + @"\worspacedir");
        }

        private static void DeleteTemporaryWorkspace(string path)
        {
            Directory.Delete(path + @"\worspacedir",true);
        }

        public static List<OrdEntity> GetJson(string[] pathsToXord, string basePath, 
                                         string docsPath, string scanpath, string managerName)
        {
            List<OrdEntity> ords = new();

            for(int i = 0; i != pathsToXord.Length; i++)
            {
                CreateTemporaryWorkspace(basePath);

                Zipper.UnZipXord(pathsToXord[i], basePath + @"\worspacedir", "herli");
                var ordDir = basePath + @"\worspacedir\meta\meta.ord";
                var ordWS = basePath + @"\worspacedir\meta\ws";
                Directory.CreateDirectory(ordWS);

                Zipper.UnZipOrd(ordDir, ordWS);
                OrdEntity entity = OrdFormalizer.GetJson(ordWS);

                string[] docs = new[]
                {
                basePath + @"\worspacedir" + @"\basefiles",
                basePath + @"\worspacedir" + @"\completefiles",
                };

                DocsTeleport.Teleport(docs, docsPath, scanpath);

                docs[0] = docsPath;
                docs[1] = scanpath;

                var sendDocsPath = basePath + @"\" + managerName + new Random().Next().ToString();

                Directory.Move(docs[0], sendDocsPath);
                Directory.Move(docs[1], sendDocsPath + @"\scans");
                DeleteTemporaryWorkspace(basePath);
                ords.Add(entity);
            }

            //DeleteTemporaryWorkspace(basePath + @"\xord");
            return ords;
        }
    }
}
