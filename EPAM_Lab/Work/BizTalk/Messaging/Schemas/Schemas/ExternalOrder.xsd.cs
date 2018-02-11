namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://www.kate.com/schemas/common",@"Order")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Order"})]
    public sealed class Common_Copy : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://www.kate.com/schemas/common"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://www.kate.com/schemas/common"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:simpleType name=""ZipCodeType"">
    <xs:restriction base=""xs:string"">
      <xs:pattern value=""\d{5}-\d{4}"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name=""AddressType"">
    <xs:sequence>
      <xs:element name=""Street"" type=""xs:string"" />
      <xs:element name=""City"" type=""xs:string"" />
      <xs:element name=""State"">
        <xs:simpleType>
          <xs:restriction base=""xs:string"">
            <xs:length value=""2"" />
          </xs:restriction>
        </xs:simpleType>
      </xs:element>
      <xs:element name=""ZipCode"" type=""ZipCodeType"" />
    </xs:sequence>
    <xs:attribute name=""AddressType"" type=""xs:string"" />
  </xs:complexType>
  <xs:element name=""Order"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""CustomerID"" type=""xs:string"" />
        <xs:element name=""Adresses"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Address"" type=""AddressType"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name=""Items"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Item"">
                <xs:complexType />
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name=""OrderID"" type=""xs:string"" />
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Common_Copy() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Order";
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
