<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInput3.aspx.cs" Inherits="UserInput_FrmUserInput3" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="radio">
            月-日
            <asp:RadioButtonList ID="rblweek" runat="server" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="所別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbSo" runat="server" Text="屏東所" Font-Bold="True" Font-Size="Larger"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="課別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbClass" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h1>中古車推進概要</h1>
    </div>
    <div class="BOX">
        換購台數:<asp:TextBox ID="txtChangeBuy" runat="server"></asp:TextBox><br />
        本週查估台數:<asp:TextBox ID="txtBuyEx" runat="server"></asp:TextBox><br />
        成交台數:<asp:TextBox ID="txtDealNum" runat="server"></asp:TextBox><br />
        戰敗車原因及流向說明:<br />
        <asp:TextBox ID="txtFailDealDetail" runat="server" TextMode="MultiLine" Height="86px" Width="600px"></asp:TextBox><br />
        管理自評:<asp:TextBox ID="txtSelfNumber" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnBack" runat="server" Text="上一頁" OnClick="btnBack_Click" /><asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

