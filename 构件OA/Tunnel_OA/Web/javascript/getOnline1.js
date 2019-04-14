var currvalue;
if(!GetMessage){
    var GetMessage = {};
}

$(document).ready(
    function(){
        currvalue=document.getElementById("currid").value;
        GetMessage.FindMessage();
    }
);

GetMessage.FindMessage = function(){
        $.ajax({
           //处理ajax请求
           url:'../javascript/Online1.aspx',
           // 当前用户的ID
           //data:{Uid:$('#userid').val()},
           cache: false,
           //回调函数返回未读短信数目
           success: function(response)
           {
              if(response!=""){
                p_qiao(response);
              };
           },
           error:function(data)
           {
               //alert("加载失败");
           }
       });
       //每隔5 秒递归调用一次，刷新未读短信数目
       window.setTimeout(GetMessage.FindMessage,8000);//核心语句
}
function p_qiao(list){
          var userlist=list.split(",");
          if(document.getElementById("currid").value=="")
              currvalue=document.getElementById("oncurrid").value;
          else
              currvalue=document.getElementById("currid").value;
          document.getElementById("DropDownList1").options.length=0;
          document.getElementById("DropDownList1").options.add(new Option('所有人',0,false,false));
          for(var i=0;i<userlist.length;i++){
              if(userlist[i]!=""){
                 if(i%2==0){
                    if(currvalue==userlist[i]){
                        document.getElementById("DropDownList1").options.add(new Option(userlist[i+1],userlist[i],false,true));
                    }else{
                        document.getElementById("DropDownList1").options.add(new Option(userlist[i+1],userlist[i],false,false));
                    }
                 }
              }
          } 
}

function viewText(){
    
        if(document.getElementById("TextBox1").value==""){
            alert("请输入聊天内空");
            document.getElementById("TextBox1").focus();
            return false;
        }
        if(document.getElementById("CheckBox1").checked==true&&document.getElementById("DropDownList1").value=="0"){
            alert("请选择指定人");
            document.getElementById("DropDownList1").focus();
            return false;
        }
}

function thidselected(val){
    document.getElementById("oncurrid").value=val;
    document.getElementById("currid").value="";
}