using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
