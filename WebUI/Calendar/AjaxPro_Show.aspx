<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxPro_Show.aspx.cs" Inherits="AjaxPro_Show" %>

<%@ OutputCache Duration="120"  VaryByParam="none" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

     <script type="text/javascript"> 

function   getServerTime() 

{ 

    //MyDemo._Default.GetServerTime()得到从服务器传来的数据是object，要写.value 
    alert(AjaxPro_Show.GetServerTime().value); //调用已经注册ajaxpro中的类的方法
    

} 

function   getAjaxTime() 

{ 

    //MyDemo._Default.GetServerTime()得到从服务器传来的数据是object，要写.value 
   document.getElementById("asdas").innerText=AjaxPro_Show.GetServerTime().value; //调用已经注册ajaxpro中的类的方法
  
  
} 

setInterval("getAjaxTime() ",1000); //每隔1秒调用函数


function   add(a,b) 

{ 

 //把文本框的值转换成int 

 var   a1   =   parseInt(a); 

 var   b1   =   parseInt(b); 

//第1、2参数为服务器方法所需要的参数，后面一个是如果服务器返回数据 

//客户端要处理这些数据的js函数名，他有个参数就是从服务器传来的数据 

AjaxPro_Show.AddTwo(a1,b1,getAdd); 

 } 

function   getAdd(rel) 

{ 

   //要加上.value 

  alert(rel.value); 

} 

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
     
            <input id="Button1" type="button" value="获得服务器时间" onclick="getServerTime()" />
            &nbsp;
            <div  id="asdas" style="width: 300px; height: 300px;"></div>
            <br />
            输入第一个数：<input   id="Text1"   type="text"   /><br />
            输入第二个数：<input   id="Text2"   type="text" /><br />
           
            <input id="Button2" type="button" value="得到两个文本框的和 " onclick='add(document.getElementById("Text1").value, document.getElementById("Text2").value)'  /><br />
            <br />
            </div>
    </form>
   
</body>
</html>
