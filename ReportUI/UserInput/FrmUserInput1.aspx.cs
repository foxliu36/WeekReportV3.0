using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_FrmUserInput1 : System.Web.UI.Page
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

        List<TB_Report> lRe = GetMainReport();

        DateTime dt = DateTime.Now;

        string OrIDFromMainRe = lRe.FirstOrDefault().OrderReID;

        using (var en = new WeekReportEntities())
        {
            TB_OrderReport Order = en.TB_OrderReport.Where(p => p.OrderReID == OrIDFromMainRe).FirstOrDefault();

            TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);

            //月目標
            int goal = (int)en.TB_MonthGoal.Where(p => p.Bureau == user.Bureau
                                                && p.Class == user.Class
                                                && p.yyyy == DateTime.Now.Year
                                                && p.mm == DateTime.Now.Month).FirstOrDefault().OrderNum;
            lbMonthGoal.Text = goal.ToString();

            //有資料時候輸出網頁
            if (Order != null)
            {
                txtOrderCount.Text = Order.OrderedCount.ToString();
                txtSaleCount.Text = Order.SaleCount.ToString();
                txtOnControl.Text = Order.OnControl.ToString();
                txtExpectation.Text = Order.Expectations.ToString();

                lbIdeaRate.Text = (((goal * 100 / DateTime.DaysInMonth(dt.Year, dt.Month)) * dt.Day) / goal).ToString() + "%";
                lbOrderRate.Text = (Order.OrderedCount * 100 / goal).ToString() + "%";
                lbSaleRate.Text = (Order.SaleCount * 100 / goal).ToString() + "%";
                lbControlRate.Text = (Order.OnControl * 100 / goal).ToString() + "%";
                lbExpectRate.Text = (Order.Expectations * 100 / goal).ToString() + "%";

                txtWeekCar.Text = Order.WeekCar;
                txtOrderDetail.Text = Order.OrderDetail;
                txtUnOrderDetail.Text = Order.UnorderDetail;
                txtOthers.Text = Order.Others;
                txtSelfnumber.Text = Order.SelfNumber.ToString();
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

    //儲存表單
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            List<TB_Report> lRe = GetMainReport();
            string OrIDFromMainRe = lRe.FirstOrDefault().OrderReID;

            using (var en = new WeekReportEntities())
            {

                TB_OrderReport Order = en.TB_OrderReport.Where(p => p.OrderReID == OrIDFromMainRe).FirstOrDefault();


                if (Order == null)
                {
                    en.TB_OrderReport.Add(new TB_OrderReport
                    {
                        OrderReID = OrIDFromMainRe,
                        OrderedCount = int.Parse(txtOrderCount.Text),
                        SaleCount = int.Parse(txtSaleCount.Text),
                        OnControl = int.Parse(txtOnControl.Text),
                        Expectations = int.Parse(txtExpectation.Text),
                        OrderDetail = txtOrderDetail.Text,
                        WeekCar = txtWeekCar.Text,
                        UnorderDetail = txtUnOrderDetail.Text,
                        Others = txtOthers.Text,
                        SelfNumber = int.Parse(txtSelfnumber.Text)
                    });

                    en.SaveChanges();
                }
                else
                {
                    Order.OrderedCount = int.Parse(txtOrderCount.Text);
                    Order.SaleCount = int.Parse(txtSaleCount.Text);
                    Order.OnControl = int.Parse(txtOnControl.Text);
                    Order.Expectations = int.Parse(txtExpectation.Text);
                    Order.OrderDetail = txtOrderDetail.Text;
                    Order.WeekCar = txtWeekCar.Text;
                    Order.UnorderDetail = txtUnOrderDetail.Text;
                    Order.Others = txtOthers.Text;
                    Order.SelfNumber = int.Parse(txtSelfnumber.Text);
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./FrmUserInputBrige.aspx");
    }
}