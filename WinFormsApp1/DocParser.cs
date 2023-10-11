using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using WinFormsApp1.Models;
using Document = WinFormsApp1.Models.Document;

namespace WinFormsApp1
{
    internal class DocParser
    {
        public Document Parse(Document doc)
        {
            var con = new Document(doc);

            con.Members = ReadPDF(doc.FullPath)
                .GroupBy(p => p.CardId)
                .Select(p => new Member()
                {
                    CardId = p.Key,
                    Positions = p.Select(q => new Positions
                    {
                        Date = q.Date,
                        Value = q.Value,
                        Id = q.Id
                    })
                });

            return con;
        }

        public void Write(Member member, string path)
        {
            var file = member.Name +"_"+ member.CardId + ".pdf";
            using FileStream fs = new FileStream(System.IO.Path.Combine(path, file), FileMode.OpenOrCreate);

            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            

            PdfPTable table = new PdfPTable(3); // 3 columns
            table.WidthPercentage = 100; // Table takes up the entire width of the page

            // Step 5: Add headers to the table
            table.AddCell("ID");
            table.AddCell("Date");
            table.AddCell("Value");

            foreach (var m in member.Positions)
            {
                table.AddCell(m.Id);
                table.AddCell(m.Date.ToString("dd.MM.yy"));
                table.AddCell(m.Value.ToString());
            }

            doc.Add(table);

            doc.Add(new LineSeparator());
            doc.Add(new LineSeparator());
            doc.Add(new LineSeparator());

            doc.Add(new Paragraph("Summer       "+ member.Positions.Sum(p => p.Value)));
            doc.Add(new Paragraph("Davon 10%    " + member.Positions.Sum(p => p.Value) * 0.1));

            doc.AddAuthor("Omar Tarin");
            doc.AddCreator("iTextSharp");
            doc.AddKeywords("Bauhaus Jahres Abrechnung");
            doc.AddSubject($"Bonus Jahres Abrechnung für {member.CardId}");
            doc.AddTitle("Bauhaus Bonus Jahres Abrechnung");
            doc.AddHeader("Title", "Bonus Jahres Abrechnung für {member.CardId}");

            doc.Close();
            fs.Close();
            writer.Close();
        }

        private IEnumerable<Items> ReadPDF(string path)
        {
            var content = new List<Items>();
            using (PdfReader reader = new PdfReader(path))
            {
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    content.AddRange(ProcessText(PdfTextExtractor.GetTextFromPage(reader, page)));
                }
            }

            return content;
        }

        private readonly string TABLECOLOUMNENAMES = "NL Kartennummer BonNr Kaufdatum Reg.Datum Bonbetrag bf.Bonbetrag";
        private CultureInfo culture = CultureInfo.GetCultureInfo("de-DE");

        private IEnumerable<Items> ProcessText(string pageText)
        {
            var content = new List<Items>();
            using (StringReader reader = new StringReader(pageText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(TABLECOLOUMNENAMES))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("Seitenübertrag") || line.Contains("Gesamtumsatz")) break;

                            var value = line.Split(" ");
                            content.Add(new Items()
                            {
                                CardId = value[1],
                                Id = value[2],
                                Date = DateTime.ParseExact(value[3], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                                Value = double.Parse(value[7], culture),
                            });
                        }
                    }
                }
            }

            return content;
        }


        internal class Items
        {
            public string Id { get; set; }
            public double Value { get; set; }
            public DateTime Date { get; set; }
            public string CardId { get; set; }
        }

    }
}
