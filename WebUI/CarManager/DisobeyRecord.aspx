<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisobeyRecord.aspx.cs" Inherits="weizhangshigujilu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>违章事故记录页面</title>
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
        .style2
        {
            height:67px;
        }
        .style3
        {
            height:88px;
        }
        .style4
        {
            height:30px;
        }
        .style5
        {
            height:31px;
        }
        .style6
        {
            height:33px;
        }
        .style7
        {
            height:27px;
        }
        .style8
        {
            height:37px;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                <h3>事故违章记录</h3></td>
            </tr>
            <tr>
                <td align="center">
    <table style="height: 499px; width: 531px;">
      
        <tr>
            <td align="left" class="style8">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                事 故 违章部门：<asp:DropDownList ID="ddlDR_Department" class="inputs" 
                    runat="server" DataSourceID="objDepartement" 
                    DataTextField="Departmentname" DataValueField="Id" 
                    onselectedindexchanged="ddlDR_Department_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
                                </td>
            <td align="right" class="style9">
                事 故 违章人：<asp:DropDownList ID="ddlDR_People" class="inputs" 
                        runat="server">
                        <asp:ListItem>请选择</asp:ListItem>
                    </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="style7">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                事 故 违章地点：<asp:TextBox ID="txtDR_Locus" class="inputs" runat="server"></asp:TextBox>
            </td>
            <td align="left" class="style10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                罚 款 金 额：<asp:TextBox 
                        ID="txtDR_Sum" class="inputs" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="style6">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                事 故 违章日期：<input type="text"  onClick="showcalendar(event, this);" 
                                    ID="txtDR_Date" class="inputs" runat="server" />
                                </td>
            <td align="left" class="style11">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                伤 亡 情 况：<asp:TextBox ID="txtDR_Circs" class="inputs" runat="server">无</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp; 经&nbsp; 济&nbsp; 损&nbsp; 失:<asp:TextBox 
                        ID="txtDR_Expense" class="inputs" 
                        runat="server"></asp:TextBox>
                                </td>
           
            <td align="left" class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    实际赔偿费：<asp:TextBox ID="txtFactCost" runat="server"></asp:TextBox>
                </td>
           
        </tr>
        <tr>
            <td align="left" class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                事故违章车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" Height="16px" 
                                    Width="99px" DataSourceID="objCarMark" DataTextField="CarMark" 
                                    DataValueField="Car_Id" 
                                    onselectedindexchanged="ddlCarMark_SelectedIndexChanged" 
                                    AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
               
                                </td>
            
            <td align="right" class="style13">
                类型：<asp:DropDownList ID="ddlDR_Type" class="inputs" runat="server">
                    <asp:ListItem>违章</asp:ListItem>
                    <asp:ListItem>事故</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            
        </tr>
        <tr>
            <td align="left" colspan="2" class="style14">
                    &nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" 
                        Text="车辆类型："></asp:Label>
                    &nbsp;
                    <asp:RadioButtonList ID="rblDR_CarType" runat="server" 
                        RepeatDirection="Horizontal" Height="29px" Width="419px">
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:RadioButtonList>
                                </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 清单照片：<asp:FileUpload 
                        ID="fuBillPhoto" runat="server" Height="19px" Width="198px" />
                    <asp:Image ID="image" runat="server" />
                    &nbsp;&nbsp;&nbsp;
                    （点击查看大图标）</td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                情况说明：<textarea name="txDes0" cols="20" id="txtDR_Explain" 
                    class="TxCss" 
                    style="border: 1px solid #99ccff; height: 91px;
                                    width: 450px; " 
                    runat="server">车辆号为粤A/K7122在南湖大道行驶超速，罚款1500.00元。</textarea></td>
        </tr>
        <tr>
            <td colspan="2" class="style3">
                备&nbsp;&nbsp;&nbsp;&nbsp; 注：<textarea  rows="2" cols="20" 
                    id="txtRemark" class="TxCss" 
                    style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" 
                    runat="server">行驶超速.</textarea></td>
           
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnSave" runat="server" class="BigButton" Text="保   存" 
                    onclick="btnSave_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClose" runat="server" class="BigButton" 
                    PostBackUrl="~/CarManager/DisobeyRecordlist.aspx" Text="返   回" 
                    CausesValidation="False" />
                <br />
                <asp:ObjectDataSource ID="objDepartement" runat="server" 
                    SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCarMark" runat="server" SelectMethod="GetAllCars" 
                    TypeName="BLL.Car.CarsManager"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server">
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