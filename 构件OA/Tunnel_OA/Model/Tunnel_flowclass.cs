using System;
namespace Tunnel.Model
{
	/// <summary>
	/// ʵ����Tunnel_flowclass���̷���� ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Tunnel_flowclass
	{
		public Tunnel_flowclass()
		{}
		#region Model
		private long _fc_id;
		private string _fc_name;
        private string _fc_desin;

        /// <summary>
        /// ���౸ע
        /// </summary>
        public string Fc_desin
        {
            get { return _fc_desin; }
            set { _fc_desin = value; }
        }
		/// <summary>
        /// ����ID
		/// </summary>
		public long fc_id
		{
			set{ _fc_id=value;}
			get{return _fc_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string fc_name
		{
			set{ _fc_name=value;}
			get{return _fc_name;}
		}
		#endregion Model

	}
}

