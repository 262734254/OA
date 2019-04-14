<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckNote.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审批记录列表</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!---审批记录-->
        <div class="title1">
            <h3>
                审批记录列表</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 18px">
                按审批类型：<select id="Select1" class="SmallStatic" name="D4">
                                 <option selected="selected">用车申请</option>
                                <option>会议申请信息</option>
                                <option>车辆采购申请</option>
                                <option>资源借用申请</option>
                                <option>资源采购申请</option>
                                <option>资源借用申请</option>
                                <option>资源采购申请</option>
                            </select>
                <input id="btnExit" type="button" value="查询" class="BigButton" onclick="history.go(-1);" /></div>
            <br />
            <div>
                &nbsp;&nbsp;&nbsp;
            </div>
        </fieldset>
        <table style="width:750px; height:176px; margin-top: 0px;" cellpadding="0" 
            cellspacing="0">
            <tr align="center" class="TableHeader">
                <td>
                    主题
                       <td>
                           审批人</td>
                <td>
                    审批时间
                </td>
                <td>
                    审批意见</td>
                <td>
                    类型
                </td>
                <td>
                    查看
                </td>
                <td>
                    删除
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    会议申请已通过</td>
                <td>
                    会议申请
                </td>
                <td>
                    <a href="Auditing.aspx">查看</a>
                </td>
                <td>
                  <asp:LinkButton ID="LinkButton1" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    信息不完整，未通过</td>
                <td>
                    会议申请</td>
                <td>
                   <a href="Auditing.aspx">查看</a>
                </td>
                <td>
                  <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    经费不足，无法采购</td>
                <td>
                    资源采购申请</td>
                <td>
                    <a href="Auditing.aspx">查看</a>
                </td>
                <td>
                   <asp:LinkButton ID="LinkButton3" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style1">
                    数据绑定
                </td>
                <td class="style1">
                    数据绑定
                </td>
                <td class="style1">
                    数据绑定
                </td>
                <td class="style1">
                    您本月出车次数太多！</td>
                <td class="style1">
                    车辆使用申请</td>
                <td class="style1">
                    <a href="Auditing.aspx">查看</a>
                </td>
                <td class="style1">
                    <asp:LinkButton ID="LinkButton4" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定</td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    任务执行完成!</td>
                <td>
                    任务进展申请</td>
                <td>
                   <a href="Auditing.aspx">查看</a>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton5" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    页&nbsp; |&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
