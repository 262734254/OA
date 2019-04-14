<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Davnotelist.aspx.cs" Inherits="CarManager_Davnotelist"%>

<%@ Register src="MyPage.ascx" tagname="MyPage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出车列表页面</title>
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
                <td class="title1"><h3>出车列表</h3></td>
            </tr>
            <tr>
                <td align="center" valign="top">
    
        <table>
             
            <tr>
                <td style="height:70px">
                    出车牌号：<asp:TextBox ID="txtMark" class="inputs" runat="server"></asp:TextBox>
                    出车部门：<asp:DropDownList ID="ddlDept" class="inputs" runat="server"  DataSourceID="odsDept" 
                        DataTextField="departmentName" DataValueField="Id" 
                        AppendDataBoundItems="True">
                        <asp:ListItem Selected="True">全部</asp:ListItem>
                    </asp:DropDownList>
                    车辆类型：<asp:DropDownList ID="ddlType" class="inputs" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="odsType" DataTextField="Genre" 
                        DataValueField="TypeId">
                       <asp:ListItem Selected="True">全部</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnSelect" class="BigButton" runat="server" 
                        Text="查   询" onclick="btnSelect_Click" ToolTip="查询" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:ObjectDataSource ID="odsDept" 
                        runat="server" SelectMethod="GetAllDepartment" 
                        TypeName="BLL.Power.DepartmentManager"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetAllType" TypeName="BLL.Car.CarTypeManager" 
                       ></asp:ObjectDataSource>
                    </a></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    &nbsp;<asp:Button ID="btnDelete" class="BigButton" runat="server" Text="删除" 
                        onclick="btnDelete_Click" ToolTip="删除" />
                </td>
            </tr>
            <tr>
                <td>
                     
                  
                         <asp:GridView ID="gvDavnote" runat="server" AutoGenerateColumns="False" 
                              Width="585px" onrowdatabound="gvDavnote_RowDataBound" 
                             onrowcommand="gvDavnote_RowCommand">
                             <Columns>
                             <asp:TemplateField HeaderText="全选">
                                <HeaderTemplate>
                                    <input id="cbAll" onclick="selAll(this)" type="checkbox" />全选
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="车牌号" SortExpression="DavMark">
                                   
                                     <ItemTemplate>
                                         <asp:Label ID="lblDavMark" runat="server" Text='<%# Eval("DavMark") %>' CommandName="cc"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="出车类型" SortExpression="DavTypeId">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("DavTypeId.genre") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%#Eval("DavTypeId.genre")%>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="出车部门" SortExpression="DavDept">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("DavDept.departmentname") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("DavDept.departmentname") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="DavData" HeaderText="出车日期" 
                                     SortExpression="DavData" DataFormatString="{0:yyyy-MM-dd}" />
                                 <asp:BoundField DataField="DavMan" HeaderText="出车人" SortExpression="DavMan" />
                                 <asp:TemplateField HeaderText="详细">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lbDetail" runat="server" 
                                             CommandArgument='<%# Eval("DavnoteId") %>' onclick="lkXianXi_Click">详细</asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText="删除">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lbDel" runat="server" 
                                             CommandArgument='<%# Eval("DavnoteId")%>' CommandName="del" 
                                             onclientclick="return confirm('您确认要删除吗！');">删除</asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                  <asp:TemplateField HeaderText="回车">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbBack" runat="server" 
                    CommandArgument='<%# Eval("DavnoteId")%>' CommandName="huiche" onclick="lnkhuiche_Click" >回车</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             </Columns>
                             <HeaderStyle CssClass="TableHeader" />
                         </asp:GridView>
                  
                        <asp:ObjectDataSource ID="odsDavNote" runat="server" 
                             SelectMethod="SelectDavnoteDark" TypeName="BLL.Car.CarDavnoteManager">
                            <SelectParameters>
                                <asp:Parameter Name="Mark" Type="String" />
                                <asp:Parameter Name="typeid" Type="String" />
                                <asp:Parameter Name="dept" Type="String" />
                            </SelectParameters>
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
