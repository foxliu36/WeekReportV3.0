<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInputBrige.aspx.cs" Inherits="UserInput_UserInputBrige" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(function () {
            $("#radio").buttonset();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="radio">
            
            月-日
            <asp:RadioButtonList ID="rblweek" runat="server" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
            (存顯示只能打本周而已)<br /><br />

            <asp:Button ID="btnStart" runat="server" Text="開啟新的周報表" OnClick="btnStart_Click"/> <br />
            新增或編輯: <br />
            <asp:Button ID="btnOr" runat="server" Text="受訂&販賣推進" OnClick="btnOr_Click" Enabled="False" />
            <asp:Button ID="btnIn" runat="server" Text="保險/分期推進" OnClick="btnIn_Click" Enabled="False" />
            <asp:Button ID="btnOl" runat="server" Text="中古車推進" OnClick="btnOl_Click" Enabled="False" />
            <asp:Button ID="btnCa" runat="server" Text="精裝配件推進" OnClick="btnCa_Click" Enabled="False" />
            <asp:Button ID="btnHu" runat="server" Text="人員管理" OnClick="btnHu_Click" Enabled="False" />
            
        </div>
        查看歷史表單:<br />

        <asp:GridView ID="gvShowAll" runat="server" AutoGenerateColumns="False" DataKeyNames="ReportID" OnRowCommand="gvShowAll_RowCommand">
            <Columns>
                <asp:ButtonField Text="觀看" CommandName="ViewData" />
                <asp:BoundField DataField="ReportID" HeaderText="報表編號" InsertVisible="False" ReadOnly="True" SortExpression="ReportID" />
                <asp:BoundField DataField="TimeStart" HeaderText="範圍起始" SortExpression="TimeStart" />
                <asp:BoundField DataField="TimeEnd" HeaderText="範圍結束" SortExpression="TimeEnd" />
                <asp:BoundField DataField="Bureau" HeaderText="所別" SortExpression="Bureau" />
                <asp:BoundField DataField="Class" HeaderText="課別" SortExpression="Class" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
