<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAssignTask.aspx.cs" Inherits="_Default333" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>任务目标下达页面</title>

    <script language="javascript" src="../js/calendar.js"type="text/javascript"></script>
  <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
   <style type="text/css">
        .style1
        {
            width: 91%;
            height:202px;
            background-color:#C6DAF3;
        }
        .style2
      {
          height: 28px;
      }
       .style3
       {
           height: 115px;
       }
       .style4
       {
           width: 70px;
       }
       .style5
       {
           width: 108px;
       }
       .style6
       {
           width: 120px;
       }
       </style>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div >
          <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>目标计划任务阶段进度更新（审核）</h3>
     </td>
            </tr>
            <tr>
               
                <td align="center">
            <table>
                <tr align="left">
                    <td>
                        <table style="height: 575px; width: 557px">
                            <tr align="left">
                                <td align="left" class="style5">
                                    年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度：
                                </td>
                                <td class="style4">
                                     <asp:DropDownList ID="ddlYears" runat="server" Height="16px" Width="56px" 
                                         CssClass="BigSelect" Enabled="False">
                                         <asp:ListItem>2010</asp:ListItem>
                                         <asp:ListItem>2011</asp:ListItem>
                                         <asp:ListItem>2012</asp:ListItem>
                                         <asp:ListItem>2013</asp:ListItem>
                                         <asp:ListItem>2014</asp:ListItem>
                                         <asp:ListItem>2015</asp:ListItem>
                                     </asp:DropDownList>
                                            </td>
                                <td  align="left">
                                    任务类型：
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlSteps" runat="server" CssClass="BigSelect" 
                                         Enabled="False">
                                         <asp:ListItem>计划性任务</asp:ListItem>
                                         <asp:ListItem>突发性任务</asp:ListItem>
                                     </asp:DropDownList>
                                            </td>
                            </tr>
                            <tr align="left">
                                <td class="style5">
                                    标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：
                                </td>
                                <td colspan="3" class="style2">
                                     <asp:TextBox ID="txtTitle" runat="server" Width="392px" MaxLength="48" 
                                         Enabled="False"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr align="left">
                                <td class="style5">
                                    目标编号：
                                </td>
                                <td class="style4">
                                     <asp:TextBox ID="txtTargeCode" runat="server" Height="21px" Width="126px" 
                                         MaxLength="5" Enabled="False" 
                                         ></asp:TextBox>
                                              </td>
                                <td align="left">
                                    领&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;域：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtLingyu" runat="server" Height="21px" 
                                         Width="126px" Enabled="False"></asp:TextBox>
                                              </td>
                            </tr>
                            <tr align="left">
                                <td class="style5">
                                    重点工作：
                                </td>
                                <td class="style4">
                                     <asp:TextBox ID="txtUserfulWork" runat="server" 
                                         Height="21px" Width="126px" MaxLength="42" Enabled="False"></asp:TextBox>
                                              </td>
                                <td align="left">
                                    完成时间：
                                </td>
                                <td>
                    <asp:TextBox ID="txFDate" runat="server" 
                                        Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                        onClick="showcalendar(event, this);" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    牵头部门：
                                </td>
                                <td class="style4">
                                     <asp:DropDownList ID="ddlLeader" runat="server" CssClass="BigSelect" 
                                         AutoPostBack="True" DataTextField="departmentName" 
                                         DataValueField="Id" Enabled="False"  >
                                     </asp:DropDownList>
                                </td>
                                <td align="left">
                                    负&nbsp;责&nbsp人：
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlLeaderMan" runat="server" CssClass="BigSelect" 
                                         DataTextField="Name" DataValueField="UID"  Enabled="false"
                                         >
                                         <asp:ListItem>部门主管</asp:ListItem>
                                     </asp:DropDownList>
                                            &nbsp;</td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    分管领导：
                                </td>
                                <td class="style4">
                                     <asp:DropDownList ID="ddlFenguanLeder" runat="server" CssClass="BigSelect" 
                                         Width="57px" DataTextField="Name" 
                                         DataValueField="Name" Enabled="False">
                                         <asp:ListItem>李成</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                                <td align="left">
                                    加权系数：
                                </td>
                                <td>
                                    
                                    <asp:DropDownList ID="ddlAddPower" runat="server" Height="16px" Width="56px" 
                                        CssClass="BigSelect" Enabled="False">
                                        <asp:ListItem>0.5</asp:ListItem>
                                        <asp:ListItem>0.1</asp:ListItem>
                                        <asp:ListItem>0.6</asp:ListItem>
                                        <asp:ListItem>0.7</asp:ListItem>
                                     </asp:DropDownList>
                                              </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    实施部门：&nbsp;
                                  </td>
                                <td colspan="3">
                                     <asp:DropDownList ID="ddlPutDepart" runat="server" CssClass="BigSelect" 
                                         AutoPostBack="True" DataSourceID="objs" DataTextField="departmentName" 
                                         DataValueField="Id" Enabled="False">
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    指定维护人员：
                                </td>
                                <td colspan="3">
                                     <asp:DropDownList ID="ddlweihuMan" runat="server" CssClass="BigSelect" 
                                         DataSourceID="bjss234" DataTextField="Name" DataValueField="UID" Enabled="False" 
                                         >
                                         <asp:ListItem>王五</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style6">
                                    目标任务：
                                </td>
                                <td colspan="3" class="style3">
                                    &nbsp;<asp:TextBox ID="txtTraget" runat="server" Height="99px" 
                                        TextMode="MultiLine" Width="389px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style6">
                                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：
                                </td>
                                <td colspan="3" class="style3"> 
                                    <asp:TextBox ID="txtMarks" runat="server" Height="99px" TextMode="MultiLine" 
                                        Width="389px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    附&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件：
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hkdown" 
                                        runat="server">下载附件</asp:HyperLink>
                                              </td>
                                <td align="left" colspan="2">
                                    &nbsp;&nbsp;&nbsp;目标金额数：<asp:TextBox 
                                        ID="txtMoney0" runat="server" Width="61px" CssClass="BigInputMoney" 
                                        ReadOnly="true" Enabled="False"></asp:TextBox>
                                    万 
                                    <asp:TextBox 
                                        ID="txtMoney" runat="server" Width="61px" CssClass="BigInputMoney" 
                                        ReadOnly="true" Visible="False"></asp:TextBox></td>
                            </tr>
                            </table>
                    </td>
                </tr>
                          </table>
                   <table style="width: 637px; height: 209px">
                      <tr align="center" class="TableContent">
                   <td  valign="top" style="padding-top:10px">
                       <asp:GridView ID="gvShowDetail" runat="server" AutoGenerateColumns="False" 
                           CellPadding="4" DataSourceID="objesf" ForeColor="#333333" GridLines="None" 
                           DataKeyNames="sId"
                           Width="670px" Height="123px">
                           <RowStyle BackColor="#EFF3FB" CssClass="TableContent" />
                           <EmptyDataRowStyle CssClass="TableContent" />
                           <Columns>
                               <asp:BoundField DataField="StepName" HeaderText="阶段名称" 
                                   SortExpression="StepName" />
                               <asp:TemplateField HeaderText="开始时间(月)" SortExpression="startTime">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("startTime") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="TextBox2" runat="server" 
                                           Text='<%# SubstrGetMonth(Eval("startTime")) %>'></asp:Label>
                                       <asp:HiddenField ID="hidSid" runat="server" Value='<%# Eval("sId") %>' />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="结束时间(月)" SortExpression="filishTime">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("filishTime") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# SubstrGetMonth(Eval("filishTime")) %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="计划完成金额(万)" SortExpression="Premoney">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Premoney") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# SubShotMoney(Eval("Premoney")) %>'></asp:Label>
                                        <asp:HiddenField ID="hidPremoney" runat="server"  Value='<%# Eval("Premoney")%>'  /> 
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="实际完成金额(万)" SortExpression="Nowmoney" ItemStyle-CssClass="BigInputMoney">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="txtNoNowNow" runat="server" Text='<%# Bind("Nowmoney") %>'></asp:TextBox>
                                    
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:TextBox ID="txtMoneyOne" runat="server" CssClass="BigInputMoney" 
                                           Text='<%# SubMoneyToShot(Eval("nowMoney")) %>' Width="45px"></asp:TextBox>
              
                                   </ItemTemplate>
     
