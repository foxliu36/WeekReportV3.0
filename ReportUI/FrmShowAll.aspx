<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmShowAll.aspx.cs" Inherits="FrmShowAll" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
        報表期間:<br />
        起始時間:
        <asp:Label ID="TimeStartLabel" runat="server" Text="" />
        <br />
        結束時間:
        <asp:Label ID="TimeEndLabel" runat="server" Text="" /><br />


        受定販賣:<br />
        <table style="width: auto;" border="1">
            <tr>
                <td>本月目標:</td>
                <td><asp:Label ID="MonthGoalLabel" runat="server" Text="" /></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgMonthGoal" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>累積至本周受定台數</td>
                <td><asp:Label ID="OrderedCountLabel" runat="server" Text="123"/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgOrderedCount" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>累積至本周販賣台數</td>
                <td><asp:Label ID="SaleCountLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgSaleCount" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>

                </td>
            </tr>
            <tr>
                <td>目前掌握台數</td>
                <td><asp:Label ID="OnControlLabel" runat="server" Text="" /></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgOnControl" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>至月底預估台數</td>
                <td><asp:Label ID="ExpectationsLabel" runat="server" Text="" /></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgExpectations" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>各業專本周受訂狀況</td>
                <td colspan="2">
                    <asp:TextBox ID="OrderDetailLabel" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                        
            </tr>
            <tr>
                <td>未開市人員</td>
                <td colspan="2">
                    <asp:TextBox ID="UnorderDetailLabel" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>針對本周該課(新訂弱勢車種)說明</td>
                <td colspan="2">
                    <asp:TextBox ID="WeekCarLabel" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>其他問題點改善說明</td>
                <td colspan="2">
                    <asp:TextBox ID="OthersLabel" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>販賣管理自評</td>
                <td colspan="2">
                    <asp:Label ID="SelfNumberLabel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        保險/分期:<br />
        續保:
        <table style="width: auto;" border="1">
            <tr>
                <td>本月目標件數</td>
                <td><asp:Label ID="InGoalLabel" runat="server" Text=""/></td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>累積至本周任意件數</td>
                <td><asp:Label ID="AnyCaseToNowLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgAnyCaseToNow" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>累積至本周車體(甲乙丙)件數</td>
                <td><asp:Label ID="CarBdCaseToNowLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgCarBdCaseToNow" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>本月目標保費</td>
                <td>
                    <asp:Label ID="lbInsurenceBill" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>累積至本周任意總保費</td>
                <td><asp:Label ID="MoneyToNowLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgMoneyToNow" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>本月預估保費達成率</td>
                <td><asp:Label ID="MonTotalExRLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
        </table>

        第二年繼續率:<br />
        <table style="width: auto;" border="1">
            <tr>
                <td>任意目標件數</td>
                <td><asp:Label ID="InSecConLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>累積至本周任意件數</td>
                <td><asp:Label ID="AnyCaseSecLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgAnyCaseSec" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>

                </td>
                <td>本月預估達成率</td>
                <td><asp:Label ID="MonAnyExRLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>車體目標件數</td>
                <td><asp:Label ID="CarBdSecLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>累積至本周車體(甲乙)件數</td>
                <td><asp:Label ID="WeekTotalBdLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgWeekTotalBd" runat="server" Width="200px">
                        <Pointer Shape="BarIndicator" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
                <td>本月預估達成率</td>
                <td><asp:Label ID="MonBdExRLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>弱勢險種改善計畫</td>
                <td><asp:TextBox ID="txtRefinProject" runat="server" Text="" TextMode="MultiLine"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
        </table>

        分期:<br />
        <table style="width: auto;" border="1">
            <tr>
                <td>本月目標</td>
                <td>
                    <asp:Label ID="lbInstallmentsMonthGoal" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>累積至本周販賣台數</td>
                <td>
                    <asp:Label ID="lbSaleCount" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>累積至本周進件台數</td>
                <td><asp:Label ID="TotalWeekImportLabel" runat="server" Text=""/></td>
                <td>
                    <telerik:RadLinearGauge ID="rlgInsurenceInstallments" runat="server" Width="200px">
                        <Pointer Shape="Arrow" Color="102, 153, 255" Value="15">
                            <Track Opacity="0.2" />
                        </Pointer>
                        <Scale Vertical="False" MajorUnit="25">
                            <Labels Format="{0} %" />
                            <Ranges>
                                <telerik:GaugeRange Color="194, 0, 0" To="20" />
                                <telerik:GaugeRange Color="255, 122, 0" From="20" To="40" />
                                <telerik:GaugeRange Color="255, 199, 0" From="40" To="60" />
                                <telerik:GaugeRange Color="141, 203, 42" From="60" To="80" />
                                <telerik:GaugeRange Color="42, 148, 203" From="80" To="100" />
                            </Ranges>
                        </Scale>
                    </telerik:RadLinearGauge>
                </td>
            </tr>
            <tr>
                <td>保險/分期管理自評</td>
                <td><asp:Label ID="SelfNumber1Label" runat="server" Text=""/></td>
                <td>
                </td>
            </tr>
        </table><br />

        中古車:<br />
        <table style="width: auto;" border="1">
            <tr>
                <td>換購台數</td>
                <td><asp:Label ID="ChangeBuyLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>本周查估台數</td>
                <td><asp:Label ID="BuyExLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>成交台數</td>
                <td><asp:Label ID="DealNumLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>戰敗車原因及流向說明</td>
                <td>
                    <asp:TextBox ID="FailDealDetailTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>中古車管理自評</td>
                <td><asp:Label ID="SelfNumber2Label" runat="server" Text=""/></td>
            </tr>
        </table><br />

        精裝配件:<br />
        <table style="width: auto;" border="1">
            <tr>
                <td>精裝招攬累計件數</td>
                <td><asp:Label ID="RefinementNumLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>影音招攬累計件數</td>
                <td><asp:Label ID="VAudioNumLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>精裝推販問題原因說明/改善計畫</td>
                <td>
                    <asp:TextBox ID="RefineDetailTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>車美仕配件問題件數</td>
                <td><asp:Label ID="AssProNumLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>PDS整備問題件數</td>
                <td><asp:Label ID="PDSProNumLabel" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>其他問題點回饋</td>
                <td>
                    <asp:TextBox ID="OthersProDetailTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>精裝管理自評</td>
                <td><asp:Label ID="SelfNumber3Label" runat="server" Text=""/></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        人員管理:
        <table style="width: auto;" border="1">
            <tr>
                <td>本課別尚缺人數</td>
                <td><asp:Label ID="PeopleNeedLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>當周面試人數</td>
                <td><asp:Label ID="InterviewLabel" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td>2年以下新入社人員狀況觀察</td>
                <td>
                    <asp:TextBox ID="NewEmpDetailTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>本周特別關懷弱勢人員</td>
                <td>
                    <asp:TextBox ID="SpecialEmpTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>本周優良業專</td>
                <td>
                    <asp:TextBox ID="WeekGoodEmpTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>人員自評管理</td>
                <td><asp:Label ID="SelfNumber4Label" runat="server" Text=""/></td>
            </tr>
        </table>

        L2Comment:
        <asp:TextBox ID="L2CommentTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        L3Comment:
        <asp:TextBox ID="L3CommentTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />

    </div>
    </form>
</body>
</html>
