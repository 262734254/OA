using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_jiaose ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_jiaose
	{
		public Tunnel_jiaose()
		{}
		#region Model
		private long _j_id;
		private string _j_name;
		private string _j_depict;
		private string _j_flag;
		private int _j_zdyjs;
		/// <summary>
		/// 
		/// </summary>
		public long j_id
		{
			set{ _j_id=value;}
			get{return _j_id;}
		}
		/// <summary>
		/// ��ɫ����
		/// </summary>
        public string j_name
		{
			set{ _j_name=value;}
			get{return _j_name;}
		}
		/// <summary>
		/// ����
		/// </summary>
        public string j_depict
		{
			set{ _j_depict=value;}
			get{return _j_depict;}
		}
		/// <summary>
		/// Ȩ��
		/// </summary>
		public string j_flag
		{
			set{ _j_flag=value;}
			get{return _j_flag;}
		}
		/// <summary>
		/// �Ƿ��Զ����ɫ  0 �����Զ���
		/// </summary>
		public int j_zdyjs
		{
			set{ _j_zdyjs=value;}
			get{return _j_zdyjs;}
		}
		#endregion Model

	}
}

