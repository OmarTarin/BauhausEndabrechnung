
namespace WinFormsApp1.Models
{
    internal class Member
    {
        public string CardId { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Positions> Positions { get; set; }
    }
}
