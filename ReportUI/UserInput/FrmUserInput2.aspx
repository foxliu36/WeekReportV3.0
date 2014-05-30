<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInput2.aspx.cs" Inherits="UserInput_FrmUserInput2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="所別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbSo" runat="server" Text="屏東所" Font-Bold="True" Font-Size="Larger"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="課別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbClass" runat="server" Text="一課" Font-Bold="True" Font-Size="Larger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h1>保險/分期推進概要</h1>
    </div>
    <div class="BOX">
        
        <table border="1">
            <tr>
                <td colspan="3">續保</td>
                <td colspan="2">第二年續保</td>
                <td>分期</td>
            </tr>
            <tr>
                <td colspan="2">本月目標件數</td>
                <td>本月目標保費</td>
                <td>任意目標件數</td>
                <td>車體目標件數</td>
                <td>本月目標</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbGoalNumber" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbGoalMoney" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbInSecCon" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbCarBdSec" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbGoalMonth" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>累積至本週任意件數</td>
                <td>累積至本週車體(甲乙丙)件數</td>
                <td>累積至本週任意總保費</td>
                <td>累積至本週任意件數</td>
                <td>累積至本週車體（甲乙）件數</td>
                <td>累積至本週販賣台數</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtAnyCaseToNow" runat="server" Text="" /></td>
                <td><asp:TextBox ID="txtCarBdCaseToNow" runat="server" Text="" /></td>
                <td><asp:TextBox ID="txtMoneyToNow" runat="server" Text="" /></td>
                <td><asp:TextBox ID="txtAnyCaseSec" runat="server" Text="" /></td>
                <td><asp:TextBox ID="txtWeekTotalBd" runat="server" Text="" /></td>
                <td><asp:Label ID="lbOrderCount" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>推進率</td>
                <td>推進率</td>
                <td>推進率</td>
                <td>推進率</td>
                <td>推進率</td>
                <td>累積至本周進件台數</td>
            </tr>
            <tr>
                <td><asp:Label ID="lbContinuePushR" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbBdContinuePushR" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbMoneyPushR" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbAnySecPushR" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lbAnyBdR" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="txtImportC" runat="server" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>本月預估保費達成率</td>
                <td>本月預估保費達成率</td>
                <td>本月預估保費達成率</td>
                <td>分期比</td>
          
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:TextBox ID="txtMonTotalExR" runat="server" Width="100px"></asp:TextBox>%</td>
                <td><asp:TextBox ID="txtMonAnyExR" runat="server" Width="100px"></asp:TextBox>%</td>
                <td><asp:TextBox ID="txtMonBdExR" runat="server" Width="100px"></asp:TextBox>%</td>
                <td><asp:Label ID="lbInstallments" runat="server" Text=""></asp:Label>%&nbsp;</td>
            </tr>
        </table> <br />
        弱勢險種改善計劃:<br />
        <asp:TextBox ID="txtRefineProject" runat="server" TextMode="MultiLine" Height="172px" Width="600px"></asp:TextBox> <br />

        管理自評:<asp:TextBox ID="txtSelfNumber" runat="server"></asp:TextBox> <br />

        <asp:Button ID="btnBack" runat="server" Text="上一頁" OnClick="btnBack_Click" />
        <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
        
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

