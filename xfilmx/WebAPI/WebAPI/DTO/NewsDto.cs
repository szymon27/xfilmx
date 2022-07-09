namespace WebAPI.DTO
{
    public class NewsDto
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public byte[] Picture { get; set; }
    }
}
