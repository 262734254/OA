<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="CarManager_logins" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <LINK href="css/public.css" type="text/css" rel="stylesheet"/>
 
  <style type="text/css">

  </style>
    <title>登录页面</title>
</head>
<body background="images/defaults.gif">
			<script src="js/windows.js" defer></script>
			<div id="fadeinbox" >
			</DIV>

<form id="form1" runat="server">
    <div align=center>
        <div style="text-align: center">
            <table style="color: #000000; width: 715px;">
                <tr>
                    <td style="text-align: center"></td>
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" 
                style="width: 716px; height: 378px; color: #000000;">
                <tr>
                    <td style="background-image:url(images/loginbg.jpg);">
                        <table cellpadding="0" cellspacing="0" width="100%" style="height: 279px">
                            <tr>
                                <td rowspan="1">&nbsp;
                              </td>
                                <td rowspan="12" class="style3">
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                                <td style="width: 45%">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td rowspan="1">
                                </td>
                                <td style="width: 39%">
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="1">
                                </td>
                                <td style="width: 39%">
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="13">&nbsp;
                              </td>
                                <td style="width: 39%">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="width: 39%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 39%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 39%">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td class="style2">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="width: 39%">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="width: 39%">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="width: 39%; text-align: left;">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" class="style2">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;" class="style3"><span class="style5">
                                  用户名：
                              </span></td>
                                <td style="width: 39%; text-align: left;">
                                    <asp:TextBox ID="txtUsername" runat="server" onmouseover="this.focus()" onfocus="this.select()" Width="110px" BorderStyle="Groove" TabIndex="1"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5" style="text-align: right;"> 密&nbsp;&nbsp; 码：</td>
                                <td style="text-align: left" class="style5">
                  <asp:TextBox ID="txtPassword" runat="server" onmouseover="this.focus()" onfocus="this.select()" TextMode="Password" Width="110px" BorderStyle="Groove" TabIndex="2"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                              </td>
                            </tr>
                            <tr>
                               
                                <td colspan="2" align="center">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="ibtnLogin" runat="server" type="image" 
                                        ImageUrl="images/login.jpg" onmouseover="changebutton()" 
                                        onmouseout="changebutton1()" TabIndex="4" onclick="ibtnLogin_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="ibtnCalenr" runat="server" type="images" ImageUrl="images/Clearlogin.jpg" onmouseover="changebutton2()" onmouseout="changebutton3()" TabIndex="5"/>
                              </td>
                            </tr>
                            <tr>
                                <td class="style3">&nbsp;
                              </td>
                                <td style="width: 39%; text-align: left;">&nbsp;
                              </td>
                            </tr>
                            <tr>
                                <td rowspan="1">
                                </td>
                                <td class="style3">&nbsp;
                              </td>
                                <td style="width: 39%">&nbsp;
                              </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        &nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
