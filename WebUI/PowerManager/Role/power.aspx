<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Power.aspx.cs" Inherits="PowerManager_Role_power" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��ɫ��Ȩ���޸�</title>
<link href="../../css/6/style.css" rel="Stylesheet" type="text/css" />
<link href="../../css/public.css" rel="Stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function save()
{
	alert('��ɫ��Ȩ�ɹ���');
}

 function selAll(obj,value)
        {
            var items=document.getElementsByName(value);
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }

</script>

        <style type="text/css">
            .style4
            {
                width: 138px;
            }
            .style5
            {
                width: 140px;
            }
            .style6
            {
                width: 143px;
            }
            .style8
            {
                width: 142px;
            }
            .style9
            {
                width: 181px;
            }
            .style10
            {
                width: 139px;
            }
            .style11
            {
                width: 144px;
            }
            .style12
            {
                width: 107px;
            }
            .style14
            {
                width: 136px;
            }
            .style15
            {
                width: 156px;
            }
            .style16
            {
                width: 120px;
            }
            .style17
            {
                width: 95px;
            }
        </style>
</head>

<body>
    <form id="form1" runat="server">
    <div style="background-color:#C6DAF3;">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="2%" align="center" class="title1"><h3>����Ȩ��</h3></td>
  </tr>
</table>
<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right"><div align="center">
      <table width="95%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style17"><div align="center">��ɫ����</div></td>
          <td><input name="textfield" id="txtRoleMame" type="text" runat="server"  style="width:90% " value="ϵͳ����Ա" class="inputs" /></td>
        </tr>
        <tr>
          <td class="style17"><div align="center">��ɫ����</div></td>
          <td><asp:TextBox ID="txtRoleDecription" 
              class="inputs" runat="server" Height="82px" TextMode="MultiLine" Width="631px"></asp:TextBox>
                            </td>
        </tr>
      </table>
    </div></td>
  </tr>
</table><br>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:HyperLink ID="hkAddPower" runat="server" 
            NavigateUrl="~/PowerManager/Role/AddPower.aspx">����Ȩ��</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbndeletPower" runat="server" 
            OnClientClick="return confirm('ȷ��Ҫɾ����')" onclick="lbndeletPower_Click1">ɾ��Ȩ��</asp:LinkButton>
        <br />
