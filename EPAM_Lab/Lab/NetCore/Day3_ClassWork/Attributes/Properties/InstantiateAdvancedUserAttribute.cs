using System;

namespace Attributes.Properties
{
    internal class InstantiateAdvancedUserAttribute : Attribute
    {
        private int v1;
        private string v2;
        private string v3;
        private int v4;

        public InstantiateAdvancedUserAttribute(int v1, string v2, string v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }
}