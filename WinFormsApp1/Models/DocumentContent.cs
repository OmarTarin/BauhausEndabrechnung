

namespace WinFormsApp1.Models
{
    internal class DocumentContent : Document
    {
        public DocumentContent(Document doc):base(doc)
        {
            Members = new List<Member>();
        }

        internal IEnumerable<Member> Members { get; set; }

        public IEnumerable<string> CarsIds()
        {
            return Members.Select(p => p.CardId);
        }

        public Member Member(string cardId)
        {
            return Members.Single(p => string.Equals(p.CardId, cardId));
        }

        public IEnumerable<Positions> Position(string cardId)
        {
            return Members.Single(p => string.Equals(p.CardId, cardId)).Positions;
        }
        
    }
}
