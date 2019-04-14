<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserList" %>




<%@ Register src="../../UserControls/RolesUserControl.ascx" tagname="RolesUserControl" tagprefix="uc1" %>




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
                    <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="objUserList" onrowcommand="gvUserList_RowCommand" 
                                        onrowdatabound="gvUserList_RowDataBound" Width="748px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="全选">
                                                <HeaderTemplate>
                                                    <input ID="Checkbox12" type="checkbox" onclick="selAll(this)" />全选
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cklish1" runat="server" />
                                                    <asp:HiddenField ID="hfUId" runat="server" Value='<%# Eval("UId") %>' />
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
                                            <asp:TemplateField HeaderText="用户角色">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="dropRole" runat="server" CssClass="BigSelect" 
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                        <HeaderStyle CssClass="TableHeader" />
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
                    <br />
                    角色列表</td>
            </tr>
            <tr>
            
            
                <td>
              
                    <br />
                  
                    <asp:PlaceHolder ID="phholder" runat="server"> 
       <uc1:RolesUserControl ID="RolesUserControl1" runat="server" />
                    </asp:PlaceHolder> 
                
                    
                
                    <br />
                    &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnDeliver" class="BigButton" 
                        runat="server" Text="分配角色" onclick="btnDeliver_Click" />
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

