using EF5Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (var en = new WeekReportEntities())
        {

            //var dd = en.Table_2.ToList();


            TB_User user = (from q in en.TB_User
                            where q.Acc == txtAcc.Text && q.pass == txtCode.Text
                            select q).FirstOrDefault();

            if (user != null)
            {
                Session[GlobalInfo.Session_User] = user;
                if (user.lv == 3)
                {
                    Response.Redirect("~/L2/FrmL2Bridge.aspx");
                }
                if (user.lv == 2)
                {
                    Response.Redirect("~/L1/L1Bridge.aspx");
                }
                if (user.lv == 1)
                {
                    Response.Redirect("~/UserInput/FrmUserInputBrige.aspx");
                }
            }
            else
            {
                Response.Write("沒有此帳號或是密碼錯誤");
            }
        }
    }
}