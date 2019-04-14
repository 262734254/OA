using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Tunnel.Model;

public partial class Dachie_UserAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserSave();
    }
    public void UserSave()
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
        Tunnel.Model.Tunnel_jiaose tjj = new Tunnel_jiaose();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
        Tunnel.Model.Tunnel_uyingshe tuu = new Tunnel_uyingshe();


        tmm.m_login = txtName.Value.Trim();
        tmm.m_name = txtName.Value.Trim();
        tmm.m_password = Tunnel.Data.DESEncrypt.Encrypt(txtPwd.Text.Trim());
        //tmm.m_mail = txtMail.Text.Trim();

        //if (Tunnel.Common.RegexComm.IsValidEmail(tmm.m_mail))
        //{
            if (tm.GetModelList("m_login='" + tmm.m_login + "'").Count == 0)
            {
                tmm.m_spassword = Tunnel.Data.DESEncrypt.Encrypt("123456");
                int i = tm.Add(tmm);
                if (i > 0)
                {
                    tuu.uy_uid = i.ToString();
                    tuu.uy_list = "";
                    tu.Add(tuu);
                    Tunnel.Common.Message.Show("添加用户成功,请继续完善资料,审批密码默认为123456,请尽快修改!", "tunnel_userupd.aspx?updid=" + i.ToString() + "");
                }
                else
                {
                    Tunnel.Common.Message.Show("注册失败");
                }
            }
            else
            {
                Tunnel.Common.Message.Show("用户名已占用");
            }
        //}
        //else
        //{
        //    Tunnel.Common.Message.Show("不是有效的邮箱名");
        //}

    }
}
