using System;
namespace Tunnel.Model
{
    /// <summary>
    /// 实体类Tunnel_bumf 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tunnel_bumf
    {
        public Tunnel_bumf()
        { }
        #region Model
        private long _b_id;
        private string _b_title;
        private int _b_sort;
        private DateTime _b_time;
        private string _b_file;
        private int _b_state;
        private int _b_user;
        private string _b_content;
        private string _b_datefield;
        private string _b_formcontent;
        private int _b_suser;
        private int _b_stype;

        /// <summary>
        /// 审批人
        /// </summary>
        public int b_suser {
            set { _b_suser = value; }
            get { return _b_suser; }
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        public int b_stype
        {
            set { _b_stype = value; }
            get { return _b_stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long b_id
        {
            set { _b_id = value; }
            get { return _b_id; }
        }

        /// <summary>
        /// 公文名称
        /// </summary>
        public string b_title {
            set { _b_title = value; }
            get { return _b_title; }
        }
        /// <summary>
        /// 公文分类
        /// </summary>
        public int b_sort
        {
            set { _b_sort = value; }
            get { return _b_sort; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime b_time
        {
            set { _b_time = value; }
            get { return _b_time; }
        }
        /// <summary>
        /// 附件
        /// </summary>
        public string b_file
        {
            set { _b_file = value; }
            get { return _b_file; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int b_state
        {
            set { _b_state = value; }
            get { return _b_state; }
        }
        /// <summary>
        /// 发布人ID
        /// </summary>
        public int b_user
        {
            set { _b_user = value; }
            get { return _b_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string b_content
        {
            set { _b_content = value; }
            get { return _b_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string b_datefield
        {
            set { _b_datefield = value; }
            get { return _b_datefield; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string b_formcontent
        {
            set { _b_formcontent = value; }
            get { return _b_formcontent; }
        }
        #endregion Model

    }
}

