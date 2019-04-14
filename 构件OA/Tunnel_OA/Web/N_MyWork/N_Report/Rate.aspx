<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Rate.aspx.cs" Inherits="SystemManage_KaoHe_Tunnel_DFList" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript">
        var intkey = /^\d*\.?\d{0,2}$/;
        var namekey = /ctl\d+/;
        function ismax(obj, num) {
            var textbox = obj.value;
            if (!intkey.test(textbox)) {
                obj.value = "";
            } else {
                var snum = num.replace('ctl00$ContentPlaceHolder1$GridView1$ctl', '').replace('$TextBox1', '');
                snum = parseInt(snum, 10);
                var maxnum = document.getElementById("maxh" + snum).value;
                if (textbox != "") {
                    if (parseInt(textbox) > parseInt(maxnum)) {
                        obj.value = "";
                    }
                }
            }
        }
    </script>

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td runat="server" width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ExamineAdd.aspx" class="a" id=xinzengkaohe runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增考核</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ProjectDel.aspx" class="a" id=guanligongcheng runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理工程</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="Rate.aspx" class="a" id=kaohedafen runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核打分</div>
                </a>
            </td>
            <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="PK_ProjectManager.aspx" class="a" id=kaohepaihang runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核排行</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td style="height: 10%" align="center" class="tou">
                盾构分公司<%=nianyue.Substring(0,4) %>年<%=nianyue.Substring(4,2) %>月项目经理月收入考核排行表
            </td>
        </tr>
        <tr>
            <td style="height: 30px" align="center">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="80px">
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td style="height: 85%">
                <center>
                    <table border="1" width="100%" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
                        bordercolordark="#FFFFFF">
                        <tr style="background: #f6f6f6">
                            <td class="style1">
                                被考核人
                            </td>
                            <td class="style2">
                                工程项目
                            </td>
                            <td class="style1">
                                考核内容
                            </td>
                            <td class="style1">
                                最大分
                            </td>
                            <td class="style1">
                                部门
                            </td>
                            <td class="style1">
                                评分
                            </td>
                            <td class="style1">
                                收入
                            </td>
                            <td class="style1">
                                总分
                            </td>
                        </tr>
                        <asp:Repeater ID="GridView1" runat="server">
                            <ItemTemplate>
                                <%nums++;%>
                                <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                                    <td style="width: 100px">
                                        <%#Eval("UserName")%>
                                    </td>
                                    <td style="width: 200px">
                                        <%#Eval("ItemsName") %>
                                    </td>
                                    <td style="width: 100px">
                                        <%#Eval("workName")%>
                                    </td>
                                    <td style="width: 100px">
                                        <%#Eval("maxCent")%><input id="maxh<%=nums%>" value="<%#Eval("maxCent")%>" name="maxh<%=nums%>"
                                            type="hidden" />                                        
                                    &nbsp;&nbsp;</td>
                                    <td style="width: 100px">
                                        <%#Eval("bumName")%>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="TextBox1" onkeyup="ismax(this,this.name)" onblur="ismax(this,this.name)"
                                            MaxLength="4" Width="80px" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("PFlist") %>' Visible="false"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px">
                                        <%#Eval("Income") %>
                                    </td>
                                    <td style="width: 100px">
                                        105分
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </center>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr class="di">
            <td>
                <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button2_Click"
                    Text="批量打分" />
            </td>
        </tr>
    </table>
</asp:Content>
