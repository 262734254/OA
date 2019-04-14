using System;
namespace Tunnel.Model
{
    /// <summary>
    /// 实体类Tunnel_step 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tunnel_step
    {
        public Tunnel_step()
        { }
        #region Model
        private long _s_id;
        private string _s_name;
        private int _s_num;
        private string _s_zid;
        private int _s_lid;
        private string _s_depict;
        private int _s_ishui;
        private int _s_isbak;
        /// <summary>
        /// 
        /// </summary>
        public long s_id
        {
            set { _s_id = value; }
            get { return _s_id; }
        }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string s_name
        {
            set { _s_name = value; }
            get { return _s_name; }
        }
        /// <summary>
        /// 步骤序号
        /// </summary>
        public int s_num
        {
            set { _s_num = value; }
            get { return _s_num; }
        }
        /// <summary>
        /// 执行人ID
        /// </summary>
        public string s_zid
        {
            set { _s_zid = value; }
            get { return _s_zid; }
        }
        /// <summary>
        /// 流程ID
        /// </summary>
        public int s_lid
        {
            set { _s_lid = value; }
            get { return _s_lid; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string s_depict
        {
            set { _s_depict = value; }
            get { return _s_depict; }
        }
        /// <summary>
        /// 是否允许会签
        /// </summary>
        public int s_ishui
        {
            set { _s_ishui = value; }
            get { return _s_ishui; }
        }
        /// <summary>
        /// 是否允许回退
        /// </summary>
        public int s_isbak
        {
            set { _s_isbak = value; }
            get { return _s_isbak; }
        }
        #endregion Model

    }
}

