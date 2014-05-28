using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF5Model;

public partial class UserInput_UserInputBrige : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetDateDisplay();
        }
        if (CheckExist())
        {
            btnStart.Enabled = false;

            btnCa.Enabled = true;
            btnHu.Enabled = true;
            btnIn.Enabled = true;
            btnOl.Enabled = true;
            btnOr.Enabled = true;
        }

        TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);
        gvShowAll.DataSource = Tool.ShowOldReport(user);
        gvShowAll.DataBind();
    }

    //建立一個新的周報表
    protected void btnStart_Click(object sender, EventArgs e)
    {
        try
        {
            TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);

            using (var en = new WeekReportEntities())
            {
                //新增報表
                en.TB_Report.Add(new TB_Report {
                    TimeStart = GetTime0((DateTime)Session[GlobalInfo.Session_StartTime]),
                    TimeEnd = GetTime1((DateTime)Session[GlobalInfo.Session_EndTime]),
                    Bureau = user.Bureau,
                    Class = user.Class,
                    Writer = user.name,
                    //給編號 所別+課別+起始日
                    OrderReID = user.Bureau + user.Class + "Or" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", ""),
                    InsurenceReID = user.Bureau + user.Class + "In" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", ""),
                    OldCarSaleReID = user.Bureau + user.Class + "Ol" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", ""),
                    CarAssReID = user.Bureau + user.Class + "Ca" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", ""),
                    HumanManageReID = user.Bureau + user.Class + "Hu" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "")
                
                });
                en.SaveChanges();
            }
            if (CheckExist())
            {
                btnStart.Enabled = false;
                btnCa.Enabled = true;
                btnHu.Enabled = true;
                btnIn.Enabled = true;
                btnOl.Enabled = true;
                btnOr.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ErrorManage.Show(ex.ToString());
        }
    }

    //顯示當日是哪個週期 並回傳當周第一天
    public void GetDateDisplay() 
    {
    }

    protected void btnOr_Click(object sender, EventArgs e)
    {
        Response.Redirect("./UserInput1.aspx");
    }

    protected void btnIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("./UserInput2.aspx");
    }

    protected void btnOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("./UserInput3.aspx");
    }

    protected void btnCa_Click(object sender, EventArgs e)
    {
        Response.Redirect("./UserInput4.aspx");
    }

    protected void btnHu_Click(object sender, EventArgs e)
    {
        Response.Redirect("./UserInput5.aspx");
    }

    public DateTime GetTime0(DateTime p_dt)
    {
        return DateTime.Parse(p_dt.ToString("yyyy-MM-dd") + " 00:00:00");
    }

    public DateTime GetTime1(DateTime p_dt)
    {
        return DateTime.Parse(p_dt.ToString("yyyy-MM-dd") + " 23:59:59");
    }

    //true 已經有資料
    public bool CheckExist() 
    {
        TB_User user = ((TB_User)Session[GlobalInfo.Session_User]);

        using (var en = new WeekReportEntities())
        {

            //end必須從新設定
            List<TB_Report> data = ( from q in en.TB_Report
                                     where q.Bureau == user.Bureau 
                                     && q.Class == user.Class
                                     && q.TimeStart <= DateTime.Now
                                     && q.TimeEnd >= DateTime.Now
                                     select q).ToList();
            
            if (data.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    protected void gvShowAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewData")
        {
            //抓出Report Key值
            int index = (int)gvShowAll.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;

            Response.Redirect("~/ShowAll.aspx?ReportId=" + index);
        }
    }
}