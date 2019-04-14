<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="StarAdd.aspx.cs" Inherits="SystemManage_Tunnel_MxAdd" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script>
        function ShowDialog() {
            var url = '../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_HiddenField1&to_name=txtUsers&type=single'; //+document.getElementById('DropDownList1').value;
            var iWidth = 380; //窗口宽度
            var iHeight = 400; //窗口高度
            var iTop = (window.screen.height - iHeight) / 2;
            var iLeft = (window.screen.width - iWidth) / 3;
            window.showModalDialog(url, window, "dialogHeight: " + iHeight + "px; dialogWidth: " + iWidth + "px;dialogTop: " + iTop + "; dialogLeft: " + iLeft + "; resizable: no; status: no;scroll:auto;location:no");
        }

        function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_Text1").value == "") {
                alert("请选择日期!");
                return false;
            }
           if (document.getElementById("ctl00_ContentPlaceHolder1_txtUser").value == "")
             {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_txtUser").focus();
            fileupload(1);
            return false;

            }
        if (document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").value == "")
        {
            alert('请选择照片！');
            document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").focus();
            fileupload(1);
            return false;
        }
        }
    </script>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="StarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布喜报</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="StarManage.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理喜报</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr>
            <td height="30" align="right" bgcolor="#f6f6f6" class="style1">
                标题：
            </td>
            <td bgcolor="#f6f6f6">
                <asp:TextBox ID="txtUser" runat="server" MaxLength="20" onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')"></asp:TextBox>
            </td>
        </tr>
   <%--     <tr>
            <td align="right" bgcolor="#ffffff" class="style1">
                照片：
            </td>
            <td bgcolor="#ffffff" class="style2">
                <asp:FileUpload ID="FileUpload1" runat="server" onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')" onkeydown="event.returnValue=false; "
                    onpaste="return   false " />
            </td>
        </tr>--%>
        <tr height="300">
            <td align="right" bgcolor="#f6f6f6" class="style1">
                事迹：
            </td>
            <td bgcolor="#f6f6f6">
                <span>
                    <FCKeditorV2:FCKeditor ID="FreeTextBox1" runat="server" BasePath="~/Vfckeditor/"
                        Height="300">
                    </FCKeditorV2:FCKeditor>
                </span>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                年月：
            </td>
            <td>

                <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

                <input type="text" class="Wdate" id="text1" onfocus="WdatePicker({startDate:'%y-%M',dateFmt:'yyyy-MM',alwaysUseStartDate:true})"
                    runat="server" />
            </td>
        </tr>
        <tr height="30">
            <td align="center" bgcolor="#e6f7ff" class="style1">
                &nbsp;
            </td>
            <td align="left" bgcolor="#e6f7ff">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk();"
                    OnClick="btnSave_Click" />
                <input type="reset" name="Submit2" value="重 置" class="button" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
