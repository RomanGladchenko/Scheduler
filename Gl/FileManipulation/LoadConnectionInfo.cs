using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Gl.FileManipulation
{
    public class LoadConnectionInfo : IBaseLoader<ConnectionInfo>
    {
        public LoadConnectionInfo()
        {
        }

        public string FindFile(string FileName)
        {
            string sourceDirectory = "../../";
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, FileName, SearchOption.AllDirectories);

                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(sourceDirectory.Length);
                    if (File.Exists(currentFile))
                    {
                        return  currentFile;
                    }

                }
                throw new ArgumentException("File Not Found");
                
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return null;
        }

        public async Task<List<ConnectionInfo>> LoadText(string FileName, bool HasTitle = false)
        {
            try
            {
                    FileName = FindFile(FileName);
                    if(!String.IsNullOrEmpty(FileName))
                    {
                         using (StreamReader stream = new StreamReader(FileName))
                        {
                            if (HasTitle)
                            {
                                await stream.ReadLineAsync();
                            }

                            var result = new List<ConnectionInfo>();
                            string str = string.Empty;

                            while ((str = await stream.ReadLineAsync()) != null)
                            {
                                var objValues = str.Split(new Char[] { ';' });

                                Int32.TryParse(objValues[0], out Int32 Id);

                                Boolean.TryParse(objValues[2], out Boolean Active);
                                ConnectionInfo obj = new ConnectionInfo(Id, objValues[1], Active);
                                result.Add(obj);

                            }

                            return result;
                         }
 
                    }
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return null;
        }
    }
}
