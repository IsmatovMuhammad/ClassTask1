using Domain.Models;

namespace Domain.Interfaces;

public interface IGenresRepository
{
    Task<bool> AddGenre(Genres genre);
    Task<bool> DeleteGenre(int id);
    Task<bool> UpdateGenre(Genres genre);
    Task<List<Genres>> GetGenres();
    Task<Genres> GetGenr(int id);
}
