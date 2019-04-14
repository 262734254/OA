<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFujian.aspx.cs" Inherits="EditFujian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=(Request.QueryString["act"]=="edit"?"在线编辑":"在线阅读") %></title>
    <script type="text/javascript">
        function getwen(){
            var url = document.getElementById("HiddenField1").value;
            document.getElementById('TANGER_OCX').OpenFromURL(url);
        }
        function saverfile(url){
            var retStr = document.getElementById('TANGER_OCX').SaveToURL('upload.aspx','EDITFILE','',url);
            if(retStr!=null){alert('保存成功！');}
        }
    </script>
    <link href="../css/group.css" rel="stylesheet" type="text/css" />
</head>
<body onload="getwen()">
    <form id="form1" runat="server">
    <div> 
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td  width="90%">
<object id="TANGER_OCX" classid="clsid:C9BC4DFF-4248-4a3c-8A49-63A7D317F404" codebase="OfficeControl.cab#version=5,0,1,0" width="100%" height="600">
<param name="ProductCaption" value="上海隧道构件公司"/>
<param name="ProductKey" value="9B8DF5E11FA9E84A644E9AF1F01CD0A612860290"/>
</object>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
