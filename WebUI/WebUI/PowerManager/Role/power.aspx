<%@ Page Language="C#" AutoEventWireup="true" CodeFile="power.aspx.cs" Inherits="PowerManager_Role_power" %>

<%@ Register Src="../../UserControls/PowerUserControl.ascx" TagName="PowerUserControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>角色赋权及修改</title>
    <link href="../../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../../css/public.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
function save()
{
	alert('角色赋权成功！');
}

 function selAll(obj,value)
        {
            var items=document.getElementsByName(value);
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
        
        
//       function CheckAll(paramId)
//       {
//         var items=document.getElementsByTagName("input");
//         for(i=0;i<items.length;i++)
//         {
//             var e=items[i];
//             var eid=e.id;
//             var m=eid.indexOf()
//           
//         }    
//          
//       
//       
//       }

    </script>

    <style type="text/css">
        .style17
        {
            width: 95px;
        }
        .style18
        {
            width: 75px;
        }
        .style19
        {
            width: 138px;
            height: 5px;
        }
        .style20
        {
            width: 142px;
            height: 5px;
        }
        .style21
        {
            width: 181px;
            height: 5px;
        }
        .style22
        {
            height: 5px;
        }
        .style26
        {
            width: 66px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="2%" align="center" class="title1">
                    <h3>
                        分配权限</h3>
                </td>
            </tr>
        </table>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    <div align="center">
                        <table width="95%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="30" class="style17">
                                    <div align="center">
                                        角色名称</div>
                                </td>
                                <td>
                                    <input name="textfield" id="txtRoleMame" type="text" runat="server" style="width: 90%"
                                        value="系统管理员" class="inputs" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <div align="center">
                                        角色描述</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRoleDecription" class="inputs" runat="server" Height="82px" TextMode="MultiLine"
                                        Width="631px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="hkAddPower" runat="server" NavigateUrl="~/PowerManager/Role/AddPower.aspx">新增权限</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbndeletPower" runat="server" OnClientClick="return confirm('确定要删除吗？')"
            OnClick="lbndeletPower_Click1">删除权限</asp:LinkButton>
        <br />
        <br />
        <br />
        <table width="95%" border="0" align="center" cellpadding="2" cellspacing="0">
            <tr>
                <td class="style18">
                    模块名称
                </td>
                <td class="style26">
                    &nbsp;全选
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    权&nbsp;&nbsp; 限
                </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;
                </td>
                <td class="style26">
                    &nbsp;
                </td>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="style19">
                            </td>
                            <td class="style20">
                            </td>
                            <td class="style21">
                            </td>
                            <td class="style22">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="td_02" colspan="3">
                    <div style="width: 100%">
                        <asp:PlaceHolder ID="phRoleDistribute" runat="server">
                            
                        </asp:PlaceHolder>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnSubmit0" runat="server" class="BigButton" Text="提   交" OnClick="btnSubmit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack0" runat="server" class="BigButton" Text="返   回" CausesValidation="False" />
                    &nbsp;
                </td>
    </form>
    </table>
    <br />
    <br />
</body>
</html>
