using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserInput_MPUserInput : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetDateDisplay();
        }
    }


    //顯示當日是哪個週期 並回傳當周第一天
    public void GetDateDisplay()
    {
        DateTime[] lAdt = Tool.GetTimePoint().ToArray();

        DateTime ldt = DateTime.Now;
        int lIndex = 0;

        for (int i = 0; i < lAdt.Count() - 1; i++)
        {
            if (ldt > lAdt[i])
            {
                lIndex = i;
            }
            if (i != 0)
            {
                rblweek.Items.Add(lAdt[i].AddDays(1).ToString("MM-dd") + " ~ " + lAdt[i + 1].ToString("MM-dd"));
            }
            else
            {
                rblweek.Items.Add(lAdt[i].ToString("MM-dd") + " ~ " + lAdt[i + 1].ToString("MM-dd"));
            }

        }

        rblweek.Items[lIndex].Selected = true;
    }
}
