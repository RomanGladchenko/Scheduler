using System;
using Gl.DataManipulation;
using Gl.FileManipulation;
using System.Collections.Generic;

namespace Gl
{
    class MainClass
    {

        public static void PrintMenu()
        { 
            Console.WriteLine("1 - Read From File \n" +
                "2 - Display inactive cases first \n" +
                "3 - Find Record By Text \n"+
                "4 - Delete Record By Id\n"+
                "5 - Edit Text Record By Id \n" +
                "6 - Save Record in File\n"+
                "7 - Clear List\n" +
                "8 - Show Record\n"+
                "9 - Mark entry completed / failed By Id\n" +
                "10 - Add new Record \n" +
                "Any Key - Exit" );
        }

        public static void ShowMessagePressAnyKey()
        {
            Console.WriteLine("Press any button to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Main(string[] args)
        {
            List<ConnectionInfo> Record = new List<ConnectionInfo>();
            LoadConnectionInfo ConnectionLoader = new LoadConnectionInfo();
            SaveConnectionInfo ConnectionSave = new SaveConnectionInfo();
            RecordList<ConnectionInfo> RecordList = new RecordList<ConnectionInfo>();
            while (true)
            {
                PrintMenu();
                Int32.TryParse(Console.ReadLine(), out Int32 CaseKey);
               
                switch (CaseKey)
                { 
                    case 1:

                        Console.WriteLine("Read from file");
                        Record.Clear();
                        String FileName = Console.ReadLine() + ".txt";
                        Record = ConnectionLoader.LoadText(FileName, true).Result;
                        ShowMessagePressAnyKey();
                        break;

                    case 2:

                        Console.WriteLine("Display inactive cases first");
                        Record.Sort();
                        RecordList<ConnectionInfo>.PrintRecord(Record);
                        ShowMessagePressAnyKey();
                        break;

                    case 3:

                        
                        Console.WriteLine("Find Record By Text");
                        string TextForSearchRecords = Console.ReadLine();
                        RecordList<ConnectionInfo>.PrintRecord(Record.FindAll(x => x.Text.Contains(TextForSearchRecords)));
                        ShowMessagePressAnyKey();
                        break;

                    case 4:


                        Console.WriteLine("Delete Record By Id");
                        Int32.TryParse(Console.ReadLine(), out Int32 DeleteById);
                        Record.RemoveAll(x => (x.Id == DeleteById));
                        ShowMessagePressAnyKey();
                        break;

                    case 5:


                        Console.WriteLine("Edit Text Record By Id");
                        Int32.TryParse(Console.ReadLine(), out Int32 IdForSearchRecords);
                        Record.Find(x => x.Id == IdForSearchRecords).Text = Console.ReadLine();
                        ShowMessagePressAnyKey();

                        break;
                        
                    case 6: 

                        Console.WriteLine("Save Record in File");
                        String FileNameWhereToSaveRecord = Console.ReadLine() + ".txt";
                        ConnectionSave.SaveFileWithRecords(Record,FileNameWhereToSaveRecord);
                        ShowMessagePressAnyKey();

                        break;

                    case 7:

                        Console.WriteLine("Clear List");
                        Record.Clear();
                        ShowMessagePressAnyKey();
                        break;

                    case 8:

                        Console.WriteLine("Show Record");
                        RecordList<ConnectionInfo>.PrintRecord(Record);
                        ShowMessagePressAnyKey();

                        break;

                    case 9:

                        Console.WriteLine("Mark entry completed / failed By Id");
                        Int32.TryParse(Console.ReadLine(), out Int32 IdForSearchRecordsToggleActive);
                        Int32 IndexForChangeActive = Record.FindIndex(x => x.Id == IdForSearchRecordsToggleActive);
                        Record[IndexForChangeActive].Active = !Record[IndexForChangeActive].Active;
                        ShowMessagePressAnyKey();

                        break;

                    case 10:

                        Console.WriteLine("Add new Record")
                        Record.Add(new ConnectionInfo(id:Record.Count+1,text:Console.ReadLine(),false));
                        ShowMessagePressAnyKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Error 404");
                        Environment.Exit(0);
                        break;

                }

            }


        }
    }
}
