using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ShowError 的摘要描述
/// </summary>
public class ErrorManage
{
    public ErrorManage()
	{
		
	}

    public static void Show(string p_Msg) 
    {
        HttpContext.Current.Response.Write("<h3 style='color:red'>" + p_Msg + "</h2>");
    }
}