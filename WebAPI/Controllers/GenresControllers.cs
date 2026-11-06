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
    public async Task<ActionResult<ApiResponse<List<Genres>>>> GetGenres()
    {
        return await service.GetGenres();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddGenres(Genres genres)
    {
        return await service.AddGenre(genres);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeletedGenres(int id)
    {
        return await service.DeleteGenre(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateGenres(Genres genres)
    {
        return await service.UpdateGenre(genres);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<Genres>>> GetGenr(int id)
    {
        return await service.GetGenr(id);
    }
}