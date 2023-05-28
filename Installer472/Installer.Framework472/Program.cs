using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installer.Framework472
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Идёт установка");

            var curDir = Directory.GetCurrentDirectory();
            string desktopPath = "C:\\";

            var sourceFolder = curDir + "\\program";
            var destFolder = desktopPath + "\\FuneralProgram";

            Console.WriteLine("Программные файлы помещены на рабочий стол");
            //Directory.Move(curDir + "\\program", desktopPath + "\\program");

            DirectoryManager directoryManage = new DirectoryManager();
            directoryManage.CopyFolder(sourceFolder, destFolder);

            //start stop bat
            Console.WriteLine("Файлы start.bat, stop.bat необходимо всегда запускать перед тем как начать работу с программой");
            System.IO.File.Copy(curDir + "\\cmd\\start.bat", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\start.bat", true);
            System.IO.File.Copy(curDir + "\\cmd\\stop.bat", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\stop.bat", true);

            //create shortcut IWSHRuntimeLibrary
            Console.WriteLine("Приложение успешно транспортировано");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Funeral.lnk");
            shortcut.TargetPath = destFolder + "\\net7.0-windows\\FUNERALMVVM.exe";
            shortcut.Save();

            //установка net
            Console.WriteLine("Установка NET");

            ProcessStartInfo startInfo4 = new ProcessStartInfo();
            startInfo4.FileName = curDir + "\\utils\\netsdk6.exe";
            startInfo4.Verb = "runas";
            Process process4 = Process.Start(startInfo4);
            process4.WaitForExit();

            ProcessStartInfo startInfo5 = new ProcessStartInfo();
            startInfo5.FileName = curDir + "\\utils\\netsdk7.exe";
            startInfo5.Verb = "runas";
            Process process5 = Process.Start(startInfo5);
            process5.WaitForExit();

            ProcessStartInfo startInfo2 = new ProcessStartInfo();
            startInfo2.FileName = curDir + "\\utils\\net6.exe";
            startInfo2.Verb = "runas";
            Process process2 = Process.Start(startInfo2);
            process2.WaitForExit();

            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.FileName = curDir + "\\utils\\net7.exe";
            startInfo3.Verb = "runas";
            Process process3 = Process.Start(startInfo3);
            process3.WaitForExit();
        }
    }
}
