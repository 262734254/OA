using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_quanxian ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_quanxian
	{
		public Tunnel_quanxian()
		{}
		#region Model
		private int _q_id;
		private string _q_name;
		private string _q_mark;
        private int _q_rId;

        public int q_rId
        {
            get { return _q_rId; }
            set { _q_rId = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int q_id
		{
			set{ _q_id=value;}
			get{return _q_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string q_name
		{
			set{ _q_name=value;}
			get{return _q_name;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string q_mark
		{
			set{ _q_mark=value;}
			get{return _q_mark;}
		}
		#endregion Model

	}
}

