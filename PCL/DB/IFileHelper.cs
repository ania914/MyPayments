namespace DataLayer
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
        void CopyFile(string source, string destination, bool overwrite);
        bool FileExists(string filename);
        void DeleteFile(string filename);
    }
}
