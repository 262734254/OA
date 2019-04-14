using System;
namespace Tunnel.Model
{
    /// <summary>
    /// ʵ����Tunnel_bumf ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ������
        /// </summary>
        public int b_suser {
            set { _b_suser = value; }
            get { return _b_suser; }
        }
        /// <summary>
        /// ����ʱ��
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
        /// ��������
        /// </summary>
        public string b_title {
            set { _b_title = value; }
            get { return _b_title; }
        }
        /// <summary>
        /// ���ķ���
        /// </summary>
        public int b_sort
        {
            set { _b_sort = value; }
            get { return _b_sort; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime b_time
        {
            set { _b_time = value; }
            get { return _b_time; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string b_file
        {
            set { _b_file = value; }
            get { return _b_file; }
        }
        /// <summary>
        /// ״̬
        /// </summary>
        public int b_state
        {
            set { _b_state = value; }
            get { return _b_state; }
        }
        /// <summary>
        /// ������ID
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

