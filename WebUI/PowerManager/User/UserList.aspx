<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�û�����</title>
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
      <h3>�û���ɫ����</h3>
     </td>
            </tr>
            <tr><td align="center" style=" height:50px;">
             
                          �û����ţ� &nbsp;&nbsp;&nbsp;<asp:DropDownList 
                              style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                              ID="dropDepartment" runat="server"
                    DataTextField="departmentName" DataValueField="Id" 
                              AppendDataBoundItems="True" DataSourceID="objDropDepartment">
                              <asp:ListItem Value="">��ѡ��</asp:ListItem>
                </asp:DropDownList>
                          <asp:ObjectDataSource ID="objDropDepartment" runat="server" 
                              SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                          </asp:ObjectDataSource>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �û�����
                                <asp:TextBox ID="txtName" Text="" runat="server"  
                              Style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                          &nbsp;���֤��&nbsp;:<asp:TextBox ID="txtCard" Text="" runat="server"  
                              Style="border-right: #99ccff 1px solid;
                                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                          &nbsp;&nbsp;״̬��<asp:DropDownList ID="dropUserStates" runat="server">
                              <asp:ListItem Value="">��ѡ��</asp:ListItem>
                              <asp:ListItem Value="��ְ">��ְ</asp:ListItem>
                              <asp:ListItem Value="��ְ">��ְ</asp:ListItem>
                          </asp:DropDownList>
                          &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                <span align="center">
                                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                              Text="��   ѯ" onclick="Button2_Click" />
            </td></tr>
            <tr>
                <td style="text-align:left">
                    &nbsp;<span align="center"><asp:Button ID="BtnDele" runat="server" 
                        class="BigButton" Text="ɾ   ��" onclientclick="return confirm('ȷ��Ҫɾ����')" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="hlAddUser" runat="server" 
                        NavigateUrl="~/PowerManager/User/AddUser.aspx"><span align="center">�����û�</span></asp:HyperLink>
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
                            �û����&gt;                         <td >
                            �û�����</td>
                        <td >��������</td>
                         <td >
                             �ֻ�����</td>
                         <td >
                                 �Ա�</td>
                         <td >
                                 ��ɫ</td>
                        <td >
                            ״̬</td>
                        <td >
                        <span align="center">
                            �༭</td>
                        <td >
                            ɾ��</td>
                    </tr>
                      <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox1" runat="server"  /></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                         <td>�Ա�</td>
                          <td> 
                              <asp:DropDownList ID="DropDownList6" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>״̬</td>
                        
                        <td><asp:HyperLink ID="hlEdit" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                            
                         <td>
                                <asp:LinkButton ID="lnkBtnDel" runat="server" OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox3" runat="server" /></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList14" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit7" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel0" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                   <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox4" runat="server" /></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList15" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit8" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel1" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                  <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox5" runat="server"/></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList16" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit9" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel2" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox6" runat="server"/></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList17" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit10" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel3" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox7" runat="server"/></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList18" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit11" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel4" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td>
                           <asp:CheckBox ID="CheckBox8" runat="server"/></td>
                        <td>
                            �û����</td>
                        <td>
                            �û�����</td>
                        <td>��������</td>
                         <td>
                             �ֻ�����</td>
                             <td>
                                 �Ա�</td>
                             <td>
                              <asp:DropDownList ID="DropDownList19" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td>
                            ״̬</td>
                        <td>
                            <asp:HyperLink ID="hlEdit12" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink></td>
                        <td>
                                <asp:LinkButton ID="lnkBtnDel5" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                            </td>
                    </tr>
                     <tr align="center" class="TableContent">
                        <td class="style2">
                           <asp:CheckBox ID="CheckBox9" runat="server"/></td>
                        <td class="style2">
                            �û����</td>
                        <td class="style2">
                            �û�����</td>
                        <td class="style2">��������</td>
                         <td class="style2">
                             �ֻ�����</td>
                             <td class="style2">
                                 �Ա�</td>
                             <td class="style2">
                              <asp:DropDownList ID="DropDownList20" runat="server" CssClass="BigSelect">
                                  <asp:ListItem>��������</asp:ListItem>
                                  <asp:ListItem>�����޸�Ա</asp:ListItem>
                              </asp:DropDownList>
                                            </td>
                        <td class="style2">
                            ״̬</td>
                        <td class="style2">
                            <asp:HyperLink ID="hlEdit13" runat="server" 
                                NavigateUrl="~/PowerManager/User/UpdateUser.aspx">�༭</asp:HyperLink>
                            </td>
                        <td class="style2">
                                <asp:LinkButton ID="lnkBtnDel6" runat="server" 
                                OnClientClick="return confirm('ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>
                                    
                                            </td>
                        <td class="style2">
                                &nbsp;</td>
                    </tr>
                </table>        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="objUserList" onrowcommand="gvUserList_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ȫѡ">
                                                <HeaderTemplate>
                                                    <input ID="Checkbox12" type="checkbox" onclick="selAll(this)" />ȫѡ
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <input ID="Checkbox11" type="checkbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UID" HeaderText="�û����" SortExpression="UID" />
                                            <asp:BoundField DataField="Name" HeaderText="�û�����" SortExpression="Name" />
                                            <asp:TemplateField HeaderText="��������" SortExpression="Department">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Department.Departmentname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MobilePhone" HeaderText="�ֻ�����" 
                                                SortExpression="MobilePhone" />
                                            <asp:BoundField DataField="Sex" HeaderText="�Ա�" SortExpression="Sex" />
                                            <asp:BoundField DataField="Age" HeaderText="����" SortExpression="Age" 
                                                Visible="False" />
                                            <asp:BoundField DataField="IdentityCard" HeaderText="���֤��" 
                                                SortExpression="IdentityCard" Visible="False" />
                                            <asp:BoundField DataField="Password" HeaderText="����" SortExpression="Password" 
                                                Visible="False" />
                                            <asp:BoundField DataField="HomePhone" HeaderText="��������" 
                                                SortExpression="HomePhone" Visible="False" />
                                            <asp:BoundField DataField="Address" HeaderText="��ַ" SortExpression="Address" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Qq" HeaderText="QQ" SortExpression="Qq" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Msn" HeaderText="MSN" SortExpression="Msn" 
                                                Visible="False" />
                                            <asp:BoundField DataField="Remark" HeaderText="��ע" SortExpression="Remark" 
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="�û���ɫ"></asp:TemplateField>
                                            <asp:BoundField DataField="UserStatus" HeaderText="״̬" 
                                                SortExpression="UserStatus" />
                                            <asp:BoundField DataField="Picture" HeaderText="�û���Ƭ" SortExpression="Picture" 
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="�༭">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" 
                                                        CommandArgument='<%# Eval("UID") %>' CommandName="Ed">�༭</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ɾ��"></asp:TemplateField>
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
                <asp:ListItem>��������</asp:ListItem>
                <asp:ListItem>���ž���</asp:ListItem>
                <asp:ListItem>����Ա��</asp:ListItem>
            </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" class="BigButton" runat="server" Text="�����ɫ" />
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

