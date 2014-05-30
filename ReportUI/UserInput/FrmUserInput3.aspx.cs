using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_FrmUserInput3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            var OldCarReport = en.TB_OldCarSaleRe.Where(p => p.OldCarSaleReID == mainReport.OldCarSaleReID).FirstOrDefault();

            if (OldCarReport != null)
            {
                txtChangeBuy.Text = OldCarReport.ChangeBuy.ToString();
                txtBuyEx.Text = OldCarReport.BuyEx.ToString();
                txtDealNum.Text = OldCarReport.DealNum.ToString();
                txtFailDealDetail.Text = OldCarReport.FailDealDetail;
                txtSelfNumber.Text = OldCarReport.SelfNumber.ToString();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var lR = GetMainReport().FirstOrDefault();

        using (var en = new WeekReportEntities())
        {
            var OldCarReport = en.TB_OldCarSaleRe.Where(p => p.OldCarSaleReID == lR.OldCarSaleReID).FirstOrDefault();

            if (OldCarReport != null)
            {
                OldCarReport.ChangeBuy = int.Parse(txtChangeBuy.Text);
                OldCarReport.BuyEx = int.Parse(txtBuyEx.Text);
                OldCarReport.DealNum = int.Parse(txtDealNum.Text);
                OldCarReport.FailDealDetail = txtFailDealDetail.Text;
                OldCarReport.SelfNumber = int.Parse(txtSelfNumber.Text);

                en.SaveChanges();
            }
            else
            {
                en.TB_OldCarSaleRe.Add(new TB_OldCarSaleRe
                {
                    OldCarSaleReID = lR.OldCarSaleReID,
                    ChangeBuy = int.Parse(txtChangeBuy.Text),
                    BuyEx = int.Parse(txtBuyEx.Text),
                    DealNum = int.Parse(txtDealNum.Text),
                    FailDealDetail = txtFailDealDetail.Text,
                    SelfNumber = int.Parse(txtSelfNumber.Text)
                });

                en.SaveChanges();
            }
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./FrmUserInputBrige.aspx");
    }
}