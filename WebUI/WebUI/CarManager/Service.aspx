<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="weixiujilu" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>维修记录页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
     <script language="javascript" src="../js/calendar.js" type="text/javascript">
function txtOutDate_onclick() {

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
            border-style:none;
            border-color:inherit;
            border-width:0px;
            text-align:center;
            background-image:url('../css/6/images/tablehdbg1.gif');          /* 表格背景图           */
            font-size:9pt; /* 字体大小             */ /*  font-weight: bold;                                          字体粗               */
            width:849px;                                               /* 表格宽度             */
            height:21px; /* 表格高度  图＋2      */ /*表格边框宽度         */
            COLOR:#264A7E;
            background-repeat:repeat-x;                                          /* 表格背景颜色         */
        }
               
        .style7
        {
            height:42px;
        }
               
        .style11
        {
            height:24px;
            width: 305px;
        }
        .style12
        {
            height: 24px;
            width: 261px;
        }
        .style14
        {
            height: 25px;
            width: 261px;
        }
        .style18
        {
            height: 18px;
            width: 261px;
        }
       
        .style21
        {
            height: 14px;
        }
       
        .style22
        {
            width: 305px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td  align="center" class="style2">
                    <h3>维修记录</h3></td>
            </tr>
            <tr>
                    <td align="center">
    
        <table style="height: 441px; width: 590px;"　>
                        <tr align="left">
                <td align="laft" class="style22" >
                    &nbsp;&nbsp;&nbsp;报修部门：<asp:DropDownList ID="ddlS_Branch" class="inputs" runat="server" 
                        DataSourceID="objDepartement" DataTextField="Departmentname" 
                        DataValueField="Id" AppendDataBoundItems="True" AutoPostBack="True" 
                        onselectedindexchanged="ddlS_Branch_SelectedIndexChanged" Width="126px" >
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td   align="left">　报修人：<asp:DropDownList ID="ddlS_People" class="inputs" 
                        runat="server">
                        <asp:ListItem >请选择</asp:ListItem>
                    </asp:DropDownList>
                              
                                </td>
            </tr>
            <tr align="left">
                <td   align="left" class="style22" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 车牌号：<asp:DropDownList ID="ddlCarMark"
                        　　class="inputs" runat="server" Height="16px" 
                        Width="126px" AppendDataBoundItems="True" AutoPostBack="True" 
                        DataSourceID="odsCarMark" DataTextField="CarMark" DataValueField="Car_Id" 
                        onselectedindexchanged="ddlCarMark_SelectedIndexChanged" >
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td  align="left">
                    维修类型：<asp:DropDownList ID="ddlS_Type" class="inputs" runat="server" 
                        AppendDataBoundItems="True">
                        <asp:ListItem>损坏</asp:ListItem>
                        <asp:ListItem>故障</asp:ListItem>
                    </asp:DropDownList>
              </td>
            </tr>
            <tr align="left">
                <td  align="left" class="style22">
                    &nbsp;&nbsp;&nbsp;进厂日期：<input type="text" onclick="showcalendar(event, this);" 
                        ID="txtBeginDate" class="inputs" runat="server" readonly="readonly" />&nbsp;<asp:RequiredFieldValidator 
                        ID="rfvBeginDate" runat="server" ControlToValidate="txtBeginDate" 
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                              
                </td>
                <td class="style14" align="left">
                    出厂日期：<input type="text"  onclick="showcalendar(event, this);" ID="txtEndDate" 
                        class="inputs" runat="server" readonly="readonly" />
                                <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" 
                        ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;</td>
            </tr>
            <tr align="left">
                <td class="style22" >
                    维修厂名称：<asp:TextBox ID="txtS_FactoryName"　 class="inputs"  runat="server" Width="126px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFactoryName" runat="server" 
                        ControlToValidate="txtS_FactoryName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style18" align="left">
                                        　验收人：<asp:DropDownList ID="ddlJerquePeople" runat="server" Width="126px">
                        <asp:ListItem>请选择</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr align="left">
                <td class="style11">
                    &nbsp;&nbsp;&nbsp; 报修费用：<asp:TextBox ID="txtS_Cost" class="inputs" runat="server" 
                        Width="126px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvS_Cost" runat="server" 
                        ControlToValidate="txtS_Cost" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rv" runat="server" 
                        ControlToValidate="txtS_Cost" ErrorMessage="格式错误" MaximumValue="100000" 
                        MinimumValue="10" Type="Double"></asp:RangeValidator>
                </td>
                <td class="style12" align="left">
                    实际费用：<asp:TextBox ID="txtUseCost" class="inputs" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUseCost" runat="server" 
                        ControlToValidate="txtUseCost" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvUseCost" runat="server" 
                        ControlToValidate="txtUseCost" ErrorMessage="格式有误" MaximumValue="100000" 
                        MinimumValue="10" Type="Double"></asp:RangeValidator>
&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style7">
<asp:Label ID="Label1" runat="server" 
                        Text="车辆类型："></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButtonList ID="rblCarType" runat="server" 
                        RepeatDirection="Horizontal" Height="29px" Width="348px" Enabled="False">
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style21">
                    &nbsp;清单照片：<asp:FileUpload ID="fuBillPhoto" class="inputs" runat="server"  
                        Width="198px" />
                   <asp:Image ID="image" runat="server" />
                    &nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td colspan="2">
                    维修原因：<asp:TextBox ID="txtS_Reason" class="inputs" 
                        runat="server" TextMode="MultiLine" 
                        Height="101px" Width="427px"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="rfvReason" runat="server" 
                        ControlToValidate="txtS_Reason" ErrorMessage="*"></asp:RequiredFieldValidator>
               
            </tr>
            <tr>
                <td colspan="2">
                    维修结果：<asp:TextBox ID="txtS_Result" class="inputs" 
                        runat="server" TextMode="MultiLine" 
                        Height="121px" Width="427px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvResult" runat="server" 
                        ControlToValidate="txtS_Result" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnSave" runat="server" class="BigButton" Text="保   存" 
                        onclick="btnSave_Click" ToolTip="修改" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClose" runat="server" class="BigButton" CausesValidation="false" 
                        PostBackUrl="~/CarManager/Servicelist.aspx" Text="返   回" Height="20px" />
                    <br />
                    <asp:ObjectDataSource ID="objDepartement" runat="server" 
                        SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCarMark" runat="server" 
                        SelectMethod="getCarsByType" TypeName="BLL.Car.ServicesManager">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsUserName" runat="server" 
                        SelectMethod="GetAllUsersByDepartmentId" TypeName="BLL.Power.UserInfoManager">
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
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

