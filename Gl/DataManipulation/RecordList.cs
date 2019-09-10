using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Gl.DataManipulation
{
    public class RecordList<T>  where T : class 
    {
        public RecordList()
        {

        }


       public static void PrintRecord(List<T> obj)
        {
            if (obj.Count != 0)
            {
                foreach (var item in obj)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("List is Empty");
                Console.ReadKey();
            }
        }
    }
}
