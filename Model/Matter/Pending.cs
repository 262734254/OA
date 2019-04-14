using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class Pending
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string responseMan;

        public string ResponseMan
        {
            get { return responseMan; }
            set { responseMan = value; }
        }
    
       
        private string timer;

        public string Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        private string applicationType;

        public string ApplicationType
        {
            get { return applicationType; }
            set { applicationType = value; }
        }
        private string states;

        public string States
        {
            get { return states; }
            set { states = value; }
        }
        private Task task = new Task();

        public Task Task
        {
            get { return task; }
            set { task = value; }
        }

        
    }
}
