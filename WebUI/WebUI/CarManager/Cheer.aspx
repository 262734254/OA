<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cheer.aspx.cs" Inherits="jiayoujilu" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>加油记录页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
    <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />
         <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <script type="text/javascript">
        function ckChar(){
            var item=document.getElementById("txtStation").value;
            for(var i=0;i<item.length;i++)
            {
                var a=item.substring(i,i+1);
                if(a>=0 && a<=9 || a=='~' || a=='！'|| a=='!'|| a>='A' && a<='Z'||a=='@'||a=='#'||a=='$'||a=='%'||a=='%'||a=='*'||a=='&'||a=='^')
                {
                    alert("加油站的格式不正确！");
                    document.getElementById("txtStation").value="";
                    break;
                }
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width:100%;background-color:#C6DAF3;
             height:450px;
        }
        .style2
        {
             height:34px;
            width: 562px;
        }
        .style3
        {
            height:30px;
            width: 562px;
        }
        .style6
        {
            height:44px;
            width: 562px;
        }
        .style8
        {
            height: 28px;
            width: 562px;
        }
        .style9
        {
            height:25px;
            width: 562px;
        }
        .style10
        {
            height:32px;
            width: 562px;
        }
        .style11
        {
            border-style:none;
            border-color:inherit;
            border-width:0px;
            text-align:center;
            background-image:url('../css/6/images/tablehdbg1.gif') ;          /* 表格背景图           */
            font-size:9pt; /* 字体大小             */ /* font-weight:bold;                                          字体粗               */
            width:757px;                                               /* 表格宽度             */
            height: 30px; /* 表格高度  图＋2      */
/* 表格边框宽度         */    COLOR: #264A7E;
            background-repeat:repeat-x;                                          /* 表格背景颜色         */
        }
        .style12
        {
            width:757px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
               <td align="center" class="style11">
                    <h3>加油记录</h3></td>
            </tr>
            <tr>
                <td align="center" class="style12">
    
                    <table style="height: 470px; width: 570px; margin-right: 41px;">
                        <tr>
                            <td align="left" class="style8">
                                车 牌 号 ：<asp:DropDownList ID="ddlCarMark" runat="server" 
                                    DataSourceID="objCarMark" DataTextField="CarMark" DataValueField="Car_Id" 
                                     AppendDataBoundItems="True" 
                                    AutoPostBack="True" onselectedindexchanged="ddlCarMark_SelectedIndexChanged" Width="126px" >
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 加油类型：<asp:DropDownList ID="ddlCheerType" 
runat="server" class="inputs" Width="126px" >
                                    <asp:ListItem>汽油 </asp:ListItem>
                                    <asp:ListItem>柴油</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="style9">
                                加油日期：<input id="txtCheerDate" class="inputs" runat="server" 
                                    onclick="showcalendar(event, this);" type="text" readonly="readonly" Width="126px"  />&nbsp;<asp:RequiredFieldValidator 
                                    ID="rfvCheerDate" runat="server" ControlToValidate="txtCheerDate" 
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 加油费用：<asp:TextBox 
                                    ID="txtMoney" runat="server" class="inputs" Width="126px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMoney" runat="server" 
                                    ControlToValidate="txtMoney" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvMoney" runat="server" ControlToValidate="txtMoney" 
                                    ErrorMessage="格式不正确" MaximumValue="10000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style8">
                                &nbsp;加油站：&nbsp; &nbsp;<asp:TextBox ID="txtStation" class="inputs" runat="server" 
                                    onchange="ckChar()" MaxLength="10" Width="126px" 
                                   ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStation" runat="server" 
                                    ControlToValidate="txtStation" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style3">
                                清单照片：<asp:FileUpload ID="fuBillPhoto" runat="server" Height="19px" 
                                    Width="198px" />
                                <asp:Image ID="image" runat="server"/>
                                &nbsp;&nbsp;&nbsp; 
                                </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label1" runat="server" Text="车辆类型："></asp:Label>
                                <asp:RadioButtonList ID="rblCarType" runat="server" Height="29px" 
                                    RepeatDirection="Horizontal" Width="348px" Enabled="False">
                                    <asp:ListItem  Value="普通用车">普通用车</asp:ListItem>
                                    <asp:ListItem Value="接待用车">接待用车</asp:ListItem>
                                    <asp:ListItem Value="大型活动用车">大型活动用车</asp:ListItem>
                                    <asp:ListItem Value="其它用车">其它用车</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                             <td class="style2">
                    备注：<textarea  rows="2" cols="20" id="txtRemark" class="TxCss" 
                        style="height: 100px;width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" 
                        runat="server" onclick="return txtRemark_onclick()"></textarea>
                                </td>
                        </tr>
                        <tr>
                            <td align="center" class="style6">
                                <asp:Button ID="btnSave" runat="server" class="BigButton" 
                                    onclick="btnSave_Click" Text="保   存" ToolTip="添加" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnClose" runat="server"  CausesValidation="false"
                                    class="BigButton" PostBackUrl="~/CarManager/Cheerlist.aspx" Text="返   回" 
                                    ToolTip="返回" />
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