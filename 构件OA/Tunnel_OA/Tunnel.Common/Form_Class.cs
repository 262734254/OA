using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Tunnel.Common
{
    /// <summary>
    /// 智能表单宏控件处理类
    /// </summary>
    public class Form_Class
    {
        private int _User_Id;

        private Tunnel.BLL.Tunnel_menber _Tbm = new Tunnel.BLL.Tunnel_menber();

        private Tunnel.Model.Tunnel_menber _Tmm = new Tunnel.Model.Tunnel_menber();

        private Tunnel.BLL.Tunnel_bum bt = new Tunnel.BLL.Tunnel_bum();

        public Form_Class()
        {

            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

            this._User_Id = ul.LoginID;

        }

        /// <summary>
        /// 智能表单内容处理
        /// </summary>
        /// <param name="htmlcontent">表单内容</param>
        /// <param name="value">表单控件值</param>
        /// <param name="dishtml">是否去掉表单控件</param>
        /// <returns>替换后的内容</returns>
        public string From_Content(string htmlcontent, string value, bool dishtml)
        {
            string content = htmlcontent.Replace("\n", "");
            content = content.Replace("\r", "");
            content = content.Replace("\t", "");
            int LV_ID = 0;
            string input_tag = @"(<input)((.|\n)*?)(>)|(<img)((.|\n)*?)(>)|(<select)((.|\n)*?)(\</select>)|(<textarea)((.|\n)*?)(\</textarea>)";
            MatchCollection mx = Regex.Matches(content, input_tag);
            foreach (Match match in mx)
            {
                if (Regex.IsMatch(match.Value, @"(<select)((.|\n)*?)(\</select>)"))
                {
                    LV_ID++;
                    content = content.Replace(match.Value, SelectTagReplace(match.Value, LV_ID, value, dishtml));
                }
                else if (Regex.IsMatch(match.Value, @"(<input)((.|\n)*?)(>)"))
                {
                    LV_ID++;
                    content = content.Replace(match.Value, InputTagReplace(match.Value, LV_ID, value, dishtml));
                }
                else if (Regex.IsMatch(match.Value, @"(<textarea)((.|\n)*?)(\</textarea>)"))
                {
                    LV_ID++;
                    content = content.Replace(match.Value, TextareaTagReplace(match.Value, LV_ID, value, dishtml));
                }
                else if (Regex.IsMatch(match.Value, @"(<img)((.|\n)*?)(>)"))
                {
                    //LV_ID++;
                    content = content.Replace(match.Value, ImgTagReplace(match.Value, LV_ID, dishtml));
                }
            }
            return content;
        }

        #region 图片控件内容替换
        /// <summary>
        /// 图片控件内容替换
        /// </summary>
        /// <param name="match">控件内容</param>
        /// <param name="lid">序号</param>
        /// <param name="dishtml">是否去掉表单控件</param>
        /// <returns>替换后的控件内容</returns>
        private string ImgTagReplace(string match, int lid, bool dishtml)
        {
            string[] inputarr = null;
            string formtitle = "";
            string INP_ID = "DATA_" + lid;
            string formjs = "";
            string formhidden = "";
            string formstyle = "";
            string formsrc = "";
            inputarr = match.Split(' ');
            if (Regex.IsMatch(match, @"(<img)((.|\n)*?)(>)"))
            {
                foreach (string listtag in inputarr)
                {
                    string[] listsontag = listtag.Split('=');
                    if (listsontag.Length > 0)
                    {
                        switch (listsontag[0])
                        {
                            case "class":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                if (listsontag[1].ToUpper() == "USER")
                                {
                                    formhidden = "<input type='hidden' name='USER_" + (lid-1) + "' value='' >";
                                    formjs = "onclick=\"SelectUser('','USER_" + (lid-1) + "','DATA_" + lid+ "')\"";
                                }
                                else if (listsontag[1].ToUpper() == "DATE")
                                {
                                    formjs = "onclick=\"td_calendar(this,'DATA_" + lid + "')\"";
                                }
                                else
                                {
                                    formjs = "";
                                }
                                break;
                            case "title":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formtitle = getListTag(listsontag[1], "");
                                break;
                            case "src":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formsrc = listsontag[1] + " ";
                                break;
                            case "style":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formstyle += "style=\"" + listsontag[1] + ";cursor:pointer\" ";
                                break;
                            case "height":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formstyle += "height=\"" + listsontag[1] + "\" ";
                                break;
                            case "width":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formstyle += "width=\"" + listsontag[1] + "\" ";
                                break;
                        }
                    }
                }
                if (dishtml)
                {
                    if (!string.IsNullOrEmpty(formtitle))
                        return "";
                    else
                        return "<img " + formstyle + " src=\"" + formsrc + "\">";
                }
                else
                {
                    return formhidden + "<img title=\"" + formtitle + "\" " + formstyle + " " + formjs + " src=\"" + formsrc + "\">";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 表单多行文本输入控件内容替换
        /// <summary>
        /// 表单多行文本输入控件内容替换
        /// </summary>
        /// <param name="match">控件内容</param>
        /// <param name="lid">序号</param>
        /// <returns>替换后的控件内容</returns>
        private string TextareaTagReplace(string match, int lid, string value, bool dishtml)
        {
            string[] inputarr = null;
            string formtitle = "";
            string INP_ID = "DATA_" + lid;
            string formstyle = "";
            string formvalue = "";
            match = match.Replace(": ", ":");
            match = match.Replace("; ", ";");
            inputarr = match.Split(' ');
            if (Regex.IsMatch(match, @"(<textarea)((.|\n)*?)(\</textarea>)"))
            {
                foreach (string listtag in inputarr)
                {
                    string[] listsontag = listtag.Split('=');
                    if (listsontag.Length > 0)
                    {
                        switch (listsontag[0])
                        {
                            case "style":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formstyle = listsontag[1];
                                break;
                            case "title":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formtitle = listsontag[1];
                                break;
                        }
                    }
                }
                if (!"".Equals(value))
                {
                    string[] values = Regex.Split(value, "<@Sep@>");
                    formvalue = values[lid - 1];
                }
                if (dishtml)
                {
                    formvalue = formvalue.Replace("\n", "<br/>");
                    formvalue = formvalue.Replace("\r", "<br/>");
                    formvalue = formvalue.Replace(" ", "&nbsp;&nbsp;");
                    return formvalue;
                }
                else
                {
                    return "<TEXTAREA NAME=\"" + INP_ID + "\" title=\"" + formtitle + "\" style=" + formstyle + ">" + formvalue + "</TEXTAREA>";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 表单单行文本输入控件内容替换
        /// <summary>
        /// 表单单行文本输入控件内容替换
        /// </summary>
        /// <param name="match">控件内容</param>
        /// <param name="lid">序号</param>
        /// <returns>替换后的控件内容</returns>
        private string InputTagReplace(string match, int lid, string value, bool dishtml)
        {
            string[] inputarr = null;
            string formcontent = "";
            string formtitle = "";
            string formtype = "";
            string formvalue = "";
            string formsize = "";
            string INP_ID = "DATA_" + lid;
            string textvalue = "";
            inputarr = match.Split(' ');
            if (Regex.IsMatch(match, @"(<input)((.|\n)*?)(>)"))
            {
                foreach (string listtag in inputarr)
                {
                    string[] listsontag = listtag.Split('=');
                    if (listsontag.Length > 0)
                    {
                        switch (listsontag[0])
                        {
                            case "datafld":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formcontent = getDataTag(listsontag[1]);
                                break;
                            case "title":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formtitle = listsontag[1];
                                break;
                            case "type":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formtype = listsontag[1];
                                break;
                            case "value":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formvalue = listsontag[1];
                                break;
                            case "size":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formsize ="size="+listsontag[1];
                                break;
                        }
                    }
                }
                if (!"".Equals(value))
                {
                    string[] values = Regex.Split(value, "<@Sep@>");
                    textvalue = values[lid - 1];
                    formcontent = textvalue;
                }
                if (dishtml)
                {
                    return formcontent;
                }
                else
                {
                    return "<input name='" + INP_ID + "' " + (formvalue == "on" ? "checked=checked" : "") + " value='" + formcontent + "' " + formsize + " title='名称：" + formtitle + ",序号：" + lid + "' type='" + formtype + "'/>";
                }
            }
            else
            {
                if (!"".Equals(value))
                {
                    string[] values = Regex.Split(value, "<@Sep@>");
                    textvalue = values[lid - 1];
                }
                if (dishtml)
                {
                    return textvalue;
                }
                else
                {
                    return "<input name='" + INP_ID + "' value=\"" + textvalue + "\" type='text'/>";
                }
            }
        }
        #endregion

        #region 表单列表控件内容替换
        /// <summary>
        /// 表单列表控件内容替换
        /// </summary>
        /// <param name="match">控件内容</param>
        /// <param name="lid">序号</param>
        /// <param name="value">控件值</param>
        /// <param name="dishtml">是否显不控件</param>
        /// <returns>替换后的控件内容</returns>
        private string SelectTagReplace(string match, int lid, string value, bool dishtml)
        {
            string[] inputarr = null;
            string formcontent = "";
            string formtitle = "";
            string INP_ID = "DATA_" + lid;
            string selectvalue = "";
            inputarr = match.Split(' ');
            if (!"".Equals(value))
            {
                string[] values = Regex.Split(value, "<@Sep@>");
                selectvalue = values[lid - 1];
            }
            if (Regex.IsMatch(match, @"(<select datafld=(.)*)((.|\n)*?)(\</select>)"))
            {
                foreach (string listtag in inputarr)
                {
                    string[] listsontag = listtag.Split('=');
                    if (listsontag.Length > 0)
                    {
                        switch (listsontag[0])
                        {
                            case "datafld":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formcontent = getListTag(listsontag[1], selectvalue);
                                break;
                            case "title":
                                listsontag[1] = listsontag[1].Replace("\"", "");
                                formtitle = listsontag[1];
                                break;
                        }
                    }
                }
                if (dishtml)
                {
                    return selectvalue;//直接显示值

                }
                else
                {
                    return "<select name='" + INP_ID + "' title='名称：" + formtitle + ",序号：" + lid + "'>" + formcontent + "</select>";
                }
            }
            else
            {
                if (dishtml)
                {
                    return selectvalue;
                }
                else
                {
                    match = Regex.Replace(match, "name=('|\")((.|\n)*?)(\"|')", "name='" + INP_ID + "'");
                    if (!"".Equals(selectvalue))
                    {
                        if (match.IndexOf(selectvalue) >= 0)
                        {
                            match = match.Replace("selected=selected", "");
                            match = match.Replace("selected=\"selected\"", "");
                            int len = match.IndexOf(selectvalue);
                            match = match.Insert(len + selectvalue.Length + 1, " selected=selected");
                        }
                    }
                    return match.ToString();
                }
            }

        }
        #endregion

        #region 智能表单宏控件单行输入框处理
        /// <summary>
        /// 智能表单宏控件单行输入框处理
        /// </summary>
        /// <param name="datafld">类型</param>
        /// <returns>结果</returns>
        private string getDataTag(string datafld)
        {
            string Tag_Content = string.Empty;
            if (datafld == string.Empty)
            {
                return "";
            }
            else
            {
                switch (datafld)
                {
                    case "SYS_DATE"://当前日期，形如 1999-01-01
                        Tag_Content = DateTime.Now.ToShortDateString();
                        break;
                    case "SYS_DATE_CN"://当前日期，形如 2009年1月1日

                        Tag_Content = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                        break;
                    case "SYS_DATE_CN_SHORT3"://当前日期，形如 2009年

                        Tag_Content = DateTime.Now.Year.ToString() + "年";
                        break;
                    case "SYS_DATE_CN_SHORT4"://当前年份，形如 2009
                        Tag_Content = DateTime.Now.Year.ToString();
                        break;
                    case "SYS_DATE_CN_SHORT1"://当前日期，形如 2009年1月

                        Tag_Content = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月";
                        break;
                    case "SYS_DATE_CN_SHORT2"://当前日期，形如 1月1日

                        Tag_Content = DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                        break;
                    case "SYS_TIME"://当前时间
                        Tag_Content = DateTime.Now.ToLongTimeString();
                        break;
                    case "SYS_DATETIME"://当前日期+时间
                        Tag_Content = DateTime.Now.ToString();
                        break;
                    case "SYS_USERID":
                    case "SYS_USERNAME":
                    case "SYS_DEPTNAME":
                    case "SYS_USERPRIV":
                        string _User_Fld = datafld;
                        _Tmm = _Tbm.GetModel(this._User_Id);
                        switch (_User_Fld)
                        {
                            case "SYS_USERID"://当前用户ID
                                Tag_Content = _Tmm.m_id.ToString();
                                break;
                            case "SYS_USERNAME"://当前用户姓名
                                Tag_Content = _Tmm.m_name;
                                break;
                            case "SYS_DEPTNAME"://当前用户部门
                                Tag_Content = Tunnel.Common.GetValue.getDataValue("Tunnel_bum", "b_name", "b_id=" + _Tmm.m_bum);
                                break;
                            case "SYS_USERPRIV"://当前用户角色
                                Tag_Content = Tunnel.Common.GetValue.getDataValue("Tunnel_jiaose", "j_name", "j_id=" + _Tmm.m_jiao);
                                break;
                            default:
                                Tag_Content = "";
                                break;
                        }
                        break;
                    case "SYS_RUNID"://流水号

                        Tag_Content = Tunnel.Common.GetValue.getDataValue("Tunnel_RunId", "run_currentid", "run_id=1");
                        break;
                    case "SYS_IP"://经办人IP地址
                        Tag_Content = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                        break;
                    default:
                        Tag_Content = "";
                        break;
                }
                return Tag_Content;
            }
        }

        #endregion

        #region 智能表单宏控件下拉菜单处理

        /// <summary>
        /// 智能表单宏控件下拉菜单处理

        /// </summary>
        /// <param name="datafld">类型</param>
        /// <returns>结果</returns>
        private string getListTag(string datafld, string value)
        {
            string Tag_Content = string.Empty;
            if (datafld == string.Empty)
            {
                return "";
            }
            else
            {
                switch (datafld)
                {
                    case "SYS_LIST_DEPT"://部门列表
                        Tag_Content = getParList(value);
                        break;
                    default:
                        Tag_Content = "";
                        break;
                }
                return Tag_Content;
            }
        }

        #endregion

        #region 无限级部门Select列表
        /// <summary>
        /// 顶级部门列表
        /// </summary>
        /// <returns>Option列表</returns>
        private string getParList(string value)
        {
            StringBuilder list = new StringBuilder();
            DataSet ds = bt.GetList("b_hid=0");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Append("<option value='" + dr["b_name"].ToString() + "' " + (value == dr["b_name"].ToString() ? " selected=selected" : "") + ">" + dr["b_name"].ToString() + "</option>");
                    list.Append(getSonList(dr["b_id"].ToString(), "--", value));
                }
            }
            return list.ToString();
        }

        /// <summary>
        /// 部门子列表

        /// </summary>
        /// <param name="hid">上级部门ID</param>
        /// <param name="space">间隔符</param>
        /// <returns>Option列表</returns>
        private string getSonList(string hid, string space, string value)
        {
            StringBuilder list = new StringBuilder();
            DataSet ds = bt.GetList("b_hid=" + hid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Append("<option value='" + dr["b_name"].ToString() + "' " + (value == dr["b_name"].ToString() ? " selected=selected" : "") + ">" + space + dr["b_name"].ToString() + "</option>");
                    getSonList(dr["b_id"].ToString(), space + "----", value);
                }
            }
            return list.ToString();
        }
        #endregion
    }
}