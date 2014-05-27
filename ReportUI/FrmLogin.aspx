<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmLogin.aspx.cs" Inherits="FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>周報表系統</h1>
        <div class="BOX">
            帳號:<asp:TextBox ID="txtAcc" runat="server" Height="36px" Width="160px"></asp:TextBox><br />
            密碼:<asp:TextBox ID="txtCode" runat="server" TextMode="Password" Height="36px" Width="160px"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="登入" Height="43px" Width="88px" />
        </div>
    </div>
    </form>
</body>
</html>
