using System;
using System.Globalization;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Infrastructure
{
    public class PersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (Person) bindingContext.Model ?? new Person();
            model.FirstName = (string) GetValue(bindingContext, controllerContext, "FirstName");
            model.LastName = (string) GetValue(bindingContext, controllerContext, "LastName");
            model.BirthDate = (DateTime) GetValue(bindingContext, controllerContext, "BirthDate");
            model.Role = (Role) GetValue(bindingContext, controllerContext, "Role");
            model.Address = (Address) new AddressBinder().BindModel(controllerContext, bindingContext);

            return model;
        }

        private object GetValue(ModelBindingContext bindingContext, ControllerContext controllerContext, string name)
        {
            var result = bindingContext.ValueProvider.GetValue(name);
            if (!ReferenceEquals(result, null))
            {
                switch (name)
                {
                    case "Role":
                    {
                        if (controllerContext.HttpContext.Request.IsLocal &&
                            (result.AttemptedValue?.ToLower() == "admin"))
                            return Role.Admin;
                        if ((result.AttemptedValue?.ToLower() == "user") ||
                            (result.AttemptedValue?.ToLower() == "admin"))
                            return Role.User;
                        return Role.Guest;
                    }
                    case "BirthDate":
                    {
                        DateTime parsed;
                        DateTime.TryParseExact(result.AttemptedValue, "dd MMM, yyyy", new CultureInfo("en-US"),
                            DateTimeStyles.None, out parsed);
                        return parsed;
                    }
                }

                return result.AttemptedValue;
            }

            return 0;
        }
    }
}