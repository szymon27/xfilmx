namespace WebAPI.DTO
{
    public class PostCelebritieDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public byte[] Picture { get; set; }
    }
}
