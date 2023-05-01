using System.IO;
using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Legacy.DocumentPictureManager
{
    public class ImageReplacer
    {
        public static void FindTextAndReplaceImage(string loadPath, string pictPath, string savePath)
        {
            // Path to a loadable document.

            // Load a document intoDocumentCore.
            DocumentCore dc = DocumentCore.Load(loadPath);

            //Find "<signature>" Text and Replace everywhere with the "Smile.png"
            // Please note, Reverse() makes sure that action replace not affects to Find().
            Regex regex = new Regex(@"IMLINK", RegexOptions.IgnoreCase);
            Picture picture = new Picture(dc, InlineLayout.Inline(new Size(50, 50)), pictPath);
            foreach (ContentRange item in dc.Content.Find(regex).Reverse())
            {
                item.Replace(picture.Content);
            }

            // Save our document into PDF format.
            dc.Save(savePath, new PdfSaveOptions());
        }
    }
}
