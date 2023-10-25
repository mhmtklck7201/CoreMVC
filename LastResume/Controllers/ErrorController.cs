using Microsoft.AspNetCore.Mvc;

namespace LastResume.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageError()
        {
            
            return View();
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
        
            return View("PageError");
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
           
            return View("PageError");
        }
        public ActionResult Page500()
        {
            Response.StatusCode = 500;
          
            return View("PageError");
        }
    }
}
