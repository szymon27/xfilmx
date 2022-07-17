namespace WebAPI.DTO
{
    public class ProductionCelebritiesDto
    {
        public int CelebritieId { get; set; }
        public string CelebritieName { get; set; }
        public string CelebritieSurname { get; set; }
        public bool IsScreenwriter { get; set; }
        public bool IsDirector { get; set; }
        public bool IsActor { get; set; }
        public string Character { get; set; }
    }
}
