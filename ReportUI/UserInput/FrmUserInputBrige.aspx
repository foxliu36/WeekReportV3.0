<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInputBrige.aspx.cs" Inherits="UserInput_FrmUserInputBrige" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="navbutton">
            
            <asp:Button ID="btnStart" runat="server" Text="開啟新的周報表" OnClick="BtnStartClick"/> <br />
            新增或編輯: <br />
            <asp:Button ID="btnOr" runat="server" Text="受訂&販賣推進" OnClick="BtnOrClick" Enabled="False" />
            <asp:Button ID="btnIn" runat="server" Text="保險/分期推進" OnClick="BtnInClick" Enabled="False" />
            <asp:Button ID="btnOl" runat="server" Text="中古車推進" OnClick="BtnOlClick" Enabled="False" />
            <asp:Button ID="btnCa" runat="server" Text="精裝配件推進" OnClick="BtnCaClick" Enabled="False" />
            <asp:Button ID="btnHu" runat="server" Text="人員管理" OnClick="BtnHuClick" Enabled="False" />
            
    </div>
        查看歷史表單:<br />

        <asp:GridView ID="gvShowAll" runat="server" AutoGenerateColumns="False" DataKeyNames="ReportID" OnRowCommand="GvShowAllRowCommand">
            <Columns>
                <asp:ButtonField Text="觀看" CommandName="ViewData" />
                <asp:BoundField DataField="ReportID" HeaderText="報表編號" InsertVisible="False" ReadOnly="True" SortExpression="ReportID" />
                <asp:BoundField DataField="TimeStart" HeaderText="範圍起始" SortExpression="TimeStart" />
                <asp:BoundField DataField="TimeEnd" HeaderText="範圍結束" SortExpression="TimeEnd" />
                <asp:BoundField DataField="Bureau" HeaderText="所別" SortExpression="Bureau" />
                <asp:BoundField DataField="Class" HeaderText="課別" SortExpression="Class" />
            </Columns>
        </asp:GridView>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#navbutton").buttonset();
        });
    </script>
</asp:Content>
