using System;

namespace Attributes
{
    // Should be applied to properties and fields.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IntValidatorAttribute : Attribute
    {
        public int Left { get; set; }
        public int Right { get; set; }

        public IntValidatorAttribute(int v1, int v2)
        {
            this.Left = v1;
            this.Right = v2;
        }
    }
}