<ItemStyle CssClass="BigInputMoney"></ItemStyle>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="描述" SortExpression="Description">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                
                                       <asp:TextBox ID="txtDescript" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" Text='<%# Eval("Description") %>'>' 
                                         ></asp:TextBox>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="存在的问题" SortExpression="Problems">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Problems") %>'></asp:TextBox>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       
                                         <asp:TextBox ID="txtProblems" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" Text='<%# Eval("Problems") %>'>' 
                                         ></asp:TextBox>
                                   </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                           <FooterStyle BackColor="#507CD1" CssClass="TableContent" Font-Bold="True" 
                               ForeColor="White" />
                           <PagerStyle BackColor="#2461BF" CssClass="TableContent" ForeColor="White" 
                               HorizontalAlign="Center" />
                           <SelectedRowStyle BackColor="#D1DDF1" CssClass="TableContent" Font-Bold="True" 
                               ForeColor="#333333" />
                           <HeaderStyle BackColor="#507CD1" CssClass="TableHeader" Font-Bold="True" 
                               ForeColor="White" />
                           <EditRowStyle BackColor="#2461BF" CssClass="TableContent" />
                           <AlternatingRowStyle BackColor="White" CssClass="TableContent" />
                       </asp:GridView>
                       <asp:ObjectDataSource ID="objesf" runat="server" 
                           SelectMethod="SelecTaskAllStageProcessByTaskId" 
                           TypeName="BLL.Target.TaskManager">
                           <SelectParameters>
                               <asp:QueryStringParameter Name="taskId" QueryStringField="Id" Type="Int32" 
                                   DefaultValue="10" />
                           </SelectParameters>
                       </asp:ObjectDataSource>
            &nbsp;&nbsp;
            <asp:Button ID="btnSubCheck" runat="server" CssClass="BigButton" Text="提交审核" 
                           onclick="btnSubCheck_Click" ToolTip="出车" />
            <asp:Button ID="btnCheck" runat="server" CssClass="BigButton" Text="审核" 
                           onclick="btnCheck_Click" ToolTip="审核" />
                          </td>
                   </tr>
                   </table>
                          <table>
                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                          </asp:ScriptManager>
            </table>
            </td>
            </tr>
        </table>
        </div>
   
    </form>
</body>
</html>
