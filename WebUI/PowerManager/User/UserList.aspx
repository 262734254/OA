<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../../css/public.css" type="text/css" rel="stylesheet"/>
 <link href="../../css/6/style.css" type="text/css" rel="Stylesheet" />  
   <style type="text/css">
        .style1
        {
           width:100%;
            background-color:#C6DAF3;
            height:450px;
        }
       
        .style2
       {
           height: 22px;
       }
       
        </style> 
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
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td  align="center" class="title1" valign="top">
      <h3>用户角色管理</h3>
     </td>
            </tr>
            <tr><td align="center" style=" height:50px;">
             
                          用户部门： &nbsp;&nbsp;&nbsp;<asp:DropDownList 
                              style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                              ID="dropDepartment" runat="server"
                    DataTextField="departmentName" DataValueField="Id" 
                              AppendDataBoundItems="True" DataSourceID="objDropDepartment">
                              <asp:ListItem Value="">请选择</asp:ListItem>
                </asp:DropDownList>
                          <asp:ObjectDataSource ID="objDropDepartment" runat="server" 
                              SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                          </asp:ObjectDataSource>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 用户名：
                                <asp:TextBox ID="txtName" Text="" runat="server"  
                              Style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                          &nbsp;身份证号&nbsp;:<asp:TextBox ID="txtCard" Text="" runat="server"  
                              Style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                          &nbsp;&nbsp;状态：<asp:DropDownList ID="dropUserStates" runat="server">
                              <asp:ListItem Value="">请选择</asp:ListItem>
                              <asp:ListItem Value="在职">在职</asp:ListItem>
                              <asp:ListItem Value="离职">离职</asp:ListItem>
                          </asp:DropDownList>
                          &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                <span align="center">
                                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                              Text="查   询" onclick="Button2_Click" />
            </td></tr>
            <tr>
                <td style="text-align:left">
                    &nbsp;<span align="center"><asp:Button ID="BtnDele" runat="server" 
                        class="BigButton" Text="删   除" onclientclick="return confirm('确定要删除？')" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="hlAddUser" runat="server" 
                        NavigateUrl="~/PowerManager/User/AddUser.aspx"><span align="center">新增用户</span></asp:HyperLink>
                </td>
            </tr>
            <tr>
            
          <td align="center" valign="top">
    <table>
            <tr>
                <td>
                    <table style=" width:750px; height:300px;" cellpadding="0" cellspacing="0">
                    <tr align="center" class="TableHeader">
                        <td >
                            <input id="Checkbox10" type="checkbox"/></td>
                        <td >
                            用户编号&gt;                         <td >
                            用户姓名</td>
                        <td >部门名称</td>
                         <td >
                             手机号码</td>
                         <td >
                                 性别</td>
                         <td >
                                 角色</td>
                        <td >
                            状态</td>
                        <td >
                        <span align="center">
                            编辑</td>
                        <td >
                            删除</td>
                    </tr>
                      <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox1" runat="server"  /></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                         <td>性别</td>
                          <td> 
                              <asp:DropDownList ID="DropDownList6" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>状态</td>
                        
                        <td><asp:HyperLink ID="hlEdit" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                            
                         <td>
                                <asp:LinkButton ID="lnkBtnDel" runat="server" OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox3" runat="server" /></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList14" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit7" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel0" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                   <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox4" runat="server" /></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList15" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit8" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel1" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                  <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox5" runat="server"/></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList16" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit9" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel2" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox6" runat="server"/></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList17" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit10" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel3" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox7" runat="server"/></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList18" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit11" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel4" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox8" runat="server"/></td>
                        <td>
                            用户编号</td>
                        <td>
                            用户姓名</td>
                        <td>部门名称</td>
                         <td>
                             手机号码</td>
                             <td>
                                 性别</td>
                             <td>
                              <asp:DropDownList ID="DropDownList19" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            状态</td>
                        <td>
                            <asp:HyperLink ID="hlEdit12" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel5" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td class="style2">
                           <asp:CheckBox ID="CheckBox9" runat="server"/></td>
                        <td class="style2">
                            用户编号</td>
                        <td class="style2">
                            用户姓名</td>
                        <td class="style2">部门名称</td>
                         <td class="style2">
                             手机号码</td>
                             <td class="style2">
                                 性别</td>
                             <td class="style2">
                              <asp:DropDownList ID="DropDownList20" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>部门主管</asp:ListItem>
                                  <asp:ListItem>会议修改员</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td class="style2">
                            状态</td>
                        <td class="style2">
                            <asp:HyperLink ID="hlEdit13" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">编辑</asp:HyperLink>
                            </td>
                        <td class="style2">
                                <asp:LinkButton ID="lnkBtnDel6" runat="server" 
                                OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                                    
                                            </td>
                        <td class="style2">
                                &nbsp;</td>
                    </tr>
                </table>        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="objUserList" onrowcommand="gvUserList_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="全选">
                                                <HeaderTemplate>
                                                    <input ID="Checkbox12" type="checkbox" onclick="selAll(this)" />全选
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <input ID="Checkbox11" type="checkbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UID" HeaderText="用户编号" SortExpression="UID" />
                                            <asp:BoundField DataField="Name" HeaderText="用户姓名" SortExpression="Name" />
                                            <asp:TemplateField HeaderText="部门名称" SortExpression="Department">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Department.Departmentname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MobilePhone" HeaderText="手机号码" 
                                                SortExpression="MobilePhone" />
                                            <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                                            <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="Age" 
                                                Visible="False" />
                                            <asp:BoundField DataField="IdentityCard" HeaderText="身份证号" 
                                                SortExpression="IdentityCard" Visible="False" />
                                            <asp:BoundField DataField="Password" HeaderText="密码" SortExpression="Password" 
                                                Visible="False" />
                                            <asp:BoundField DataField="HomePhone" HeaderText="座机号码" 
                                                SortExpression="HomePhone" Visible="False" />
                                            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Qq" HeaderText="QQ" SortExpression="Qq" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Msn" HeaderText="MSN" SortExpression="Msn" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" 
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="用户角色"></asp:TemplateField>
                                            <asp:BoundField DataField="UserStatus" HeaderText="状态" 
                                                SortExpression="UserStatus" />
                                            <asp:BoundField DataField="Picture" HeaderText="用户照片" SortExpression="Picture" 
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" 
                                                        CommandArgument='<%# Eval("UID") %>' CommandName="Ed">编辑</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="删除"></asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                                    <asp:ObjectDataSource ID="objUserList" runat="server" SelectMethod="SelectUserInfoByAll" 
                                        TypeName="BLL.Power.UserInfoManager">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txtCard" Name="identityCard" 
                                                PropertyName="Text" Type="String" />
                                            <asp:ControlParameter ControlID="txtName" Name="name" PropertyName="Text" 
                                                Type="String" />
                                            <asp:ControlParameter ControlID="dropUserStates" Name="userStatus" 
                                                PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="dropDepartment" Name="departmentID" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
            
            
                <td>
              
                    <br />
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>部门主管</asp:ListItem>
                <asp:ListItem>部门经理</asp:ListItem>
                <asp:ListItem>部门员工</asp:ListItem>
            </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" class="BigButton" runat="server" Text="分配角色" />
                    </td>
            </tr>
        </table>
         </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body class="bodycolor" topmargin="5" leftmargin="0">
    </body>
</html>

