using System;
using System.Web.Mvc;
using ModelBinding.Infrastructure;

namespace ModelBinding.Models
{
    [ModelBinder(typeof(PersonBinder))]
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Role Role { get; set; }

        public Address Address { get; set; }
    }
}