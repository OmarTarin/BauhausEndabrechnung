
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    internal class DocReader
    {
        private readonly Config _conf;


        public DocReader(Config conf)
        {
            _conf = conf;
        }

        internal void CreateDocDirectory()
        {
            if (!Directory.Exists(_conf.DocDirectory))
                Directory.CreateDirectory(_conf.DocDirectory);
            if (!Directory.Exists(_conf.ExportDirectory))
                Directory.CreateDirectory(_conf.ExportDirectory);
        }

        internal IEnumerable<Document> ReadDocDirectory()
        {
            var docs = new List<Document>();

            if (!Directory.Exists(_conf.DocDirectory))
                throw new Exception($"Document directory does not exists {_conf.DocDirectory}");

            var files = Directory.GetFiles(_conf.DocDirectory);

            return files.Select(p => new Document()
            {
                Title = Path.GetFileName(p),
                FullPath = p
            });
        }

        internal Document ReadDocContent(Document doc)
        {
            if (!Directory.Exists(_conf.DocDirectory))
                throw new Exception($"Document directory does not exists {_conf.DocDirectory}");
            
            if (!File.Exists(doc.FullPath))
                throw new Exception($"Document {doc.Title} does not exist in ${doc.FullPath}");

            var parser = new DocParser();
            return parser.Parse(doc);
        }

        internal Document FindDocument(string fileName)
        {
            if (!Directory.Exists(_conf.DocDirectory))
                throw new Exception($"Document directory does not exists {_conf.DocDirectory}");

            return Directory.EnumerateFiles(_conf.DocDirectory)
                    .Where(p => string.Equals(Path.GetFileName(p), fileName))
                    .Select(p => new Document()
                    {
                        Title = Path.GetFileName(p),
                        FullPath = p
                    })
                    .SingleOrDefault();
        }


        public void WritePdf(Member member)
        {
            var parser = new DocParser();
            parser.Write(member, _conf.ExportDirectory);
        }
    }
}
