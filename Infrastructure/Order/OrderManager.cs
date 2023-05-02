using System.Text.RegularExpressions;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using Domain.Order;

namespace LegacyInfrastructure.Order
{
    public class OrderManager
    {
        public void CreateDoc(string number,
                              string name,
                              string passport,
                              string adress,
                              string servs,
                              string servprice,
                              string funprice,
                              string prepayment,
                              string phonenumber)
        {
            // Path to a loadable document.
            string loadPath = Directory.GetCurrentDirectory() + @"\.docs\CreateDock.docx";
            string savePath = Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedDock.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "NUMBER", number);
            DocCreator(loadPath, savePath, "CLIENTNAME", name);
            DocCreator(loadPath, savePath, "PASSPORT", passport);
            DocCreator(loadPath, savePath, "ADRESS", adress);
            DocCreator(loadPath, savePath, "SERVICES", servs);
            DocCreator(loadPath, savePath, "PRICESERVICES", servprice);
            DocCreator(loadPath, savePath, "PRICEFUNERAL", funprice);
            DocCreator(loadPath, savePath, "PREDOPLATA", prepayment);
            DocCreator(loadPath, savePath, "PH", phonenumber);
            // Open the result for demonstration purposes.
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(loadPath) { UseShellExecute = true });

        }

        public void CreateFuneralDock(string number,
                              string name,
                              string passport,
                              string adress,
                              string komplekt,
                              string price,
                              string prepayment,
                              string phonenumber,
                              string orderAdress)
        {
            string loadPath = Directory.GetCurrentDirectory() + @"\.docs\CreateFuneralDock.docx";
            string savePath = Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedFuneralDock.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "NUMBER", number);
            DocCreator(loadPath, savePath, "CLIENTNAME", name);
            DocCreator(loadPath, savePath, "PASSPORT", passport);
            DocCreator(loadPath, savePath, "ADRESS", adress);
            DocCreator(loadPath, savePath, "COMPLEKT", komplekt);
            DocCreator(loadPath, savePath, "CLIENTADRESS", orderAdress);
            DocCreator(loadPath, savePath, "PRICE", price);
            DocCreator(loadPath, savePath, "PREDOPLATA", prepayment);
            DocCreator(loadPath, savePath, "WHATSUP", phonenumber);
        }

        public void CreateBlank(
                      int modifier,
                      string name,
                      string adress,
                      string komplekt,
                      string price,
                      string prepayment,
                      string phonenumber,
                      string orderAdress,
                      string deliverAdress,
                      string today,
                      string obelisk,
                      string tumba,
                      string grob,
                      string color,
                      string polish,
                      string other,
                      string uppart,
                      string downpart,
                      string otherofform,
                      string materialfuneral,
                      List<DeadEntity> entities)
        {
            string loadPath = "";
            switch (modifier)
            {
                case 1:
                    loadPath = Directory.GetCurrentDirectory() + @"\.docs\blank1.docx";
                    break ; 
                case 2:
                    loadPath = Directory.GetCurrentDirectory() + @"\.docs\blank2.docx";
                    break;   
                case 3:
                    loadPath = Directory.GetCurrentDirectory() + @"\.docs\blank3.docx";
                    break;   
                case 4:
                    loadPath = Directory.GetCurrentDirectory() + @"\.docs\blank4.docx";
                    break;
            }
            string savePath = Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedFuneralBlank.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "CLIENTNAME", name);
            DocCreator(loadPath, savePath, "ADRESS", adress);
            DocCreator(loadPath, savePath, "COMPLEKT", komplekt);
            DocCreator(loadPath, savePath, "CADRES", adress);
            DocCreator(loadPath, savePath, "PRICE", price);
            DocCreator(loadPath, savePath, "PREDOPLATA", prepayment);
            DocCreator(loadPath, savePath, "WHATSUP", phonenumber);

            DocCreator(loadPath, savePath, "DADR", deliverAdress);
            DocCreator(loadPath, savePath, "TODAYDATE", today);
            DocCreator(loadPath, savePath, "FORMOBELISK", obelisk);
            DocCreator(loadPath, savePath, "FORMTUMBA", tumba);
            DocCreator(loadPath, savePath, "FORMGROB", grob);
            DocCreator(loadPath, savePath, "COLOR", color);
            DocCreator(loadPath, savePath, "POLISH", polish);

            DocCreator(loadPath, savePath, "OTHER", other);
            DocCreator(loadPath, savePath, "UPPART", uppart);
            DocCreator(loadPath, savePath, "DOWNPART", downpart);
            DocCreator(loadPath, savePath, "OFFORM", otherofform);
            DocCreator(loadPath, savePath, "FUNERALMATERIAL", materialfuneral);

            switch (modifier)
            {
                case 1:
                    DocCreator(loadPath, savePath, "DO", entities[0].DeadFIO);
                    DocCreator(loadPath, savePath, "DMO", entities[0].DeadBirth);
                    DocCreator(loadPath, savePath, "VIZO", entities[0].DeadDie);
                    break;
                case 2:
                    DocCreator(loadPath, savePath, "DO", entities[0].DeadFIO);
                    DocCreator(loadPath, savePath, "DMO", entities[0].DeadBirth);
                    DocCreator(loadPath, savePath, "VIZO", entities[0].DeadDie);

                    DocCreator(loadPath, savePath, "TXO", entities[1].DeadFIO);
                    DocCreator(loadPath, savePath, "TMI", entities[1].DeadBirth);
                    DocCreator(loadPath, savePath, "TIHO", entities[1].DeadDie);
                    break;
                case 3:
                    DocCreator(loadPath, savePath, "DO", entities[0].DeadFIO);
                    DocCreator(loadPath, savePath, "DMO", entities[0].DeadBirth);
                    DocCreator(loadPath, savePath, "VIZO", entities[0].DeadDie);

                    DocCreator(loadPath, savePath, "TXO", entities[1].DeadFIO);
                    DocCreator(loadPath, savePath, "TMI", entities[1].DeadBirth);
                    DocCreator(loadPath, savePath, "TIHO", entities[1].DeadDie);

                    DocCreator(loadPath, savePath, "THR", entities[2].DeadFIO);
                    DocCreator(loadPath, savePath, "THMR", entities[2].DeadBirth);
                    DocCreator(loadPath, savePath, "THIMI", entities[2].DeadDie);
                    break;
                case 4:
                    DocCreator(loadPath, savePath, "DO", entities[0].DeadFIO);
                    DocCreator(loadPath, savePath, "DMO", entities[0].DeadBirth);
                    DocCreator(loadPath, savePath, "VIZO", entities[0].DeadDie);

                    DocCreator(loadPath, savePath, "TXO", entities[1].DeadFIO);
                    DocCreator(loadPath, savePath, "TMI", entities[1].DeadBirth);
                    DocCreator(loadPath, savePath, "TIHO", entities[1].DeadDie);

                    DocCreator(loadPath, savePath, "THR", entities[2].DeadFIO);
                    DocCreator(loadPath, savePath, "THMR", entities[2].DeadBirth);
                    DocCreator(loadPath, savePath, "THIMI", entities[2].DeadDie);

                    DocCreator(loadPath, savePath, "FL", entities[3].DeadFIO);
                    DocCreator(loadPath, savePath, "PB", entities[3].DeadBirth);
                    DocCreator(loadPath, savePath, "VLF", entities[3].DeadDie);
                    break;
            }
        }

        private void DocCreator(string loadPath, string savePath, string tag, string content)
        {
            using (WordprocessingDocument wordDoc =
            WordprocessingDocument.Open(savePath, true))
            {
                string docText = "";
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex(tag);
                docText = regexText.Replace(docText, content);

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }

        private void ImageReplace(string loadPath, string savePath, string tag, string content)
        {

        }
    }
}
