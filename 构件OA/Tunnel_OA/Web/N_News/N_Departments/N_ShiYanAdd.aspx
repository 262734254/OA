<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="N_ShiYanAdd.aspx.cs" Inherits="N_News_N_Departments_N_ShiYanAdd" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>新增科室信息</title>
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
        
        function ShowDialog() {
        var url = '../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_id_toValue&to_name=ctl00_ContentPlaceHolder1_tb_toname&titles=0';
        var iWidth = 380; //窗口宽度
        var iHeight = 400; //窗口高度
        var iTop = (window.screen.height - iHeight) / 4.3;
        var iLeft = (window.screen.width - iWidth) / 1.2;
        window.showModalDialog(url, window, "dialogHeight: " + iHeight + "px; dialogWidth: " + iWidth + "px;dialogTop: " + iTop + "; dialogLeft: " + iLeft + "; resizable: no; status: no;scroll:auto");
    }
    function removeimg(name, id) {
        var td_mail = document.getElementById("ctl00_ContentPlaceHolder1_td_tomail");
        var to_id = document.getElementById("ctl00_ContentPlaceHolder1_id_toValue");
        var to_name = document.getElementById("ctl00_ContentPlaceHolder1_tb_toname");
        to_id.value = to_id.value.replace(id + ",", "");
        to_name.value = to_name.value.replace(name + ",", "");
        innerHTMLtext.innerHTML = name + '<IMG id=' + name + id + ' onclick=' + "'" + 'removeimg("' + name + '","' + id + '");' + "'" + ' src="../../image/remove.png">,';
        td_mail.innerHTML = td_mail.innerHTML.replace(innerHTMLtext.innerHTML, "");
    }
function Button2_onclick() {

}
    function setCSS(tdName)
        {
            document.getElementById("icon1").className="showicons";
            document.getElementById("icon2").className="showicons";
            document.getElementById("icon3").className="showicons";
            
            switch(tdName)
            {
                case "1":
                    document.getElementById("icon1").className="showicon";
                    break;
                case "2":
                    document.getElementById("icon2").className="showicon";
                    break;
                case "3":
                    document.getElementById("icon3").className="showicon";
                    break;
                default:
                    document.getElementById("icon4").className="showicon";
                    break;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="N_ShiYanAdd.aspx?parentID=47" onclick="setCSS('1')" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布信息
                    </div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_ShiYanAdd.aspx?parentID=48" onclick="setCSS('2')" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理信息
                    </div>
                </a>
            </td>
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_ShiYanAdd.aspx?parentID=49" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布信息
                    </div>
                </a>
            </td>
            <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_ShiYanManage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理信息
                    </div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left: 1px #6f97b1 solid;
                    border-right: 1px #6f97b1 solid">
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
                            <input id="file1" type="file" runat="server" />&nbsp;
                            <asp:Label ID="Label2" runat="server" Visible="false" Text="Label"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                            <asp:Label ID="Label4" ForeColor="Gray" Visible="false" runat="server" Text="如需修改附件请重新选择，保留请勿选。"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" rowspan="2">
                            浏览人：
                        </td>
                        <td rowspan="1">
                            <div runat="server" id="td_tomail" 
                                style="border:1;width:80%;height:40px;overflow-y:auto; background-color: #D9D9D9;"></div>
                            <input runat="server" id="id_toValue" type="hidden" />
                            <asp:TextBox runat="server" ID="tb_toname"  TextMode="MultiLine" ReadOnly="true" Style="display:none;" Width="80%" Rows="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input  id="Button2" runat="server" class="button" type="button" value="浏览人" onclick="ShowDialog();" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblUserID" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lblUser" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                            <asp:Label ID="lblUserMes" ForeColor="Gray" Visible="false" runat="server" Text="如需修改浏览人请重新选择，保留请勿选。"></asp:Label>
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
    <div style="display:none;" id="innerHTMLtext"></div>
    <div runat="server" id="Div1" style="width: 100px; height: 100px; top:200px;left: 330px; position: absolute; display: none">
        <img src="../../image/img/uploading.gif" style="width: 100px; height: 100px" />
    </div>
</asp:Content>