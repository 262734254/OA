using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类Car_Type 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Car_Type
    {
        public Car_Type()
        { }
        #region Model
        private int typeid;
        private string genre;
        /// <summary>
        /// 
        /// </summary>
        public int TypeId
        {
            set { typeid = value; }
            get { return typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Genre
        {
            set { genre = value; }
            get { return genre; }
        }
        #endregion Model

    }
}


