using Microsoft.Win32;
using System;
using System.IO;

namespace ClassLibrary
{
    public class PickManager
    {
        private string _fileName;
        private string _filePath;

        [Obsolete]
        public void AddToWorkspace()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            _filePath = openFileDialog.FileName;
            _fileName = openFileDialog.SafeFileName;

            if(_filePath != "")
            {
                File.Copy(_filePath, CurrentDir() + _fileName);
                _filePath = "\\.workspace\\" + _fileName;
            }
        }

        private string CurrentDir()
        {
            return Directory.GetCurrentDirectory() + "\\.workspace\\";
        }
        public string GetCurrentDir()
        {
            return _filePath;
        }

        [Obsolete]
        public void OpenManager()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        [Obsolete]
        public string OpenManagerFileName(int modif)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(modif == 2)
            {
                openFileDialog.Filter = "DOCX (*.docx)|*.docx";
            }
            else
            {
                openFileDialog.Filter = "DOCX (*.docx)|*.docx";
            }
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        [Obsolete]
        public string OpenManagerFileNameOrd()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ORD (*.ord)|*.ord";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        public void Remove(string path)
        {
            var dir = CurrentDir();
        }
    }
}
