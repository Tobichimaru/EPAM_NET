using System;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InstantiateUserAttribute : Attribute
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public InstantiateUserAttribute(string v1, string v2)
        {
            this.FirstName = v1;
            this.LastName = v2;
        }

        public InstantiateUserAttribute(int v, string v1, string v2)
        {
            this.Id = v;
            this.LastName = v2;
            this.FirstName = v1;
        }
    }
}
