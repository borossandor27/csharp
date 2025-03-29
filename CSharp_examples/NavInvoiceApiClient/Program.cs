using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.IO;


namespace NavInvoiceApiClient
{
    public class TokenResponse
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
    }

    public class InvoiceStatusResponse
    {
        public List<ProcessingResult> ProcessingResults { get; set; }
    }

    public class ProcessingResult
    {
        public int Index { get; set; }
        public string InvoiceStatus { get; set; }
        public string InvoiceNumber { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientId = "your_client_id";
            var clientSecret = "your_client_secret";
            var apiClient = new NavInvoiceApiClient(clientId, clientSecret);

            try
            {
                // 1. XML generálás
                string xmlData = GenerateSampleXmlInvoice();
                Console.WriteLine("XML számla:");
                Console.WriteLine(xmlData);

                // 2. Beküldés a NAV-nak
                string response = await apiClient.SendInvoicesAsync(xmlData);
                Console.WriteLine("NAV válasz:");
                Console.WriteLine(response);

                // 3. Feldolgozás állapotának lekérdezése (ha szükséges)
                // var transactionId = "123456789"; // A válaszból kinyerhető
                // var status = await apiClient.CheckInvoiceStatusAsync(transactionId);
                // Console.WriteLine($"Állapot: {status.ProcessingResults[0].InvoiceStatus}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

        private static string GenerateSampleXmlInvoice()
        {
            throw new NotImplementedException();
        }

public class InvoiceData
    {
        public string InvoiceNumber { get; set; }
        public string TaxNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        // További mezők...
    }

    public class NavInvoiceService
    {
        private readonly string _connectionString;

        public NavInvoiceService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 1. Számlák lekérése MSSQL-ből
        public List<InvoiceData> GetInvoicesFromDatabase()
        {
            var invoices = new List<InvoiceData>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                SELECT 
                    InvoiceNumber, 
                    TaxNumber, 
                    IssueDate, 
                    TotalAmount
                FROM Invoices
                WHERE IsSentToNav = 0"; // Csak még nem beküldött számlák

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(new InvoiceData
                        {
                            InvoiceNumber = reader["InvoiceNumber"].ToString(),
                            TaxNumber = reader["TaxNumber"].ToString(),
                            IssueDate = (DateTime)reader["IssueDate"],
                            TotalAmount = (decimal)reader["TotalAmount"]
                        });
                    }
                }
            }

            return invoices;
        }

        // 2. XML generálás NAV számára
        public string GenerateNavXmlFromInvoices(List<InvoiceData> invoices)
        {
            var navInvoices = new Invoices
            {
                Invoice = invoices.Select(i => new Invoice
                {
                    InvoiceNumber = i.InvoiceNumber,
                    TaxNumber = i.TaxNumber,
                    IssueDate = i.IssueDate.ToString("yyyy-MM-dd"),
                    TotalAmount = i.TotalAmount
                    // További mezők a NAV XSD szerint...
                }).ToList()
            };

            var serializer = new XmlSerializer(typeof(Invoices));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "http://schemas.nav.gov.hu/OSA/3.0/api"); // NAV névtér

            var xmlWriter = new StringWriterWithEncoding(Encoding.UTF8);
            serializer.Serialize(xmlWriter, navInvoices, namespaces);
            return xmlWriter.ToString();
        }

        // Segédosztály UTF-8 kódoláshoz
        private class StringWriterWithEncoding : StringWriter
        {
            public override Encoding Encoding { get; }
            public StringWriterWithEncoding(Encoding encoding) => Encoding = encoding;
        }
            [XmlRoot("Invoices", Namespace = "http://schemas.nav.gov.hu/OSA/3.0/api")]
            public class Invoices
            {
                [XmlElement("invoice")]
                public List<Invoice> Invoice { get; set; }
            }

            public class Invoice
            {
                [XmlElement("invoiceNumber")]
                public string InvoiceNumber { get; set; }

                [XmlElement("taxNumber")]
                public string TaxNumber { get; set; }

                [XmlElement("issueDate")]
                public string IssueDate { get; set; }

                [XmlElement("invoiceTotalAmount")]
                public decimal TotalAmount { get; set; }

                // További kötelező/opcionális mezők a NAV XSD alapján:
                // Pl.: customerName, paymentDueDate, taxAmount stb.
            }
        }
}
}
