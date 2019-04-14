<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Power.aspx.cs" Inherits="PowerManager_Role_power" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>角色赋权及修改</title>
<link href="../../css/6/style.css" rel="Stylesheet" type="text/css" />
<link href="../../css/public.css" rel="Stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function save()
{
	alert('角色赋权成功！');
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
    <td width="2%" align="center" class="title1"><h3>分配权限</h3></td>
  </tr>
</table>
<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right"><div align="center">
      <table width="95%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style17"><div align="center">角色名称</div></td>
          <td><input name="textfield" id="txtRoleMame" type="text" runat="server"  style="width:90% " value="系统管理员" class="inputs" /></td>
        </tr>
        <tr>
          <td class="style17"><div align="center">角色描述</div></td>
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
            NavigateUrl="~/PowerManager/Role/AddPower.aspx">新增权限</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbndeletPower" runat="server" 
            OnClientClick="return confirm('确定要删除吗？')" onclick="lbndeletPower_Click1">删除权限</asp:LinkButton>
        <br />
<table width="95%" border="0" align="center" cellpadding="2" cellspacing="0">
  <tr>
    <td width="15%">模块名称</td>
    <td width=>全选</td>
    <td>权限</td>
  </tr>
  <tr>
    <td>会议管理</td>
    <td><input type="checkbox" name="checkbox" id="ck1" value="checkbox" onclick="selAll(this,'checkbox2')"></td>
    <td><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox2" value="checkbox">查看会议室信息</td>
          <td height="30" class="style8"><input type="checkbox" name="checkbox2" value="checkbox">新增会议纪要</td>
          <td height="30" class="style9"><input type="checkbox" name="checkbox2" value="checkbox">查看历史会议纪要</td>
          <td height="30"><input type="checkbox" name="checkbox2" value="checkbox">申请会议室</td>
        </tr>
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox2" value="checkbox">添加会议室</td>
          <td height="30" class="style8"><input type="checkbox" name="checkbox2" value="checkbox">申请会议</td>
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
    <td class="td_02">车辆管理</td>
    <td class="td_02"><input type="checkbox" name="checkbox11" value="checkbox" onclick="selAll(this,'checkbox3')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">申请车辆</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查看出车记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查看维修记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">新增加油记录</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">采购车辆申请</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">新增出车记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">新增维修记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">违章事故录入</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查询车辆信息</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查看车辆杂费</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">新车入库</td>
          <td height="30">&nbsp;</td>
        </tr>
        <tr>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查看加油记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">添加杂费记录</td>
          <td height="30"><input type="checkbox" name="checkbox3" value="checkbox">查看违章事故记录</td>
          <td height="30">&nbsp;</td>
        </tr>
    </table>
      </td>
  </tr>
  <tr>
    <td class="td_01">资源管理</td>
    <td class="td_01"><input type="checkbox" name="checkbox10" value="checkbox" onclick="selAll(this,'checkbox4')"></td>
    <td class="td_01"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox4" value="checkbox">资源信息查询</td>
          <td height="30" class="style6"><input type="checkbox" name="checkbox4" value="checkbox">资源使用记录查询</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源借用申请</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源归还记录</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源损坏记录</td>
        </tr>
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox4" value="checkbox">历史采购单查询</td>
          <td height="30" class="style6"><input type="checkbox" name="checkbox4" value="checkbox">资源采购申请</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源回收记录</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源领取记录</td>
          <td height="30"><input type="checkbox" name="checkbox4" value="checkbox">资源归还记录</td>
        </tr>
    </table></td>
  </tr>
  <tr>
    <td class="td_02">通讯录</td>
    <td class="td_02"><input type="checkbox" name="checkbox11" value="checkbox" onclick="selAll(this,'checkbox5')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style10"><input type="checkbox" name="checkbox5" value="checkbox">添加联系人</td>
          <td height="30" class="style11"><input type="checkbox" name="checkbox5" value="checkbox">导入联系人</td>
          <td height="30" class="style12"><input type="checkbox" name="checkbox5" value="checkbox">查看联系人信息</td>
          <td height="30"><input type="checkbox" name="checkbox5" value="checkbox">联系人记录打印报表</td>
          <td height="30"><input type="checkbox" name="checkbox5" value="checkbox">导出联系人</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">留言簿</td>
    <td class="td_02"><input type="checkbox" name="checkbox12" value="checkbox" onclick="selAll(this,'checkbox6')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style5"><input type="checkbox" name="checkbox6" value="checkbox">发留言</td>
          <td height="30"><input type="checkbox" name="checkbox6" value="checkbox">查看留言</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">日程管理</td>
    <td class="td_02"><input type="checkbox" name="checkbox13" value="checkbox" onclick="selAll(this,'checkbox7')"></td>
    <td class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style4"><input type="checkbox" name="checkbox7" value="checkbox">新增日程</td>
          <td height="30"><input type="checkbox" name="checkbox7" value="checkbox">查看日程</td>
        </tr>
        </table></td>
  </tr>
  <tr>
    <td class="td_02">重点任务目标管理管理</td>
    <td class="td_02">
        <input type="checkbox" name="checkbox36" value="checkbox" onclick="selAll(this,'checkbox9')"></td>
    <td>
    
    
    
    <table  border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
          <td height="30" class="style14"><input type="checkbox" name="checkbox9" value="checkbox">任务目标下达保存</td>
          <td height="30" class="style15"><input type="checkbox" name="checkbox9" value="checkbox">修改任务目标</td>
          <td height="30" class="style16"><input type="checkbox" name="checkbox9" value="checkbox">目标进展情况录入</td>
          <td height="30"><input type="checkbox" name="checkbox9" value="checkbox">统计具体目标阶段进度</td>
          <td height="30">&nbsp;</td>
        </tr>
        <tr>
          <td height="30" class="style14"><input type="checkbox" name="checkbox9" value="checkbox">任务目标下达发送</td>
          <td height="30" class="style15"><input type="checkbox" name="checkbox9" value="checkbox">删除任务目标</td>
          <td height="30" class="style16"><input type="checkbox" name="checkbox9" value="checkbox">目标进展情况查看</td>
          <td height="30"><input type="checkbox" name="checkbox9" value="checkbox">统计目标任务进度</td>
          <td height="30">&nbsp;</td>
        </tr>
    </table>
     </td>
  </tr>
  <tr>
  <td align="center" colspan="3">
  <asp:Button ID="btnSubmit" runat="server" class="BigButton"   PostBackUrl="~/PowerManager/Role/RoleList.aspx"
            Text="提   交" />
                
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
  <asp:Button ID="Button2" runat="server" class="BigButton" 
            Text="返   回" CausesValidation="False" 
          PostBackUrl="~/PowerManager/Role/RoleList.aspx" />
                
  &nbsp;</td>
  </form>
</body>
</html>

