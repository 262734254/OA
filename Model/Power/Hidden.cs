using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Model
{
	/// <summary>
	/// 类Hidden。
	/// </summary>
    public class Hidden
    {
        public Hidden()
        { }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int? roleid;

        public int? Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }
        private int? add;

        public int? Add
        {
            get { return add; }
            set { add = value; }
        }
        private int? delete;

        public int? Delete
        {
            get { return delete; }
            set { delete = value; }
        }
        private int? update;

        public int? Update
        {
            get { return update; }
            set { update = value; }
        }
        private int? select;

        public int? Select
        {
            get { return select; }
            set { select = value; }
        }
        private int? checke;

        public int? Checke
        {
            get { return checke; }
            set { checke = value; }
        }
        private int? send;

        public int? Send
        {
            get { return send; }
            set { send = value; }
        }
        private int? back;

        public int? Back
        {
            get { return back; }
            set { back = value; }
        }
        private int? comein;

        public int? Comein
        {
            get { return comein; }
            set { comein = value; }
        }
    }

}