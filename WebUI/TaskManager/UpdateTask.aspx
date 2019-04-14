<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateTask.aspx.cs" Inherits="_Default" %>



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
           width: 182px;
       }
       .style5
       {
           width: 91px;
       }
       .style6
       {
           height: 115px;
           width: 91px;
       }
    </style>
    <script language="javascript" type="text/javascript">
   function checkInput(fileUpload)
   {
      var min=fileUpload.value;
      min=min.toLowerCase().substr(min.lastIndexOf("."));
      if(min!=".rar")
      {
      
       fileUpload.value="";
       alert("只能是rar格式！");
       
      } 
   
   }
   
</script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div runat="server">
          <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>更新任务目标</h3>
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
                                         CssClass="BigSelect">
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
                                     <asp:DropDownList ID="ddlSteps" runat="server" CssClass="BigSelect">
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
                                     <asp:TextBox ID="txtTitle" runat="server" Width="392px" MaxLength="48"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                         ControlToValidate="txtTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                            </tr>
                            <tr align="left">
                                <td class="style5">
                                    目标编号：
                                </td>
                                <td class="style4">
                                     <asp:TextBox ID="txtTargeCode" runat="server" Height="21px" Width="126px" MaxLength="5" 
                                         ></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                         runat="server" ControlToValidate="txtTargeCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                         ControlToValidate="txtTargeCode" ErrorMessage="只能为数字" Operator="GreaterThan" 
                                         Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                                              </td>
                                <td align="left">
                                    领&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;域：
                                </td>
                                <td>
                                     <asp:TextBox ID="txtLingyu" runat="server" Height="21px" 
                                         Width="126px"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                         runat="server" ControlToValidate="txtLingyu" ErrorMessage="*"></asp:RequiredFieldValidator>
                                              </td>
                            </tr>
                            <tr align="left">
                                <td class="style5">
                                    重点工作：
                                </td>
                                <td class="style4">
                                     <asp:TextBox ID="txtUserfulWork" runat="server" 
                                         Height="21px" Width="126px" MaxLength="42"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                         runat="server" ControlToValidate="txtUserfulWork" ErrorMessage="*"></asp:RequiredFieldValidator>
                                              </td>
                                <td align="left">
                                    完成时间：
                                </td>
                                <td>
                    <asp:TextBox ID="txFDate" runat="server" 
                                        Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                        onClick="showcalendar(event, this);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="txtTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    牵头部门：
                                </td>
                                <td class="style4">
                                     <asp:DropDownList ID="ddlLeader" runat="server" CssClass="BigSelect" 
                                         AutoPostBack="True" DataSourceID="objs" DataTextField="departmentName" 
                                         DataValueField="Id" >
                                     </asp:DropDownList>
                                </td>
                                <td align="left">
                                    负&nbsp;责&nbsp人：
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlLeaderMan" runat="server" CssClass="BigSelect" 
                                         DataSourceID="objess12" DataTextField="Name" DataValueField="UID"  Enabled="false"
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
                                         Width="57px" DataSourceID="objssss" DataTextField="Name" 
                                         DataValueField="Name">
                                         <asp:ListItem>李成</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                                <td align="left">
                                    加权系数：
                                </td>
                                <td>
                                    
                                    <asp:DropDownList ID="ddlAddPower" runat="server" Height="16px" Width="56px" 
                                        CssClass="BigSelect">
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
                                         DataValueField="Id">
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style5">
                                    指定维护人员：
                                </td>
                                <td colspan="3">
                                     <asp:DropDownList ID="ddlweihuMan" runat="server" CssClass="BigSelect" 
                                         DataSourceID="bjss234" DataTextField="Name" DataValueField="UID" 
                                         >
                                         <asp:ListItem>王五</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style6">
                                    目标任务：
                                </td>
                                <td colspan="3" class="style3">
                                    &nbsp;<asp:TextBox ID="txtTraget" runat="server" Height="99px" TextMode="MultiLine" Width="389px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style6">
                                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：
                                </td>
                                <td colspan="3" class="style3"> 
                                    <asp:TextBox ID="txtMarks" runat="server" Height="99px" TextMode="MultiLine" 
                                        Width="389px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style5">
                                    附&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件：
                                </td>
                                <td colspan="3" align="left">
                                    &nbsp;<asp:FileUpload ID="fuAddUpload" runat="server" Height="21px"  onchange="checkInput(this)"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目标金额数：<asp:TextBox 
                                        ID="txtMoney" runat="server" Width="61px" CssClass="BigInputMoney"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="txtMoney" ErrorMessage="*"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                         ControlToValidate="txtMoney" ErrorMessage="只能为数字" Operator="GreaterThan" 
                                         Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                                    万</td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnSave" runat="server" CssClass="BigButton" 
                                        onclick="btnSave_Click" Text="更  新" />
&nbsp;&nbsp;<asp:Button ID="btnSend" runat="server" CssClass="BigButton" onclick="btnSend_Click" Text="发  送" />
&nbsp;
                                    <asp:Button ID="btnCanel" runat="server" CssClass="BigButton" 
                                        onclick="btnCanel_Click" Text="取   消" />
                                    &nbsp;&nbsp;&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
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
