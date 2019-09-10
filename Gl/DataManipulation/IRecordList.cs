using System;
namespace Gl.DataManipulation
{
    public interface IRecordList<T> where T : class
    {
        void AddNewRecord(T obj);
        void DeleteRecordById(Int32 id);
        void FindRecordById(Int32 id);
        void SortRecord();

    }
}
