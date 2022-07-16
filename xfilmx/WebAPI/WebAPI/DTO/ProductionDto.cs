namespace WebAPI.DTO
{
    public class ProductionDto
    {
        public bool IsSerie { get; set; }
        public int ProductionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public byte[] Picture { get; set; }
        public List<string> Countries { get; set; }   
        public List<string> Genres { get; set; }
        public double Rate { get; set; }
        public int RateCount { get; set; }
    }
}
