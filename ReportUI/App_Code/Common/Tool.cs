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

    /// <summary>
    /// 抓出某課所有的報表
    /// </summary>
    /// <param name="p_User"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 取出某課當周的主報表
    /// </summary>
    /// <param name="p_User"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 取得本周起始日
    /// </summary>
    /// <returns></returns>
    public static DateTime GetNowWeekStartTime() 
    {

        DateTime ldtstart = (DateTime)HttpContext.Current.Session[GlobalInfo.Session_StartTime];

        if (ldtstart == null)
        {
            Tool.SetTime();
            ldtstart = (DateTime)HttpContext.Current.Session[GlobalInfo.Session_StartTime];
            return ldtstart;
        }
        else
        {
            return ldtstart;
        }
    }

    /// <summary>
    /// 取得本周結束日
    /// </summary>
    /// <returns></returns>
    public static DateTime GetNowWeekEndTime()
    {

        DateTime ldtend = (DateTime)HttpContext.Current.Session[GlobalInfo.Session_EndTime];

        if (ldtend == null)
        {
            Tool.SetTime();
            ldtend = (DateTime)HttpContext.Current.Session[GlobalInfo.Session_EndTime];
            return ldtend;
        }
        else
        {
            return ldtend;
        }
    }

    /// <summary>
    /// 取得本月所有時間分隔點
    /// </summary>
    /// <returns></returns>
    public static List<DateTime> GetTimePoint()
    {

        List<DateTime> lLdtpoints = HttpContext.Current.Session[GlobalInfo.Session_TimePoint] as List<DateTime>;

        if (lLdtpoints == null)
        {
            Tool.SetTime();
            lLdtpoints = HttpContext.Current.Session[GlobalInfo.Session_TimePoint] as List<DateTime>;
            return lLdtpoints;
        }
        else
        {
            return lLdtpoints;
        }
    }

    /// <summary>
    /// 設定Session時間資料
    /// </summary>
    public static void SetTime() 
    {
        DateTime ldtnow = DateTime.Now;

        //當月第一天
        DateTime lmonthfirst = ldtnow.AddDays(-ldtnow.Day + 1);

        List<DateTime> lLtimepoint = new List<DateTime>();
        lLtimepoint.Add(lmonthfirst);

        while (lmonthfirst.Month < ldtnow.Month + 1)
        {
            DateTime start = lmonthfirst;

            DateTime end = lmonthfirst.AddDays(DayOfWeek.Saturday - lmonthfirst.DayOfWeek);

            if (end.Month > ldtnow.Month)
            {
                end = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.AddMonths(1).Day);
            }
            lmonthfirst = end.AddDays(1);

            //rblweek.Items.Add(start.ToString("MM-dd") + " ~ " + end.ToString("MM-dd"));
            lLtimepoint.Add(end);

            if (ldtnow > start && ldtnow < end.AddSeconds(1))
            {
                //把現在的時間帶入
                HttpContext.Current.Session[GlobalInfo.Session_StartTime] = start;
                HttpContext.Current.Session[GlobalInfo.Session_EndTime] = end;
            }
        }
        HttpContext.Current.Session[GlobalInfo.Session_TimePoint] = lLtimepoint;
    }
}