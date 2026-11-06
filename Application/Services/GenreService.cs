using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class GenreService(IGenresRepository genresRepository): IGenreService
{
    private IGenresRepository repository = genresRepository;

    public async Task<ApiResponse<bool>> AddGenre(Genres genre)
    {
        var conn = await repository.AddGenre(genre);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added !", conn);
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var conn = await repository.DeleteGenre(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<Genres>> GetGenr(int id)
    {
        var conn = await repository.GetGenr(id);
        return new ApiResponse<Genres>(HttpStatusCode.OK, "Genres with given id. ", conn);
    }

    public async Task<ApiResponse<List<Genres>>> GetGenres()
    {
        var conn = await repository.GetGenres();
        return new ApiResponse<List<Genres>>(HttpStatusCode.OK, "List of genres", conn);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(Genres genre)
    {
        var conn = await repository.UpdateGenre(genre);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated !", conn);
    }

}
