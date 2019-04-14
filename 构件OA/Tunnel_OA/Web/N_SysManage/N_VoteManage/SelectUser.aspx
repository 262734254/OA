<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectUser.aspx.cs" Inherits="grzm_SelectUser" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>选择用户</title>
<link href="../css/group.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
function CheckAll(form)
{
	for(var y=0; y<form1.elements.length; y++)
	{
		var e = form.elements[y];
		if (e.name != "all"&&e.disabled==false)
        e.checked = form.all.checked;
	}
}
function CheckGroup(form,ID)
//---选组---
{
	var nameStr="click"+ID.toString();
	for(var i=0;i<form.elements.length;i++)
	{
		if (form.elements[i].id == nameStr)
		{
			form.elements[i].checked = eval("form.gourp"+ID+".checked");
		}
	}
}
function SelectUser(form,name)
{
    var nameStr = name;
	var str = ""
	var strName = "";
	var strValue = "";
	for(var x=0; x<form.elements.length; x++)
	{
		if(form.elements[x].id >= nameStr)
		{
			if (form.elements[x].checked == true)
			{
			    var temp = form.elements[x].value;
			    var strArr = temp.split(',');
				strName = strName + strArr[1] +",";
				strValue = strValue + strArr[0] +",";
			}
		}
	}
	strName = strName.slice(0,strName.length-1)
	strValue = strValue.slice(0,strValue.length-1)
	var objName = window.opener.aspnetForm.ctl00_ContentPlaceHolder1_TextbumName;
	var objValue = window.opener.aspnetForm.ctl00_ContentPlaceHolder1_TextbumId;
    if(objName != null)
        objName.value = strName;
    if(objValue != null)
        objValue.value = strValue+"|"+strName;
    window.close();
    //alert(strName)
}
function expandTree(str)
{
    var objStr = document.getElementById(str)
    if(objStr != null)
    {
        if(objStr.style.display == "none")
            objStr.style.display = "";
        else
            objStr.style.display = "none";    
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">
  <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td colspan="3" class="tou" height="30" align="center"> 选择部门 </td>
      </tr>
    </table>    
    <table width="96%" border="0" cellpadding="0" cellspacing="0" align="center">
       <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>        
          <tr>
            <td height="23" align="left" style="width: 10%">
            <div style=" background-color:#e8e8e8; height: 18px; padding-top: 4px; padding-left:4px;"> <a onclick="expandTree('user_Content<%#Eval("b_id")%>');" style=" cursor: hand; text-decoration: none"><%#Eval("b_name")%></a>
                        <input type="checkbox" id='click<%#Eval("b_id") %>' value='<%#Eval("b_id") %>,<%#Eval("b_name")%>' title="点击您要选择部门" />
            </div>
            </td>            
          </tr>
        </ItemTemplate>
      </asp:Repeater>
    </table>    
    <table width="96%" border="0" align="center" cellpadding="6" cellspacing="0">
      <tr>
        <td style="padding-left: 11px;"><input type="checkbox" id="all" title="全选" onclick="CheckAll(this.form)" /> 全选</td>
        <td align="center">&nbsp;&nbsp; <input type="button" value=" 确定 "  class="button"  onclick="SelectUser(this.form,'click');"></td>
      </tr>
    </table>
  </div>
</form>
</body>
</html>