<table width="95%" border="0" align="center" cellpadding="2" cellspacing="0">
  <tr>
    <td width="15%">ģ������</td>
    <td width=>ȫѡ</td>
    <td>Ȩ��</td>
  </tr>
  <tr>
    <td>�������</td>
    <td><input type="checkbox" name="checkbox" id="ck1" value="checkbox" onclick="selAll(this,'checkbox2')"></td>
    <td><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox2" value="checkbox">�鿴��������Ϣ</td>
          <td height="30" class="style8"><input type="checkbox" name="checkbox2" value="checkbox">���������Ҫ</td>
          <td height="30" class="style9"><input type="checkbox" name="checkbox2" value="checkbox">�鿴��ʷ�����Ҫ</td>
          <td height="30"><input type="checkbox" name="checkbox2" value="checkbox">���������</td>
        </tr>
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox2" value="checkbox">��ӻ�����</td>
          <td height="30" class="style8"><input type="checkbox" name="checkbox2" value="checkbox">�������</td>
          <td height="30" class="style9">
              <asp:CheckBox ID="CheckBox1" runat="server" />
                                </td>
          <td height="30">
              <asp:CheckBox ID="CheckBox2" runat="server" />
                                </td>
        </tr>
    </table></td>
  </tr>
  <tr>
    <td class="td_02">��������</td>
    <td class="td_02"><input type="checkbox" name="checkbox11" value="checkbox" onclick="selAll(this,'checkbox3')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">���복��</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�鿴������¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�鿴ά�޼�¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�������ͼ�¼</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�ɹ���������</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">����������¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">����ά�޼�¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">Υ���¹�¼��</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">��ѯ������Ϣ</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�鿴�����ӷ�</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�³����</td>
          <td height="30">&nbsp;</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�鿴���ͼ�¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">����ӷѼ�¼</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">�鿴Υ���¹ʼ�¼</td>
          <td height="30">&nbsp;</td>
        </tr>
    </table>
      </td>
  </tr>
  <tr>
    <td class="td_01">��Դ����</td>
    <td class="td_01"><input type="checkbox" name="checkbox10" value="checkbox" onclick="selAll(this,'checkbox4')"></td>
    <td class="td_01"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox4" value="checkbox">��Դ��Ϣ��ѯ</td>
          <td height="30" class="style6"><input type="checkbox" name="checkbox4" value="checkbox">��Դʹ�ü�¼��ѯ</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ��������</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ�黹��¼</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ�𻵼�¼</td>
        </tr>
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox4" value="checkbox">��ʷ�ɹ�����ѯ</td>
          <td height="30" class="style6"><input type="checkbox" name="checkbox4" value="checkbox">��Դ�ɹ�����</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ���ռ�¼</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ��ȡ��¼</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">��Դ�黹��¼</td>
        </tr>
    </table></td>
  </tr>
  <tr>
    <td class="td_02">ͨѶ¼</td>
    <td class="td_02"><input type="checkbox" name="checkbox11" value="checkbox" onclick="selAll(this,'checkbox5')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style10"><input type="checkbox" name="checkbox5" value="checkbox">�����ϵ��</td>
          <td height="30" class="style11"><input type="checkbox" name="checkbox5" value="checkbox">������ϵ��</td>
          <td height="30" class="style12"><input type="checkbox" name="checkbox5" value="checkbox">�鿴��ϵ����Ϣ</td>
          <td height="30"><input type="checkbox" name="checkbox5" value="checkbox">��ϵ�˼�¼��ӡ����</td>
          <td height="30"><input type="checkbox" name="checkbox5" value="checkbox">������ϵ��</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">���Բ�</td>
    <td class="td_02"><input type="checkbox" name="checkbox12" value="checkbox" onclick="selAll(this,'checkbox6')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox6" value="checkbox">������</td>
          <td height="30"><input type="checkbox" name="checkbox6" value="checkbox">�鿴����</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">�ճ̹���</td>
    <td class="td_02"><input type="checkbox" name="checkbox13" value="checkbox" onclick="selAll(this,'checkbox7')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox7" value="checkbox">�����ճ�</td>
          <td height="30"><input type="checkbox" name="checkbox7" value="checkbox">�鿴�ճ�</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">�ص�����Ŀ��������</td>
    <td class="td_02">
        <input type="checkbox" name="checkbox36" value="checkbox" onclick="selAll(this,'checkbox9')"></td>
    <td>
    
    
    
    <table  border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style14"><input type="checkbox" name="checkbox9" value="checkbox">����Ŀ���´ﱣ��</td>
          <td height="30" class="style15"><input type="checkbox" name="checkbox9" value="checkbox">�޸�����Ŀ��</td>
          <td height="30" class="style16"><input type="checkbox" name="checkbox9" value="checkbox">Ŀ���չ���¼��</td>
          <td height="30"><input type="checkbox" name="checkbox9" value="checkbox">ͳ�ƾ���Ŀ��׶ν���</td>
          <td height="30">&nbsp;</td>
        </tr>
        <tr>
          <td height="30" class="style14"><input type="checkbox" name="checkbox9" value="checkbox">����Ŀ���´﷢��</td>
          <td height="30" class="style15"><input type="checkbox" name="checkbox9" value="checkbox">ɾ������Ŀ��</td>
          <td height="30" class="style16"><input type="checkbox" name="checkbox9" value="checkbox">Ŀ���չ����鿴</td>
          <td height="30"><input type="checkbox" name="checkbox9" value="checkbox">ͳ��Ŀ���������</td>
          <td height="30">&nbsp;</td>
        </tr>
    </table>
     </td>
  </tr>
  <tr>
  <td align="center" colspan="3">
  <asp:Button ID="btnSubmit" runat="server" class="BigButton"   PostBackUrl="~/PowerManager/Role/RoleList.aspx"
            Text="��   ��" />
                
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
  <asp:Button ID="Button2" runat="server" class="BigButton" 
            Text="��   ��" CausesValidation="False" 
          PostBackUrl="~/PowerManager/Role/RoleList.aspx" />
                
  &nbsp;</td>
  </form>
</body>
</html>

