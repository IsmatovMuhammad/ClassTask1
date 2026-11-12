using Application.DTOs.Genres;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresControllers(
    IGenreService genreService,
    ILogger<GenresControllers> logger 
    ) : Controller
{
    private IGenreService service = genreService;
    private ILogger<GenresControllers> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GenresResponseDto>>>> GetGenres()
    {
        _logger.LogInformation("List of Genre {Time}", DateTime.Now);
        return await service.GetGenres();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddGenres(GenresCreateDto genres)
    {
        _logger.LogInformation("Genre added {Time}", DateTime.Now);
        return await service.AddGenre(genres);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeletedGenres(int id)
    {
        _logger.LogInformation("Genre deleted {Time}", DateTime.Now);
        return await service.DeleteGenre(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateGenres(int id, GenresUpdateDto genres)
    {
        _logger.LogInformation("Genre updated {Time}", DateTime.Now);
        return await service.UpdateGenre(id, genres);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<GenresResponseDto>>> GetGenr(int id)
    {
        _logger.LogInformation("Genre by id {Time}", DateTime.Now);
        return await service.GetGenr(id);
    }
}