

namespace WinFormsApp1.Models
{
    internal class Document
    {
        public Document() { }

        public Document(Document doc) 
        {
            Title = doc.Title;
            Id = doc.Id;
            FullPath = doc.FullPath;
        }

        internal int Id { get; set; }
        internal string Title { get; set; }
        internal string FullPath { get; set; }
    }
}
