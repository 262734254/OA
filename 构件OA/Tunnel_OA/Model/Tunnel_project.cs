using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_project���̱� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_project
	{
		public Tunnel_project()
		{}
		#region Model
		private long _p_id;
		private string _p_name;
		private string _p_yname;
		private string _p_jname;
		private string _p_xfile;
		private string _p_zfile;
		private int _p_user;
        private string p_ip;
		/// <summary>
		/// 
		/// </summary>
		public long p_id
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string p_name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// ҵ������
		/// </summary>
		public string p_yname
		{
			set{ _p_yname=value;}
			get{return _p_yname;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string p_jname
		{
			set{ _p_jname=value;}
			get{return _p_jname;}
		}
		/// <summary>
		/// ��Ŀ�ſ�
		/// </summary>
		public string p_xfile
		{
			set{ _p_xfile=value;}
			get{return _p_xfile;}
		}
		/// <summary>
		/// ��֯�ṹ
		/// </summary>
		public string p_zfile
		{
			set{ _p_zfile=value;}
			get{return _p_zfile;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int p_user
		{
			set{ _p_user=value;}
			get{return _p_user;}
		}

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string p_Ip 
        {
            set { p_ip = value; }
            get { return p_ip; }
        }
		#endregion Model

	}
}

