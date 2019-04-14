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
           url:'../javascript/getChatList.ashx',
           // 当前用户的ID
           data:{Uid:$('#userid').val()},
           cache: false,
           //回调函数返回未读短信数目
           success: function(response)
           {
              if(response!=""){
                 $("#Chatlist").empty();
                 $("#Chatlist").append(response);
                 parent.mainFrame.scrollTo(parent.mainFrame.document.body.scrollWidth,parent.mainFrame.document.body.scrollHeight);
              };
           },
           error:function(data)
           {
               //alert("加载失败");
           }
       });
       //每隔5 秒递归调用一次，刷新未读短信数目
       window.setTimeout(GetMessage.FindMessage,3000);//核心语句
}