<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Other_zSp.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_MyApply_Apply_zSp" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
<script type="text/javascript">
    function issub(){
        if($("#ctl00_ContentPlaceHolder1_TextBox2").val()==""){
            alert("请选择下一步审批人");$("#ctl00_ContentPlaceHolder1_TextBox2").focus();return false;
        }
        if($("#ctl00_ContentPlaceHolder1_spPassword").val()==""){
            alert("请输入审批密码");
            $("#ctl00_ContentPlaceHolder1_spPassword").focus();
            return false;
        }
    
    }
    function issub2(){
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
             function ShowDialog() {
                 var url = '../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_m_value&to_name=ctl00_ContentPlaceHolder1_TextBox2&Competence=sp'; //+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
</script>
<style type="text/css">
ul{ margin:0px; padding:0px}
li{ list-style:none; height:20px; text-align:center; margin:0px; width:100%; padding-top:5px; cursor:pointer}
</style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
      <tr>
        <td height="30" width="68" align="right" bgcolor="#f6f6f6">申请流程：</td>
        <td bgcolor="#f6f6f6" align="left">&nbsp;自定义流程&nbsp;<font color="red">(自选审批人)</font> <a href="Other_FlowView.aspx?lid=<%=Request.Params["bid"]%>" target="_blank">查看流程图</a>
        </td>
      </tr>
      <tr>
        <td height="30" width="68" align="right" bgcolor="#f6f6f6">名称：</td>
        <td bgcolor="#f6f6f6">&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label></td>
      </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td height="30" width="100" align="right" bgcolor="#f6f6f6">下一步审批人：</td>
        <td bgcolor="#f6f6f6" align="left">
            <asp:TextBox ID="TextBox2" runat="server" Height="44px" 
                ReadOnly="True"
                        Width="261px" TextMode="MultiLine"></asp:TextBox>&nbsp;<span style="color:Red">*</span><asp:HiddenField ID="m_value" runat="server" />
                    <a href="#" onclick="ShowDialog()"><span style="color: Blue">+选择</span></a></td>
      </tr>
      <tr>
        <td width="100" height="100" align="right" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td align="left" valign="top" id="contenttd" style="border-bottom:1px #6f97b1 solid; padding:10px">
            <asp:Label ID="Label1" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td height="100" style="border-bottom:1px #6f97b1 solid" colspan="2">
        <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 100%">
    <tr>
        <td align="left" colspan="4" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold;">
            &nbsp;流程图</td>
    </tr><%i = 1;%>
    <%=toptb%>
           <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
           <tr>
                <td align="center" style="height: 30px; width: 10%;">第 <font color=red><%=(++i) %></font> 步</td>
                <td align="left" style="width:20%">&nbsp;<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString()) %></td>
                <td align="left" style="width: 30%">&nbsp;&nbsp;<strong style="color:Red"><%#getUname(Eval("e_user").ToString()) %> 主办</strong> [<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString(),1) %>]
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：<%#Eval("e_time") %>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结束于：<%#Eval("e_endtime") %>
                </td>
                <td align="left" style="height: 30px; width: 40%;padding-left:3px"><%#GetAtive(Eval("e_user").ToString(),Eval("e_gid").ToString()) %></td>
            </tr> 
            </ItemTemplate>
           </asp:Repeater>
           <%=nextb%> 
       <%if (isend)
         { %>
       <tr>
        <td align="left" colspan="4" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold;">
            &nbsp;流程结束</td>
    </tr>
    <% }%>
    </table>
        </td>
      </tr>
      <tr>
        <td width="100" align="right" bgcolor="#f6f6f6">审批意见：</td>
        <td align="center" bgcolor="#f6f6f6">
            <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="~/Vfckeditor/" ToolbarSet="Basic" Width="100%" Height="100" ToolbarStartExpanded="true" runat="server">
            </FCKeditorV2:FCKeditor>
          </td>
      </tr>
      <%if(isuploads){ %>
      <tr>
        <td height="30" align="right" bgcolor="#f6f6f6">附件：</td>
        <td bgcolor="#f6f6f6">
            <div id="label3"><%=formfile %></div></td>
    </tr> 
     <%} %>
        <tr>
        <td height="30" align="right" bgcolor="#f6f6f6">审批密码：</td>
        <td bgcolor="#f6f6f6"><asp:TextBox ID="spPassword" TextMode="Password" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="审批通过" CssClass="button" 
                OnClientClick="return issub()" onclick="Button1_Click"/>
                <asp:Button ID="Button2" runat="server" Text="审批不通过" CssClass="button" 
                OnClientClick="return issub2()" onclick="Button2_Click"/>
          &nbsp;
          <asp:Button ID="Button4" runat="server" OnClientClick="return issub2()" Text="结束流程" CssClass="button" 
                onclick="Button4_Click" />&nbsp;<asp:Button ID="Button3" runat="server" Text="返 回" CssClass="button" 
                onclick="Button3_Click" /></td>
      </tr>
    </table></td>
  </tr>
</table></td></tr>
</table>
</asp:Content>
