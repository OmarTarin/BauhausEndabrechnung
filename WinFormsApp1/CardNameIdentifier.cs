
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    internal class CardNameIdentifier
    {
        private readonly string IdentifierFileName = "./CardItentifier";


        internal Document Identify(Document doc)
        {
            if (File.Exists(IdentifierFileName))
            {
                var lines = File.ReadLines(IdentifierFileName);
                var cards = lines.ToDictionary(p => p.Split(';')[0], p => p.Split(';')[1]);

                doc.Members = doc.Members.Select(p =>
                {
                    var name = cards.Keys.FirstOrDefault(q => string.Equals(p.CardId, q));
                    if (string.IsNullOrEmpty(name))
                        return p;

                    p.Name = cards[name];

                    return p;
                }).ToList();
            }

            return doc;
        }
        

        public void Set(IEnumerable<Member> source)
        {
            if (File.Exists(IdentifierFileName))
                File.Delete(IdentifierFileName);

            var writer = File.AppendText(IdentifierFileName);
            foreach (var card in source)
            {
                writer.WriteLine($"{card.CardId};{card.Name}");
            }

            writer.Close();
            writer.Dispose();
        }
    }
}
