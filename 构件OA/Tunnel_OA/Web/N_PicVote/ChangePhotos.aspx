<%@ Page Language="c#" AutoEventWireup="true" CodeFile="changephotos.aspx.cs" MasterPageFile="~/MasterPage.master"
    Inherits="n_picvote_changephotos" %>

<asp:Content ContentPlaceHolderID="Header" runat="server" ID="content1">

    <script type="text/javascript" language="javascript">     
        function SetColor() {
            window.open("coloSet.htm", 'newwindow', 'height=500, width=600, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content2">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr>
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
   <td width="74" id="Td3" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="../../N_PicVote/ChangePhotos.aspx"class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        整体风格</div>
                </a>
            </td>
                <td width="74" id="Td4" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
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
    <table cellpadding="0" cellspacing="0" border="0" width=100%>
        <tr bgcolor="#f6f6f6"  height=35px>
            <td align="right">
                顶部图片：
            </td>
            <td>
                <asp:FileUpload ID="uptitilepic" runat="server" Width="341px" /><font color="red"> 
                    上传图片宽度:1024像素 高度:195像素</font>
            </td>
        </tr>
        <tr  height=35px>
            <td align="right">
                页面标题：
            </td>
            <td align="left" >
                <asp:TextBox ID="txttitle" runat="server" Width="173px"></asp:TextBox>&nbsp;
                <img src="title.jpg" />
            </td>
        </tr>
        <tr bgcolor="#f6f6f6"  height=35px>
            <td align="right">
                投票主题：
            </td>
            <td align="left">
                <asp:TextBox ID="txttopic" runat="server" Width="537px"></asp:TextBox>
            </td>
        </tr>
        <tr  height=35px>
            <td align="right">
                背景颜色：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcolor" runat="server" Width="88px"></asp:TextBox>
                
            &nbsp;
                <input id="Button2" type="button" class="button" onclick="SetColor()" value="获取颜色" />  
            </td>
        </tr>
        <tr class="di" align="center"  height=35px>
            <td colspan=2>
                <asp:Button ID="btnok" runat="server" Text="上传" CssClass="button" OnClick="btnok_click" />
            </td>
        </tr>
    </table>


</asp:Content>
