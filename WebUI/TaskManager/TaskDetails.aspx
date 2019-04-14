<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskDetails.aspx.cs" Inherits="PowerManager_Role_power" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>重点任务目标详情</title>
    <link rel="stylesheet" type="text/css" href="../css/6/style.css" />
    <link rel="Stylesheet" type="text/css" href="../css/public.css" />
     <style type="text/css">
        .style1
        {
            width: 100%;
            height:450px;
            background-color:#C6DAF3;
        }
         .style2
         {
             width: 150px;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>目标详情</h3>
     </td>
            </tr>
            <tr>
                <td align="center">
    
        <table align="center" style="height: 384px; width: 603px">
            <tr align="left">
                <td>
                    年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 度：</td>
                <td class="style2">
                    <asp:DropDownList ID="ddlDateTime" runat="server" CssClass="BigSelect" 
                        Enabled="False">
                        <asp:ListItem>2010</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    目标级别：</td>
                <td>
                    <asp:DropDownList ID="ddlSteps" runat="server" CssClass="BigSelect" 
                        Enabled="False">
                        <asp:ListItem>计划性任务</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="left">
                <td>
                   领&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;域：</td>
                <td class="style2">
                    <asp:TextBox ID="txtField" runat="server" 
                        style="border: #99ccff 1px solid;" Enabled="False">asd</asp:TextBox>
                </td>
                <td>
                    重点工作：</td>
                <td>
                    <asp:TextBox ID="txtContolPart0" runat="server" 
                        style="border: #99ccff 1px solid;" Enabled="False">asd</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    主责部门：</td>
                <td class="style2">
                    <asp:TextBox ID="txtContolPart" runat="server" 
                        style="border: #99ccff 1px solid;" Enabled="False">asd</asp:TextBox>
                </td>
                <td>
                                        负&nbsp; 责 人：</td>
                <td>
                    <asp:TextBox ID="txtProtectMan" runat="server"  
                        style="border: #99ccff 1px solid;" Enabled="False">asdf</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    分管区长：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtQuyuMan" runat="server"  style="border: #99ccff 1px solid;" 
                        Enabled="False">hty</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    维护部门：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtProtected" runat="server" Width="492px"  
                        style="border: #99ccff 1px solid;" Enabled="False">grtdsf</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    协作部门：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtdoGet" runat="server" Width="494px"  
                        style="border: #99ccff 1px solid;" Enabled="False">gart</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    维护人员：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTwo" runat="server" Width="495px"  
                        style="border: #99ccff 1px solid;" Enabled="False">jhstysg</asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    完成状态：</td>
                <td colspan="3">
                    <asp:RadioButton ID="rdoNotStart" runat="server" Text="尚未启动" GroupName="aa" 
                        Enabled="False" />&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoProcess" runat="server" Text="正在进行" GroupName="aa" 
                        Enabled="False" />&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoOver" runat="server" Text="已经完成" 
                         GroupName="aa" Enabled="False" />&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoHard" runat="server" Text="存在困难"
                      
                        GroupName="aa" Enabled="False" />
                </td>
            </tr>
            <tr align="left">
                <td>
                    目标任务：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtAllTotlals" runat="server" Height="80px" 
                        TextMode="MultiLine"  style="border: #99ccff 1px solid;"
                        Width="500px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td colspan="4" align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td class="title1">
                    &nbsp;
                    目标进展情况</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvsteps" runat="server" AutoGenerateColumns="False" DataSourceID="objes" 
                                        CssClass="TableControl" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" Height="119px" Width="479px">
                        <RowStyle CssClass="TableContent" BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="Monthlength" HeaderText="月份" 
                                SortExpression="Monthlength" />
                            <asp:BoundField DataField="StepName" HeaderText="阶段" 
                                SortExpression="StepName" />
                            <asp:BoundField DataField="Status" HeaderText="完成状态" 
                                SortExpression="Status" />
                            <asp:BoundField DataField="sId" HeaderText="sId" SortExpression="sId" 
                                Visible="False" />
                            <asp:BoundField DataField="taskId" HeaderText="taskId" SortExpression="taskId" 
                                Visible="False" />
                            <asp:BoundField DataField="Problems" HeaderText="完成问题" 
                                SortExpression="Problems" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle CssClass="TableHeader" BackColor="#5D7B9D" Font-Bold="True" 
                            ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                                    <asp:ObjectDataSource ID="objes" runat="server" 
                                        SelectMethod="SelectTaskAllStageByTaskId" 
                        TypeName="BLL.Target.TaskManager">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="id" QueryStringField="Id" Type="Int32" />
                                        </SelectParameters>
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
