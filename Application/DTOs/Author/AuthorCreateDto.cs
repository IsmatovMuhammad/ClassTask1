namespace Application.DTOs.Author;

public class AuthorCreateDto
{
    public string FullName { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int BirthYear { get; set; }
}
