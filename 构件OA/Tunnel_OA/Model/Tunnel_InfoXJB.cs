using System;
using System.Collections.Generic;
using System.Text;

namespace Tunnel.Model
{
    public class Tunnel_InfoXJB
    {
        private int id;
        private int typeId;
        private int sectype;
        private string title;
        private string content;
        private string imagePaht;
        private string htmlSource;
        private DateTime setDate;
        private int userId;
        //private string imageBind;
        private string files;
        private int bum_bz;
        private int modiUser;
        private DateTime modiDate;
        private int delUser;
        private DateTime delDate;
        private int del;
        private string filename;

        public Tunnel_InfoXJB()
        {
            id = 0;
            typeId = 0;
            sectype = 0;
            title = string.Empty;
            content = string.Empty;
            imagePaht = string.Empty;
            htmlSource = string.Empty;
            setDate = Convert.ToDateTime("1800-01-01");
            userId = 0;
            files = string.Empty;
            bum_bz = 0;
            modiUser = 0;
            modiDate = Convert.ToDateTime("1800-01-01");
            delUser = 0;
            delDate = Convert.ToDateTime("1800-01-01");
            del = 0;
            filename = string.Empty;
        }

        /// <summary>
        /// 附件名
        /// </summary>
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary>
        /// 二级分类
        /// </summary>
        public int Sectype
        {
            get { return sectype; }
            set { sectype = value; }
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
        public DateTime SetDate
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
        /// 修改人
        /// </summary>
        public int ModiUser
        {
            set { modiUser = value; }
            get { return modiUser; }
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModiDate
        {
            set { modiDate = value; }
            get { return modiDate; }
        }
        /// <summary>
        /// 删除人
        /// </summary>
        public int DelUser
        {
            set { delUser = value; }
            get { return delUser; }
        }
        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime DelDate
        {
            set { delDate = value; }
            get { return delDate; }
        }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int Del
        {
            set { del = value; }
            get { return del; }
        }
        /// <summary>
        /// 绑定的图片
        /// </summary>
        //public string ImageBind
        //{
        //    set { imageBind = value; }
        //    get { return imageBind; }
        //}
    }
}
