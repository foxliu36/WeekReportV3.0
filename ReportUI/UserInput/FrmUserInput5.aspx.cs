using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_FrmUserInput5 : System.Web.UI.Page
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
        //抓到主要報表
        TB_Report lReMain = Tool.GetNowReport((TB_User)Session[GlobalInfo.Session_User]).FirstOrDefault();

        using (var en = new WeekReportEntities())
        {
            TB_HumanRe HumanRe = en.TB_HumanRe.Where(p => p.HumanResourceReID == lReMain.HumanManageReID).FirstOrDefault();

            if (HumanRe != null)
            {
                txtHumanLess.Text = HumanRe.PeopleNeed.ToString();
                txtInterview.Text = HumanRe.Interview.ToString();
                txtObservation.Text = HumanRe.NewEmpDetail;
                txtWeekPeople.Text = HumanRe.SpecialEmp;
                txtGoodSales.Text = HumanRe.WeekGoodEmp;
                txtSelfNumber.Text = HumanRe.SelfNumber.ToString();
            }
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
            using (var en = new WeekReportEntities())
            {
                TB_Report ReMain = Tool.GetNowReport((TB_User)Session[GlobalInfo.Session_User]).FirstOrDefault();

                TB_HumanRe HumanRe = en.TB_HumanRe.Where(p => p.HumanResourceReID == ReMain.HumanManageReID).FirstOrDefault();

                if (HumanRe == null)
                {
                    en.TB_HumanRe.Add(new TB_HumanRe
                    {
                        HumanResourceReID = ReMain.HumanManageReID,
                        PeopleNeed = Convert.ToInt32(txtHumanLess.Text),
                        Interview = Convert.ToInt32(txtInterview.Text),
                        NewEmpDetail = txtObservation.Text,
                        SpecialEmp = txtWeekPeople.Text,
                        WeekGoodEmp = txtGoodSales.Text,
                        SelfNumber = Convert.ToInt32(txtSelfNumber.Text)
                    });

                    en.SaveChanges();
                }
                else
                {
                    HumanRe.PeopleNeed = Convert.ToInt32(txtHumanLess.Text);
                    HumanRe.Interview = Convert.ToInt32(txtInterview.Text);
                    HumanRe.NewEmpDetail = txtObservation.Text;
                    HumanRe.SpecialEmp = txtWeekPeople.Text;
                    HumanRe.WeekGoodEmp = txtGoodSales.Text;
                    HumanRe.SelfNumber = Convert.ToInt32(txtSelfNumber.Text);

                    en.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            ErrorManage.Show(ex.ToString());
        }
    }
}