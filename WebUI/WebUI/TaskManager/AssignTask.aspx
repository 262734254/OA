<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignTask.aspx.cs" Inherits="_Default" %>



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
          height: 10px;
      }
       .style3
       {
           height: 67px;
       }
       .style5
       {
           width: 108px;
       }
       .style6
       {
           width: 120px;
       }
       .style7
       {
           width: 62px;
       }
       .style8
       {
           width: 84px;
       }
       .style9
       {
           width: 116px;
       }
       .style10
       {
           width: 108px;
           height: 13px;
       }
       .style11
       {
           width: 70px;
           height: 13px;
       }
       .style12
       {
           height: 13px;
       }
       .style13
       {
           width: 108px;
           height: 10px;
       }
       .style14
       {
           width: 70px;
           height: 8px;
       }
       .style15
       {
           width: 108px;
           height: 8px;
       }
       .style16
       {
           height: 8px;
       }
       .style17
       {
           width: 108px;
           height: 12px;
       }
       .style18
       {
           width: 70px;
           height: 12px;
       }
       .style19
       {
           height: 12px;
       }
       .style20
       {
           width: 108px;
           height: 14px;
       }
       .style21
       {
           height: 14px;
       }
       .style22
       {
           width: 108px;
           height: 15px;
       }
       .style23
       {
           height: 15px;
       }
       .style24
       {
           width: 120px;
           height: 72px;
       }
       .style25
       {
           height: 72px;
       }
       .style26
       {
           width: 120px;
           height: 67px;
       }
       .style27
       {
           height: 23px;
       }
       .style28
       {
           height: 27px;
       }
    </style>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div runat="server">
          <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>目标计划任务阶段划分执行</h3>
     </td>
            </tr>
            <tr>
               
                <td align="center">
                
                    <br />
                <div id="divShow" runat="server">
            <table>
                <tr align="left">
                    <td>
                        <table style="height: 575px; width: 557px">
                            <tr align="left">
                                <td align="left" class="style15">
                                    年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;度：                                 </td>
                                <td class="style14">
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
                                <td  align="left" class="style16">
                                    任务类型：
                                </td>
                                <td class="style16">
                                     <asp:DropDownList ID="ddlSteps" runat="server" CssClass="BigSelect" 
                                         Enabled="False">
                                         <asp:ListItem>计划性任务</asp:ListItem>
                                         <asp:ListItem>突发性任务</asp:ListItem>
                                     </asp:DropDownList>
                                            </td>
                            </tr>
                            <tr align="left">
                                <td class="style13">
                                    标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：
                                </td>
                                <td colspan="3" class="style2">
                                     <asp:TextBox ID="txtTitle" runat="server" Width="392px" Height="19px"  MaxLength="48" 
                                         Enabled="False"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr align="left">
                                <td class="style10">
                                    目标编号：
                                </td>
                                <td class="style11">
                                     <asp:TextBox ID="txtTargeCode" runat="server" Height="19px" Width="126px" 
                                         MaxLength="5" Enabled="False" 
                                         ></asp:TextBox>
                                              </td>
                                <td align="left" class="style12">
                                    领&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;域：
                                </td>
                                <td class="style12">
                                     <asp:TextBox ID="txtLingyu" runat="server" Height="19px"
                                         Width="126px" Enabled="False"></asp:TextBox>
                                              </td>
                            </tr>
                            <tr align="left">
                                <td class="style10">
                                    重点工作：
                                </td>
                                <td class="style11">
                                     <asp:TextBox ID="txtUserfulWork" runat="server" 
                                        Height="19px" Width="126px" MaxLength="42" Enabled="False"></asp:TextBox>
                                              </td>
                                <td align="left" class="style12">
                                    完成时间：
                                </td>
                                <td class="style12">
                    <asp:TextBox ID="txFDate" runat="server" 
                                        Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                Height="19px"    onClick="showcalendar(event, this);" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style17">
                                    牵头部门：
                                </td>
                                <td class="style18">
                                     <asp:DropDownList ID="ddlLeader" runat="server" CssClass="BigSelect" 
                                         AutoPostBack="True" DataTextField="departmentName" 
                                         DataValueField="Id" Enabled="False"  Height="19px" >
                                     </asp:DropDownList>
                                </td>
                                <td align="left" class="style19">
                                    负&nbsp;责&nbsp人：
                                </td>
                                <td class="style19">
                                     <asp:DropDownList ID="ddlLeaderMan" runat="server" CssClass="BigSelect" 
                                         DataTextField="Name" DataValueField="UID"  Enabled="false"
                                         >
                                         <asp:ListItem>部门主管</asp:ListItem>
                                     </asp:DropDownList>
                                            &nbsp;</td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style17">
                                    分管领导：
                                </td>
                                <td class="style18">
                                     <asp:DropDownList ID="ddlFenguanLeder" runat="server" CssClass="BigSelect" 
                                         Width="57px" DataTextField="Name" 
                                         DataValueField="Name" Enabled="False">
                                         <asp:ListItem>李成</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                                <td align="left" class="style19">
                                    加权系数：
                                </td>
                                <td class="style19">
                                    
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
                                <td align="left" class="style20">
                                    实施部门：&nbsp;
                                  </td>
                                <td colspan="3" class="style21">
                                     <asp:DropDownList ID="ddlPutDepart" runat="server" CssClass="BigSelect" 
                                         AutoPostBack="True" DataSourceID="objs" DataTextField="departmentName" 
                                         DataValueField="Id" Enabled="False">
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style22">
                                    指定维护人员：
                                </td>
                                <td colspan="3" class="style23">
                                     <asp:DropDownList ID="ddlweihuMan" runat="server" CssClass="BigSelect" 
                                         DataSourceID="bjss234" DataTextField="Name" DataValueField="UID" Enabled="False" 
                                         >
                                         <asp:ListItem>王五</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style24">
                                    目标任务：
                                </td>
                                <td colspan="3" class="style25">
                                    &nbsp;<asp:TextBox ID="txtTraget" runat="server" Height="68px" 
                                        TextMode="MultiLine" Width="384px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" class="style26">
                                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：
                                </td>
                                <td colspan="3" class="style3"> 
                                    <asp:TextBox ID="txtMarks" runat="server" Height="65px" TextMode="MultiLine" 
                                        Width="385px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" class="style27">
                                    附&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件：
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hkdown" 
                                        runat="server">下载附件</asp:HyperLink>
                                              </td>
                                <td align="left" colspan="2" class="style27">
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
                          &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:LinkButton ID="lnkAddStep" runat="server" 
                        onclick="lnkAddStep_Click">添加阶段</asp:LinkButton>
