using Domain.Models;

namespace Domain.Interfaces;

public interface IGenresRepository
{
    void AddGenre(Genres genre);
    void DeleteGenre(int id);
    void UpdateGenre(Genres genre);
    void ShowAll();
}
