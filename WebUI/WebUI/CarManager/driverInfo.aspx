<%@ Page Language="C#" AutoEventWireup="true" CodeFile="driverInfo.aspx.cs" Inherits="CarManager_driverInfo" %>

<%@ Register src="MyPage.ascx" tagname="MyPage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>驾驶员信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style2 
        {
        	width: 100%; background-color:#C6DAF3;
            height: 450px;
             }
        .style3
        {
            height: 40px;
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
    <form id="form1" runat="server">
    <div>
    
        <table class="style2">
            <tr>
                <td class="title1"><h3>驾驶员信息</h3></td>
            </tr>
            <tr>
                <td align="center" valign="top">
    
        <table>
             
            <tr>
                <td class="style3">
                    姓名：<asp:TextBox ID="txtMark" class="inputs" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnSelect" class="BigButton" runat="server" 
                        Text="查   询" onclick="btnSelect_Click" ToolTip="查询" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
                        ID="lkaddDriver" runat="server" PostBackUrl="AddDriver.aspx" ToolTip="添加">添加记录</asp:LinkButton>
                    &nbsp; </a></td>
            </tr>
            <tr>
                <td>
                     
                  
                         <asp:GridView ID="gvUserInfo" runat="server" AutoGenerateColumns="False" 
                             style="margin-right: 0px" 
                             Width="572px" onrowcommand="gvUserInfo_RowCommand">
                             <Columns>
                                 <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" 
                                     Visible="False" />
                                 <asp:BoundField DataField="UserName" HeaderText="姓名" 
                                     SortExpression="UserName" />
                                 <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="Age" />
                                 <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                                 <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                                 <asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" />
                                 <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State" />
                                 <asp:TemplateField HeaderText="删除">
                                  
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDel" runat="server" 
                    CommandArgument='<%# Eval("UserId")%>' CommandName="del" 
                    onclientclick="return confirm('您确认要删除吗！');">删除</asp:LinkButton>
                                        </ItemTemplate>
                                   
                                 </asp:TemplateField>
                             </Columns>
                             <HeaderStyle CssClass="TableHeader" />
                         </asp:GridView>
                         <asp:ObjectDataSource ID="odsUserInfo" runat="server" 
                             SelectMethod="GetAllUserInfo" TypeName="BLL.Car.CarUserInfoManager">
                         </asp:ObjectDataSource>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:MyPage ID="ucpage" runat="server" />
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
