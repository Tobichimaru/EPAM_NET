namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://Schemas.PostOfficeRecord",@"PostInfo")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"PostInfo"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.Student", typeof(global::Schemas.Student))]
    public sealed class PostOfficeRecord : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://Schemas.PostOfficeRecord"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://Schemas.Student"" targetNamespace=""http://Schemas.PostOfficeRecord"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""Schemas.Student"" namespace=""http://Schemas.Student"" />
  <xs:annotation>
    <xs:appinfo>
      <b:references>
        <b:reference targetNamespace=""http://Schemas.Student"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""PostInfo"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Address"" type=""ns0:AddressType"" />
        <xs:element name=""Person"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Name"" type=""xs:string"" />
              <xs:element name=""Phone"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public PostOfficeRecord() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "PostInfo";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
