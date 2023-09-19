namespace API.ViewModels
{
    public class PatternRequest
    {
        public DateTime RequestDate { get; set; }
        public string Phrase { get; set; } = null!;
        public int User { get; set; }
    }
}
