using System.Xml;
using System.Xml.Schema;
using System.IO;
using System;

public class NavXmlValidator
{
    public static void ValidateXmlWithXsd(string xmlFilePath, string xsdFilePath)
    {
        // 1. XML és XSD beolvasása
        var xml = File.ReadAllText(xmlFilePath);
        var xsd = File.ReadAllText(xsdFilePath);

        // 2. XML séma beállítása
        var schemaSet = new XmlSchemaSet();
        using (var xsdReader = XmlReader.Create(new StringReader(xsd)))
        {
            schemaSet.Add("http://schemas.nav.gov.hu/OSA/3.0/api", xsdReader);
        }

        // 3. XML validálás
        var xmlSettings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            Schemas = schemaSet,
            ValidationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints |
                              XmlSchemaValidationFlags.ReportValidationWarnings
        };

        xmlSettings.ValidationEventHandler += (sender, e) =>
        {
            if (e.Severity == XmlSeverityType.Error)
                throw new Exception($"XSD validálási hiba: {e.Message}");
        };

        using (var xmlReader = XmlReader.Create(new StringReader(xml), xmlSettings))
        {
            while (xmlReader.Read()) { } // A validálás itt történik
        }

        Console.WriteLine("Az XML érvényes a NAV XSD séma szerint!");
    }
}