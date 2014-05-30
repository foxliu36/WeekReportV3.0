using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_FrmUserInput2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Defense.SqlInjectDefense();
        if (!Page.IsPostBack)
        {
            LoadReportData();
            lbSo.Text = ((TB_User)Session[GlobalInfo.Session_User]).Bureau.ToString();
            lbClass.Text = ((TB_User)Session[GlobalInfo.Session_User]).Class.ToString();
        }
    }

    public void LoadReportData()
    {
        List<TB_Report> lR = GetMainReport();

        var mainReport = lR.FirstOrDefault();

        TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);

        using (var en = new WeekReportEntities())
        {
            //訂單資料
            var OrderReport = en.TB_OrderReport.Where(p => p.OrderReID == mainReport.OrderReID).FirstOrDefault();

            //保險資料
            TB_InsurenceRe InReport = (from q in en.TB_InsurenceRe
                                       where q.InsurenceID == mainReport.InsurenceReID
                                       select q).FirstOrDefault();

            //抓其他資料表的資料
            var Goal = en.TB_MonthGoal.Where(p => p.Bureau == user.Bureau
                                                && p.Class == user.Class
                                                && p.yyyy == DateTime.Now.Year
                                                && p.mm == DateTime.Now.Month).FirstOrDefault();

            int InGoalNum = (int)Goal.InGoalNum;
            int InAny = (int)Goal.InAny;
            int InBd = (int)Goal.InBd;

            lbGoalNumber.Text = Goal.InGoalNum.ToString();
            lbInSecCon.Text = Goal.InAny.ToString();
            lbCarBdSec.Text = Goal.InBd.ToString();
            lbGoalMoney.Text = (InGoalNum * 0.76 * 11000).ToString();

            if (InReport != null)
            {
                int AnyCaseToNow = (int)InReport.AnyCaseToNow;
                int CarBdCaseToNow = (int)InReport.CarBdCaseToNow;
                int MoneyToNow = (int)InReport.MoneyToNow;
                int AnyCaseSec = (int)InReport.AnyCaseSec;
                int WeekTotalBd = (int)InReport.WeekTotalBd;

                txtAnyCaseToNow.Text = InReport.AnyCaseToNow.ToString();
                txtCarBdCaseToNow.Text = InReport.CarBdCaseToNow.ToString();
                txtMoneyToNow.Text = InReport.MoneyToNow.ToString();
                txtAnyCaseSec.Text = InReport.AnyCaseSec.ToString();
                txtWeekTotalBd.Text = InReport.WeekTotalBd.ToString();

                lbContinuePushR.Text = (AnyCaseToNow * 100 / InGoalNum).ToString() + "%";
                lbBdContinuePushR.Text = (CarBdCaseToNow * 100 / InGoalNum).ToString() + "%";
                lbMoneyPushR.Text = (MoneyToNow * 100 / (InGoalNum * 0.76 * 11000)).ToString("0.00") + "%";
                lbAnySecPushR.Text = (AnyCaseSec * 100 / InAny).ToString() + "%";
                lbAnyBdR.Text = (WeekTotalBd * 100 / InBd).ToString() + "%";

                txtMonTotalExR.Text = InReport.MonTotalExR.ToString();
                txtMonAnyExR.Text = InReport.MonAnyExR.ToString();
                txtMonBdExR.Text = InReport.MonBdExR.ToString();

                lbGoalMonth.Text = OrderReport.OrderedCount.ToString();
                lbOrderCount.Text = OrderReport.SaleCount.ToString();
                txtImportC.Text = InReport.TotalWeekImport.ToString();
                lbInstallments.Text = ((int)InReport.TotalWeekImport * 100 / (int)OrderReport.SaleCount).ToString();

                txtRefineProject.Text = InReport.RefinProject;
                txtSelfNumber.Text = InReport.SelfNumber.ToString();
            }
        }

    }

    //抓出報表主檔
    public List<TB_Report> GetMainReport()
    {
        using (var en = new WeekReportEntities())
        {
            TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);

            //end必須從新設定
            List<TB_Report> data = (from q in en.TB_Report
                                    where q.Bureau == user.Bureau
                                    && q.Class == user.Class
                                    && q.TimeStart <= DateTime.Now
                                    && q.TimeEnd >= DateTime.Now
                                    select q).ToList();

            //偵錯
            if (data.Count() > 1)
            {
                ErrorManage.Show("比數大於二有問題");
            }

            return data;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./FrmUserInputBrige.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var lR = GetMainReport().FirstOrDefault();
            using (var en = new WeekReportEntities())
            {
                TB_InsurenceRe InReport = en.TB_InsurenceRe.Where(p => p.InsurenceID == lR.InsurenceReID).FirstOrDefault();

                if (InReport != null)
                {
                    InReport.AnyCaseToNow = int.Parse(txtAnyCaseToNow.Text);
                    InReport.CarBdCaseToNow = int.Parse(txtCarBdCaseToNow.Text);
                    InReport.MoneyToNow = int.Parse(txtMoneyToNow.Text);
                    InReport.AnyCaseSec = int.Parse(txtAnyCaseSec.Text);
                    InReport.WeekTotalBd = int.Parse(txtWeekTotalBd.Text);

                    InReport.MonTotalExR = int.Parse(txtMonTotalExR.Text);
                    InReport.MonAnyExR = int.Parse(txtMonAnyExR.Text);
                    InReport.MonBdExR = int.Parse(txtMonBdExR.Text);

                    InReport.TotalWeekImport = int.Parse(txtImportC.Text);

                    InReport.RefinProject = txtRefineProject.Text;

                    InReport.SelfNumber = int.Parse(txtSelfNumber.Text);

                    en.SaveChanges();
                }
                else
                {
                    en.TB_InsurenceRe.Add(new TB_InsurenceRe
                    {
                        InsurenceID = lR.InsurenceReID,

                        AnyCaseToNow = int.Parse(txtAnyCaseToNow.Text),
                        CarBdCaseToNow = int.Parse(txtCarBdCaseToNow.Text),
                        MoneyToNow = int.Parse(txtMoneyToNow.Text),
                        AnyCaseSec = int.Parse(txtAnyCaseSec.Text),
                        WeekTotalBd = int.Parse(txtWeekTotalBd.Text),

                        MonTotalExR = int.Parse(txtMonTotalExR.Text),
                        MonAnyExR = int.Parse(txtMonAnyExR.Text),
                        MonBdExR = int.Parse(txtMonBdExR.Text),

                        TotalWeekImport = int.Parse(txtImportC.Text),

                        RefinProject = txtRefineProject.Text,

                        SelfNumber = int.Parse(txtSelfNumber.Text)
                    });

                    en.SaveChanges();
                }

                this.LoadReportData();
            }

        }
        catch (Exception ex)
        {
            ErrorManage.Show(ex.ToString());
        }
    }
}