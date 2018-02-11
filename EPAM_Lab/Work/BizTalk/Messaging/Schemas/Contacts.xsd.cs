namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://www.kate.com/schemas/contacts",@"Contacts")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Contacts"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.Common", typeof(global::Schemas.Common))]
    public sealed class Contacts : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://www.kate.com/schemas/contacts"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:common=""http://www.kate.com/schemas/common"" targetNamespace=""http://www.kate.com/schemas/contacts"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""Schemas.Common"" namespace=""http://www.kate.com/schemas/common"" />
  <xs:annotation>
    <xs:appinfo>
      <b:references>
        <b:reference targetNamespace=""http://www.kate.com/schemas/common"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Contacts"">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" name=""Contact"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Name"" type=""xs:string"" />
              <xs:element name=""Phone"" type=""xs:string"" />
              <xs:element name=""Email"" type=""xs:string"" />
              <xs:element name=""Money"" type=""xs:double"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name=""Addresses"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Address"" type=""common:AddressType"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Contacts() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Contacts";
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
