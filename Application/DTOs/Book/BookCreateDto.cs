namespace Application.DTOs.Book;

public class BookCreateDto
{
    public string Title {get; set;} = null!;
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; }
}