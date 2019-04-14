function folderNode(id,nodeSta,folderSta,name,link,path,subFolder)
{
	var arrayAux;
	arrayAux = new Array;
	arrayAux[0] = id;
	arrayAux[1] = nodeSta;
	arrayAux[2] = folderSta;
	arrayAux[3] = name;
	arrayAux[4] = link; 	
    arrayAux[5] = path;
    arrayAux[6] = subFolder;
    
    return arrayAux;
}

function appendChild(parent, child)
{
	parent[parent.length] = child;
	return child;
}

function redrawTree()
{
	var doc = frames(0).window.document;

	doc.clear();
	doc.writeln("<html><head><meta http-equiv='Content-Type' content='text/html' charset='gb2312'>");
	doc.writeln("<link rel='stylesheet' href='../default.css' type='text/css'></head>");
	doc.writeln("<body bgcolor='#F7F7F7' text='#000099' link='#000099' vlink='#000099' alink='#FF3300' leftmargin='0' rightmargin='5' marginheight='0'>");
    doc.writeln("<form name='MyForm' method='Post'>");
	doc.writeln("<table width='100%' border='0' cellspacing='0' cellpadding='0' height='100%'  style='background: url(../Images/pageHeaderBG_File.gif) no-repeat fixed left top'><tr><td height='100'>&nbsp;</td></tr><tr><td>");	
	doc.writeln("<div style='position:absolute; left:5px; top:85px; width:100%; height:100%; overflow: auto'>");
	redrawNode(foldersTree, doc, 0, 1, "");
	doc.writeln("</td></tr></table>");
	doc.writeln("</div>");
    doc.writeln("</form>");  
	doc.writeln("</body>");
	doc.writeln("<html>");
	doc.close();
}

function redrawNode(foldersNode, doc, level, lastNode, leftSide)
{
	var j=0;
	var i=0;

	doc.writeln("<table border=0 cellspacing=0 cellpadding=0>");
	doc.writeln("<tr><td valign = middle nowrap>");
	doc.write(leftSide);
	if (level > 0)
	{
		if (foldersNode.length > 7 && foldersNode[1]) 
		{
			if (lastNode) 
			{
				doc.write("<A href='javascript:parent.openBranch(\"" + foldersNode[0] + "\")'>");
				doc.write("<img src='images/lastMinus.gif' width=20 height=22 border=noborder></a>");
				leftSide = leftSide + "<img src='images/blank.gif' width=20 height=22>" ;
			}
			else
			{
				doc.write("<A href='javascript:parent.openBranch(\"" + foldersNode[0] + "\")'>");
				doc.write("<img src='images/minusNode.gif' width=20 height=22 border=noborder></a>");
				leftSide = leftSide + "<img src='images/vertline.gif' width=20 height=22>";
			}
		}
		else if (foldersNode.length > 7 && !foldersNode[1])
		{
			if (lastNode) 
			{
				doc.write("<A href='javascript:parent.openBranch(\"" + foldersNode[0] + "\")'>");
				doc.write("<img src='images/lastPlus.gif' width=20 height=22 border=noborder></a>");
				leftSide = leftSide + "<img src='images/blank.gif' width=20 height=22>" ;
			}
			else
			{
				doc.write("<A href='javascript:parent.openBranch(\"" + foldersNode[0] + "\")'>");
				doc.write("<img src='images/plusNode.gif' width=20 height=22 border=noborder></a>");
				leftSide = leftSide + "<img src='images/vertline.gif' width=20 height=22>";
			}
		}
		else
		{
			if (lastNode) 
			{
				doc.write("<img src='images/lastnode.gif' width=20 height=22>");
				leftSide = leftSide + "<img src='images/blank.gif' width=20 height=22>" ;
			}
			else
			{
				doc.write("<img src='images/node.gif' width=20 height=22>");
				leftSide = leftSide + "<img src='images/vertline.gif' width=20 height=22>";
			}
		}
	}
	if (level == 0)  
	{
		doc.write("<img src=images/mainIcon.gif width=24 height=22 border=noborder></a>");
		doc.write("<td valign=middle align=left nowrap>");
		doc.write("<font style='font-size:9pt;font-family:宋体'>"+foldersNode[3]+"</a></font>");
		doc.writeln("</table>");
	}
	else
	{
		displayIconAndLabel(foldersNode, doc);
		doc.writeln("</table>");
	}
	if (foldersNode.length > 7 && foldersNode[1]) 
	{
		level=level+1;
		for (i=7; i<foldersNode.length;i++)
			if (i==foldersNode.length-1)
				redrawNode(foldersNode[i], doc, level, 1, leftSide);
			else
				redrawNode(foldersNode[i], doc, level, 0, leftSide);
	}
}
function displayIconAndLabel(foldersNode, doc)
{
	doc.write("<A href='javascript:parent.openFolder(\"" + foldersNode[0] + "\",\"" + foldersNode[4] + "\")'><img src=images/");
	if (foldersNode[2])
		doc.write("openfolder.gif width=24 height=22 border=noborder></a>");
	else
		doc.write("closedfolder.gif width=24 height=22 border=noborder></a>");
	doc.write("<td valign=middle align=left nowrap>");
	doc.write("<a href='javascript:parent.openFolder(\"" + foldersNode[0] + "\",\"" + foldersNode[4] + "\")'>");
	doc.write("<font style='font-size:9pt;font-family:宋体'>"+foldersNode[3]+"</a></font>");
    doc.write("<input type='hidden' name='hidPath"+foldersNode[0]+"' value='"+foldersNode[5]+"'>");
    doc.write("<input type='hidden' name='hidSubFolder"+foldersNode[0]+"' value='"+foldersNode[6]+"'>");
}

function closeBranch(foldersNode)
{
	var i=0;
   	for (i=7; i< foldersNode.length; i++)
       	closeBranch(foldersNode[i]);
 	foldersNode[1] = 0;
	foldersNode[2] = 0;
	if (foldersNode[0] == lastopenfolder)
	{
		isopen = 1;
	}
}

function clickOnBranch(foldersNode, folderID)
{
	var i=0;

    if (foldersNode[0] == folderID)
	{
		if (foldersNode[1])
		{
			closeBranch(foldersNode);
			if (isopen == 1)
			{
				isopen = 0;
				openFolder(foldersNode[0],foldersNode[4]);
			}
		}
		else
		{
			foldersNode[1] = 1;
		}
	}
	else
	{
   		for (i=7; i< foldersNode.length; i++)
       		clickOnBranch(foldersNode[i], folderID);
	}
}

function clickOnFolder(foldersNode, folderID)
{
	var i=0;
	foldersNode[2] = 0;
	if (foldersNode[0] == folderID)
	{
		foldersNode[2] = 1;
	}
	for (i=7; i< foldersNode.length; i++)
	{
 		clickOnFolder(foldersNode[i], folderID);
 	}	
}

function openBranch(branchID)
{
	clickOnBranch(foldersTree, branchID);
	if (branchID=="Start folder" && foldersTree[1]==0)
		frames(1).location="basefolder.htm"
	timeOutId = setTimeout("redrawTree()",100);
}

function openFolder(branchID,linkfilename)
{
	lastopenfolder = branchID;
	clickOnFolder(foldersTree, branchID);    
	frames(1).location = linkfilename;
	if (branchID=="Start folder" && foldersTree[1]==0)
		frames(1).location="basefolder.htm"
	timeOutId = setTimeout("redrawTree()",100);
}

function initializeTree()
{
	generateTree();
	redrawTree();
}
