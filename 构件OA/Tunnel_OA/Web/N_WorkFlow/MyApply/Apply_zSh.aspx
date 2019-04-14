<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_zSh.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_MyApply_Apply_zSh" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
<script type="text/javascript">
    function issub(){
        if($("#ctl00_ContentPlaceHolder1_spPassword").val()==""){
            alert("请输入审批密码");
            $("#ctl00_ContentPlaceHolder1_spPassword").focus();
            return false;
        }
    
    }
            function fshow(obj){
                $("#"+obj).show();
             }
            function fhide(obj){
                $("#"+obj).hide();
             }
            
</script>
<style type="text/css">
ul{ margin:0px; padding:0px}
li{ list-style:none; height:20px; text-align:center; margin:0px; width:100%; padding-top:5px; cursor:pointer}
                .style1
                {
                    width: 93px;
                }
                .style2
                {
                    height: 24px;
                    width: 93px;
                }
            </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
      <tr>
        <td height="30" align="center" width="70" bgcolor="#f6f6f6">流程：</td>
        <td bgcolor="#f6f6f6"><font color=red>审核</font>→<asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate><%#ShowCurr(Eval("s_name").ToString(), Eval("s_id").ToString())%>
      </ItemTemplate>
      </asp:Repeater>流程结束
            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label> <font color=red>(注：红色代表当前执行步骤)</font>
        </td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">名称：</td>
        <td bgcolor="#f6f6f6">
            <asp:Label ID="Label4" runat="server"></asp:Label>
                                </td>
      </tr>
      </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="68" align="center" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td width="796" align="center" id="contenttd" style="border-bottom:1px #6f97b1 solid">
            <asp:Label ID="Label1" runat="server"></asp:Label></td>
      </tr>
      <%if(isuploads){ %>
      <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">附件：</td>
        <td bgcolor="#f6f6f6">
            <div id="label3"><%=formfile %></div></td>
    </tr> 
     <%} %>
        <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="同 意" CssClass="button" 
                OnClientClick="return issub()" onclick="Button1_Click"/>
                <asp:Button ID="Button2" runat="server" Text="不同意" CssClass="button" 
                OnClientClick="return issub()" onclick="Button2_Click"/>
          &nbsp;
          <asp:Button ID="Button3" runat="server" Text="返 回" CssClass="button" 
                onclick="Button3_Click" /></td>
      </tr>
    </table></td>
  </tr>
</table>
</asp:Content>