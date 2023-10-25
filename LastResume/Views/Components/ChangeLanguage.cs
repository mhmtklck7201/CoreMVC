using Microsoft.AspNetCore.Mvc;

namespace LastResume.Views.Components
{
    public class ChangeLanguage : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string dil = string.Empty;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name.ToLower();
            if (currentCulture.Contains("tr"))
            {
                dil = "Türkçe";

            }
            else
                dil = "english";
             ViewData["Dil"] = dil;
          
            return View("Default" );
        }
    }
}