&nbsp;&nbsp;
                              <asp:LinkButton ID="lnkAddStep0" runat="server" 
                        onclick="lnkAddStep0_Click">删除阶段</asp:LinkButton>
                          </div>
                   <table style="width: 637px; height: 209px">
                   <tr align="center"  class="TableHeader">
                   <td class="style7">阶段名称</td>
                   <td class="style8">开始时间(月)</td>
                   <td class="style9">结束时间(月)</td>
                   <td class="style5">计划完成金额(万)</td>
                   <td class="style6">实际完成金额(万)</td>
                   <td>描述</td>
                   <td>存在的问题</td>
                   </tr>
                   <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep1" runat="server" Text="第一阶段"></asp:Label>
&nbsp;<td class="style8">
                           &nbsp;<asp:DropDownList ID="ddlStart1" runat="server" CssClass="BigSelect">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                       </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver1" runat="server" CssClass="BigSelect">
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                       </td>
                   <td class="style5">
                       &nbsp;<asp:TextBox ID="txtPreMoneyOne" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="1"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtPreMoneyOne" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator16" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyOne" 
                           ErrorMessage="&lt;" Operator="LessThanEqual" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                       </td>
                   <td class="style6">
                       <asp:TextBox ID="txtMoneyOne" runat="server" Width="45px" 
                           CssClass="BigInputMoney"  Text="0"></asp:TextBox>
                       </td>
                   <td>
                                     <asp:TextBox ID="txtDescript1" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                       </td>
                   <td>
                                     <asp:TextBox ID="txtProblems1" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48"  
                                         ></asp:TextBox>
                       </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep2" runat="server" Text="第二阶段"></asp:Label>
                          </td>
                   <td class="style8">
                       &nbsp;<asp:DropDownList ID="ddlStart2" runat="server" CssClass="BigSelect">
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver2" runat="server" CssClass="BigSelect">
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style5">
                                              &nbsp;
                       <asp:TextBox ID="txtPreMoneyTwo" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Height="18px"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator1" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyOne" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                       <asp:CompareValidator ID="CompareValidator11" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyTwo" 
                           ErrorMessage="&lt;" Operator="LessThan" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                          </td>
                   <td class="style6">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtMoneyTwo" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="0" Enabled="False"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator6" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtMoneyTwo" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtDescript2" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48"  
                                         ></asp:TextBox>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtProblems2" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48"  
                                         ></asp:TextBox>
                          </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep3" runat="server" Text="第三阶段"></asp:Label>
                          </td>
                   <td class="style8">
                       &nbsp;<asp:DropDownList ID="ddlStart3" runat="server" CssClass="BigSelect">
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver3" runat="server" CssClass="BigSelect">
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style5"> 
                                              &nbsp;
                       <asp:TextBox ID="txtProMoneyThree" runat="server" Width="45px" 
                           CssClass="BigInputMoney"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator2" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtProMoneyThree" 
                           ErrorMessage="￥" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                       <asp:CompareValidator ID="CompareValidator12" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtProMoneyThree" 
                           ErrorMessage="&lt;" Operator="LessThan" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                          </td>
                   <td class="style6">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtMoneyThree" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="0" Enabled="False"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator7" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtMoneyThree" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtDescript3" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtProblems3" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep4" runat="server" Text="第四阶段"></asp:Label>
                          </td>
                   <td class="style8">
                       &nbsp;<asp:DropDownList ID="ddlStart4" runat="server" CssClass="BigSelect">
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver4" runat="server" CssClass="BigSelect">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style5">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtPreMoneyFour" runat="server" Width="45px" 
                           CssClass="BigInputMoney"  ></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator3" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyFour" 
                           ErrorMessage="￥" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                       <asp:CompareValidator ID="CompareValidator13" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyFour" 
                           ErrorMessage="&lt;" Operator="LessThan" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                          </td>
                   <td class="style6">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtMoneyFour" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="0" Enabled="False" ></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator8" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyFour" 
                           ErrorMessage="￥" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtDescript4" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtProblems4" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep5" runat="server" Text="第五阶段"></asp:Label>
                          </td>
                   <td class="style8">
                       &nbsp;<asp:DropDownList ID="ddlStart5" runat="server" CssClass="BigSelect">
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver5" runat="server" CssClass="BigSelect">
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style5">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtPreMoneyFive" runat="server" Width="45px" 
                           CssClass="BigInputMoney"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator4" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyFive" 
                           ErrorMessage="￥" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                       <asp:CompareValidator ID="CompareValidator14" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneyFive" 
                           ErrorMessage="&lt;" Operator="LessThan" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                          </td>
                   <td class="style6">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtMoneyFive" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="0" Enabled="False"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator9" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtMoneyFive" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtDescript5" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtProblems5" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td class="style7">
                       <asp:Label ID="lblStep6" runat="server" Text="第六阶段"></asp:Label>
                          </td>
                   <td class="style8">
                       &nbsp;<asp:DropDownList ID="ddlStart6" runat="server" CssClass="BigSelect">
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style9">
                       <asp:DropDownList ID="ddlOver6" runat="server" CssClass="BigSelect">
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                          </td>
                   <td class="style5">
                       &nbsp;
                       <asp:TextBox ID="txtPreMoneySix" runat="server" Width="45px" 
                           CssClass="BigInputMoney"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator5" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneySix" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                       <asp:CompareValidator ID="CompareValidator15" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtPreMoneySix" 
                           ErrorMessage="&lt;" Operator="LessThan" SetFocusOnError="True" 
                           Type="Double"></asp:CompareValidator>
                          </td>
                   <td class="style6">
                       &nbsp;&nbsp;
                       <asp:TextBox ID="txtMoneySix" runat="server" Width="45px" 
                           CssClass="BigInputMoney" Text="0" Enabled="False"></asp:TextBox>
                          <asp:CompareValidator ID="CompareValidator10" runat="server" 
                           ControlToCompare="txtMoney" ControlToValidate="txtMoneySix" ErrorMessage="￥" 
                           Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtDescript6" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" 
                                         ></asp:TextBox>
                          </td>
                   <td>
                                     <asp:TextBox ID="txtProblems7" runat="server" Height="21px" Width="83px" 
                                         MaxLength="48" ></asp:TextBox>
                          </td>
                   </tr>
                      <tr align="center" class="TableContent">
                   <td colspan="7" class="style28">
            &nbsp;&nbsp;
            <asp:Button ID="btnJustDo" runat="server" CssClass="BigButton" Text="分发给部门执行" 
                       ToolTip="出车"     onclick="btnJustDo_Click" />
                          </td>
                   </tr>
                   </table>
                          <br />
                          <asp:GridView ID="gvStepShow" runat="server" CellPadding="4" 
                              GridLines="None" Height="111px" Width="639px" 
                              HeaderStyle-CssClass="TableHeader" ForeColor="#333333" 
                              DataSourceID="objs" AutoGenerateColumns="False" >
                              <FooterStyle BackColor="#507CD1" ForeColor="White" CssClass="TableContent" 
                                  Font-Bold="True" />
                              <RowStyle BackColor="#EFF3FB" CssClass="TableContent" />
                              <EmptyDataRowStyle CssClass="TableContent" />
                              <Columns>
                                  <asp:TemplateField HeaderText="阶段名称" SortExpression="StepName">
                                      <ItemTemplate>
                                          <asp:Label ID="lblStepName" runat="server" Text='<%# Eval("StepName") %>'></asp:Label>
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StepName") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="开始时间(月)" SortExpression="StartMonth">
                                      <ItemTemplate>
                                          <asp:TextBox ID="txtStartTime" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="36px" Text='<%# Eval("StartMonth") %>' ></asp:TextBox>
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StartMonth") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="结束时间(月)" SortExpression="EndMonth">
                                      <ItemTemplate>
                                          <asp:TextBox ID="txtEndMonth" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="36px" Text='<%# Eval("EndMonth") %>' ></asp:TextBox>
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("EndMonth") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="计划完成金额(万)" SortExpression="Premoney">
                                      <ItemTemplate>
                                       <asp:TextBox ID="txtPremoney" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="36px" Text='<%# Eval("Premoney") %>' ></asp:TextBox>
                                        
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Premoney") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="实际完成金额(万)" SortExpression="Nowmoney">
                                      <ItemTemplate>
                                      <asp:TextBox ID="txtNowmoney" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="56px" Text='<%# Eval("Nowmoney") %>' ></asp:TextBox>
                                        
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Nowmoney") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="描述" SortExpression="Description">
                                      <ItemTemplate>
                                       <asp:TextBox ID="txtDescription" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="76px" Text='<%# Eval("Description") %>' ></asp:TextBox>

                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="存在的问题" SortExpression="Problems">
                                      <ItemTemplate>
                                        <asp:TextBox ID="txtProblems" runat="server" CssClass="SmallInput" 
                                              Height="18px" Width="76px" Text='<%# Eval("Problems") %>' ></asp:TextBox>
                                        
                                      </ItemTemplate>
                                      <EditItemTemplate>
                                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Problems") %>'></asp:TextBox>
                                      </EditItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
                                  CssClass="TableContent" />
                              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" 
                                  CssClass="TableContent" />
                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                  CssClass="TableHeader" />
                              <EditRowStyle BackColor="#2461BF" CssClass="TableContent" />
                              <AlternatingRowStyle BackColor="White" />
                          </asp:GridView>
                          <asp:ObjectDataSource ID="objs" runat="server" 
                              SelectMethod="GetStageListDataShow" TypeName="BLL.Target.TaskManager"></asp:ObjectDataSource>
                          <br />
            <asp:Button ID="btnJustDo0" runat="server" CssClass="BigButton" Text="分发给部门执行" 
                       ToolTip="出车"     onclick="btnJustDo_Click" />
                          <table>
            </table>
            </td>
            </tr>
        </table>
        </div>
   
    </form>
</body>
</html>
