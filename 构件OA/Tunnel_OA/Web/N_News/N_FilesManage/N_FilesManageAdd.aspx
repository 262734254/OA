<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="N_FilesManageAdd.aspx.cs" Inherits="N_News_N_FilesManage_N_FilesManageAdd" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>新档案信息</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function formCheck() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "") {
                alert('请输入标题！');
                document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
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
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="N_FilesManageAdd.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
                    <div style="width:73; height:27px; cursor:pointer;">新增<%=Request.QueryString["name"] %></div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_FilesManageManage.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
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
                        <td width="50" height="70" align="center" bgcolor="#f6f6f6">
                            标题：
                        </td>
                        <td align="left" bgcolor="#f6f6f6">
                            <asp:TextBox runat="server" ID="tb_Title" Width="70%" TextMode="MultiLine" onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')"
                                Height="35px"></asp:TextBox>
                            <br />
                            <asp:Label ID="lbl1" runat="server" Font-Size="12px" Text="0/200"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#f6f6f6">
                            内容：
                        </td>
                        <td bgcolor="#f6f6f6">
                            <FCKeditorV2:FCKeditor ID="FCKeditor" Height="480" Width="100%" BasePath="~/Vfckeditor/"
                                runat="server">
                            </FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="center">
                            附件：
                        </td>
                        <td align="left">
                            <input id="file1" type="file" runat="server" />
                            <asp:Label ID="lblUrl" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lblFiles" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblMes" ForeColor="Gray" Visible="false" runat="server" Text="如需修改附件请重新选择，保留请勿选。"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                            &nbsp;
                        </td>
                        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                            <asp:Button ID="Button1" runat="server" CssClass="button" Text="提交信息" OnClick="Button1_Click"
                                OnClientClick="return formCheck();fileupload(0);" />
                            &nbsp;
                            <input type="reset" name="Submit2" value="重 置" class="button" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div runat="server" id="fileuploaddiv" style="width: 100px; height: 100px; top: 280px;
        left: 330px; position: absolute; display: none">
        <img src="../../image/img/uploading.gif" style="width: 100px; height: 100px" />
    </div>
</asp:Content>