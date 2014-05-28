using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Models;

/// <summary>
/// Defense 的摘要描述
/// </summary>
public class Defense
{
	public Defense()
	{
	}

    public static void SqlInjectDefense() 
    {
        HttpContext.Current.Response.Write("此程式已經有防禦SQL攻擊保護功能 <br />");

        if (HttpContext.Current.Session["user"] == null)
        {
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }
    }

    public static void CheckAuth(int pAuth)
    {
        //if (((TB_User)HttpContext.Current.Session["user"]).lv < p_Auth)
        //{
        //    HttpContext.Current.Response.Write("你沒有權限,請回上一頁<br />");
        //    HttpContext.Current.Response.End();
        //}
    }
}