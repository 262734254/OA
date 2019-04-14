<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_ArchivesAdd.aspx.cs" Inherits="profile_profileAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function check() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value == "") {
                alert('请输入档案名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").focus();
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_ArchivesAdd.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">新增档案</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_ArchivesManage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">档案管理</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
            <tr>
                <td width="80" height="30" align="center" bgcolor="#f6f6f6">
                  档案名称：
                </td>
                <td height="84" align="left"  bgcolor="#f6f6f6">
                    <asp:TextBox ID="TextBox1" runat="server" Width="480px" TextMode="MultiLine" MaxLength="300"
                        Height="80px" onkeyup="javascrip:checkWord(600,event,'ctl00_ContentPlaceHolder1_lbl1')"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/600"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                   年份：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  height="30" align="center"  bgcolor="#f6f6f6">
                部门：
                </td>
                <td bgcolor="#f6f6f6" align="left">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>党总支</asp:ListItem>
                        <asp:ListItem>工会</asp:ListItem>
                        <asp:ListItem>总工程师室</asp:ListItem>
                        <asp:ListItem>总经理办公室</asp:ListItem>
                        <asp:ListItem>人力资源部</asp:ListItem>
                        <asp:ListItem>经营计划部</asp:ListItem>
                        <asp:ListItem>资产管理部</asp:ListItem>
                        <asp:ListItem>工程管理部</asp:ListItem>
                        <asp:ListItem>安全管理部</asp:ListItem>
                        <asp:ListItem>贯标办公室</asp:ListItem>
                        <asp:ListItem>信息管理中心</asp:ListItem>
                        <asp:ListItem>团总支</asp:ListItem>
                        <asp:ListItem>防水室</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="30" align="center" >
                文件类型：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>通知/办法/决议/批复/请示</asp:ListItem>
                        <asp:ListItem>规定/制度/标准</asp:ListItem>
                        <asp:ListItem>报表</asp:ListItem>
                        <asp:ListItem>申报材料/评比表彰</asp:ListItem>
                        <asp:ListItem>会议记录</asp:ListItem>
                        <asp:ListItem>计划/总结</asp:ListItem>
                        <asp:ListItem>大事记</asp:ListItem>
                        <asp:ListItem>QC</asp:ListItem>
                        <asp:ListItem>论文</asp:ListItem>
                        <asp:ListItem>专利</asp:ListItem>
                        <asp:ListItem>合同</asp:ListItem>
                        <asp:ListItem>施组</asp:ListItem>
                        <asp:ListItem>特殊载体</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
                &nbsp;
                </td>
                <td align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
                
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return check();"
                        OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
