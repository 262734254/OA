 function FunSave(strContent)  { 　　 var strOut=getStyle()+strContent;　　 var winSave = window.open(); 　　 winSave.document.open ("text/html","gb2312"); 　　 winSave.document.write (strOut); 　　 winSave.document.execCommand ("SaveAs",true,""+this.document.title+".xls"); 　　 winSave.close(); } function getStyle(){var Style='<style>TB{BACKGROUND-COLOR: black;FONT-SIZE: 12px;LINE-HEIGHT: 16px;TEXT-DECORATION: none;} td{mso-number-format:"\@";BACKGROUND-COLOR:white} td.top{BACKGROUND-COLOR: #4F93DC;COLOR: #ffffff;FONT-SIZE: 12px; LINE-HEIGHT: 16px; TEXT-DECORATION: none;}</style>';return Style;}