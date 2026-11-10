using System.Net;
using Application.DTOs.Author;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Application.Services;

public class AuthorService(IAuthorRepository repository1) : IAuthorService
{
    private IAuthorRepository repository = repository1;

    public async Task<ApiResponse<bool>> AddAuthor(AuthorCreateDto author)
    {
        var auth = new Author()
        {
            FullName = author.FullName,
            Country = author.Country,
            BirthYear = author.BirthYear
        };
        var res = await repository.AddAuthor(auth);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Authro added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Author not added !");
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var auth = await repository.DeleteAuthor(id);
        return auth == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Author deleted !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Author not deleted !");
    }

    public async Task<ApiResponse<AuthorResponseDto>> GetAuthor(int id)
    {
        var auth = await repository.GetAuthor(id);
        var data = new AuthorResponseDto
        {
            FullName = auth.FullName,
            Country = auth.Country,
            BirthYear = auth.BirthYear
        };
        return new ApiResponse<AuthorResponseDto>(HttpStatusCode.OK, "Author by id. ", data);
    }

    public async Task<ApiResponse<List<AuthorResponseDto>>> GetAuthors()
    {
        var auth = await repository.GetAuthors();
        var data = auth.Select(s => new AuthorResponseDto
        {
            Id = s.Id,
            FullName = s.FullName,
            Country = s.Country,
            BirthYear = s.BirthYear
        }).ToList();
        return new ApiResponse<List<AuthorResponseDto>>(HttpStatusCode.OK, "List of Author", data);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(int id, AuthorUpdateDto author)
    {
        var auth = new Author()
        {
            Id = id,
            FullName = author.FullName,
            Country = author.Country,
            BirthYear = author.BirthYear
        };
        var res = await repository.UpdateAuthor(auth);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Author updated !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Author not Updated !");
    }

}
