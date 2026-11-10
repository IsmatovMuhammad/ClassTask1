using Application.DTOs.Genres;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<bool>> AddGenre(GenresCreateDto genre);
    Task<ApiResponse<bool>> DeleteGenre(int id);
    Task<ApiResponse<bool>> UpdateGenre(int id, GenresUpdateDto genre);
    Task<ApiResponse<List<GenresResponseDto>>> GetGenres();
    Task<ApiResponse<GenresResponseDto>> GetGenr(int id);
}
