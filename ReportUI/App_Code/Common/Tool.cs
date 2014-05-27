using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF5Model;

/// <summary>
/// Tool 的摘要描述
/// </summary>
public class Tool
{
	public Tool()
	{
	}

    //抓出某課所有的報表
    public static List<TB_Report> ShowOldReport(TB_User p_User)
    {
        using (var en = new WeekReportEntities())
        {
            //end必須從新設定
            List<TB_Report> data = (from q in en.TB_Report
                                    where q.Bureau == p_User.Bureau
                                    && q.Class == p_User.Class
                                    select q).ToList();

            return data;
        }
    }

    //取出某課當周的主報表
    public static List<TB_Report> GetNowReport(TB_User p_User) 
    {
        using (var en = new WeekReportEntities())
        {
            List<TB_Report> data = (from q in en.TB_Report
                                    where q.Bureau == p_User.Bureau
                                    && q.Class == p_User.Class
                                    && q.TimeStart <= DateTime.Now
                                    && q.TimeEnd >= DateTime.Now
                                    select q).ToList();

            return data;
        }
    }

    /// <summary>
    /// 抓出本周所有課報表
    /// </summary>
    /// <param name="p_User"></param>
    /// <returns></returns>
    public static List<TB_Report> GeAllClasstMainReport(TB_User p_User)
    {
        using (var en = new WeekReportEntities())
        {
            TB_User user = p_User;

            //end必須從新設定
            List<TB_Report> data = (from q in en.TB_Report
                                    where q.Bureau == user.Bureau
                                    && q.TimeStart <= DateTime.Now
                                    && q.TimeEnd >= DateTime.Now
                                    select q).ToList();

            return data;
        }
    }
}