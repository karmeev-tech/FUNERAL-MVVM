using DocumentFormat.OpenXml.Packaging;
using Domain.Order;
using System.Text.RegularExpressions;

namespace OrderManager
{
    public class OrderCreator
    {
        public string Workspace { get; set; }
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
            string loadPath = Workspace + @"\.docs\CreateDock.docx";
            string savePath = Workspace + @"\.workspace\docs\ReplacedDock.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "NUMBER", number);
            DocCreator(loadPath, savePath, "CLIENTNAME", name);
            DocCreator(loadPath, savePath, "PASSPORT", passport);
            DocCreator(loadPath, savePath, "ADRESS", adress);
            DocCreator(loadPath, savePath, "SERVICES", servs);
            DocCreator(loadPath, savePath, "GTS", servprice);
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
            string loadPath = Workspace + @"\.docs\CreateFuneralDock.docx";
            string savePath = Workspace + @"\.workspace\docs\ReplacedFuneralDock.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "NUMB", number);
            DocCreator(loadPath, savePath, "CLM", name);
            DocCreator(loadPath, savePath, "PASS", passport);
            DocCreator(loadPath, savePath, "ADRESS", adress);
            DocCreator(loadPath, savePath, "COMPLEKT", komplekt);
            DocCreator(loadPath, savePath, "CLIENTADRESS", orderAdress);
            DocCreator(loadPath, savePath, "PRICE", price);
            DocCreator(loadPath, savePath, "PREDOPLATA", prepayment);
            DocCreator(loadPath, savePath, "WHATSUP", phonenumber);
        }

        public void CreateBlank(
                      int modifier, List<DeadModel> entities, string typeblank, string obeliskForm, string tumbaForm,
                      string grobForm, string funColor, string polish, string other, string upFuneral, string downFuneral,
                      string otherFuneral, string epitafia, string todayDate, string createDate, string clientFIO,
                      string clientAdress, string clientPhone, string clientFuneral, string clientDelivery,
                      string clientInstal, string clientPrice,  string clientPrepayment, string clientRe,
                      string funeralMaterial, string funeralNumber
            )
        {
            string loadPath = "";
            switch (modifier)
            {
                case 1:
                    loadPath = Workspace + @"\.docs\blanks\" + typeblank + "blank1.docx";
                    break;
                case 2:
                    loadPath = Workspace + @"\.docs\blanks\" + typeblank + "blank2.docx";
                    break;
                case 3:
                    loadPath = Workspace + @"\.docs\blanks\" + typeblank + "blank3.docx";
                    break;
                case 4:
                    loadPath = Workspace + @"\.docs\blanks\" + typeblank + "blank4.docx";
                    break;
            }
            string savePath = Workspace + @"\.workspace\docs\ReplacedFuneralBlank.docx";

            File.Copy(loadPath, savePath, true);

            DocCreator(loadPath, savePath, "сёдня", todayDate);
            DocCreator(loadPath, savePath, "зара", createDate);

            DocCreator(loadPath, savePath, "фоб", obeliskForm);
            DocCreator(loadPath, savePath, "фт", tumbaForm);
            DocCreator(loadPath, savePath, "фг", grobForm);
            DocCreator(loadPath, savePath, "цп", funColor);
            DocCreator(loadPath, savePath, "полир", polish);
            DocCreator(loadPath, savePath, "проч", other);

            DocCreator(loadPath, savePath, "вчб", upFuneral);
            DocCreator(loadPath, savePath, "нчб", downFuneral);
            DocCreator(loadPath, savePath, "поф", otherFuneral);

            DocCreator(loadPath, savePath, "эпия", epitafia);

            DocCreator(loadPath, savePath, "клиф", clientFIO);
            DocCreator(loadPath, savePath, "клиа", clientAdress);
            DocCreator(loadPath, savePath, "клт", clientPhone);
            DocCreator(loadPath, savePath, "клд", clientFuneral);
            DocCreator(loadPath, savePath, "дс", clientDelivery);
            DocCreator(loadPath, savePath, "уст", clientInstal);
            DocCreator(loadPath, savePath, "цз", clientPrice);
            DocCreator(loadPath, savePath, "пред", clientPrepayment);
            DocCreator(loadPath, savePath, "токст", clientRe);

            DocCreator(loadPath, savePath, "фунмат", funeralMaterial);
            DocCreator(loadPath, savePath, "нмбр", funeralNumber);

            switch (modifier)
            {
                case 1:
                    DocCreator(loadPath, savePath, "фиод", entities[0].Name + " " + entities[0].ThirdName + " " + entities[0].LastName + " ");
                    DocCreator(loadPath, savePath, "чмгрд", entities[0].Life);
                    DocCreator(loadPath, savePath, "чмгсд", entities[0].Death);
                    break;
                case 2:
                    DocCreator(loadPath, savePath, "фиод", entities[0].Name + " " + entities[0].ThirdName + " " + entities[0].LastName + " ");
                    DocCreator(loadPath, savePath, "чмгрд", entities[0].Life);
                    DocCreator(loadPath, savePath, "чмгсд", entities[0].Death);

                    DocCreator(loadPath, savePath, "TXO", entities[1].Name);
                    DocCreator(loadPath, savePath, "TMI", entities[1].Life);
                    DocCreator(loadPath, savePath, "TIHO", entities[1].Death);
                    break;
                case 3:
                    DocCreator(loadPath, savePath, "фиод", entities[0].Name + " " + entities[0].ThirdName + " " + entities[0].LastName + " ");
                    DocCreator(loadPath, savePath, "чмгрд", entities[0].Life);
                    DocCreator(loadPath, savePath, "чмгсд", entities[0].Death);

                    DocCreator(loadPath, savePath, "TXO", entities[1].Name);
                    DocCreator(loadPath, savePath, "TMI", entities[1].Life);
                    DocCreator(loadPath, savePath, "TIHO", entities[1].Death);

                    DocCreator(loadPath, savePath, "THR", entities[2].Name);
                    DocCreator(loadPath, savePath, "THMR", entities[2].Life);
                    DocCreator(loadPath, savePath, "THIMI", entities[2].Death);
                    break;
                case 4:
                    DocCreator(loadPath, savePath, "фиод", entities[0].Name + " " + entities[0].ThirdName + " " + entities[0].LastName + " ");
                    DocCreator(loadPath, savePath, "чмгрд", entities[0].Life);
                    DocCreator(loadPath, savePath, "чмгсд", entities[0].Death);

                    DocCreator(loadPath, savePath, "ф2иод", entities[1].Name + " " + entities[1].ThirdName + " " + entities[1].LastName + " ");
                    DocCreator(loadPath, savePath, "ч2мгрд", entities[1].Life);
                    DocCreator(loadPath, savePath, "ч2мгсд", entities[1].Death);

                    DocCreator(loadPath, savePath, "3дои", entities[2].Name + " " + entities[2].ThirdName + " " + entities[2].LastName + " ");
                    DocCreator(loadPath, savePath, "3чрд", entities[2].Life);
                    DocCreator(loadPath, savePath, "3рсд", entities[2].Death);

                    DocCreator(loadPath, savePath, "чи4к", entities[3].Name + " " + entities[3].ThirdName + " " + entities[3].LastName + " ");
                    DocCreator(loadPath, savePath, "4фати", entities[3].Life);
                    DocCreator(loadPath, savePath, "таф4", entities[3].Death);
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
    }
}
