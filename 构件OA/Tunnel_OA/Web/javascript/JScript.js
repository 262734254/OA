
        var xmlHttp;
        function CreateXMLHTTPRequest()
        {
            if(window.ActiveXObject)
            {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            else if(window.XMLHttpRequest)
            {
                xmlHttp = new XMLHttpRequest();
            }
        }
        function StartRequest()
        {
            CreateXMLHTTPRequest();            
            var URL = "Handler.ashx?UserName="+document.getElementById("txtUserName").value;            
            xmlHttp.open("POST",URL,true);
            xmlHttp.onreadystatechange = handleStateChange;
            xmlHttp.send(null);
        }
        function handleStateChange()
        {
            if(xmlHttp.readyState == 4)
            {
                if(xmlHttp.status == 200)
                {
                      
                    if(xmlHttp.responseText == "yes")
                    {
                        document.getElementById("show").src = "../../image/noico.gif";
                    }else if(xmlHttp.responseText == "no")
                    {
                        document.getElementById("show").src = "../../image/yesico.gif";
                    }else
                    {
                        document.getElementById("show").src = "";
                    }
                }
            }
        }
