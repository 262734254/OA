<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Send.aspx.cs" Inherits="Send" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加发送者</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />      
    <script language="javascript">
function makeValue()
{
	document.getElementById("dept").options.length=0;
	if(document.getElementById("select").value==1)
	{
		document.getElementById("dept").options.length=0;
		document.getElementById("dept").options.add(new Option("张三","张三")); 
		document.getElementById("dept").options.add(new Option("李四","李四")); 
		document.getElementById("dept").options.add(new Option("王五","王五")); 
	}
	if(document.getElementById("select").value==2)
	{
		document.getElementById("dept").options.length=0;
		document.getElementById("dept").options.add(new Option("小李","小李")); 
		document.getElementById("dept").options.add(new Option("小王","小王")); 
		document.getElementById("dept").options.add(new Option("小猪","小猪")); 
	}
}
function selectPerson()
{
	document.getElementById("txtName").value=document.getElementById("dept").options.value;
}
function clickOk()
{
	var name=document.getElementById("txtName").value;
	if(name==null || name=="")
	{
		alert('请填写会议主持人');
		document.getElementById("txtName").focus();
		return false;
	}
	window.returnValue = name;
	window.close();
}
</script>
<base target="_self" />
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
            height: 370px;
        }
        .style5
        {
            width: 22%;
        }
        .style6
        {
            width: 22%;
            height: 57px;
        }
        .style7
        {
            height: 57px;
        }
    </style>
    
</head>
<body>
    <form id="Form1" runat="server">
    <div class="style4">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td background="../../images/bg_03.gif" valign="middle" width="2%">
                    &nbsp;</td>
                <td background="../../images/bg_03.gif" valign="middle" width="2%">
                    <img align="absmiddle" height="9" src="../../images/main_28.gif" width="9" /></td>
                <td background="../../images/bg_03.gif" height="30" valign="middle">
                    <div align="left">
                        <font color="#FFFFFF">添加会议主持人</font></div>
                </td>
            </tr>
        </table>
        <br />
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            style="height: 116px; width: 57%">
            <tr>
                <td class="td_page">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td height="30" class="style5">
                                <div align="center">
                                    部门选择&nbsp;</div>
                            </td>
                            <td height="30">
                                <span class="style4">
                                    <asp:DropDownList ID="ddlDepartment"  style="width:170px " runat="server" CssClass="box" 
                                   runat="server" DataSourceID="odsAllDepartment" 
                                    DataTextField="Departmentname" DataValueField="Id" 
                                    AppendDataBoundItems="True" 
                                    onselectedindexchanged="ddlDepartment_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                   <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsAllDepartment" runat="server" 
                                    SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                                </asp:ObjectDataSource>
                               </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                <div align="center">
                                </div>
                            </td>
                            <td class="style7">
                                <select id="dept" name="selectBasRight" runat="server"  onchange="selectPerson()" size="16" 
                                    style="width:84%; height: 91px;">
                                </select></td>
                        </tr>
                        <tr>
                            <td height="30" class="style5">
                                <div align="center">
                                    会议主持人</div>
                            </td>
                            <td>
                                <input id="txtName" class="input" runat="server"  name="txtName" style="width:94%" 
                                    type="text" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            style="height: 22px; width: 95%">
            <tr>
                <td class="td_page">
                    <div align="center">
                        <input class="BigButton" name="Submit1" onclick="clickOk()" type="button" 
                            value="  确认  " /> &nbsp;
                        <input class="BigButton" name="Submit" onclick="window.close()" 
                            type="button" value="  关闭  " />
                    </div>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
	<SCRIPT language="javascript">
	function Ok() 
	{
		window.close();
		opener.document.all.txtOtherMan.value = window.Form1.hide.value;
	}
    	function Cancel() 
	{
    		window.close();
   	}
</SCRIPT>
</html>
