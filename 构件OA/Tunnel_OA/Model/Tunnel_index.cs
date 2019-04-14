using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_index
    {
        private int id;
        private int typeId;
        private string title;
        private string content;
        private string imagePaht;
        private string htmlSource;
        private string setDate;
        private int userId;
        private string imageBind;
        private string files;
        private int bum_bz;
        private string filename;
        private string readUser;
        private int isDel;

        /// <summary>
        /// ������
        /// </summary>
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        /// <summary>
        /// ���ű�ʶ
        /// </summary>
        public int Bum_bz
        {
            get { return bum_bz; }
            set { bum_bz = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Files
        {
            get { return files; }
            set { files = value; }
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int TypeId
        {
            set { typeId = value; }
            get { return typeId; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        /// <summary>
        /// �ı�����
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string ImagePaht
        {
            set { imagePaht = value; }
            get { return imagePaht; }
        }
        /// <summary>
        /// Դ��
        /// </summary>
        public string HtmlSource
        {
            set { htmlSource = value; }
            get { return htmlSource; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string SetDate
        {
            set { setDate = value; }
            get { return setDate; }
        }
        /// <summary>
        /// �û�Id
        /// </summary>
        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }

        /// <summary>
        /// �󶨵�ͼƬ
        /// </summary>
        public string ImageBind
        {
            set { imageBind = value; }
            get { return imageBind; }
        }
        
        /// <summary>
        /// ָ���������
        /// </summary>
        public string ReadUser
        {
            set { readUser = value; }
            get { return readUser; }
        }

        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public int IsDel
        {
            set { isDel = value; }
            get { return isDel; }
        }
    }
}
