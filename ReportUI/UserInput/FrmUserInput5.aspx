<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInput5.aspx.cs" Inherits="UserInput_FrmUserInput5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="所別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbSo" runat="server" Text="屏東所" Font-Bold="True" Font-Size="Larger"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="課別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbClass" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h1>中古車推進概要</h1>
    </div>

    <div class="BOX">
    本課別尚缺人數:<asp:TextBox ID="txtHumanLess" runat="server"></asp:TextBox><br />
    當週面試人數:<asp:TextBox ID="txtInterview" runat="server"></asp:TextBox><br />
    2年以下新入社人員狀況觀察禮貌、話術、專業知識、I-PAD使用概況:<br />
    <asp:TextBox ID="txtObservation" runat="server" Height="100px" Width="600px" TextMode="MultiLine"></asp:TextBox><br />

    本週特別關懷弱勢人員:<br />
    <asp:TextBox ID="txtWeekPeople" runat="server" Height="100px" Width="600px" TextMode="MultiLine"></asp:TextBox><br />
    本週優良業專:<br />
    <asp:TextBox ID="txtGoodSales" runat="server" Height="100px" Width="600px" TextMode="MultiLine"></asp:TextBox><br />
    人員管理自評:
    <asp:TextBox ID="txtSelfNumber" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnBack" runat="server" Text="上一頁" OnClick="btnBack_Click" />
    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
