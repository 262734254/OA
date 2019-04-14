using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Web;
using System.IO;

namespace Tunnel.Common
{
    /// <summary>
    /// 发送邮件类
    /// </summary>
    public class SendEamil
    {
        /// <summary>
        /// 发送邮件的地址
        /// </summary>
        /// 
        public string SmtpAddrees
        {
            get { return ConfigurationManager.AppSettings["SenderEmailSererAddress"]; }
        }

        /// <summary>
        /// 发送人的邮箱
        /// </summary>
        public string NcUserEmail
        {
            get { return ConfigurationManager.AppSettings["SenderUserEmail"]; }
        }

        /// <summary>
        /// 发送邮件的密码
        /// </summary>
        public string NcUserPassword
        {
            get { return ConfigurationManager.AppSettings["UserEmailPassword"]; }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sendEmail">发信人邮箱</param>
        /// <param name="toEamil">目的邮箱</param>
        /// <param name="title">邮件标题</param>
        /// <param name="body">正文</param>
        /// <param name="attact">附件</param>
        public int SendEmail(string sendEmail, string toEamil, string title, string body, string[] attact)
        {
            try
            {
               
                if (string.IsNullOrEmpty(title))
                    return 3;

                title = title.Replace("\r", "").Replace("\n", "");

                if (string.IsNullOrEmpty(sendEmail))
                    return 1;

                if (string.IsNullOrEmpty(toEamil))
                    return 2;


                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(sendEmail, toEamil, title, body);

                //if (toEamil.ToLower().IndexOf("@yahoo.") >= 0)
                //{
                //    Encoding conven = Encoding.BigEndianUnicode;
                //    //conven = Encoding.UTF32;
                //    conven = Encoding.GetEncoding("HZ");
                //    message.BodyEncoding = conven;
                //} 
               

                if (attact != null)
                {
                    foreach (string s in attact)
                    {
                        if (File.Exists(s))
                            message.Attachments.Add(new Attachment(s));
                    }
                }

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.IsBodyHtml = true;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(SmtpAddrees);

                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(NcUserEmail, NcUserPassword);

                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                client.Send(message);

                

                message.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        /// <summary>
        /// 输出Js
        /// </summary>
        /// <param name="jsContent">js代码</param>
        public void ResponseJs(string jsContent)
        {
            StringBuilder sbjs = new StringBuilder();

            sbjs.Append("<script type='text/javascript'>");

            sbjs.Append(jsContent);

            sbjs.Append("</script>");
        }


    }
}
