<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="N_NewSh.aspx.cs" Inherits="Common_ViewNewsAnnouncement" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title>查看详细</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function formCheck() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "") {
                alert('请输入标题！');
                document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value == "0" || document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value == "") {
                alert('请选择类型！');
                document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").focus();
                return false;
            }
            //        var obj=document.getElementById('ctl00_ContentPlaceHolder1_file1');
            //        if(obj.value!="")
            //        {
            //            var stuff=obj.value.match(/^(.*)(\.)(.{1,8})$/)[3]; 
            //            if(stuff!='jpg')
            //            {
            //               alert('文件类型不正确，请选择.jpg类型的图片文件');
            //               return false;
            //            }
            //        }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="border-collapse: collapse; border-top: 1px #6f97b1 solid;
            border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-left: 0px; border-top: 0px; border-right: 0px;" bgcolor="#f6f6f6"
                            height="35" colspan="2" align="center">
                            <span id="Label1">
                                <%--标题：--%><%#Eval("i_title")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left: 0px; border-right: 0px;" align="center" colspan="2" height="35">
                            发布人：<%#ShowUserName(Eval("i_user").ToString())%>
                            发布时间：<%#Eval("i_time")%>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left: 0px; border-right: 0px; border-bottom: 0px" colspan="2" align="left"
                            style="padding: 10px" valign="top" height="300">
                            <%#Eval("i_content")%>
                    </tr>
                    <tr>
                        <td style="height: 6px">
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table width="100%" style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid;
            border-bottom: 1px #6f97b1 solid;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="border-top: 0px">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="height: 25px; width: 70px" align="right" bgcolor="#f6f6f6">
                                审核状态：
                            </td>
                            <td bgcolor="#f6f6f6">
                                <asp:RadioButton ID="RadioButton2" GroupName="r1" Text="通过" runat="server" />
                                <asp:RadioButton ID="RadioButton1" GroupName="r1" Text="驳回" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 120px" align="right">
                                评语：
                            </td>
                            <td>
                                <asp:TextBox  ID="TextBox1" runat="server" TextMode="MultiLine" Height="100px" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border: 0px" height="25" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid"
                    colspan="2">
                    <asp:Button ID="Button2" CssClass="button" runat="server" Text="提交审核" 
                        onclick="Button2_Click"  OnClientClick="return formCheck();" />
                    <input id="Button1" class="button" type="button" onclick="window.history.go(-1)"
                        value="返 回" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
