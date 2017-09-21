using System.Web;
using System.Web.Mvc;

namespace Serie_2___Aufgabe_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
