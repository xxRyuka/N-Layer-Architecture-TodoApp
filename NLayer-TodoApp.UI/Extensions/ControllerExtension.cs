using Microsoft.AspNetCore.Mvc;
using NLayer_TodoApp.Common.ResponseObjects;

namespace NLayer_TodoApp.UI.Extensions;

public static class ControllerExtension
{
    public static IActionResult ResponsedRedirectToAction<T>(this Controller controller, string actionName,
        IResponse<T> response)
    {
        if (response.ResponseType == ResponseType.NotFound)
        {
            return controller.NotFound();
        }

        if (response.ResponseType == ResponseType.ValidateError)
        {
            foreach (var error in response.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return controller.View(response.Data);
        }


        return controller.RedirectToAction(actionName);
    }

    public static IActionResult ResponsedView<T>(this Controller controller, string actionName, IResponse<T> response)
    {
        if (response.ResponseType == ResponseType.NotFound)
        {
            return controller.NotFound();
        }
        if (response.ResponseType == ResponseType.ValidateError)
        {
            return controller.View(response.Data);
        }
        return controller.View(response.Data);
    }
}