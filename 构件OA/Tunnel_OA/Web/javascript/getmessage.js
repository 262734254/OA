var timeoutID;
if(!GetMessage){
    var GetMessage = {};
}

$(document).ready(
    function(){
        GetMessage.FindMessage();
    }
);

GetMessage.FindMessage = function(){
        $.ajax({
           //处理ajax请求
           url: '/javascript/findmessage.ashx',
           // 当前用户的ID
           data:{Uid:$('#ctl00_Left1_userid').val()},
           cache: false,
           //回调函数返回未读短信数目
           success: function(response)
           {
               if (response > 0) {
                window.open("/showmessage.aspx?mid="+response,"消息提示","height=90,width=400,top="+document.body.scrollHeight+", left=0,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no,status=no");
              }
           },
           error:function(data)
           {
               alert("加载失败");
           }
       });
       //每隔5 秒递归调用一次，刷新未读短信数目
       timeoutID=window.setTimeout(GetMessage.FindMessage, 5000); //核心语句
   }

   GetMessage.StopMessage = function() {
       window.clearTimeout(timeoutID);
   }