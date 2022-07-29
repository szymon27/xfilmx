namespace WebAPI.Models
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}