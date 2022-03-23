using System.Web;
using System.Web.Mvc;

namespace n01519708_assignment3_w2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
