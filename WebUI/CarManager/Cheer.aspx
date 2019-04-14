<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cheer.aspx.cs" Inherits="jiayoujilu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>加油记录页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
    <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />
         <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style1
        {
           width:100%; background-color:#C6DAF3;
            height:450px;
        }
        .style2
        {
            height:130px;
        }
        .style3
        {
            height: 43px;
        }
        .style4
        {
            height: 38px;
        }
        .style5
        {
            height: 55px;
        }
        .style6
        {
            height: 61px;
        }
        .style7
        {
            height: 45px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
               <td align="center" class="title1">
                    <h3>加油记录</h3></td>
            </tr>
            <tr>
                <td align="center">
    
                    <table style="height: 468px; width: 532px;">
                        <tr>
                            <td align="left" class="style5">
                                车 牌 号 ：<asp:DropDownList ID="ddlCarMark" runat="server" 
                                    DataSourceID="objCarMark" DataTextField="CarMark" DataValueField="Car_Id" 
                                    Height="16px" Width="124px" AppendDataBoundItems="True" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCarMark_SelectedIndexChanged">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 加油类型：<asp:DropDownList ID="ddlCheerType" 
runat="server" class="inputs">
                                    <asp:ListItem>汽油 </asp:ListItem>
                                    <asp:ListItem>柴油</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="style4">
                                加油日期：<input id="txtCheerDate" runat="server" 
                                    onclick="showcalendar(event, this);" type="text" />&nbsp;&nbsp;<asp:RegularExpressionValidator 
                                    ID="revDate" runat="server" ControlToValidate="txtCheerDate" ErrorMessage="*" 
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 加油费用：<asp:TextBox ID="txtMoney" runat="server" class="inputs"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                加油站：&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtStation" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                清单照片：<asp:FileUpload ID="fuBillPhoto" runat="server" Height="19px" 
                                    Width="198px" />
                                <asp:Image ID="image" runat="server" Height="21px" Width="42px" />
                                &nbsp;&nbsp;&nbsp; （点击查看大图标）</td>
                        </tr>
                        <tr>
                            <td align="left" class="style7">
                                <asp:Label ID="Label1" runat="server" Text="车辆类型："></asp:Label>
                                <asp:RadioButtonList ID="rblCarType" runat="server" Height="29px" 
                                    RepeatDirection="Horizontal" Width="348px">
                                    <asp:ListItem  Value="普通用车" Selected>普通用车</asp:ListItem>
                                    <asp:ListItem Value="接待用车">接待用车</asp:ListItem>
                                    <asp:ListItem Value="大型活动用车">大型活动用车</asp:ListItem>
                                    <asp:ListItem Value="其它用车">其它用车</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                             <td class="style2">
                    备注：<textarea  rows="2" cols="20" id="txtRemark" class="TxCss" 
                        style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" 
                        runat="server" onclick="return txtRemark_onclick()"></textarea>
                                </td>
                        </tr>
                        <tr>
                            <td align="center" class="style6">
                                <asp:Button ID="btnSave" runat="server" class="BigButton" 
                                    onclick="btnSave_Click" Text="保   存" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnClose" runat="server" CausesValidation="False" 
                                    class="BigButton" PostBackUrl="~/CarManager/Cheerlist.aspx" Text="返   回" />
                                <br />
                                <asp:ObjectDataSource ID="objCarMark" runat="server" 
                                    SelectMethod="GetAllCars" TypeName="DAL.Car.CarsService">
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