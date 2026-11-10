using System.Net;
using Application.DTOs.Genres;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class GenreService(IGenresRepository genresRepository): IGenreService
{
    private IGenresRepository repository = genresRepository;

    public async Task<ApiResponse<bool>> AddGenre(GenresCreateDto genre)
    {
        var genr = new Genres()
        {
            Name = genre.Name
        };
        var res = await repository.AddGenre(genr);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Genre added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Genre not added !");
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var conn = await repository.DeleteGenre(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<GenresResponseDto>> GetGenr(int id)
    {
        var genr = await repository.GetGenr(id);
        var genr1 = new GenresResponseDto()
        {
            Name = genr.Name
        };
        return new ApiResponse<GenresResponseDto>(HttpStatusCode.OK, "Genre by id. ", genr1);
    }

    public async Task<ApiResponse<List<GenresResponseDto>>> GetGenres()
    {
        var genr = await repository.GetGenres();
        var genr1 = genr.Select(s => new GenresResponseDto
        {
            Name = s.Name
        }).ToList();
        return new ApiResponse<List<GenresResponseDto>>(HttpStatusCode.OK, "List of Genre", genr1);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(int id, GenresUpdateDto genre)
    {
        var genre1 = new Genres()
        {
            Id = id,
            Name = genre.Name
        };
        var genr = await repository.UpdateGenre(genre1);
        return genr == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Genre updated !", genr)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Genre not update"); 
    }

}
