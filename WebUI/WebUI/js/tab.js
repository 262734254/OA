var path			= ""

// tabs
var tab_width			= ""
var up_arrow			= "^ "
var show_parent			= true
var show_sibs			= false
var tab_color			= "#8c8ea3"
var tab_font_color		= "#FFFFFF"
var open_tab_color		= "#FFFFFF"
var open_tab_font_color		= "#ffffff"

// buttons
var button_font			= "tahoma, arial, 宋体"
var button_width		= ""
var button_color		= "#666699"
var button_font_color		= "#ffffff"
var selected_button_color	= "#666699"
var selected_button_font_color	= "#e5e5e5"

// links
var splitter			= "&nbsp;&nbsp;|&nbsp;&nbsp; "
var link_font			= "tahoma, arial, 宋体"
var splitter_color		= "#3333CC"
var link_color			= "#888888"

// dropdown
var dropdown_font		= "lucida console, courier"
var dropdown_indent		= "&nbsp;"


function link(path, name, parent)
{
 this.path = path
 this.name = name
 this.parent = parent
 this.props = new Array (path, name, parent)
}


function do_dropdown(level)
{
 document.writeln ("<font face='" + dropdown_font + "' size=1>")
 document.writeln ("<form name='quick_nav'>")
 document.writeln ("<select name='list' size=1 style=\"font-family='" + dropdown_font + "'; font-size=13\"")
 document.writeln (" onChange=\"if(this.value){document.location=this.value}\">")
 document.writeln ("<option value='' selected>快速跳转")
 document.writeln ("<option value=''>---------")

 var links_length = links.length;

 for(num=0; num<links_length; num++)
 {
  if((links[num].parent == level && level == "") || links[num].name == level)
  {
   document.writeln ("<option value='" + links[num].path + "'>" + links[num].name + " ")
   for(sub=0; sub<links_length; sub++)
   {
    if(links[sub].parent == links[num].name)
    {
     document.writeln ("<option value='" + links[sub].path + "'>" + dropdown_indent + links[sub].name + " ")
    }
   }
  }
 }
 document.writeln ("</select></form>")
}


function do_links(parent)
{
 var i=0

 var links_length = links.length;
 for(num=0; num<links.length; num++)
 {
  if(links[num].parent == parent)
  {
   if(i>0){
    document.writeln ("<font face='" + link_font + "' size=1 color='" + splitter_color + "'>" + splitter + "</font>") 
   }
   document.writeln ("<a href='" + links[num].path + "' title='" + links[num].name + "'>")
   document.writeln ("<font face='" + link_font + "' size=1 color='" + link_color + "'>" + links[num].name + "</font></a>")
   i++
  }
 }
}


function do_table()
{
 var links_length = links.length

 document.writeln ("<table border=1>")
 for (row=0; row<links_length; row++)
 {
  document.writeln ("<tr>")
  for (col=0; col<links[row].props.length; col++)
  {
   document.writeln ("<td><font size=1>")
   document.writeln (links[row].props[col])
   document.writeln ("&nbsp;</font></td>")
  }
  document.writeln ("</tr>")
 }
 document.writeln ("</table>")
}


function do_tabs(section, page)
{
 var children = false
 var level = ""
 var links_length = links.length

 for( num=0; num<links_length; num++){
  if (links[num].name == section){ 
   level = links[num].parent
  }
 }

 document.writeln ("<table  border=0 cellpadding=0 cellspacing=0><tr colspan="+ links_length+1 +" height=2><td></td></tr><tr><td width=6></td>")

 for( num=0; num<links_length; num++)
 {
  if(links[num].name == level || links[num].parent == level)
  {
   if (links[num].name == section) { navclass="navLight" }
   else { navclass = "navDark" }

   if(links[num].name == level && show_parent)
   {
    document.writeln ("<td class='" + navclass+ "' align='center' align='middle' width=" + tab_width + "><nobr>")
    document.write   ( up_arrow )
    document.write   ("&nbsp;&nbsp;")
    document.write   ("<a href='" + links[num].path + "' title='" + links[num].name + "' class=navlink>")
    document.write   ("" + links[num].name + "</a>")
    document.write   ("&nbsp;&nbsp;")
    document.writeln ("</nobr></td>")
    document.writeln ("<td width=6></td>")  
   }
   if(links[num].parent == level)
   {
    document.writeln ("<td class='" + navclass+ "' align='center' align='middle' width=" + tab_width + "><nobr>")
    document.write   ("&nbsp;&nbsp;")
    document.write   ("<a href='" + links[num].path + "' title='" + links[num].name + "' class=navLink>")
    document.write   ( links[num].name + "</a>")
    document.write   ("&nbsp;&nbsp")
    document.writeln ("</nobr></td>")
    document.writeln ("<td width=6></td>")
   }
  }
 }
 document.writeln ("</tr></table>")    

 document.writeln ("<table border=0 cellpadding=0 cellspacing=0 width='100%' align=center><tr><td class='navLight'>")
 document.writeln ("<table border=0 cellpadding=0 cellspacing=2><tr>")

 for(num=0; num<links_length; num++)
 {
  if(links[num].parent == section && section != "")
  {
   if (page == links[num].name) { button_class = "navLink2"}   
   else { button_class = "navLink" }
   document.writeln ("<td class='navLight' align='center' align='middle' width=" + button_width + " ><nobr>")
   document.write   ("&nbsp;&nbsp;")
   document.write   ("<a href='" + links[num].path + "' title='" + links[num].name + "' class='"+button_class+"'>")
   document.write   ("" + links[num].name + "</a>")
   document.write   ("&nbsp;<font class=navLink2>|</font>&nbsp;")
   document.writeln ("</nobr></td>")
   children = true
  }
 }
 if(! children) document.writeln ("<td></td>")
 document.writeln ("</tr></table>")
 document.writeln ("</td></tr></table>")
}

function do_tree(level)
{
 var links_length = links.length

 document.writeln ("<ul>")
 for(num=0; num<links_length; num++)
 {
  if((links[num].parent == level && level == "") || links[num].name == level)
  {
   document.writeln ("<li><a href='" + links[num].path + "'>" + links[num].name + "</a>")
   document.writeln ("<ul>")
  
   for(sub=0; sub<links_length; sub++)
   {
    if(links[sub].parent == links[num].name)
    {
     document.writeln ("<li><a href='" + links[sub].path + "'>" + links[sub].name + "</a>")
    }
   }
   document.writeln ("</ul>")
  }
 }
 document.writeln ("</ul>")
}

function do_tree_r(level)
{
 var links_length = links.length

 for(num=0; num<links_length; num++)
 {
  if(links[num].parent == level)
  {
   document.write ("<li><a href='" + links[num].path + "'>" + name + "</a>")
   do_tree_r(links[num].name)
  }
 }
}

