<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Office2Html.aspx.cs" Inherits="Office2Html" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Word转Html" ID="btnWord" runat="server" CommandArgument="docx" OnClick="btnWord_Click" />
            <asp:Button ID="btnExcel" Text="Excel转Html" runat="server" CommandArgument="xlsx" OnClick="btnWord_Click" />
            <asp:Button ID="btnPPT" Text="PPT转Html" runat="server" CommandArgument="ppt" OnClick="btnWord_Click" />
        </div>
    </form>
    <br /><br /><br />
    CSDN博客<a href="http://blog.csdn.net/djk8888" target="_blank">http://blog.csdn.net/djk8888</a>&nbsp;|&nbsp;
    腾讯微博<a href="http://t.qq.com/djk8888" target="_blank">http://t.qq.com/djk8888</a>
</body>
</html>
