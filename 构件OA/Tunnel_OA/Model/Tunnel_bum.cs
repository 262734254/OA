using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_bum���ű� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_bum
	{
		public Tunnel_bum()
		{}
		#region Model
		private long _b_id;
		private string _b_name;
		private int _b_hid;
		private string _b_depict;
        private int _b_projectid;

        /// <summary>
        /// �Ƿ�Ϊ����Ǿʹ��϶Դ����ID
        /// </summary>
        public int b_projectid
        {
            get { return _b_projectid; }
            set { _b_projectid = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public long b_id
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string b_name
		{
			set{ _b_name=value;}
			get{return _b_name;}
		}
		/// <summary>
		/// �ϼ�����ID
		/// </summary>
		public int b_hid
		{
			set{ _b_hid=value;}
			get{return _b_hid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string b_depict
		{
			set{ _b_depict=value;}
			get{return _b_depict;}
		}
		#endregion Model

	}
}

