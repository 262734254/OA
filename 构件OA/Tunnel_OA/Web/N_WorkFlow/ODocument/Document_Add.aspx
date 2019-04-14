<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_Add.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_ODocument_Document_Add" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">

    <script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>
<script src="../../javascript/StrLength.js" type="text/javascript" language="javascript" ></script>
<script type="text/javascript">
    function disup(){
        $("#fileup").toggle($("#fileup").css('display') == 'none');
    }
    var inputid=1;
    function shiws(obj){
        var path=obj.value;
        if(document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value.indexOf(path)>=0)
        {
            $(obj).val("");
            alert("己经添加过该文件了");            
        }else{
            var index=path.lastIndexOf('\\');
            var filename=path.substring(index+1,path.length); 
            var reg=/\\/g;
            document.getElementById("Label3").innerHTML+="<span><img src=\"../../image/attach.png\">"+filename+"<img style='cursor:hand' onclick=\"del(this,'"+path.replace(reg,"\\\\")+"','File"+inputid+"')\" alt='删除附件' src=\"../../image/remove.png\">;</span>";
            inputid++;
            $("#inputq").append(CreateFileEl("File"+inputid,obj.onchange));
            $(obj).hide();
            document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value+=path+",";
            //alert(document.getElementById("HiddenField1").value);
        }
    }
    function del(obj,path,input){
        //alert(path);
        var h_path=document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;
        h_path=h_path.replace(path+",",'');
        document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value=h_path;
        $("#"+input).remove();
        $(obj).parents("span").remove();
    }
    function delp(obj){
        $(obj).parent("div").remove();
    }
    function CreateFileEl(id,onchange)
    {   
       var attach=document.createElement("input");
       attach.type="file";
       attach.className="butt";
       attach.name=id;
       attach.id=id;
       attach.size=20;
       attach.hideFocus="true";
       attach.onchange=onchange;
       return attach;
    }
    function issub(){
        if($("#ctl00_ContentPlaceHolder1_TextBox1").val()==""){
            alert("请输入公文名称!");fileupload(2);
            $("#ctl00_ContentPlaceHolder1_TextBox1").focus();
            return false;
        }
        if($("#ctl00_ContentPlaceHolder1_HiddenField2").val()=="0"){
            alert("本公文未设置流程,请与系统管理员联系!");fileupload(2);return false;
        }
    
    }
    function fileupload(str) {
        if (str == 0) {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = '';
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = "none";
        }
    }
    </script>
    <style type="text/css">
        .button
        {
            width: 71px;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Document_Add.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">新建公文</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Manage.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">管理公文</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid; border-top:none">
      <tr>
        <td height="30" width="80" align="center" bgcolor="#f6f6f6">公文流程：</td>
        <td bgcolor="#f6f6f6"><asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate><%#Eval("s_name") %><%#getNext(Eval("s_num").ToString()) %>
      </ItemTemplate>
      </asp:Repeater>
            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label><asp:HiddenField
                ID="HiddenField2" runat="server" />
        </td>
      </tr>
      <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">公文类型：</td>
        <td bgcolor="#f6f6f6">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
      </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td height="30" width="80" align="center" bgcolor="#f6f6f6">公文名称：</td>
        <td bgcolor="#f6f6f6" align="left"><asp:TextBox ID="TextBox1" runat="server" Width="255px" onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')"></asp:TextBox>
          &nbsp;<span style="color:Red">* </span><asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/200"></asp:Label></td>
      </tr>
      <tr>
        <td colspan="2" align="left" bgcolor="#ffffff" id="contenttd">
            <asp:Label ID="Label1" runat="server"></asp:Label></td>
      </tr>
      <%if(isuploads){ %>
      <tr>
        <td height="30" width="80" align="center" bgcolor="#f6f6f6">附件：</td>
        <td bgcolor="#f6f6f6">    
    <table border="0" align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" colspan="2" rowspan="1" style="height: 30px;">
            <div id="label3"></div></td>
    </tr> 
    <tr>
        <td align="left" colspan="2" rowspan="1" style="height:30px;">
        <div id="Div1"></div>
        <font style="color: blue; cursor:pointer" onclick="disup()">+添加附件&nbsp;</font> 
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </td>
    </tr>
    <tr  id="fileup" style="display:none">
        <td align="left" colspan="2" rowspan="1" id="inputq" style="height: 30px;">
            <input id="File1" name="File1" type="file" onchange="shiws(this)" class="butt" />
            </td></tr>
            </table>
          </td>
      </tr>
        <%} %>
      <tr>
      
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="发 布" CssClass="button" 
                OnClientClick="fileupload(0);return issub()" onclick="Button1_Click" 
                Height="24px" Width="70px"/>
          &nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
    </table></td>
  </tr>
</table>
<div runat="server" id="fileuploaddiv" style="width:100px;height:100px;top:300px;left:450px;position:absolute;display:none" ><img src="../../image/img/uploading.gif" style="width:100px;height:100px" /></div>
</asp:Content>
