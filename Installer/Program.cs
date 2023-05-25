// See https://aka.ms/new-console-template for more information
using Installer;
using IWshRuntimeLibrary;
using System.Diagnostics;

Console.WriteLine("Идёт установка");

var curDir = Directory.GetCurrentDirectory();
string desktopPath = "C:\\";

var sourceFolder = curDir + "\\program";
var destFolder = desktopPath + "\\FuneralProgram";

Console.WriteLine("Программные файлы помещены на рабочий стол");
//Directory.Move(curDir + "\\program", desktopPath + "\\program");

DirectoryManage directoryManage = new DirectoryManage();
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

//установка sql 
Console.WriteLine("Установка Sql");
ProcessStartInfo startInfo = new ProcessStartInfo();
startInfo.FileName = curDir + "\\utils\\sql.exe";
startInfo.Verb = "runas";
Process process = Process.Start(startInfo);
process.WaitForExit();