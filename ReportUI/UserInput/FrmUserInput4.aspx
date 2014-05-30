<%@ Page Title="" Language="C#" MasterPageFile="~/UserInput/MPUserInput.master" AutoEventWireup="true" CodeFile="FrmUserInput4.aspx.cs" Inherits="UserInput_FrmUserInput4" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="所別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbSo" runat="server" Text="屏東所" Font-Bold="True" Font-Size="Larger"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="課別:" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lbClass" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h1>中古車推進概要</h1>
    </div>
    <div class="BOX">
        <table style="width: 100%;" border="1">
            <tr>
                <td>精裝招攬累計件數</td>
                <td>影音招攬累計件數</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtRefinementNum" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="txtVAudioNum" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>精裝推進率 </td>
                <td>影音推進率 </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbRefinePush" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbVAudioPush" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        精裝推販問題根因說明/改善計劃:<br />

        <asp:TextBox ID="txtRefineDetail" runat="server" TextMode="MultiLine" Height="117px" Width="600px"></asp:TextBox><br /><br />

        <table style="width: 100%;">
            <tr>
                <td colspan="2">配件問題點回饋</td>
            </tr>
            <tr>
                <td>車美仕配件問題件數</td>
                <td>PDS整備問題件數</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAssProNum" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPDSProNum" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>

        其他問題點回饋:<br />
        <asp:TextBox ID="txtOtherProDetail" runat="server" Height="100px" Width="600px" TextMode="MultiLine"></asp:TextBox><br />

        精裝管理自評:<asp:TextBox ID="txtSelfNum" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnBack" runat="server" Text="上一頁" OnClick="btnBack_Click" />
        <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

