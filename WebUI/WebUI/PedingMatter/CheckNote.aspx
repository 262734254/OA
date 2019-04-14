<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckNote.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审批记录列表</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    </head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3; height: 504px;">
        <!---审批记录-->
        <div class="title1">
            <h3>
                审批记录列表</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 18px">
                按审批类型：
                <asp:DropDownList ID="ddlTyep" runat="server" Height="16px">
                <asp:ListItem >会议申请</asp:ListItem>
                <asp:ListItem >用车申请</asp:ListItem>
                <asp:ListItem >资源借用</asp:ListItem>
                <asp:ListItem >资源采购</asp:ListItem>
                    <asp:ListItem>任务申请</asp:ListItem>
                </asp:DropDownList>    
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询 " CssClass="BigButton" 
                    onclick="btnSearch_Click" />
            </div>
            <br />
            <div>
                &nbsp;&nbsp;&nbsp;
            </div>
        </fieldset>
        <br />
        <asp:GridView ID="gvExamine" runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsExamine" Width="751px" 
            onrowcommand="gvExamine_RowCommand">
            <Columns>
                <asp:BoundField DataField="RequisitionID" HeaderText="审批单号" 
                    SortExpression="RequisitionID" />
                <asp:BoundField DataField="EndTime" HeaderText="审批时间" 
                    SortExpression="EndTime" />
                <asp:BoundField DataField="RequisitionType" HeaderText="申请类型" 
                    SortExpression="RequisitionType" />
                <asp:BoundField DataField="ExamineIdea" HeaderText="审批意见" 
                    SortExpression="ExamineIdea" />
                <asp:BoundField DataField="IsApproved" HeaderText="是否通过" 
                    SortExpression="IsApproved" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDet" CommandName="De" CommandArgument='<%# Eval("EID") %>' runat="server" OnClientClick="return comfirm('确定要删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="TableHeader" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsExamine" runat="server" 
            SelectMethod="SearchExamineByType" TypeName="BLL.Matter.ExamineManager">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlTyep" Name="type" 
                    PropertyName="SelectedValue" DefaultValue="会议申请" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <uc1:Pager ID="Pager1" runat="server" />
    </div>
    </form>
</body>
</html>
