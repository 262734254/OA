<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XiBao.aspx.cs" Inherits="N_MyWork_N_Star_XiBao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公司喜报</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
    
 
    <style type="text/css">
        .style1
        {
            width: 324px;
        }
        .style2
        {
        }
    </style>
    
 
</head>
<body style="text-align:center">
    <form id="form1" style="width:95%" runat="server">
    <div>


  <table border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        
                style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; width: 80%;">
        <tr>
          
            <td align="center" bgcolor="#f6f6f6" colspan="3" style="width: 47%">
                <span class="big3">&nbsp;公司喜报 </span></td>
            
        </tr>
       
        <tr>
          
            <td width="33%" align="center" bgcolor="#f6f6f6">
                标题
            </td>
            <td width="14%" align="center" bgcolor="#f6f6f6">
                年
            </td>
            <td width="14%" align="center" bgcolor="#f6f6f6">
                月
            </td>
            
        </tr>
        <asp:repeater id="Repeater1" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                        onmouseout="this.style.backgroundColor='';this.style.color='';" height="26px">
                                            
                        <td align="center" bgcolor="#FFFFFF">
                        
       <a href="/N_Right/XiBaoView.aspx?id=<%#Eval("m_Id") %>" target="_blank"> <%#Eval("Title") %> </a> 
<%-- <a href="/N_Right/XiBao.aspx?id=<%#Tunnel.Data.DESEncrypt.Encrypt(Eval("b_id").ToString()) %>" target="_blank"><%#Eval("b_title")%></a>
--%>                      </td>
                        <td align="center" bgcolor="#FFFFFF">
                            <%#Eval("m_year") %>
                        </td>
                        <td align="center" bgcolor="#FFFFFF">
                            <%#Eval("m_moon") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
    </table>
</div>



    
    </form>
       
</body>
</html>
