using System;
using System.Collections.Generic;

namespace Gl.FileManipulation
{
    public interface IBaseSave<T> where T : new()
    {
        bool SaveFileWithRecords(List<T> obj,string FileName);
    }
}
