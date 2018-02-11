using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Infrastructure
{
    public class AddressBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as Address ?? new Address();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            model.Line1 = GetValue(bindingContext, "Line1");
            model.Line2 = GetValue(bindingContext, "Line2");
            model.PostalCode = GetValue(bindingContext, "PostalCode");
            model.Summary = StringValidator(model.Line1, model.City, model.PostalCode)
                ? $"{model.PostalCode} {model.City}, {model.Line1}"
                : "No Personal Address";

            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            var result = context.ValueProvider.GetValue("Address." + name);
            if (!ReferenceEquals(result, null))
            {
                if (string.IsNullOrWhiteSpace(result.AttemptedValue)
                    || result.AttemptedValue.ToLower().Contains("po box"))
                    return "<not-defined>";
                if ((name == "PostalCode") && (result.AttemptedValue.Length < 6))
                    return "<not-defined>";
            }

            return result?.AttemptedValue ?? "<not-defined>";
        }

        private bool StringValidator(params string[] strings)
        {
            foreach (var str in strings)
                if (string.IsNullOrWhiteSpace(str) || (str == "<not-defined>"))
                    return false;

            return true;
        }
    }
}