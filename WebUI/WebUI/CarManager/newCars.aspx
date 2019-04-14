<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newCars.aspx.cs" Inherits="CarManager_newCars" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
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
            height: 115px;
        }
       
        .style4
        {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            text-align: center;
            background-image: url('../css/6/images/tablehdbg1.gif') ;          /* 表格背景图           */
            font-size: 9pt; /* 字体大小             */ /*font-weight: bold;                                          字体粗               */
            width: 1008px;                                               /* 表格宽度             */
            height: 30px; /* 表格高度  图＋2      */
/* 表格边框宽度         */    COLOR: #264A7E;
            background-repeat: repeat-x;                                          /* 表格背景颜色         */
        }
        .style5
        {
            width: 1008px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
    
        <table class="style1">
            <tr>
                  <td  align="center" class="style4">
                <h3>
                    <asp:Label ID="lblTitle1" runat="server"></asp:Label>
                      </h3>
                    </td>
            </tr>
            <tr>
                <td align="center" class="style5">
    
       <table style="height: 422px">
            
            <tr>
                <td class="style2" align="right" >
                    车 牌 号：</td>
                <td class="style2" >
                    <asp:TextBox ID="txtLisence" class="inputs" runat="server" MaxLength="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtLisence"></asp:RequiredFieldValidator>
                </td>
                <td class="style2" >
                    &nbsp;购买日期：</td>
                <td class="style2" >
        
                    <asp:TextBox ID="txtBuyDate"   CssClass="inputs" 
                        onclick="showcalendar(event, this);" runat="server"  ></asp:TextBox>
                   
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" ErrorMessage="*"
                                    ControlToValidate="txtBuyDate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="4">
                    车辆类型：<asp:RadioButton ID="rdo1" class="inputs" runat="server" 
                        Text="普通车辆" GroupName="a" Checked="True" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdo2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdo3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdo4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                </td>
            
            </tr>
            <tr>
                <td class="style2" align="right">
                    购买厂家：</td>
                <td class="style2">
                    <asp:TextBox ID="txtChangJia" class="inputs" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtChangJia"></asp:RequiredFieldValidator>
                </td>
                <td class="style2" align="right">
                    购买金额：</td>
                <td class="style2">
                    <asp:TextBox ID="txtBuyMoney" class="inputs" runat="server" MaxLength="7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                        ControlToValidate="txtBuyMoney" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtBuyMoney" ErrorMessage="请填写正确的金额！" Type="Double" 
                        ValueToCompare="0" Operator="GreaterThan"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="4" align="left">
                    备&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" runat="server" 
                        class="inputs" Height="100px" 
                        TextMode="MultiLine" Width="438px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="style2" align="right">
                    状&nbsp;&nbsp;&nbsp;&nbsp; 态：</td>
               <td class="style2" >
                    <asp:DropDownList ID="ddlState" class="inputs" 
                        runat="server">
                         <asp:ListItem>未出车</asp:ListItem>
                        <asp:ListItem>以出车</asp:ListItem>
                        <asp:ListItem>维修中</asp:ListItem>
                    </asp:DropDownList>
                                   
                                </td>
                                 <td class="style2" >
                    &nbsp;座位数：</td>
                     <td class="style2" >
                         <asp:TextBox ID="txtSeating" class="inputs" runat="server"></asp:TextBox>
                   
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ErrorMessage="*"
                                    ControlToValidate="txtSeating"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td align="center" colspan="4">
                <asp:Button ID="btnSave" class="BigButton" runat="server" Text="保   存" 
                        onclick="btnSave_Click" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Button ID="btnSubmit"  class="BigButton" runat="server" Text="提   交" 
                        onclick="btnSubmit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;<asp:Button ID="btnback" class="BigButton" runat="server" 
                        Text="返   回" CausesValidation="False" 
                        PostBackUrl="~/CarManager/carslist.aspx" onclick="btnback_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnrepeat" class="BigButton" runat="server"  Text="重   置" 
                        Height="20px" onclick="btnrepeat_Click" CausesValidation="False" 
                         />
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
