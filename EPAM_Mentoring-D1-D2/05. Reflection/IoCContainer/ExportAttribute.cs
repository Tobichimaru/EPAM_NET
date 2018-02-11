using System;

namespace IoCContainer
{
    public class ExportAttribute : Attribute
    {
        public Type ExportType { get; set; }

        public ExportAttribute()
        {
        }

        public ExportAttribute(Type type)
        {
            ExportType = type;
        }
    }
}
