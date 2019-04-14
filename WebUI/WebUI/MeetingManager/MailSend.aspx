<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailSend.aspx.cs" Inherits="UserWork_MailSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加发送者</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />      
 
    <style type="text/css">
        .style1
        {
            width: 101px;
        }
        .style3
        {
            height: 72px;
            width: 101px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
    <base target="_self" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="style4">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
     
        <table style="position: relative; top: 1px; left: 0px; width: 432px; height: 451px;" 
            align="center">
            <tr>
                <td class="style1">
                </td>
                <td style="width: 37px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td>
                    部门：<asp:DropDownList ID="ddlDepartment" class="inputs" runat="server" 
                         AppendDataBoundItems="True" 
                        DataSourceID="odsAllDepartment" DataTextField="Departmentname" 
                        DataValueField="Id" 
                        onselectedindexchanged="ddlDepartment_SelectedIndexChanged" 
                        AutoPostBack="True">
                    <asp:ListItem Selected="True">请选择</asp:ListItem>
                    
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsAllDepartment" runat="server" 
                        SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                    </asp:ObjectDataSource>
                </td>
                <td colspan="2" style="height: 42px">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    人员</td>
                <td style="width: 37px">
                </td>
                <td style="width: 100px">
                    已选人员</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:ListBox ID="txtLeft"  runat="server" class="inputs" Height="241px" Width="146px">
                   </asp:ListBox></td>
                <td style="width: 37px; height: 72px;">
                
                <table align="center" style="width: 10px; height: 217px">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ibRight" runat="server" ImageUrl="~/images/sel1.gif" 
                                onclick="ibRight_Click" style="height: 23px"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ibLeft" runat="server"  ImageUrl="~/images/sel2.gif" 
                                onclick="ibLeft_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgTo" runat="server" ImageUrl="~/images/sel3.gif" 
                                onclick="imgTo_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgReturn" runat="server"  ImageUrl="~/images/sel4.gif" 
                                onclick="imgReturn_Click" Width="23px" />
                        </td>
                    </tr>
                </table>
                </td>
                <td style="width: 100px; height: 72px;">
                    <asp:ListBox ID="txtRight" runat="server" class="inputs" Height="241px" 
                        Width="146px" ></asp:ListBox></td>
            </tr>
            <tr>
                <td align="center" colspan="3" class="style4">
                    	
                             <input type="button" value="确   定" class="BigButton" onclick="clickOk()" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton"  Text="取   消" Height="25px" /></td>
            </tr>
            
        </table>
           
        </ContentTemplate>
        </asp:UpdatePanel>
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
   	function clickOk()
    {
  
	    var name=new Array();
	    for(var i=0;i<document.getElementById("txtRight").options.length;i++)
	    {
	        name[i]=document.getElementById("txtRight").options[i].value;
	    }
	    if(name.length==0)
	    {
		    alert('请填写与会人员');
		    document.getElementById("txtRight").focus();
		    return false;
	    }
	    window.returnValue = name;
	    window.close();
    }
</SCRIPT>
</html>
