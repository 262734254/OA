using System;
namespace Tunnel.Model
{
	/// <summary>
    /// ʵ����Tunnel_vannewpaper �ȷ汨 ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_vannewpaper
	{
		public Tunnel_vannewpaper()
		{}
		#region Model
		private long _v_id;
		private string _v_title;
		private string _v_img;
        private string _v_file;
		private int _v_user;
		private int _v_sort;
        private string v_ip;
		/// <summary>
		/// 
		/// </summary>
		public long v_id
		{
			set{ _v_id=value;}
			get{return _v_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string v_title
		{
			set{ _v_title=value;}
			get{return _v_title;}
		}
		/// <summary>
		/// ����ͼ
		/// </summary>
		public string v_img
		{
			set{ _v_img=value;}
			get{return _v_img;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string v_file
		{
			set{ _v_file=value;}
			get{return _v_file;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int v_user
		{
			set{ _v_user=value;}
			get{return _v_user;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int v_sort
		{
			set{ _v_sort=value;}
			get{return _v_sort;}
		}

        /// <summary>
        /// �û�Ip
        /// </summary>
        public string v_Ip
        {
            set { v_ip = value; }
            get { return v_ip; }
        }
		#endregion Model

	}
}

