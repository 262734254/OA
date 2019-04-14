<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisobeyRecord.aspx.cs" Inherits="weizhangshigujilu" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>违章事故记录页面</title>
     <link href="../css/public.css" type="text/css" rel="stylesheet"/>
      <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
      <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
        <script type="text/javascript">
        function ckChar(){
            var item=document.getElementById("txtDR_Locus").value;
            for(var i=0;i<item.length;i++)
            {
                var a=item.substring(i,i+1);
                if(a=='！'||a=='!'||a=='~'||a=='@'||a=='#'||a=='$'||a=='%'||a=='%'||a=='*'||a=='&'||a=='^')
                {
                    alert("事故违章地点的格式不正确！");
                    document.getElementById("txtDR_Locus").value="";
                    break;
                 }
            }
        }
         function ckCharqk(){
            var item=document.getElementById("txtDR_Circs").value;
            for(var i=0;i<item.length;i++)
            {
                var a=item.substring(i,i+1);
                if(a=='~' || a=='！'||a=='!'|| a>='A' && a<='Z'||a=='~'||a=='@'||a=='#'||a=='$'||a=='%'||a=='%'||a=='*'||a=='&'||a=='^'||a=='.')
                {
                  alert("伤亡情况格式不正确！");
                  document.getElementById("txtDR_Circs").value="";
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
            height:67px;
        }
        .style3
        {
            height:88px;
        }
        .style5
        {
            height:31px;
            width: 316px;
        }
        .style6
        {
            height:33px;
            width: 316px;
        }
        .style7
        {
            height:27px;
            width: 316px;
        }
        .style8
        {
            height:37px;
            width: 316px;
        }
        .style9
        {
            width: 288px;
        }
        .style10
        {
            width: 316px;
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
    <table style="height: 499px; width: 595px;">
      
        <tr>
            <td align="left" class="style8">
               
                　事故违章部门：<asp:DropDownList ID="ddlDR_Department" class="inputs" 
                    runat="server" DataSourceID="objDepartement" 
                    DataTextField="Departmentname" DataValueField="Id" 
                    onselectedindexchanged="ddlDR_Department_SelectedIndexChanged" 
                    AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
                                </td>
            <td align="left" class="style9">
                事故违章人：<asp:DropDownList ID="ddlDR_People" class="inputs" 
                        runat="server">
                        <asp:ListItem>请选择</asp:ListItem>
                    </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="style7">
              
                　事故违章地点：<asp:TextBox ID="txtDR_Locus" onchange="ckChar()" class="inputs" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLocus" runat="server" 
                    ControlToValidate="txtDR_Locus" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td align="left" class="style9">
                　罚款金额：<asp:TextBox 
                        ID="txtDR_Sum" class="inputs" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSum" runat="server" 
                    ControlToValidate="txtDR_Sum" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvSum" runat="server" ControlToValidate="txtDR_Sum" 
                    ErrorMessage="格式不正确" Type="Double" MaximumValue="100000" 
                    MinimumValue="10"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="style6">
                               
                                　事故违章日期：<input type="text"  onClick="showcalendar(event, this);" 
                                    ID="txtDR_Date" class="inputs" runat="server" readonly="readonly" /><asp:RequiredFieldValidator 
                                    ID="rfvate" runat="server" ControlToValidate="txtDR_Date" ErrorMessage="*"></asp:RequiredFieldValidator>
&nbsp;</td>
            <td align="left" class="style9">
                　伤亡情况：<asp:TextBox ID="txtDR_Circs"  onchange="ckCharqk()"  class="inputs" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCircs" runat="server" 
                    ControlToValidate="txtDR_Circs" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="style5">
                                       　　　经济损失：<asp:TextBox 
                        ID="txtDR_Expense" class="inputs" 
                        runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvExpense" runat="server" 
                        ControlToValidate="txtDR_Expense" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvExplain" runat="server" 
                        ControlToValidate="txtDR_Expense" ErrorMessage="格式不正确" MaximumValue="100000" 
                        MinimumValue="10" Type="Double"></asp:RangeValidator>
                                </td>
           
            <td align="left" class="style9">
                    实际赔偿费：<asp:TextBox ID="txtFactCost" class="inputs" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFactCost" runat="server" 
                        ControlToValidate="txtFactCost" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvFactCost" runat="server" 
                        ControlToValidate="txtFactCost" ErrorMessage="格式不正确" MaximumValue="5000000" 
                        MinimumValue="10" Type="Double"></asp:RangeValidator>
                </td>
           
        </tr>
        <tr>
            <td align="left" class="style10">
                                事故违章车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" 
                                    DataSourceID="objCarMark" DataTextField="CarMark" 
                                    DataValueField="Car_Id" 
                                    onselectedindexchanged="ddlCarMark_SelectedIndexChanged" 
                                    AppendDataBoundItems="True" AutoPostBack="True"  
                                    Width="126px" Height="16px">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList>
               
                                </td>
            
            <td align="left" class="style9">
                &nbsp;　　　类型：<asp:DropDownList ID="ddlDR_Type" class="inputs" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="ddlDR_Type_SelectedIndexChanged">
                    <asp:ListItem>违章</asp:ListItem>
                    <asp:ListItem>事故</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            
        </tr>
        <tr>
            <td align="left" colspan="2" class="style14">
                    &nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" 
                        Text="车辆类型："></asp:Label>
                    &nbsp;
                    <asp:RadioButtonList ID="rblDR_CarType" runat="server" 
                        RepeatDirection="Horizontal" Height="29px" Width="419px" Enabled="False">
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
                    &nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                情况说明：<textarea cols="20" id="txtDR_Explain" 
                    class="TxCss" 
                    style="border: 1px solid #99ccff; height: 91px; width: 450px; " 
                    runat="server"></textarea><asp:RequiredFieldValidator ID="rfvxplain" 
                    runat="server" ControlToValidate="txtDR_Explain" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
        </tr>
        <tr>
            <td colspan="2" class="style3">
                备&nbsp;&nbsp;&nbsp;&nbsp; 注：<textarea  rows="2" cols="20" 
                    id="txtRemark" class="TxCss" 
                    style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" 
                    runat="server"></textarea></td>
           
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnSave" runat="server" class="BigButton" Text="保   存" 
                    onclick="btnSave_Click" ToolTip="添加" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClose" runat="server" class="BigButton" CausesValidation="false"
                    PostBackUrl="~/CarManager/DisobeyRecordlist.aspx" Text="返   回" 
                     />
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