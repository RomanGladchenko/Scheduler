using System;
using System.Collections.Generic;
using System.IO;

namespace Gl.FileManipulation
{
    public class SaveConnectionInfo: IBaseSave<ConnectionInfo>
    {
        public SaveConnectionInfo()
        {
        }


        public bool SaveFileWithRecords(List<ConnectionInfo> obj, string FileName)
        {

            using (StreamWriter sw = new StreamWriter("../../FileUpload/"+FileName))
            {
                sw.WriteLine("Id;Text;Active;");
                foreach (var item in obj)
                {

                    sw.WriteLine("{0};{1};{2};", item.Id, item.Text, item.Active);

                }
                return true;
            }
            
        }

    }
}
