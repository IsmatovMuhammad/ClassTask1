namespace Application.DTOs.Author;

public class AuthorResponseDto
{
    public int Id {get; set; }
    public string? FullName { get; set; } 
    public string? Country { get; set; } 
    public int BirthYear { get; set; }
}
