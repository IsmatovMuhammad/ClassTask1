using Application.DTOs.Author;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorControllers(IAuthorService authorService) : Controller
{
    private IAuthorService auth = authorService;
    
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<AuthorResponseDto>>>> GetAuthors()
    {
        return await auth.GetAuthors();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddAuthor(AuthorCreateDto author)
    {
        return await auth.AddAuthor(author);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAuthor(int id)
    {
        return await auth.DeleteAuthor(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateAuthor(int id, AuthorUpdateDto author)
    {
        return await auth.UpdateAuthor(id, author);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<AuthorResponseDto>>> GetAuthor(int id)
    {
        return await auth.GetAuthor(id);
    }
}