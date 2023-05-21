using BossInstruments;
using Domain.Dord;
using Domain.GeneralOrder;
using ORDCreator;

namespace ConsoleApp1
{
    internal class Bossing
    {
        public static void StartUp()
        {
            var bossFolder = @"C:\Users\Kuririn\Desktop\boss";
            var dordFile = "C:\\Users\\Kuririn\\Desktop\\send.dord";

            //Zipper zipper = new();
            //zipper.UnZip(dordFile, bossFolder);

            //IordEntity iord = IordFormalizer.GetJson(Directory.GetFiles(bossFolder + @"\iord"));

            DordMeta meta = DordMetaFormalizer.GetJson(bossFolder + @"\json\request.json");

            var gendocsDir = bossFolder + @"\gendocs";
            var scandocsDir = bossFolder + @"\scandocs";

            ////List<OrdEntity> ord = XordFormalizer.GetJson(
            //    Directory.GetFiles(bossFolder + @"\xord"),
            //    bossFolder, 
            //    gendocsDir, scandocsDir, "manager");

            Directory.Delete(bossFolder + @"\iord", true);
            Directory.Delete(bossFolder + @"\json", true);
            Directory.Delete(bossFolder + @"\xord", true);
        }
    }
}
