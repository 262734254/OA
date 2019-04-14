<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shenlist.aspx.cs" Inherits="shenlist" %>

<%@ Register src="MyPage.ascx" tagname="MyPage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
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
                <td class="title1" valign="top" align="center">
                <h3>申请记录</h3>
                   </td>
            </tr>
            <tr>
                <td align="center" valign="top">
        <table>
            <tr>
                <td style="height:70px">
                    &nbsp;&nbsp;姓名：<asp:TextBox ID="txtDept" class="inputs" runat="server"></asp:TextBox>
                    &nbsp; 车辆类型：<asp:DropDownList ID="drlCarType" class="inputs" 
                        runat="server" DataSourceID="odsType" AppendDataBoundItems="True" 
                                DataTextField="Genre" DataValueField="TypeId">
                         <asp:ListItem Selected="True">全部</asp:ListItem>
                         
      
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 状态：<asp:DropDownList ID="drlCarStae"
                        class="inputs" runat="server">
                        
                        <asp:ListItem Selected="True">全部</asp:ListItem>
                        <asp:ListItem>待办</asp:ListItem>
                        <asp:ListItem>已办</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSelect" runat="server" class="BigButton" Text="查   询" 
                        onclick="Button1_Click1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>
  <table>
       

            <tr>
                <td>
                    
                    <asp:GridView ID="gvByappyl" runat="server" AutoGenerateColumns="False" 
                         Width="639px" onrowcommand="gvByappyl_RowCommand" 
                        onrowdatabound="gvByappyl_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ByMan" HeaderText="申请人" SortExpression="ByMan" />
                            <asp:BoundField DataField="ByDttion" HeaderText="目的地" 
                                SortExpression="ByDttion" />
                            <asp:TemplateField HeaderText="类型" SortExpression="ByTypeid">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("bytypeid.genre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("bytypeid.genre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="部门" SortExpression="ByDept">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("bydept.Departmentname") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server"  Text='<%# Eval("bydept.Departmentname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="State" HeaderText="状态" 
                                SortExpression="State" />
                           
                            <asp:TemplateField HeaderText="详细">
                            
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDetail" runat="server" onclick="lkXianXi_Click" 
                                        CommandArgument='<%# Eval("ByapplyId") %>' >详细</asp:LinkButton>
                                </ItemTemplate>
                            
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出车">
                             <ItemTemplate>
                                    <asp:LinkButton ID="lbSend" runat="server" 
                                        CommandArgument='<%# Eval("ByapplyId") %>' onclick="lkShenPi_Click" >出车</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="删除">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDel" runat="server" 
                    CommandArgument='<%# Eval("ByapplyId") %>' CommandName="del" 
                    onclientclick="return confirm('您确认要删除吗！');" onclick="lnkdel_Click">删除</asp:LinkButton>
                        <asp:HiddenField ID="lblByappyId" runat="server" Value='<%# Bind("ByapplyId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                           
                        </Columns>
                        <HeaderStyle CssClass="TableHeader" />
                    </asp:GridView>   
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsbyappy" runat="server" 
                        SelectMethod="GetAllCarByapply" TypeName="BLL.Car.CarByapplyManager">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsType" runat="server" 
                        SelectMethod="GetAllType" TypeName="BLL.Car.CarTypeManager">
                    </asp:ObjectDataSource>
                    <uc1:MyPage ID="ucpage" runat="server" />
                </td>
            </tr>
        </table>
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
