namespace Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://Schemas.Student",@"Student")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Student"})]
    public sealed class Student : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://Schemas.Student"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://Schemas.Student"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:simpleType name=""PhoneNumberType"">
    <xs:restriction base=""xs:string"">
      <xs:pattern value=""/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:simpleType name=""NameType"">
    <xs:restriction base=""xs:string"">
      <xs:maxLength value=""15"" />
      <xs:minLength value=""2"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:complexType name=""AddressType"">
    <xs:sequence>
      <xs:element name=""City"" type=""xs:string"" />
      <xs:element name=""Street"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Student"" type=""Student"" />
  <xs:complexType name=""Student"">
    <xs:sequence>
      <xs:element name=""Address"" type=""AddressType"" />
      <xs:element name=""GeneralInfo"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""FirstName"" type=""NameType"" />
            <xs:element name=""LastName"" type=""NameType"" />
            <xs:element name=""Phone"" type=""PhoneNumberType"" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""RecordBook"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""Marks"">
              <xs:simpleType>
                <xs:list itemType=""xs:integer"" />
              </xs:simpleType>
            </xs:element>
            <xs:element name=""AverageMark"" type=""xs:double"" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
  </xs:complexType>
</xs:schema>";
        
        public Student() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Student";
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
