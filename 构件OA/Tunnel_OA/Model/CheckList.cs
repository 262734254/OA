using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    [Serializable]
    public class CheckList
    {
        public CheckList()
        {
            cent = 0;
        }
        private string itemsName;//项目名
        private string userName;//考核人的名字
        private int score;//总分
        private string income;//收入
        private string checkdate;//年月
        private string workName;//工作名称
        private int cent;//分数
        private string bumName;//部门名称
        private int maxCent;//最大分值
        private string pFlist;

        public string ItemsName
        {
            set { itemsName = value; }
            get { return itemsName; }
        }

        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }

        public int Score
        {
            set { score = value; }
            get { return score; }
        }

        public string Income
        {
            set { income = value; }
            get { return income; }
        }

        public string Checkdate
        {
            set { checkdate = value; }
            get { return checkdate; }
        }

        public string WorkName
        {
            set { workName = value; }
            get { return workName; }
        }

        public int Cent
        {
            set { cent = value; }
            get { return cent; }
        }

        public string BumName
        {
            set { bumName = value; }
            get { return bumName; }
        }

        public int MaxCent
        {
            set { maxCent = value; }
            get { return maxCent; }
        }

        public string PFlist
        {
            set { pFlist = value; }
            get { return pFlist; }
        }
    }
}
