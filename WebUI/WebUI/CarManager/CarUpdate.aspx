<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarUpdate.aspx.cs" Inherits="CarManager_CarUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>车辆信息修改页面</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/>
   <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
   <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
       
        .style1
        {
              width: 100%; background-color:#C6DAF3;
           height: 450px;
        }
       
        .style2
        {
        	text-align:left;
        }
       
        .style3
        {
            height: 123px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
    
        <table class="style1">
            <tr>
                  <td  align="center" class="title1">
                <h3>车辆修改</h3>
                    </td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 422px">
            
            <tr>
                <td class="style2" >
                    车 牌 号：<asp:TextBox ID="txtLisence" class="inputs" runat="server">湘F00305</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtLisence"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    购买日期：<asp:TextBox ID="txtBuyDate" runat="server" onclick="showcalendar(event, this);">2010-05-02</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" ErrorMessage="*"
                                    ControlToValidate="txtBuyDate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    车辆类型：<asp:RadioButton ID="RadioButton1" class="inputs" runat="server" 
                        Text="普通车辆" GroupName="a" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                </td>
                
            </tr>
            <tr>
                <td class="style2">
                    购买厂家：<asp:TextBox ID="txtChangJia" class="inputs" runat="server">中国一汽大众</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtChangJia"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    座&nbsp; 位 数：<FONT face="宋体"><asp:TextBox id="txtSeating"  class="inputs" runat="server">5</asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="txtLisence" ErrorMessage="*"></asp:RequiredFieldValidator>
			</FONT></td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    购买金额：<asp:TextBox ID="txtBuyMoney" class="inputs" runat="server">500000</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtBuyMoney"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" runat="server" 
                        class="inputs" Height="100px" 
                        TextMode="MultiLine" Width="438px">此车性能很好。</asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="style2">
                    状&nbsp;&nbsp;&nbsp;&nbsp; 态：<asp:DropDownList ID="ddlState" class="inputs" 
                        runat="server">
                        <asp:ListItem>待出车</asp:ListItem>
                        <asp:ListItem>以出车</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" class="BigButton"  
                        PostBackUrl="~/CarManager/carslist.aspx" Text="确认" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                        PostBackUrl="~/CarManager/carslist.aspx" Text="返   回" 
                        CausesValidation="False" />
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

