﻿using System.Web;
using System.Web.Mvc;

namespace Serie_1___Aufgabe_1___Controller
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
