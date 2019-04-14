using System;
namespace Tunnel.Model
{
	/// <summary>
	/// 实体类Tunnel_menber 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Tunnel_menber
	{
		public Tunnel_menber()
		{
            m_bum = 0;
            m_duty = 0;
            m_xjb = "";
            m_flag = string.Empty;
            m_idcard = "";
            m_jiao = 0;
            m_login = "";
            m_mail = "";
            m_mobile="";
            m_name="";
            m_password="";
            m_spassword="";
            m_state = 0;
            m_zdyqx = 0;
            m_birth = Convert.ToDateTime("1800-01-01");
            m_ksid = "";
            
        }
		#region Model
		private long _m_id;
		private string _m_login;
		private string _m_name;
		private string _m_password;
		private string _m_mobile;
		private string _m_mail;
		private string _m_idcard;
		private string _m_spassword;
		private int _m_jiao;
		private int _m_bum;
		private int _m_duty;
        private string _m_xjb;
		private int _m_state;
		private string _m_flag;
		private int _m_zdyqx;
        private string m_selected;
        private string m_ip;
        private DateTime _m_birth;
        private string _m_online;
        private string _m_counttime;
        private string m_ksid;
        /// <summary>
        /// 总在线时间
        /// </summary>
        public string m_counttime
        {
            get { return _m_counttime; }
            set { _m_counttime = value; }
        }
        private string _m_onlinetime;

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string m_onlinetime
        {
            get { return _m_onlinetime; }
            set { _m_onlinetime = value; }
        }

        /// <summary>
        /// 是否登录，1：登录0：未登录
        /// </summary>
        public string m_online
        {
            get { return _m_online; }
            set { _m_online = value; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime m_birth
        {
            set { _m_birth = value; }
            get {return _m_birth; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long m_id
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string m_login
		{
			set{ _m_login=value;}
			get{return _m_login;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string m_name
		{
			set{ _m_name=value;}
			get{return _m_name;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string m_password
		{
			set{ _m_password=value;}
			get{return _m_password;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string m_mobile
		{
			set{ _m_mobile=value;}
			get{return _m_mobile;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string m_mail
		{
			set{ _m_mail=value;}
			get{return _m_mail;}
		}
		/// <summary>
		/// 身份证
		/// </summary>
		public string m_idcard
		{
			set{ _m_idcard=value;}
			get{return _m_idcard;}
		}
		/// <summary>
		/// 审批密码
		/// </summary>
		public string m_spassword
		{
			set{ _m_spassword=value;}
			get{return _m_spassword;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int m_jiao
		{
			set{ _m_jiao=value;}
			get{return _m_jiao;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public int m_bum
		{
			set{ _m_bum=value;}
			get{return _m_bum;}
		}
		/// <summary>
		/// 职务ID
		/// </summary>
		public int m_duty
		{
			set{ _m_duty=value;}
			get{return _m_duty;}
		}
        /// <summary>
        /// 项经部ID
        /// </summary>
        public string m_xjb
        {
            set { _m_xjb = value; }
            get { return _m_xjb; }
        }
		/// <summary>
		/// 状态
		/// </summary>
		public int m_state
		{
			set{ _m_state=value;}
			get{return _m_state;}
		}
		/// <summary>
		/// 没用了
		/// </summary>
		public string m_flag
		{
			set{ _m_flag=value;}
			get{return _m_flag;}
		}
		/// <summary>
		/// 自定义权限 默认0 则无自定义权限
		/// </summary>
		public int m_zdyqx
		{
			set{ _m_zdyqx=value;}
			get{return _m_zdyqx;}
		}

        /// <summary>
        /// 是否被选中
        /// </summary>
        public string m_Selected
        {
            set { m_selected = value; }
            get { return m_selected; }
        }

        /// <summary>
        /// 用户Ip
        /// </summary>
        public string m_Ip
        {
            set { m_ip = value; }
            get { return m_ip; }
        }

        /// <summary>
        /// 科室ID
        /// </summary>
        public string m_KSID
        {
            set { m_ksid = value; }
            get { return m_ksid; }
        }
		#endregion Model

	}
}

