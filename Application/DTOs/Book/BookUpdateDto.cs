namespace Application.DTOs.Book;

public class BookUpdateDto
{
    public string Title {get; set;} = null!;
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; }
}
