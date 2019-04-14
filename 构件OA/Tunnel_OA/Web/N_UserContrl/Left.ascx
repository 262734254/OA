<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="N_UserContrl_Left" %>
<asp:HiddenField runat="server" ID="userid" />
<table cellpadding="0" cellspacing="0" border="0" width="160" class="table">
    <tr valign="top" id="wjgl1" runat="server">
        <td>
            <a href="#" class="topmenu" onclick="showsubmenu('_01');">文件管理</a>
        </td>
    </tr>
    <tr id="pId_01" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="fbgw" runat="server" href="/N_WorkFlow/ODocument/Document_Add.aspx">发布公文</a></li>
                <li><a id="wjcy" runat="server" href="/N_WorkFlow/CDocument/Document_Add.aspx">文件传阅</a></li>
                
                <li><a id="wjgx" runat="server" href="/N_WorkFlow/FShaRing/FShaRing_Add.aspx">文件共享</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top" id="scgl11" runat="server">
        <td>
            <a href="#" class="topmenu" onclick="showsubmenu('_11');">生产管理</a>
        </td>
    </tr>
    <tr id="pId_11" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="scxm" runat="server" href="/N_Produce/Produce_Add.aspx?type=Item&name=项目">项目排片</a></li>
                <li><a id="scap" runat="server" href="/N_Produce/Produce_Add.aspx?type=Plan&name=安排">生产安排</a></li>
                <li><a id="scbb" runat="server" href="/N_Produce/Produce_Add.aspx?type=Report&name=报表">生产报表</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top" id="wdgz1" runat="server">
        <td>
            <a href="#" class="topmenu" onclick="showsubmenu('_07');">我的工作</a>
        </td>
    </tr>
    <tr id="pId_07" runat="server">
        <td>
            <ul id="leftlist">
            <li><a href="/N_MyWork/N_Star/StarAdd.aspx" id="mxyg" runat="server">喜报管理</a></li>
                <li><a href="/N_MyWork/N_Report/Index.aspx" id="cwbb" runat="server">常务报表</a></li>
                <li><a href="/N_WorkFlow/MyApply/Apply_Sp.aspx" id="lcsp" runat="server">流程审批</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top" id="xxjl1" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_04');" class="topmenu">信息交流</a>
        </td>
    </tr>
    <tr id="pId_04" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="wcly" runat="server" href="/N_Message/MessageAdd.aspx">外出留言</a></li>
                <li><a id="zndx" runat="server" href="/N_Exchange/N_Message/N_MessageSend.aspx">站内短信</a></li>
                <li><a id="wbyj" runat="server" href="/N_Exchange/N_ExternalMail/N_MailSend.aspx">外部邮件</a></li>
                <li><a id="lts" runat="server" href="/N_Chat/Default.aspx">聊天室</a></li>                            
            </ul>
        </td>
    </tr>
    <tr valign="top" id="wdkq12" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_12');" class="topmenu">我的申请</a>
        </td>
    </tr>
    <tr id="pId_12" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="qjsq" runat="server" href="/N_WorkFlow/MyApply/Apply_Add.aspx?Flow=67">请假申请</a></li>
                <li><a id="bgsq" runat="server" href="/N_WorkFlow/MyApply/Apply_Add.aspx?Flow=69">报告申请</a></li>
               <%-- <li><a id="kqcx" runat="server" href="">考勤查询</a></li>--%>
                                            
            </ul>
        </td>
    </tr>
    <tr valign="top" id="dagl" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_12');" class="topmenu">档案管理</a>
        </td>
    </tr>
    <tr id="pId_13" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="ryhz" runat="server" href="/N_News/N_FilesManage/N_FilesManageAdd.aspx?type=Glory&name=荣誉">荣誉汇总</a></li>
                <li><a id="tzgl" runat="server" href="/N_News/N_FilesManage/N_FilesManageAdd.aspx?type=Paper&name=图纸">图纸管理</a></li>
                <li><a id="xztp" runat="server" href="/N_News/N_Picture/N_PictureAdd.aspx">图片管理</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top" id="jxkh" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_02');" class="topmenu">绩效考核</a>
        </td>
    </tr>
    <tr id="pId_02" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="kskh" runat="server" href="/N_News/N_Performance/N_SectionAdd.aspx">科室考核</a></li>
                <li><a id="fckh" runat="server" href="/N_News/N_Performance/N_Factory.aspx">分厂考核</a></li>
                <li><a id="glks" runat="server" href="/N_News/N_Performance/N_ManagementSection.aspx">管理科室</a></li>  
                <li><a id="glfc" runat="server" href="/N_News/N_Performance/N_ManagFactory.aspx">管理分厂</a></li>                                            
            </ul>
        </td>
    </tr>
    <tr valign="top" id="xxfb1" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_03');" class="topmenu">信息发布</a>
        </td>
    </tr>
    <tr id="pId_03" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="fbgg" runat="server" href="/N_News/N_Bulletin/N_GonggaoAdd.aspx">公告管理</a></li>
                <li><a id="fbxw" runat="server" href="/N_News/N_News/N_NewAdd.aspx">新闻管理</a></li>
                <li><a id="djxx" runat="server" href="/N_News/N_Information/N_InformationAdd.aspx?type=1">党建信息</a></li>
                <li><a id="ghxx" runat="server" href="/N_News/N_Information/N_InformationAdd.aspx?type=2">工会信息</a></li>
                <li><a id="twxx" runat="server" href="/N_News/N_Information/N_InformationAdd.aspx?type=3">团务信息</a></li>
                <%--<li><a id="jxkh" runat="server" href="/N_News/N_Performance/N_SectionAdd.aspx?type=1&name=科室考核">绩效考核</a></li>--%>
                <li><a id="fbksxx" runat="server" href="/N_News/N_Departments/N_KeshiAdd.aspx">科室信息</a></li>
                <%--<li><a id="bzgf" runat="server" href="/N_News/N_Standard/N_StandardAdd.aspx">标准规范</a></li>--%>
                <li><a id="xjbgl" runat="server" href="/N_News/N_EntryByTheDepartmentOf/N_XJBInfoAdd.aspx">项经部管理</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top">
        <td>
            <a href="#" onclick="showsubmenu('_06');" class="topmenu">个人信息</a>
        </td>
    </tr>
    <tr id="pId_06" runat="server">
        <td>
            <ul id="leftlist">
                <li><a id="grzl" runat="server" href="/N_Personal_Info/N_Personal/Tunnel_UserUpd.aspx">
                    个人资料</a></li>
                <li><a id="maxg" runat="server" href="/N_Personal_Info/N_PassWord/PassUpd.aspx">密码修改</a></li>
            </ul>
        </td>
    </tr>
    <tr valign="top" runat="server" id="xtsz1">
        <td>
            <a href="#" onclick="showsubmenu('_08');" class="topmenu">系统设置</a>
        </td>
    </tr>
    <tr id="pId_08" runat="server">
        <td>
            <ul id="leftlist">
                <li id="lcfl" runat="server"><a onclick="ShowMenu('/N_SysManage/FlowClass/FlowClass_Add.aspx')"
                    href="#">流程分类</a></li>
                <li id="bdsj" runat="server"><a onclick="ShowMenu('/N_SysManage/FormDesign/Form_Add.aspx')"
                    href="#">表单设计</a></li>
                <li id="lcsj" runat="server"><a onclick="ShowMenu('/N_SysManage/FlowDesign/Flow_Add.aspx')"
                    href="#">流程设计</a></li>
                <li id="yhgl" runat="server"><a onclick="ShowMenu('/N_SysManage/N_User/Tunnel_UserAdd.aspx')"
                    href="#">用户管理</a></li>
                <li id="bmgl" runat="server"><a onclick="ShowMenu('/N_SysManage/N_Bum/Tunnel_Bum.aspx')"
                    href="#">部门管理</a></li>
                <li id="zwgl" runat="server"><a onclick="ShowMenu('/N_SysManage/N_Duty/Tunnel_DutyAdd.aspx')"
                    href="#">职务管理</a></li>
                <li id="jsgl" runat="server"><a onclick="ShowMenu('/N_SysManage/N_JueSe/Tunnel_JueseAdd.aspx')"
                    href="#">角色管理</a></li>               
               <%-- <li id="sjbf" runat="server"><a onclick="ShowMenu('/N_SysManage/N_Bak/Tunnel_SQLCopy.aspx')"
                    href="#">数据备份</a></li>--%>
            </ul>
        </td>
    </tr>
   <%-- <tr valign="top" id="wdsq" runat="server">
        <td>
            <a href="#" onclick="showsubmenu('_02');" class="topmenu">我的申请</a>
        </td>
    </tr>
    <tr id="pId_02" runat="server">
        <td>
            <ul id="leftlist">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li><a href="/N_WorkFlow/MyApply/Apply_Add.aspx?Flow=<%#Eval("f_id")%>">
                            <%#Eval("f_name")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                <li><a href="/N_WorkFlow/OtherDocument/Other_Add.aspx">其它申请</a></li>
            </ul>
        </td>
    </tr>--%>
    
</table>
