<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project_View.aspx.cs" Inherits="N_Project_Project_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 500px">
    <tr>
        <td align="left">
       <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width:100%">
    <tr>
        <td align="left" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></td>
    </tr> 
           <tr>
                <td align="center" style="height: 30px;" width="33%">人员需求计划</td>
                <td align="center" style="height: 30px;"  width="40%">&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label></td>
                <td align="center"  width="27%">&nbsp;<asp:HyperLink ID="HyperLink1" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink7" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
           <tr>
                <td align="center" style="height: 30px;">合同签订计划</td>
                <td align="center" style="height: 30px;">&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label></td>
                <td align="center">&nbsp;<asp:HyperLink ID="HyperLink2" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink8" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
            <tr>
                <td align="center" style="height: 30px;">设备需求计划</td>
                <td align="center" style="height: 30px;">&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label></td>
                <td align="center">&nbsp;<asp:HyperLink ID="HyperLink3" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink9" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
            <tr>
                <td align="center" style="height: 30px;">材料进场计划</td>
                <td align="center" style="height: 30px;">&nbsp;<asp:Label ID="Label5" runat="server"></asp:Label></td>
                <td align="center">&nbsp;<asp:HyperLink ID="HyperLink4" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink10" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
            <tr>
                <td align="center" style="height: 30px;">施工方案编制计划</td>
                <td align="center" style="height: 30px;">&nbsp;<asp:Label ID="Label6" runat="server"></asp:Label></td>
                <td align="center">&nbsp;<asp:HyperLink ID="HyperLink5" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink11" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
            <tr>
                <td align="center" style="height: 30px;">安全申报计划</td>
                <td align="center" style="height: 30px;">&nbsp;<asp:Label ID="Label7" runat="server"></asp:Label></td>
                <td align="center">&nbsp;<asp:HyperLink ID="HyperLink6" runat="server">查看</asp:HyperLink> <asp:HyperLink ID="HyperLink12" runat="server">提醒负责人</asp:HyperLink></td>
            </tr> 
       <tr>
        <td align="center" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;</td>
    </tr>
    </table><br/>
</td>
</tr>
</table>
    </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="center">
                    <input id="Button1" class="butt" type="button" value="关 闭" onclick="window.close();" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
