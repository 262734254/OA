<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>       

  
<script type="text/javascript" language="javascript">
 var i=0;//ѭ������
     var VoiceObj = new ActiveXObject("Sapi.SpVoice");
//      VoiceObj.Voice = VoiceObj.GetVoices().Item(3); //���Ů��
      
    function SpeakText()
    {
      
        var a1 = document.getElementById("TextMe").value;
        VoiceObj.Speak(a1);
             //alert(a1);   
           // debugger;//�ϵ����
          
            i++;
         
            if(i>5)//6�����ת
           {
                //debugger;//�ϵ����
                window.location.href("SelectCalender.aspx"); //��ת�������ճ̰���ҳ��
           }
           
           
    } 
    
    setInterval("SpeakText()",2000);//2����ѭ��һ��������ʾ

</script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Users/Peace.jpg" 
        Height="669px" Width="863px" />
    <div>
        <asp:HiddenField ID="TextMe" runat="server" />
      
    
    </div>
    </form>
</body>
</html>

