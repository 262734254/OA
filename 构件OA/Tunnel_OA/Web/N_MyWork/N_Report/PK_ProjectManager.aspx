<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="PK_ProjectManager.aspx.cs" Inherits="SystemManage_KaoHe_Tunnel_SpuDFList" %>

<asp:Content runat="server" ID="contetn1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td runat="server" width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ExamineAdd.aspx" class="a" id=xinzengkaohe runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增考核</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ProjectDel.aspx" class="a" id=guanligongcheng runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理工程</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="Rate.aspx" class="a" id=kaohedafen runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核打分</div>
                </a>
            </td>
            <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="PK_ProjectManager.aspx" class="a" id=kaohepaihang runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核排行</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    
        <style>
        .widht
        {
            width: 65px;
            text-align: center;
        }
    </style>
    <table  border="1"
        style="width: 700px; height: 100%" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <caption class="tou">
            盾构分公司<%=nianyue.Substring(0,4) %>年<%=nianyue.Substring(4,2) %>月项目经理月收入考核排行表<br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </caption>
        <tr style="height: 20px; background: #f6f6f6">
            <td class="widht">
                被考核人
            </td>
            <td class="widht">
                工程项目
            </td>
            <td class="widht">
                成本控制<br />
                10分<br />
                经营计划部
            </td>
            <td class="widht">
                虚拟账户<br />
                5分<br />
                经营计划部
            </td>
            <td class="widht">
                生产计划<br />
                5分<br />
                经营计划部
            </td>
            <td class="widht">
                文明施工<br />
                10分<br />
                安全管理部
            </td>
            <td class="widht">
                安全生产<br />
                20分<br />
                安全管理部
            </td>
            <td class="widht">
                工程质量<br />
                20分<br />
                工程管理部
            </td>
            <td class="widht">
                设备管理<br />
                5分<br />
                资产管理部
            </td>
            <td class="widht">
                材料管理<br />
                5分<br />
                资产管理部
            </td>
            <td class="widht">
                综合治理<br />
                5分<br />
                安全管理部
            </td>
            <td class="widht">
                贯标工作<br />
                5分<br />
                贯标办公室
            </td>
            <td class="widht">
                宣传工作<br />
                5分<br />
                信息管理中心
            </td>
            <td class="widht">
                党支部工作<br />
                5分<br />
                人力资源部
            </td>
            <td class="widht">
                信息工作<br />
                5分<br />
                信息管理中心
            </td>
            <td class="widht">
                总分<br />
                105分
            </td>
            <td class="widht">
                收入
            </td>
        </tr>

        <asp:Repeater runat="server" ID="GridView1">
            <ItemTemplate>
                <tr style="height: 20px" onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td class="widht">
                        <%#Eval("UserName")%>
                    </td>
                    <td class="widht">
                        <%#Eval("ItemsName")%>
                    </td>
                    <td class="widht">
                        <%#Eval("CbkzCent")%>
                    </td>
                    <td class="widht">
                        <%#Eval("XnzhCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("ScjhCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("WmsgCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("AqscCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("GczlCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("SbglCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("ClglCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("ZhzlCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("GbgzCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("XcgzCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("DzbgzCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("XxgzCent") %>
                    </td>
                    <td class="widht">
                        <%#Eval("AllCent") %>
                    </td>
                    <td class="widht">
                        &nbsp;<%#Eval("Income") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
