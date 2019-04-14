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
        /// 附件名
        /// </summary>
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        /// <summary>
        /// 部门标识
        /// </summary>
        public int Bum_bz
        {
            get { return bum_bz; }
            set { bum_bz = value; }
        }
        /// <summary>
        /// 附件
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
        /// 类型
        /// </summary>
        public int TypeId
        {
            set { typeId = value; }
            get { return typeId; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePaht
        {
            set { imagePaht = value; }
            get { return imagePaht; }
        }
        /// <summary>
        /// 源码
        /// </summary>
        public string HtmlSource
        {
            set { htmlSource = value; }
            get { return htmlSource; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string SetDate
        {
            set { setDate = value; }
            get { return setDate; }
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }

        /// <summary>
        /// 绑定的图片
        /// </summary>
        public string ImageBind
        {
            set { imageBind = value; }
            get { return imageBind; }
        }
        
        /// <summary>
        /// 指定的浏览人
        /// </summary>
        public string ReadUser
        {
            set { readUser = value; }
            get { return readUser; }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel
        {
            set { isDel = value; }
            get { return isDel; }
        }
    }
}
