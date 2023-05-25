namespace BossInstruments
{
    public class DocsTeleport
    {
        public static void Teleport(string[] folderDocPath,
            string docsPath, string scansPath)
        {
            //Directory.CreateDirectory(newFolderDocPath + type[0]);
            //Directory.CreateDirectory(newFolderDocPath + type[1]);

            Directory.Move(folderDocPath[0], docsPath);
            Directory.Move(folderDocPath[1], scansPath);
        }
    }
}
