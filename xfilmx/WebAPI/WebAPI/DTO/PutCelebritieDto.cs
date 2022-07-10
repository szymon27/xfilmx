namespace WebAPI.DTO
{
    public class PutCelebritieDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }  
    }
}
