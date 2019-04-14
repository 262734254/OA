<%@ Page Language="C#" AutoEventWireup="true" CodeFile="elseCost.aspx.cs" Inherits="CarManager_elseCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>其他费用页面</title>
     <link href="../css/public.css" type="text/css" rel="stylesheet"/>
   <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
   <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
   
    <style type="text/css">
        .style1
        {
            width:100%;background-color:#C6DAF3;
           height:450px;
        }
        .style3
        {
            height:40px;
        }
        .style4
        {
            height:42px;
        }
        .style6
        {
            height:117px;
        }
        .style7
        {
            height:110px;
        }
        .style8
        {
            height:41px;
        }
        .style9
        {
            height:68px;
        }
    </style>
   
   
</head>
<body>
   <body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                <h3>其它费用记录</h3>
                   </td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 388px; width: 610px; margin-left: 35px;">
            <tr>
                <td class="style8">
                                        费用日期：<input type="text" onclick="showcalendar(event, this);" ID="txtCS_Date" 
                        runat="server"  /> &nbsp;&nbsp;<asp:RegularExpressionValidator 
                        ID="revDate" runat="server" 
                        ControlToValidate="txtCS_Date" ErrorMessage="*" 
                        
                        
                        
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 产生费用车牌号：<asp:DropDownList 
                                            ID="ddlMark" runat="server" Height="16px" 
                        Width="99px" DataSourceID="odsDisobeyRecord" DataTextField="CarMark" DataValueField="Car_Id" 
                                            onselectedindexchanged="ddlMark_SelectedIndexChanged" 
                                            AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    费用项目：&nbsp;<asp:DropDownList ID="ddlCS_Item" runat="server">
                        <asp:ListItem>月保费</asp:ListItem>
                        <asp:ListItem>路桥费</asp:ListItem>
                        <asp:ListItem>临时保管费</asp:ListItem>
                        <asp:ListItem>洗车费</asp:ListItem>
                        <asp:ListItem>保险费</asp:ListItem>
                        <asp:ListItem>其它费用</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;费 用 金 额：<asp:TextBox 
                        ID="txtC_Sum" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            
            <tr>
                <td  align="left" class="style4">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" 
                        Text="车辆类型："></asp:Label>
                    <asp:RadioButtonList ID="rblCarType" runat="server" 
                        RepeatDirection="Horizontal" Height="29px" Width="419px">
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               
            </tr>
            
            <tr>
                <td class="style9" >
                                        清单照片：<asp:FileUpload ID="fuBillPhoto" runat="server" Height="19px" 
                        Width="198px" />
                    <asp:Image ID="image" runat="server" />
                                        &nbsp;&nbsp;
                    （点击查看大图标）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
               
            </tr>
            <tr>
                <td class="style6" >
                    备注：<textarea  rows="2" cols="20" id="txtRemark" class="TxCss" 
                        style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" 
                        runat="server"></textarea></td>
                
            </tr>
            <tr>
                <td align="center" class="style7">
                    <asp:Button ID="btnSave" runat="server" class="BigButton" Text="保   存" onclick="btnSave_Click" 
                        />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClose" runat="server" class="BigButton" 
                        PostBackUrl="~/CarManager/ElseCostlist.aspx" Text="返   回" 
                        CausesValidation="False" />
                    <br />
                    <asp:ObjectDataSource ID="odsDisobeyRecord" runat="server" 
                        SelectMethod="GetAllCars" TypeName="BLL.Car.CarsManager">
                    </asp:ObjectDataSource>
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