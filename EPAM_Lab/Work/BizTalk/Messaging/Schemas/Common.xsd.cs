namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Address", @"ShipAddress"})]
    public sealed class Common : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://www.kate.com/schemas/common"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://www.kate.com/schemas/common"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Address"" type=""AddressType"" />
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
    <xs:attribute name=""ID"" type=""xs:string"" />
  </xs:complexType>
  <xs:element name=""ShipAddress"" type=""AddressType"" />
</xs:schema>";
        
        public Common() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [2];
                _RootElements[0] = "Address";
                _RootElements[1] = "ShipAddress";
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
        
        [Schema(@"http://www.kate.com/schemas/common",@"Address")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Address"})]
        public sealed class Address : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Address() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Address";
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
        
        [Schema(@"http://www.kate.com/schemas/common",@"ShipAddress")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ShipAddress"})]
        public sealed class ShipAddress : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ShipAddress() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ShipAddress";
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
}
