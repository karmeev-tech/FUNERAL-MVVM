using ClassLibrary;
using Microsoft.Win32;
namespace Infrastructure.Storage
{
#nullable disable
    public class PickManagerExtendet
    {
        PickManager _pick = new();

        [Obsolete]
        public void AddToWorkspace()
        {
            _pick.AddToWorkspace();
        }

        public string GetCurrentDir()
        {
            return _pick.GetCurrentDir();
        }
        public string CheckNotEmpty()
        {
            if (_pick.GetCurrentDir() == "")
            {
                return "empty";
            }
            else
            {
                return "not empty";
            }
        }
    }
}
