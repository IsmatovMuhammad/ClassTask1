using Application.DTOs.Author;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorControllers(
    IAuthorService authorService,
    ILogger<AuthorControllers> logger
    ) : Controller
{
    private IAuthorService auth = authorService;
    private ILogger<AuthorControllers> _logger = logger;
    
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<AuthorResponseDto>>>> GetAuthors()
    {
        _logger.LogInformation("List of author {Time}", DateTime.Now);
        return await auth.GetAuthors();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddAuthor(AuthorCreateDto author)
    {
        _logger.LogInformation("Author added {Time}", DateTime.Now);
        return await auth.AddAuthor(author);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAuthor(int id)
    {
        _logger.LogInformation("Author deleted {Time}", DateTime.Now);
        return await auth.DeleteAuthor(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateAuthor(int id, AuthorUpdateDto author)
    {
        _logger.LogInformation("Author updated {Time}", DateTime.Now);
        return await auth.UpdateAuthor(id, author);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<AuthorResponseDto>>> GetAuthor(int id)
    {
        _logger.LogInformation("Author by id {Time}", DateTime.Now);
        return await auth.GetAuthor(id);
    }
}