using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmShowAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowData();

    }


    public void ShowData()
    {
        
        int reID = (int)Session[GlobalInfo.Session_ShowAllParam];
        using (var en = new WeekReportEntities())
        {
            //抓到目前的報表主檔
            TB_Report MainRe = en.TB_Report.Where(p => p.ReportID == reID).FirstOrDefault();

            //目前報表當月目標
            TB_MonthGoal MonthGoal = en.TB_MonthGoal.Where(p => p.Bureau == MainRe.Bureau
                                                            && p.Class == MainRe.Class
                                                            && p.yyyy == MainRe.TimeStart.Value.Year
                                                            && p.mm == MainRe.TimeStart.Value.Month)
                                                            .FirstOrDefault();

            //訂單報表
            TB_OrderReport OrderRe = en.TB_OrderReport.Where(p => p.OrderReID == MainRe.OrderReID).FirstOrDefault();
            //保險報表
            TB_InsurenceRe InsureRe = en.TB_InsurenceRe.Where(p => p.InsurenceID == MainRe.InsurenceReID).FirstOrDefault();
            //中古車報表
            TB_OldCarSaleRe OldCarRe = en.TB_OldCarSaleRe.Where(p => p.OldCarSaleReID == MainRe.OldCarSaleReID).FirstOrDefault();
            //精裝配件
            TB_CarAssRe CarAssRe = en.TB_CarAssRe.Where(p => p.CarAssReID == MainRe.CarAssReID).FirstOrDefault();
            //人員管理概要
            TB_HumanRe HumanRe = en.TB_HumanRe.Where(p => p.HumanResourceReID == MainRe.HumanManageReID).FirstOrDefault();

            #region ---------------------------訂單部分-----------------------------

            //本月目標
            MonthGoalLabel.Text = MonthGoal.OrderNum.ToString();

            DateTime dt = ((DateTime)MainRe.TimeEnd);

            Decimal rate = (decimal)((DateTime)MainRe.TimeEnd).Day / (decimal)DateTime.DaysInMonth(dt.Year, dt.Month);

            rlgMonthGoal.Pointer.Value = rate * 100;


            //累積至本周受定台數
            OrderedCountLabel.Text = Convert.ToString(OrderRe.OrderedCount);

            rlgOrderedCount.Pointer.Value = (decimal)OrderRe.OrderedCount / (decimal)MonthGoal.OrderNum * 100;

            if (rlgOrderedCount.Pointer.Value < rlgMonthGoal.Pointer.Value)
            {
                rlgOrderedCount.Pointer.Color = System.Drawing.Color.Red;
            }

            //累積至本周販賣台數
            SaleCountLabel.Text = OrderRe.SaleCount.ToString();

            rlgSaleCount.Pointer.Value = (decimal)OrderRe.SaleCount / (decimal)MonthGoal.OrderNum * 100;

            if (rlgSaleCount.Pointer.Value < rlgMonthGoal.Pointer.Value)
            {
                rlgSaleCount.Pointer.Color = System.Drawing.Color.Red;
            }

            //目前掌握台數
            OnControlLabel.Text = OrderRe.OnControl.ToString();

            rlgOnControl.Pointer.Value = (decimal)OrderRe.OnControl / (decimal)MonthGoal.OrderNum * 100;

            if (rlgOnControl.Pointer.Value < rlgMonthGoal.Pointer.Value)
            {
                rlgOnControl.Pointer.Color = System.Drawing.Color.Red;
            }

            //至月底預估台數
            ExpectationsLabel.Text = OrderRe.Expectations.ToString();

            rlgExpectations.Pointer.Value = (decimal)OrderRe.Expectations / (decimal)MonthGoal.OrderNum * 100;

            if (rlgExpectations.Pointer.Value < rlgMonthGoal.Pointer.Value)
            {
                rlgExpectations.Pointer.Color = System.Drawing.Color.Red;
            }

            //各業專本周受訂狀況
            OrderDetailLabel.Text = OrderRe.OrderDetail;
            //未開市人員
            UnorderDetailLabel.Text = OrderRe.UnorderDetail;
            //針對本周該課(新訂弱勢車種)說明
            WeekCarLabel.Text = OrderRe.WeekCar;
            //其他問題點改善說明
            OthersLabel.Text = OrderRe.Others;
            //販賣管理自評
            SelfNumberLabel.Text = OrderRe.SelfNumber.ToString();

            #endregion

            #region ---------------------------保險部分-----------------------------

            //本月目標件數
            InGoalLabel.Text = MonthGoal.InGoalNum.ToString();
            //累積至本周任意件數
            AnyCaseToNowLabel.Text = InsureRe.AnyCaseToNow.ToString();
            rlgAnyCaseToNow.Pointer.Value = (decimal)InsureRe.AnyCaseToNow / (decimal)MonthGoal.InGoalNum * 100;

            //累積至本周車體(甲乙丙)件數
            CarBdCaseToNowLabel.Text = InsureRe.CarBdCaseToNow.ToString();
            rlgCarBdCaseToNow.Pointer.Value = (decimal)InsureRe.CarBdCaseToNow / (decimal)MonthGoal.InGoalNum * 100;

            //本月目標保費
            lbInsurenceBill.Text = (MonthGoal.InGoalNum * 0.76 * 11000).ToString();

            //累積至本周任意總保費
            MoneyToNowLabel.Text = InsureRe.MoneyToNow.ToString();
            rlgMoneyToNow.Pointer.Value = (decimal)InsureRe.MoneyToNow / (decimal)(MonthGoal.InGoalNum * 0.76 * 11000) * 100;

            //本月預估保費達成率
            MonTotalExRLabel.Text = InsureRe.MonTotalExR.ToString() + "%";


            //任意目標件數
            InSecConLabel.Text = MonthGoal.InAny.ToString();

            //累積至本周任意件數
            AnyCaseSecLabel.Text = MonthGoal.InAny.ToString();
            rlgAnyCaseSec.Pointer.Value = (decimal)MonthGoal.InAny / (decimal)MonthGoal.InAny * 100;

            //本月預估達成率
            MonAnyExRLabel.Text = InsureRe.MonAnyExR.ToString() + "%";

            //車體目標件數
            CarBdSecLabel.Text = InsureRe.CarBdSec.ToString();

            //累積至本周車體(甲乙)件數
            WeekTotalBdLabel.Text = InsureRe.WeekTotalBd.ToString();
            rlgWeekTotalBd.Pointer.Value = (decimal)InsureRe.WeekTotalBd / (decimal)MonthGoal.InBd * 100;

            //本月預估達成率
            MonBdExRLabel.Text = InsureRe.MonBdExR.ToString() + "%";

            //弱勢險種改善計畫
            txtRefinProject.Text = InsureRe.RefinProject;

            //本月目標
            lbInstallmentsMonthGoal.Text = ((decimal)(MonthGoal.OrderNum * 0.45)).ToString("0");

            //累積至本周販賣台數
            lbSaleCount.Text = OrderRe.SaleCount.ToString();

            //累積至本周進件台數
            TotalWeekImportLabel.Text = InsureRe.TotalWeekImport.ToString();
            rlgInsurenceInstallments.Pointer.Value = (decimal)InsureRe.TotalWeekImport / (decimal)OrderRe.SaleCount * 100;

            //保險/分期管理自評
            SelfNumber1Label.Text = InsureRe.SelfNumber.ToString();

            #endregion

            #region ---------------------------中古車部分---------------------------
            //換購台數
            ChangeBuyLabel.Text = OldCarRe.ChangeBuy.ToString();

            //本周查估台數
            BuyExLabel.Text = OldCarRe.BuyEx.ToString();

            //成交台數
            DealNumLabel.Text = OldCarRe.DealNum.ToString();

            //戰敗車原因及流向說明
            FailDealDetailTextBox.Text = OldCarRe.FailDealDetail.ToString();

            //中古車管理自評
            SelfNumber2Label.Text = OldCarRe.SelfNumber.ToString();
            #endregion

            #region --------------------------精裝配件------------------------------

            //精裝招攬累計件數
            RefinementNumLabel.Text = CarAssRe.RefinementNum.ToString();

            //影音招攬累計件數
            VAudioNumLabel.Text = CarAssRe.VAudioNum.ToString();

            //精裝推販問題原因說明/改善計畫
            RefineDetailTextBox.Text = CarAssRe.RefineDetail.ToString();

            //車美仕配件問題件數
            AssProNumLabel.Text = CarAssRe.AssProNum.ToString();

            //PDS整備問題件數
            PDSProNumLabel.Text = CarAssRe.PDSProNum.ToString();

            //其他問題點回饋
            OthersProDetailTextBox.Text = CarAssRe.OthersProDetail.ToString();

            //精裝管理自評
            SelfNumber3Label.Text = CarAssRe.SelfNumber.ToString();

            #endregion

            #region--------------------------人員管理------------------------------

            //本課別尚缺人數
            PeopleNeedLabel.Text = HumanRe.PeopleNeed.ToString();

            //當周面試人數
            InterviewLabel.Text = HumanRe.Interview.ToString();

            //2年以下新入社人員狀況觀察
            NewEmpDetailTextBox.Text = HumanRe.NewEmpDetail;

            //本周特別關懷弱勢人員
            SpecialEmpTextBox.Text = HumanRe.SpecialEmp;

            //本周優良業專
            WeekGoodEmpTextBox.Text = HumanRe.WeekGoodEmp;

            //人員自評管理
            SelfNumber4Label.Text = HumanRe.SelfNumber.ToString();

            #endregion
        }
    }
}