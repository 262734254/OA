 //<!--
      var duration=4900;
      var timer=null;
      var endTime = new Date().getTime() + duration + 100;
      function interval()
      {
          var n=(endTime-new Date().getTime())/1000;
          if(n<0) return;
          document.getElementById("timeout").innerHTML = n.toFixed(0);
          setTimeout(interval, 10);
      }
      function stopJump()
      {
          clearTimeout(timer);
          document.getElementById("jumphint").style.display = "none";
      }
      
      //-->