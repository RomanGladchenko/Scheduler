using System;

namespace Gl
{
    public class ConnectionInfo : IComparable  , IEquatable<ConnectionInfo>
    {
       
        public Int32 Id { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }

        public ConnectionInfo()
        {

        }
        public ConnectionInfo(Int32 id , string text , bool active)
        {
            Id = id;
            Text = text;
            Active = active;
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
            {
                return 1;
            }

            ConnectionInfo compareobj = obj as ConnectionInfo;
            if(compareobj != null)
            {
                return Active.CompareTo(compareobj.Active);
            }
            else
            {
                throw new ArgumentException("Object is not a ConenctionInfo");
            }
            
        }

        public override string ToString() => $"ID: {Id} ;Text: {Text}; Active: {Active}";

        public bool Equals(ConnectionInfo other)
        {
            if (other == null)
            {
                return false;
            }
            ConnectionInfo ObjAsConnectionInfo = other as ConnectionInfo;
            if (ObjAsConnectionInfo == null) return false;
            else return Equals(ObjAsConnectionInfo);

        }


      

    }
}
