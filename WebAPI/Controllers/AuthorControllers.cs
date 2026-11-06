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
    public async Task<ActionResult<ApiResponse<List<Author>>>> GetAuthors()
    {
        return await auth.GetAuthors();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddAuthor(Author author)
    {
        return await auth.AddAuthor(author);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteAuthor(int id)
    {
        return await auth.DeleteAuthor(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateAuthor(Author author)
    {
        return await auth.UpdateAuthor(author);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<Author>>> GetAuthor(int id)
    {
        return await auth.GetAuthor(id);
    }
}