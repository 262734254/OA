using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_file�ļ� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_file
	{
		public Tunnel_file()
		{}
		#region Model
		private long _f_id;
		private string _f_title;
		private string _f_file;
		private string _f_size;
		private int _f_sort;
		private DateTime _f_addtime;
		private int _f_user;
		private string _f_juser;
        private int f_type;
        private string f_ip;
        private string f_content;
        private int f_bum;
		/// <summary>
		/// 
		/// </summary>
		public long f_id
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// �ļ�����
		/// </summary>
		public string f_title
		{
			set{ _f_title=value;}
			get{return _f_title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string f_file
		{
			set{ _f_file=value;}
			get{return _f_file;}
		}
		/// <summary>
		/// �ļ���С
		/// </summary>
		public string f_size
		{
			set{ _f_size=value;}
			get{return _f_size;}
		}
		/// <summary>
		/// 1�ǹ��� 0������
		/// </summary>
		public int f_sort
		{
			set{ _f_sort=value;}
			get{return _f_sort;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime f_addtime
		{
			set{ _f_addtime=value;}
			get{return _f_addtime;}
		}
		/// <summary>
		/// ������	
		/// </summary>
		public int f_user
		{
			set{ _f_user=value;}
			get{return _f_user;}
		}
		/// <summary>
		/// �����û�
		/// </summary>
		public string f_juser
		{
			set{ _f_juser=value;}
			get{return _f_juser;}
		}
        /// <summary>
        /// ��������1����������û� 2�����ָ���û�
        /// </summary>
        public int f_Type
        {
            set { f_type = value; }
            get { return f_type; }
        }

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string f_Ip
        {
            set { f_ip = value; }
            get { return f_ip; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string f_Content
        {
            set { f_content = value; }
            get { return f_content; }
        }

        /// <summary>
        /// ����Id
        /// </summary>
        public int f_Bum
        {
            set { f_bum = value; }
            get { return f_bum; }
        }
		#endregion Model

	}
}

