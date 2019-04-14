using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
   public class Tunnel_Performance
    {
        private int createUser;

        public int CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       private int type;

       public int Type
       {
           get { return type; }
           set { type = value; }
       }
       private string title;

       public string Title
       {
           get { return title; }
           set { title = value; }
       }

 
       private string file;

       public string File
       {
           get { return file; }
           set { file = value; }
       }
       private string name;

       public string Name
       {
           get { return name; }
           set { name = value; }
       }
       private DateTime createDate;

       public DateTime CreateDate
       {
           get { return createDate; }
           set { createDate = value; }
       }
    


}
}
