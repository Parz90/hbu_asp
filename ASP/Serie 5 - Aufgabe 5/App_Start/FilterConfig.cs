using System.Web;
using System.Web.Mvc;

namespace Serie_5___Aufgabe_5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
