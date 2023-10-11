

namespace WinFormsApp1.Models
{
    internal class Document
    {
        public Document()
        {
            Members = new List<Member>();
        }

        public Document(Document doc) : this()
        {
            Title = doc.Title;
            Id = doc.Id;
            FullPath = doc.FullPath;
        }

        internal int Id { get; set; }
        internal string Title { get; set; }
        internal string FullPath { get; set; }

        internal IEnumerable<Member> Members { get; set; }
    }
}
