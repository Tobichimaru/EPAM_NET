using System;

namespace Attributes
{
    // Should be applied to properties and fields.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class StringValidatorAttribute : Attribute
    {
        public int Value { get; set; }

        public StringValidatorAttribute(int v)
        {
            this.Value = v;
        }
        
    }
}
