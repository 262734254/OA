<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpPhoto.aspx.cs" MasterPageFile="~/MasterPage.master"
    Inherits="toupiao_UpPhoto" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ContentPlaceHolderID="Header" runat="server" ID="content1">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content2">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr height=35px>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
               <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../N_SysManage/N_VoteManage/NewVote.aspx"class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增投票</div>
                </a>
            </td>
             <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../N_SysManage/N_VoteManage/VoteManageList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票管理</div>
                </a>
            </td>
    <td width="74" id="Td3" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/ChangePhotos.aspx"class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        整体风格</div>
                </a>
            </td>
                <td width="74" id="Td4" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="../../N_PicVote/UpPhoto.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        上传票项</div>
                </a>
            </td>
                            <td width="74" id="Td5" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/Manage_VotePic.aspx" class="a"  target=_blank>
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理票项</div>
                </a>
            </td>
          
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width=100%>
        <tr bgcolor="#f6f6f6">
            <td>
                图片标题：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPicTitle" runat="server" Width="472px"></asp:TextBox>
           </td>
        </tr>
        <tr>
            <td>
                图片作者：
            </td>
            <td align="left">
                <asp:TextBox ID="txtAuthor" runat="server" Width="103px"></asp:TextBox>
            </td>
        </tr>
        <tr bgcolor="#f6f6f6">
            <td>
                图片路径：
            </td>
            <td align="left">
                <asp:FileUpload ID="upPhoto" runat="server" Width="470px" />
            </td>
        </tr>
        <tr>
            <td>
                图片说明：
            </td>
            <td align="left">
                <asp:TextBox ID="txtRemark" runat="server" Width="477px" TextMode="MultiLine" 
                    Rows="3" Height="166px" ></asp:TextBox>
            </td>
        </tr>
        <tr align="center" class="di" height=35px>
            <td colspan="2">
                <asp:Button ID="btnAdd" runat="server" Text="上传" OnClientClick="" OnClick="btnAdd_Click" CssClass="button"
                    Width="70px"></asp:Button>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        //判断文本框输入的是否为数字
        function IsNum(TextId) {
            var txtValue = TextId.value.replace(/(^\s*)|(\s*$)/g, " ");
            txtValue = txtValue.replace(/(^\s*)|(\s*$)/g, "");
            if (txtValue.length > 0) {
                if (isNaN(txtValue)) {
                    alert('必须是数字！');
                    TextId.value = "0";
                    return false;
                }
            } else {
                alert('不能为空和空格！');
                TextId.value = "0";
            }
        }        
       
    </script>

</asp:Content>
