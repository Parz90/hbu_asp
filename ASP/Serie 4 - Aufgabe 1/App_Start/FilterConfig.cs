﻿using System.Web;
using System.Web.Mvc;

namespace Serie_4___Aufgabe_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}