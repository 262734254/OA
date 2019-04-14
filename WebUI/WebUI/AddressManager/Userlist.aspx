<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Userlist.aspx.cs" Inherits="AddressManager_Userlist" %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表信息页面</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/>
      <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
       <script type="text/javascript">
        function selAll(obj)
        {
            var items=document.getElementsByTagName("input");
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
    </script>
    <style type="text/css">
        .style2
        {
            width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style3
        {
          width: 700px;
            height:300px;	
        }
      
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <table class="style2">
            <tr>
                <td align="center" class="title1">
                    <h3>用户信息管理</h3></td>
            </tr>
            <tr>
                <td align="center">
       
        <table>
            <tr>
                <td rowspan="3" class="style2" valign="top">
                <uc1:WebUserControl ID="WebUserControl1" runat="server" />
                    &nbsp;</td>
                <td>
                    姓名：<asp:TextBox ID="TextBox1" class="inputs" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" class="BigButton" Text="查   询" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="AddUserInfo.aspx">新增用户信息</a>
                </td>
            </tr>
            <tr>
                <td style="text-align:left">
                    <input type="button" class="BigButton" value="删  除" onclick="return confirm('确定要删除？')"/>
                </td>
            </tr>
            <tr>
                
                <td valign="top">
                     <table class="style3" cellpadding="0" cellspacing="0">
                    <tr align="center" class="TableHeader">
                        <td>
                                <input id="Checkbox1" type="checkbox" onclick="selAll(this)" />序号</td>
                        <td>
                            姓名</td>
                        <td>
                           年龄</td>
                        <td>
                            电话号码</td>
                        <td>
                            详情</td>
                        <td>
                            修改</td>
                        <td>
                            删除</td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox2" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">详情</a></td>
                        <td>
                            <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel" runat="server" OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox3" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">
                            详情</a></td>
                        <td>
                           <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel0" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox4" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">详情</a></td>
                        <td>
                            <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel1" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox5" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">
                            详情</a></td>
                        <td>
                           <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel2" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox6" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">详情</a></td>
                        <td>
                            <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel3" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox7" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UserInfoDetails.aspx">
                            详情</a></td>
                        <td>
                           <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel4" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox8" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                          <a href="UserInfoDetails.aspx">
                            详情</a></td>
                        <td>
                            <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel5" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td>
                                <input id="Checkbox9" type="checkbox" />数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                           <a href="UserInfoDetails.aspx">
                            详情</a></td>
                        <td>
                            <a href="UpdateUserInfo.aspx">
                            修改</a></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel6" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                </table></td>
            </tr>
            <tr>
                
                <td colspan="2">
                    共有Label记录&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp; 首页&nbsp; 上一页&nbsp; 下一页&nbsp;&nbsp; 尾页</td>
            </tr>
        </table>
    
                </td>
            </tr>
        </table>
    
    </div>
    
    </form>
</body>
</html>
