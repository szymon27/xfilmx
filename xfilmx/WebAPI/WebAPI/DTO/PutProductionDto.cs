namespace WebAPI.DTO
{
    public class PutProductionDto
    {
        public bool IsSerie { get; set; }
        public string Title { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
