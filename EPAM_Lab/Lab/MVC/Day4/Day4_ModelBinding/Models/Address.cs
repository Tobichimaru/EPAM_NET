using System.Web.Mvc;
using ModelBinding.Infrastructure;

namespace ModelBinding.Models
{
    [ModelBinder(typeof(AddressBinder))]
    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Summary { get; set; }
    }
}