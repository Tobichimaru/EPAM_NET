namespace Maps {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.Student", typeof(global::Schemas.Student))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.PostOfficeRecord", typeof(global::Schemas.PostOfficeRecord))]
    public sealed class StudentToPostRecord : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0"" xmlns:ns1=""http://Schemas.PostOfficeRecord"" xmlns:ns0=""http://Schemas.Student"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/ns0:Student"" />
  </xsl:template>
  <xsl:template match=""/ns0:Student"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(string(GeneralInfo/FirstName/text()) , string(GeneralInfo/LastName/text()))"" />
    <ns1:PostInfo>
      <Address>
        <City>
          <xsl:value-of select=""Address/City/text()"" />
        </City>
        <Street>
          <xsl:value-of select=""Address/Street/text()"" />
        </Street>
      </Address>
      <Person>
        <Name>
          <xsl:value-of select=""$var:v1"" />
        </Name>
        <Phone>
          <xsl:value-of select=""GeneralInfo/Phone/text()"" />
        </Phone>
      </Person>
    </ns1:PostInfo>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string StringConcat(string param0, string param1)
{
   return param0 + param1;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"Schemas.Student";
        
        private const global::Schemas.Student _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"Schemas.PostOfficeRecord";
        
        private const global::Schemas.PostOfficeRecord _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"Schemas.Student";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"Schemas.PostOfficeRecord";
                return _TrgSchemas;
            }
        }
    }
}
