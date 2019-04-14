using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;

public partial class N_Project_Project_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel_ProJectMent TPModel = new Tunnel_ProJectMent();
        TPModel.Pro_Title = tb_Title.Text.Trim();
        TPModel.Pro_Name = tb_Title0.Text.Trim();
        TPModel.Pro_Manager = 0;
        TPModel.Pro_StartDate = Convert.ToDateTime(tb_Title1.Text.Trim());

        //人员需求计划
        TPModel.Pro_ManDate = Convert.ToDateTime(tb_Title2.Text.Trim());
        //合同签订计划
        TPModel.Pro_ContractDate = Convert.ToDateTime(tb_Title3.Text.Trim());
        //设备需求计划
        TPModel.Pro_EquipmentDate = Convert.ToDateTime(tb_Title4.Text.Trim());
        //材料进场计划
        TPModel.Pro_MaterialDate = Convert.ToDateTime(tb_Title5.Text.Trim());
        //施工方案编制计划
        TPModel.Pro_PlanDate = Convert.ToDateTime(tb_Title6.Text.Trim());
        //安全申报计划
        TPModel.Pro_SecurityDate = Convert.ToDateTime(tb_Title7.Text.Trim());

        Tunnel.BLL.Tunnel_ProJectMent TPBll = new Tunnel.BLL.Tunnel_ProJectMent();
        int ReSult = TPBll.Add(TPModel);
        if (ReSult > 0)
        {
            Tunnel_bum TbModel = new Tunnel_bum();
            TbModel.b_name = tb_Title0.Text.Trim();
            TbModel.b_depict = tb_Title.Text.Trim();
            TbModel.b_hid = 0;
            TbModel.b_projectid = ReSult;
            Tunnel.BLL.Tunnel_bum TbBll = new Tunnel.BLL.Tunnel_bum();
            if (TbBll.Add(TbModel) > 0)
            {
                Tunnel.Common.Message.Show("项目新建成功!");
            }
        }
    }
}