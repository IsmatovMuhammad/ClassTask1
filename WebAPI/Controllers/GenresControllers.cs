using Application.DTOs.Genres;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresControllers(IGenreService genreService) : Controller
{
    private IGenreService service = genreService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GenresResponseDto>>>> GetGenres()
    {
        return await service.GetGenres();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddGenres(GenresCreateDto genres)
    {
        return await service.AddGenre(genres);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeletedGenres(int id)
    {
        return await service.DeleteGenre(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateGenres(int id, GenresUpdateDto genres)
    {
        return await service.UpdateGenre(id, genres);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<GenresResponseDto>>> GetGenr(int id)
    {
        return await service.GetGenr(id);
    }
}