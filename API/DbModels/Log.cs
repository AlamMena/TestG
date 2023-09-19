namespace API.DbModels
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Request { get; set; } = null!;
        public DateTime ResponseDate { get; set; }
        public string Response { get; set; } = null!;
        public int StatusCode { get; set; }
        public int User { get; set; }

    }
}
