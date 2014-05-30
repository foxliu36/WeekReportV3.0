using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_FrmUserInput4 : System.Web.UI.Page
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

        //抓到主要報表
        TB_Report lReMain = Tool.GetNowReport((TB_User)Session[GlobalInfo.Session_User]).FirstOrDefault();

        DateTime dt = DateTime.Now;

        using (var en = new WeekReportEntities())
        {
            //抓到訂單報表
            TB_OrderReport Order = en.TB_OrderReport
                                        .Where(p => p.OrderReID == lReMain.OrderReID)
                                        .FirstOrDefault();

            //抓到對應的配件報表
            TB_CarAssRe CarAss = en.TB_CarAssRe.Where(p => p.CarAssReID == lReMain.CarAssReID).FirstOrDefault();

            if (CarAss != null)
            {
                txtRefinementNum.Text = CarAss.RefinementNum.ToString();
                txtVAudioNum.Text = CarAss.VAudioNum.ToString();
                lbRefinePush.Text = ((decimal)CarAss.RefinementNum / (decimal)(Order.OrderedCount * 0.8) * 100).ToString("00.00");
                lbVAudioPush.Text = ((decimal)CarAss.VAudioNum / (decimal)(Order.OrderedCount * 0.5) * 100).ToString("00.00");

                txtRefineDetail.Text = CarAss.RefineDetail;
                txtAssProNum.Text = CarAss.AssProNum.ToString();
                txtPDSProNum.Text = CarAss.PDSProNum.ToString();
                txtOtherProDetail.Text = CarAss.OthersProDetail;

                txtSelfNum.Text = CarAss.SelfNumber.ToString();
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("./FrmUserInputBrige.aspx");
        }
        catch (Exception ex)
        {
            ErrorManage.Show(ex.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            using (var en = new WeekReportEntities())
            {

                TB_Report ReMain = Tool.GetNowReport((TB_User)Session[GlobalInfo.Session_User]).FirstOrDefault();

                TB_CarAssRe CarAssRe = en.TB_CarAssRe.Where(p => p.CarAssReID == ReMain.CarAssReID).FirstOrDefault();

                if (CarAssRe != null)
                {
                    CarAssRe.RefinementNum = Convert.ToInt32(txtRefinementNum.Text);
                    CarAssRe.VAudioNum = Convert.ToInt32(txtVAudioNum.Text);
                    CarAssRe.RefineDetail = txtRefineDetail.Text;
                    CarAssRe.AssProNum = Convert.ToInt32(txtAssProNum.Text);
                    CarAssRe.PDSProNum = Convert.ToInt32(txtPDSProNum.Text);
                    CarAssRe.OthersProDetail = txtOtherProDetail.Text;
                    CarAssRe.SelfNumber = Convert.ToInt32(txtSelfNum.Text);
                    en.SaveChanges();
                }
                else
                {
                    en.TB_CarAssRe.Add(new TB_CarAssRe
                    {
                        CarAssReID = ReMain.CarAssReID,
                        RefinementNum = Convert.ToInt32(txtRefinementNum.Text),
                        VAudioNum = Convert.ToInt32(txtVAudioNum.Text),

                        RefineDetail = txtRefineDetail.Text,
                        AssProNum = Convert.ToInt32(txtAssProNum.Text),
                        PDSProNum = Convert.ToInt32(txtPDSProNum.Text),
                        OthersProDetail = txtOtherProDetail.Text,
                        SelfNumber = Convert.ToInt32(txtSelfNum.Text)

                    });
                    en.SaveChanges();
                }
                LoadReportData();
            }
        }
        catch (Exception ex)
        {
            ErrorManage.Show(ex.ToString());
        }
    }

    
}