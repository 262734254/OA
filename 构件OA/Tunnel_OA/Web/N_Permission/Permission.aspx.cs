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

public partial class N_Permission_Permission : System.Web.UI.Page
{
    public Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public static int tmpId = 0;//相应的管理编号
    public string tempName = "";//管理类型名称
    public string tempName_TypeName = "";//管理类中相应的设置对象名称
    public static int typeId = 0;//管理类型编号


    /// <summary>
    /// 根据 用户编号获取用户拥有的所有权限
    /// </summary>
    /// <param name="userId"></param>
    public void GetUserAllPermission(int userId)
    {
        ListBox3.Items.Clear();
        int bumId = 0;
        int dutyId = 0;
        int jueSeId = 0;
        string qxList = string.Empty;

        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();

        Tunnel.BLL.Tunnel_uyingshe uy = new Tunnel.BLL.Tunnel_uyingshe();
        Tunnel.Model.Tunnel_uyingshe uyy = new Tunnel.Model.Tunnel_uyingshe();

        Tunnel.BLL.Tunnel_dyingshe dy = new Tunnel.BLL.Tunnel_dyingshe();
        Tunnel.Model.Tunnel_dyingshe dyy = new Tunnel.Model.Tunnel_dyingshe();

        Tunnel.BLL.Tunnel_yingshe jy = new Tunnel.BLL.Tunnel_yingshe();
        Tunnel.Model.Tunnel_yingshe jyy = new Tunnel.Model.Tunnel_yingshe();

        Tunnel.BLL.Tunnel_byingshe by = new Tunnel.BLL.Tunnel_byingshe();
        Tunnel.Model.Tunnel_byingshe byy = new Tunnel.Model.Tunnel_byingshe();

        tmm = tm.GetModel(userId);

        #region 判断
        if (tmm != null)
        {
            bumId = tmm.m_bum;
            dutyId = tmm.m_duty;
            jueSeId = tmm.m_jiao;
            if (uy.GetModelList("uy_uid=" + userId).Count > 0)
            {
                uyy = uy.GetModelList("uy_uid=" + userId)[0];
                if (uyy != null)
                    if (uyy.uy_list.Length > 0)
                        qxList += uyy.uy_list + "|";
            }
            if (by.GetModelList("by_bid=" + bumId).Count > 0)
            {
                byy = by.GetModelList("by_bid=" + bumId)[0];
                if (byy != null)
                    if (byy.by_list.Length > 0)
                        qxList += byy.by_list + "|";
            }
            if (dy.GetModelList("dy_did=" + dutyId).Count > 0)
            {
                dyy = dy.GetModelList("dy_did=" + dutyId)[0];
                if (dyy != null)
                    if (dyy.dy_list.Length > 0)
                        qxList += dyy.dy_list + "|";
            }
            if (jy.GetModelList("y_jsid=" + jueSeId).Count > 0)
            {
                jyy = jy.GetModelList("y_jsid=" + jueSeId)[0];
                if (jyy != null)
                    if (jyy.y_qxlist.Length > 0)
                        qxList += jyy.y_qxlist + "|";

            }
            if (qxList.Length > 1)
                qxList = qxList.Substring(0, qxList.Length - 1);

        }
        #endregion
        Tunnel.BLL.Tunnel_quanxian tq = new Tunnel.BLL.Tunnel_quanxian();

        if (qxList.Length > 0)
        {
            foreach (string item in qxList.Split('|'))
            {
                Tunnel.Model.Tunnel_quanxian tqq = new Tunnel.Model.Tunnel_quanxian();
                tqq = tq.GetModel(int.Parse(item));
                if (tqq != null)
                {
                    ListItem li = new ListItem(tqq.q_mark + "-->>" + tqq.q_name, tqq.q_id.ToString());
                    if (!ListBox3.Items.Contains(li))
                    {
                        ListBox3.Items.Add(li);
                    }
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            getAllPermission();
            getIdtypeId(ref tmpId, ref typeId);
            PageBind(tmpId, typeId);
        }
    }
    /// <summary>
    /// 得到 类型ID 和 ID
    /// </summary>
    public void getIdtypeId(ref int tmpId, ref int typeId)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
        {
            tmpId = Convert.ToInt32(Request.QueryString["uid"].ToString());
            tempName = "用户管理";
            Tunnel.BLL.Tunnel_menber menberBLL = new Tunnel.BLL.Tunnel_menber();
            Tunnel.Model.Tunnel_menber menberModel = menberBLL.GetModel(tmpId);
            tempName_TypeName = menberModel.m_name;
            typeId = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
            {
                GetUserAllPermission(int.Parse(Request.QueryString["uid"]));
            }
        }
        if (!string.IsNullOrEmpty(Request.QueryString["jid"]))
        {
            tmpId = Convert.ToInt32(Request.QueryString["jid"].ToString());
            tempName = "角色管理";
            Tunnel.BLL.Tunnel_jiaose jiaoseBLL = new Tunnel.BLL.Tunnel_jiaose();
            Tunnel.Model.Tunnel_jiaose jiaoseModel = jiaoseBLL.GetModel(tmpId);
            tempName_TypeName = jiaoseModel.j_name;
            this.tmpSet.Visible = false;
            typeId = 2;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["did"]))
        {
            tmpId = Convert.ToInt32(Request.QueryString["did"].ToString());
            tempName = "职位管理";
            Tunnel.BLL.Tunnel_duty dutyBLL = new Tunnel.BLL.Tunnel_duty();
            Tunnel.Model.Tunnel_duty dutyModel = dutyBLL.GetModel(tmpId);
            tempName_TypeName = dutyModel.d_name;
            this.tmpSet.Visible = false;
            typeId = 3;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["bid"]))
        {
            tmpId = Convert.ToInt32(Request.QueryString["bid"].ToString());
            Tunnel.BLL.Tunnel_bum bumBLL = new Tunnel.BLL.Tunnel_bum();
            Tunnel.Model.Tunnel_bum bumModels = bumBLL.GetModel(tmpId);
            tempName_TypeName = bumModels.b_name;
            tempName = "部门管理";
            this.tmpSet.Visible = false;
            typeId = 4;
        }

    }
    /// <summary>
    /// 得到所有权限
    /// </summary>
    public Dictionary<int, string> getAllPermission()
    {
        Dictionary<int, string> allDic = new Dictionary<int, string>();

        Tunnel.BLL.Tunnel_quanxian tq = new Tunnel.BLL.Tunnel_quanxian();
        List<Tunnel.Model.Tunnel_quanxian> tqList = new List<Tunnel.Model.Tunnel_quanxian>();
        if (ul.JiaoSe(ul.LoginID) == "系统管理员")
        {
            tqList = tq.GetModelList("1=1 order by q_rId asc ");
            foreach (Tunnel.Model.Tunnel_quanxian item in tqList)
            {
                allDic.Add(item.q_id, item.q_mark + "-->>" + item.q_name);
            }
        }
        else
        {
            Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
            Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
            tmm = tm.GetModel(ul.LoginID);
            if (!string.IsNullOrEmpty(Convert.ToString(tmm.m_bum)))
            {
                Tunnel.BLL.Tunnel_byingshe tb = new Tunnel.BLL.Tunnel_byingshe();
                Tunnel.Model.Tunnel_byingshe tbb = new Tunnel.Model.Tunnel_byingshe();
                List<Tunnel.Model.Tunnel_byingshe> tbList = new List<Tunnel.Model.Tunnel_byingshe>();
                tbList = tb.GetModelList("by_bid = " + tmm.m_bum + "");
                if (tbList.Count > 0)
                {
                    tbb = tbList[0];
                    string byList = tbb.by_list;
                    if (byList.Length > 0)
                    {
                        string[] temp = byList.Split('|');
                        foreach (string item in temp)
                        {
                            Tunnel.Model.Tunnel_quanxian tqq = new Tunnel.Model.Tunnel_quanxian();
                            tqq = tq.GetModel(int.Parse(item));
                            if (tqq != null)
                            {
                                allDic.Add(tqq.q_id, tqq.q_mark + "-->>" + tqq.q_name);
                            }
                        }
                    }
                }
            }
        }
        return allDic;
    }

    /// <summary>
    /// 绑定listview
    /// </summary>
    /// <param name="tmpId">id</param>
    /// <param name="typeId">类系 1,用户  2,角色  3,职务 4.部门</param>
    public void PageBind(int tmpId, int typeId)
    {
        if (typeId == 1)
            ListBox3.Visible = true;
        Dictionary<int, string> cloneDic = new Dictionary<int, string>(getAllPermission());
        ListBox3.Items.Clear();
        ListBox2.Items.Clear();
        string TempList = string.Empty;
        switch (typeId)
        {
            case 1:
                TempList = string.Empty;
                Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
                List<Tunnel.Model.Tunnel_uyingshe> tuuList = tu.GetModelList("uy_uid = " + tmpId + "");
                if (tuuList.Count > 0)
                {
                    TempList = tuuList[0].uy_list;
                    if (TempList.Length > 0)
                    {
                        foreach (string item in TempList.Split('|'))
                        {
                            string tempValue = string.Empty;
                            if (getAllPermission().TryGetValue(int.Parse(item), out tempValue))
                            {
                                ListBox2.Items.Add(new ListItem(tempValue, item));
                                cloneDic.Remove(int.Parse(item));
                            }
                        }
                    }
                }
                foreach (KeyValuePair<int, string> item in cloneDic)
                {
                    ListBox1.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }
                GetUserAllPermission(tmpId);
                break;
            case 2:
                TempList = string.Empty;
                Tunnel.BLL.Tunnel_yingshe tj = new Tunnel.BLL.Tunnel_yingshe();
                List<Tunnel.Model.Tunnel_yingshe> tjjList = tj.GetModelList("y_jsid = " + tmpId + "");
                if (tjjList.Count > 0)
                {
                    TempList = tjjList[0].y_qxlist;
                    if (TempList.Length > 0)
                    {
                        foreach (string item in TempList.Split('|'))
                        {
                            string tempValue = string.Empty;
                            if (getAllPermission().TryGetValue(int.Parse(item), out tempValue))
                            {
                                ListBox2.Items.Add(new ListItem(tempValue, item));
                                cloneDic.Remove(int.Parse(item));
                            }
                        }
                    }
                }
                foreach (KeyValuePair<int, string> item in cloneDic)
                {
                    ListBox1.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }
                break;
            case 3:
                TempList = string.Empty;
                Tunnel.BLL.Tunnel_dyingshe td = new Tunnel.BLL.Tunnel_dyingshe();
                List<Tunnel.Model.Tunnel_dyingshe> tddList = td.GetModelList("dy_did = " + tmpId + "");
                if (tddList.Count > 0)
                {
                    TempList = tddList[0].dy_list;
                    if (TempList.Length > 0)
                    {
                        foreach (string item in TempList.Split('|'))
                        {
                            string tempValue = string.Empty;
                            if (getAllPermission().TryGetValue(int.Parse(item), out tempValue))
                            {
                                ListBox2.Items.Add(new ListItem(tempValue, item));
                                cloneDic.Remove(int.Parse(item));
                            }
                        }
                    }
                }
                foreach (KeyValuePair<int, string> item in cloneDic)
                {
                    ListBox1.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }
                break;
            case 4:
                TempList = string.Empty;
                Tunnel.BLL.Tunnel_byingshe tb = new Tunnel.BLL.Tunnel_byingshe();
                List<Tunnel.Model.Tunnel_byingshe> tbbList = tb.GetModelList("by_bid = " + tmpId + "");
                if (tbbList.Count > 0)
                {
                    TempList = tbbList[0].by_list;
                    if (TempList.Length > 0)
                    {
                        foreach (string item in TempList.Split('|'))
                        {
                            string tempValue = string.Empty;
                            if (getAllPermission().TryGetValue(int.Parse(item), out tempValue))
                            {
                                ListBox2.Items.Add(new ListItem(tempValue, item));
                                cloneDic.Remove(int.Parse(item));
                            }
                        }
                    }
                }
                foreach (KeyValuePair<int, string> item in cloneDic)
                {
                    ListBox1.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 得到权限string
    /// </summary>
    /// <returns></returns>
    public string getString()
    {
        string tempString = string.Empty;
        foreach (ListItem item in ListBox2.Items)
        {
            tempString += item.Value + "|";
        }
        if (tempString.Length > 0)
        {
            //更新添加权限，用‘|’连接成字符串,去除最后的竖线
            tempString = tempString.Substring(0, tempString.Length - 1);
        }
        return tempString;
    }

    /// <summary>
    /// 更新权限
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        switch (typeId)
        {
            #region 添加/更新用户权限
            case 1:
                Tunnel.BLL.Tunnel_uyingshe tyu = new Tunnel.BLL.Tunnel_uyingshe();
                Tunnel.Model.Tunnel_uyingshe tyuu = new Tunnel.Model.Tunnel_uyingshe();
                List<Tunnel.Model.Tunnel_uyingshe> uslist = new List<Tunnel.Model.Tunnel_uyingshe>();
                uslist = tyu.GetModelList("uy_uid='" + tmpId + "'");
                if (uslist.Count > 0)
                {
                    tyuu.uy_id = uslist[0].uy_id;
                    tyuu.uy_uid = tmpId.ToString();
                    tyuu.uy_list = getString();
                    tyu.Update(tyuu);
                    Tunnel.Common.Message.Show("更新用户权限成功");//更新用户权限
                }
                else
                {
                    tyuu.uy_uid = tmpId.ToString();
                    tyuu.uy_list = getString();
                    tyu.Add(tyuu);
                    Tunnel.Common.Message.Show("添加用户权限成功");//更新用户权限
                }
                ListBox2.Items.Clear();

                break;
            #endregion

            #region 添加/更新角色权限
            case 2:
                Tunnel.BLL.Tunnel_yingshe tyj = new Tunnel.BLL.Tunnel_yingshe();
                Tunnel.Model.Tunnel_yingshe tyjj = new Tunnel.Model.Tunnel_yingshe();
                List<Tunnel.Model.Tunnel_yingshe> jslist = new List<Tunnel.Model.Tunnel_yingshe>();
                jslist = tyj.GetModelList("y_jsid=" + tmpId + "");
                if (jslist.Count > 0)
                {
                    tyjj.y_id = jslist[0].y_id;
                    tyjj.y_jsid = tmpId;
                    tyjj.y_qxlist = getString();
                    tyj.Update(tyjj);
                    Tunnel.Common.Message.Show("更新角色权限成功");//更新角色权限
                }
                else
                {
                    tyjj.y_jsid = tmpId;
                    tyjj.y_qxlist = getString();
                    tyj.Add(tyjj);
                    Tunnel.Common.Message.Show("添加角色权限成功");//添加角色权限
                }
                ListBox2.Items.Clear();
                break;
            #endregion

            #region 添加/更新职位权限
            case 3:
                Tunnel.BLL.Tunnel_dyingshe tyd = new Tunnel.BLL.Tunnel_dyingshe();
                Tunnel.Model.Tunnel_dyingshe tydd = new Tunnel.Model.Tunnel_dyingshe();
                List<Tunnel.Model.Tunnel_dyingshe> dulist = new List<Tunnel.Model.Tunnel_dyingshe>();
                dulist = tyd.GetModelList("dy_did='" + tmpId + "'");
                if (dulist.Count > 0)
                {
                    tydd.dy_id = dulist[0].dy_id;
                    tydd.dy_did = tmpId.ToString();
                    tydd.dy_list = getString();
                    tyd.Update(tydd);
                    Tunnel.Common.Message.Show("更新职位权限成功");//更新职务权限
                }
                else
                {
                    tydd.dy_did = tmpId.ToString();
                    tydd.dy_list = getString();
                    tyd.Add(tydd);
                    Tunnel.Common.Message.Show("添加职位权限成功");//添加职务权限
                }
                ListBox2.Items.Clear();
                break;
            #endregion

            #region 添加/更新部门权限
            case 4:
                Tunnel.BLL.Tunnel_byingshe tyb = new Tunnel.BLL.Tunnel_byingshe();
                Tunnel.Model.Tunnel_byingshe tybb = new Tunnel.Model.Tunnel_byingshe();
                List<Tunnel.Model.Tunnel_byingshe> bulist = new List<Tunnel.Model.Tunnel_byingshe>();
                bulist = tyb.GetModelList("by_bid='" + tmpId + "'");
                //判断是修改还是添加权限
                if (bulist.Count > 0)
                {
                    tybb.by_id = bulist[0].by_id;
                    tybb.by_bid = tmpId.ToString();
                    tybb.by_list = getString();
                    tyb.Update(tybb);
                    Tunnel.Common.Message.Show("更新部门权限成功");//更新部门权限
                }
                else
                {
                    tybb.by_bid = tmpId.ToString();
                    tybb.by_list = getString();
                    tyb.Add(tybb);
                    Tunnel.Common.Message.Show("添加部门权限成功");//添加部门权限
                }
                ListBox2.Items.Clear();
                break;
            #endregion
            default:
                break;
        }
    }

    protected void btnRight_Click(object sender, EventArgs e)
    {
        Dictionary<int, string> tmpDic = new Dictionary<int, string>(getAllPermission());
        Dictionary<int, string> dic = new Dictionary<int, string>();
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                ListItem li = new ListItem(item.Text, item.Value);
                if (!ListBox3.Items.Contains(li))
                {
                    dic.Add(int.Parse(item.Value), item.Text);
                }
            }
        }
        foreach (KeyValuePair<int, string> item in dic)
        {
            ListBox2.Items.Add(new ListItem(item.Value, item.Key.ToString()));
        }
        ListBox1.Items.Clear();
        foreach (KeyValuePair<int, string> item in tmpDic)
        {
            ListItem li = new ListItem(item.Value, item.Key.ToString());
            if (!ListBox3.Items.Contains(li))
                ListBox1.Items.Add(li);
        }
    }

    protected void btnLeft_Click(object sender, EventArgs e)
    {
        Dictionary<int, string> dic1 = new Dictionary<int, string>(getAllPermission());
        Dictionary<int, string> dic = new Dictionary<int, string>();

        foreach (ListItem item in ListBox2.Items)
        {
            if (!item.Selected)
                dic.Add(int.Parse(item.Value), item.Text);
        }
        ListBox2.Items.Clear();
        foreach (KeyValuePair<int, string> item in dic)
        {
            ListBox2.Items.Add(new ListItem(item.Value, item.Key.ToString()));
        }
        ListBox1.Items.Clear();
        foreach (KeyValuePair<int, string> item in dic1)
        {
            ListItem li = new ListItem(item.Value, item.Key.ToString());
            if (!ListBox2.Items.Contains(li))
                ListBox1.Items.Add(li);
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        switch (typeId)
        {
            case 1:
                Response.Redirect("../N_SysManage/N_User/Tunnel_UserList.aspx");
                break;
            case 2:
                Response.Redirect("../N_SysManage/N_Juese/Tunnel_JueSeGuanLi.aspx");
                break;
            case 3:
                Response.Redirect("../N_SysManage/N_Duty/Tunnel_DutyList.aspx");
                break;
            case 4:
                Response.Redirect("../N_SysManage/N_Bum/Tunnel_Bum.aspx");
                break;

            default:
                break;
        }
    }
}