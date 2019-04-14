<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Produce_Add.aspx.cs" Inherits="N_Produce_Produce_Add" %>

<%@ Register assembly="Tunnel.BLL" namespace="OurControl" tagprefix="cc1" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">

    <script type="text/javascript">
      function ShowDialog() {
           var url='../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_m_value&to_name=ctl00_ContentPlaceHolder1_TextBox2';//+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
      function ShowDialog1() {
           var url='../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_first_value&to_name=ctl00_ContentPlaceHolder1_TextBox3&type=single';//+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
     function formCheck() {
        if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value=="")
        {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
            fileupload(1);
            return false;
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
    
    function showtr(num){
        if(num==1)
            document.getElementById("zuser").style.display='';
        else
            document.getElementById("zuser").style.display='none';
    }
    
    function disup(){
        $("#fileup").toggle($("#fileup").css('display') == 'none');
    }
    var inputid=1;
    function shiws(obj){
        var path=obj.value;
        if(document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value.indexOf(path)>=0 || document.getElementById("ctl00_ContentPlaceHolder1_hidFiles").value.indexOf(path.substring(path.lastIndexOf('\\')+1,path.length))>=0)
        {
            $(obj).val("");
            alert("己经添加过该文件了");
            inputid ++;
            $("#inputq").append(CreateFileEl("File"+inputid,obj.onchange));
            $(obj).hide();
        }else{
            var index=path.lastIndexOf('\\');
            var filename=path.substring(index+1,path.length); 
            var reg=/\\/g;
            document.getElementById("divFileInfo").innerHTML+="<span><img src=\"../../image/attach.png\">"+filename+"<img style='cursor:hand' onclick=\"del(this,'"+path.replace(reg,"\\\\")+"','File"+inputid+"')\" alt='删除附件' src=\"../../image/remove.png\">;</span>";
            inputid++;
            $("#inputq").append(CreateFileEl("File"+inputid,obj.onchange));
            $(obj).hide();
            document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value+=path+",";
            //alert(document.getElementById("HiddenField1").value);
        }
    }
    function del(obj,path,input){
        var h_path=document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;
        h_path=h_path.replace(path+",",'');
        document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value=h_path;
        $("#"+input).remove();
        $(obj).parents("span").remove();
    }
    function delF(obj,path,input){
        var h_path=document.getElementById("ctl00_ContentPlaceHolder1_hidFiles").value;
        h_path=h_path.replace(path+",",'');
//        h_path=h_path.replace(","+path,'');
//        h_path=h_path.replace(path,'');
        document.getElementById("ctl00_ContentPlaceHolder1_hidFiles").value=h_path;
        $(obj).parents("span").remove();
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
    </script>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
    <tr>
        <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
        <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
            <a href="Produce_Add.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
                <div style="width:73; height:27px; cursor:pointer;">创建<%=Request.QueryString["name"] %></div>
            </a>
        </td>
        <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
            <a href="Produce_Manage.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
                <div style="width:73; height:27px;cursor:pointer;">管理<%=Request.QueryString["name"] %></div>
            </a>
        </td>
        <td bgcolor="#f6f6f6">&nbsp;</td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
                <tr>
                    <td height="30" align="center" bgcolor="#ffffff">标题：</td>
                    <td  bgcolor="#ffffff">
                        <asp:TextBox runat="server" ID="tb_Title" onkeyup="javascrip:checkWord(100,event,'ctl00_ContentPlaceHolder1_lbl1')" Width="328px" ></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                        <asp:HiddenField ID="hidProID" runat="server" Value="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font style="color: blue;">
                        <asp:Label ID="lblFJ" runat="server" Text="已传附件"></asp:Label>
                        </font>
                        <asp:HiddenField ID="hidFiles" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server"  ID="lblFilesInfo" ForeColor="Red" Text=""></asp:Label>
                        <div id="divFiles"><%=strFiles%></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font style="color: blue; cursor:pointer" onclick="disup()">+添加附件&nbsp;</font> 
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr id="fileup" style="display:none">
                    <td align="left" colspan="2" rowspan="1" id="inputq" style="height: 30px;"><input id="File1" name="File1" type="file" onchange="shiws(this)" class="butt" /><asp:Label runat="server"  ID="lblFileInfo" ForeColor="Red" Text=""></asp:Label><div id="divFileInfo"></div>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
                    <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
                        <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" OnClientClick="fileupload(0);return formCheck();" onclick="Button1_Click"/>
                        &nbsp;
                        <input type="reset" name="Submit2" value="重 置" class="button"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    <div runat="server" id="fileuploaddiv" style="width:100px;height:100px;top:300px;left:350px;position:absolute;display:none" >
    <img src="../../image/img/uploading.gif" style="width:100px;height:100px" /></div>
</asp:Content>
