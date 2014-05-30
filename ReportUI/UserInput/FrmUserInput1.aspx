<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInput1.aspx.cs" Inherits="UserInput_FrmUserInput1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="所別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbSo" runat="server" Text="屏東所" Font-Bold="True" Font-Size="Larger"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="課別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbClass" runat="server" Text="一課" Font-Bold="True" Font-Size="Larger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h1>受訂&販賣推販進度</h1>

    </div>
    <div class="BOX">
        
        <table style="width: 100%;">
            <tr>
                <td>本月目標</td>
                <td>累積至本周受訂</td>
                <td>累積至本周販賣</td>
                <td>目前掌握台數</td>
                <td>至月底前預估</td>
            </tr>
            <tr>
                <td><asp:Label ID="lbMonthGoal" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtOrderCount" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtSaleCount" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtOnControl" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtExpectation" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>販賣理想推進率</td>
                <td>推進率</td>
                <td>推進率</td>
                <td>掌握達成率</td>
                <td>預估達成率</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbIdeaRate" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbOrderRate" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbSaleRate" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td><asp:Label ID="lbControlRate" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td><asp:Label ID="lbExpectRate" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
        </table>
        <br />
        針對本週該課『新訂弱勢車種』說明:<br />
        <asp:TextBox ID="txtWeekCar" runat="server" Height="71px" TextMode="MultiLine" Width="600px"></asp:TextBox>
        <br />
        
        各業專本週受訂狀況:<br />
        <asp:TextBox ID="txtOrderDetail" runat="server" Height="53px" TextMode="MultiLine" Width="600px"></asp:TextBox>
        <br />
        <br />
        未開市人員:<br />
        <asp:TextBox ID="txtUnOrderDetail" runat="server" Height="54px" TextMode="MultiLine" Width="600px"></asp:TextBox>
        <br />
        其他問題點改善說明:<br />
        <asp:TextBox ID="txtOthers" runat="server" Height="63px" TextMode="MultiLine" Width="600px"></asp:TextBox>
        <br />
        販賣管理自評:
        <asp:TextBox ID="txtSelfnumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnBack" runat="server" Text="回上一頁" OnClick="btnBack_Click" />
        <asp:Button ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click" />

    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

    </script>
</asp:Content>

