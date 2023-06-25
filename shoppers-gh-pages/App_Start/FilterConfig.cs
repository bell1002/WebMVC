using System.Web;
using System.Web.Mvc;

namespace shoppers_gh_pages
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
