namespace WebAPI.DTO
{
    public class CelebritieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public byte[] Picture { get; set; }
    }
}
