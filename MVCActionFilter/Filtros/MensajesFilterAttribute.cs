using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Windows.Input;
using System.Web.Routing;

namespace MVCActionFilter.Filtros
{
    public class MensajesFilterAttribute:ActionFilterAttribute
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string tmpMsg = string.Empty;
            base.OnActionExecuting(filterContext);
            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

            IDictionary<string, object> parametros = filterContext.ActionParameters;
            foreach (string key in parametros.Keys)
            {
                tmpMsg += "[" + key + ": " + parametros[key].ToString() + "] ";
            }

           

            log.Debug("ActionParameters: " + tmpMsg);
            log.Debug(" --------------------------------------- ");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string tmpMsg = string.Empty;
            base.OnActionExecuted(filterContext);

            // Almacenamos el nombre del método
            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

            // Recogemos el resultado
            ActionResult result = filterContext.Result;
            log.Debug("ActionResult: " + result.ToString());

            // Comprobamos si se ha producido alguna excepción durante la ejecución.
            // En caso afirmativo, la almacenamos
            if (filterContext.Exception != null)
                log.Error("Error durante la ejecución de la acción", filterContext.Exception);

            log.Debug(" --------------------------------------- ");

        }

        // Método ejecutado justo antes de la ejecución del resultado
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

            // Recogemos el resultado
            ActionResult result = filterContext.Result;
            log.Debug("ActionResult: " + result.ToString());

            log.Debug(" --------------------------------------- ");
        }

        // Método ejecutado justo después de la ejecución del resultado
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

            // Recogemos el resultado
            ActionResult result = filterContext.Result;
            log.Debug("ActionResult: " + result.ToString());

            log.Debug(" --------------------------------------- ");
        }

    }
}
 