using System.Web;
using System.Web.Mvc;
using MVCActionFilter.Filtros;

namespace MVCActionFilter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MensajesFilterAttribute());
        }
    }
}
