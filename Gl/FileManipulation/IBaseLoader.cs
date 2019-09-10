using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gl.FileManipulation
{
    public interface IBaseLoader<T> where T : new()
    {
        Task<List<T>> LoadText(string FileName, bool HasTitle = false);
        string FindFile(string FileName);
    }
}
