using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace DoktormandenDk.Controllers.ActionFilters
{
    public class TestValidEConsultationUser : ActionFilterAttribute
    {

        // Simple check to see if the "logged in" user is of valid type (Currently either Patient or GP)
        // OnActionExecuting is called on all Controller methods with the TestValidEConsultationUser  attribute
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var controller = context.Controller;
         
            if (((EConsultationsController)controller).LoggedInUser == null)
            {
                context.Result = new RedirectToActionResult("Forbidden", "EConsultations", null);
            }

        }

    }
}
