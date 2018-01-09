using DataLayer;
using MyPaymentsCrossPlatform.Droid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MyPaymentsCrossPlatform.Droid
{ 
    public class FileHelper : IFileHelper
    {
        public void CopyFile(string source, string destination, bool overwrite)
        {
            var sourcePath = GetLocalFilePath(source);
            var destinationPath = GetLocalFilePath(destination);
            File.Copy(source, destination, overwrite);
        }

        public void DeleteFile(string filename)
        {
            if (!FileExists(filename)) return;
            var fullPath = GetLocalFilePath(filename);
            File.Delete(fullPath);
        }

        public bool FileExists(string filename)
        {
            var fullPath = GetLocalFilePath(filename);
            return File.Exists(fullPath);
        }

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}