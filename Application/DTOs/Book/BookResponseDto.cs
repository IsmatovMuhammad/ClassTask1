namespace Application.DTOs.Book;

public class BookResponseDto
{
    public int Id { get; set;}
    public string Title {get; set;} = null!;
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; }
}
