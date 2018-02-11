namespace Maps {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.Contacts", typeof(global::Schemas.Contacts))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Schemas.Customer", typeof(global::Schemas.Customer))]
    public sealed class ContactToCustomer : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s1 s0 userCSharp"" version=""1.0"" xmlns:s1=""http://www.kate.com/schemas/contacts"" xmlns:s0=""http://www.kate.com/schemas/common"" xmlns:ns0=""http://Schemas.Customer"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s1:Contacts"" />
  </xsl:template>
  <xsl:template match=""/s1:Contacts"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringLowerCase(string(Contact/Name/text()))"" />
    <xsl:variable name=""var:v2"" select=""userCSharp:DateCurrentDateTime()"" />
    <ns0:Customer>
      <Name>
        <xsl:value-of select=""$var:v1"" />
      </Name>
      <DateAdded>
        <xsl:value-of select=""$var:v2"" />
      </DateAdded>
      <HomeAddress>
        <Street>
          <xsl:value-of select=""Addresses/Address/Street/text()"" />
        </Street>
        <City>
          <xsl:value-of select=""Addresses/Address/City/text()"" />
        </City>
        <State>
          <xsl:value-of select=""Addresses/Address/State/text()"" />
        </State>
        <Zip>
          <xsl:value-of select=""Addresses/Address/ZipCode/text()"" />
        </Zip>
      </HomeAddress>
      <WorkAddress>
        <Street>
          <xsl:value-of select=""Addresses/Address/Street/text()"" />
        </Street>
        <City>
          <xsl:value-of select=""Addresses/Address/City/text()"" />
        </City>
        <State>
          <xsl:value-of select=""Addresses/Address/State/text()"" />
        </State>
        <Zip>
          <xsl:value-of select=""Addresses/Address/ZipCode/text()"" />
        </Zip>
      </WorkAddress>
      <PhoneNumber>
        <xsl:value-of select=""Contact/Phone/text()"" />
      </PhoneNumber>
      <EmailAddress>
        <xsl:value-of select=""Contact/Email/text()"" />
      </EmailAddress>
      <xsl:variable name=""var:v3"" select=""userCSharp:Square(string(Contact/Money/text()))"" />
      <Money>
        <xsl:value-of select=""$var:v3"" />
      </Money>
    </ns0:Customer>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string StringLowerCase(string str)
{
	if (str == null)
	{
		return """";
	}
	return str.ToLower(System.Globalization.CultureInfo.InvariantCulture);
}


public string DateCurrentDateTime()
{
	DateTime dt = DateTime.Now;
	string curdate = dt.ToString(""yyyy-MM-dd"", System.Globalization.CultureInfo.InvariantCulture);
	string curtime = dt.ToString(""T"", System.Globalization.CultureInfo.InvariantCulture);
	string retval = curdate + ""T"" + curtime;
	return retval;
}



public double Square(double x)
{
	return x*x;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"Schemas.Contacts";
        
        private const global::Schemas.Contacts _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"Schemas.Customer";
        
        private const global::Schemas.Customer _trgSchemaTypeReference0 = null;
        
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
                _SrcSchemas[0] = @"Schemas.Contacts";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"Schemas.Customer";
                return _TrgSchemas;
            }
        }
    }
}
