<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carslist.aspx.cs" Inherits="CarManager_carslist" %>

<%@ Register src="MyPage.ascx" tagname="MyPage" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<title>车辆档案记录</title>
<head runat="server">
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
                <h3>车辆档案管理</h3>
                   </td>
            </tr>
            <tr>
                <td align="center" valign="top">
        <table>
            <tr>
                <td style="height:70px">
                            <br />
                    车牌号：<asp:TextBox ID="txtDept" class="inputs" runat="server"></asp:TextBox>
                    &nbsp;&nbsp; 车辆类型：<asp:DropDownList ID="drlCarType" class="inputs" 
                        runat="server" DataSourceID="odsType" AppendDataBoundItems="True" 
                                DataTextField="genre" DataValueField="TypeId">
                         <asp:ListItem Selected="True">全部</asp:ListItem>
                         
      
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 状态：<asp:DropDownList ID="drlCarStae"
                        class="inputs" runat="server">
                        
                        <asp:ListItem Selected="True">全部</asp:ListItem>
                        <asp:ListItem>已出车</asp:ListItem>
                        <asp:ListItem>未出车</asp:ListItem>
                        <asp:ListItem>维修</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSelet" runat="server" class="BigButton" Text="查   询" 
                        onclick="Button1_Click1" ToolTip="查询" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
                                ID="lknewCar" runat="server" PostBackUrl="newCars.aspx?op=1&amp;id=0" 
                                ToolTip="新车入库">新车入库</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="text-align:left">
                    
                    <asp:Button ID="btnDelete" class="BigButton" runat="server" Text="删除" 
                        onclick="btnDelete_Click1" onclientclick="return confirm('您确认要删除吗！');" 
                        ToolTip="删除"  />
                </td>
            </tr>  
            <tr>
                <td>
  <table>
       
            <tr>
                <td>
                    <asp:GridView ID="gvCars" runat="server" AutoGenerateColumns="False" 
                        Width="636px" 
                        onrowcommand="gvCars_RowCommand" onrowdatabound="gvCars_RowDataBound">
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
                            <asp:BoundField DataField="CarMark" HeaderText="车牌号" SortExpression="CarMark" />
                            <asp:BoundField DataField="Seating" HeaderText="座位数" SortExpression="Seating" />
                            <asp:TemplateField HeaderText="车辆类型" SortExpression="Typeid">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Typeid.genre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Typeid.genre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BuyData" HeaderText="购买日期" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="BuyData" />
                            <asp:BoundField DataField="Buywork" HeaderText="购买厂家" 
                                SortExpression="Buywork" />
                            <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State" />
                            <asp:TemplateField HeaderText="详细">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDetail" runat="server" onclick="lkXianXi_Click" 
                                        CommandArgument='<%# Eval("Car_Id") %>' >详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbUp" runat="server" onclick="lkUpdate_Click" 
                                        CommandArgument='<%# Eval("Car_Id") %>'>修改</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="删除">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDel" runat="server" 
                    CommandArgument='<%# Eval("Car_Id")%>' CommandName="del" 
                    onclientclick="return confirm('您确认要删除吗！');" onclick="lnkdel_Click">删除</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="维修">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbSend" runat="server" 
                    CommandArgument='<%# Eval("Car_Id")%>' CommandName="weixiou" 
                    onclientclick="return confirm('您确认要维修吗？！');" onclick="lbWeiXiou_Click" >维修</asp:LinkButton>
                     <asp:HiddenField ID="lblWei" runat="server" Value='<%# Bind("Car_Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                            <asp:BoundField DataField="Car_Id" HeaderText="Car_Id" SortExpression="Car_Id" 
                                Visible="False" />
                        </Columns>
                        <HeaderStyle CssClass="TableHeader" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetAllType" 
                        TypeName="BLL.Car.CarTypeManager"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCars" runat="server" SelectMethod="GetAllCars" 
                        TypeName="BLL.Car.CarsManager"></asp:ObjectDataSource>                      
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
