using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Application.Services;

public class AuthorService(IAuthorRepository repository) : IAuthorService
{
    private IAuthorRepository author1 = repository;

    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        var conn = await author1.AddAuthor(author);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added !", conn);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var conn = await author1.DeleteAuthor(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        var conn = await author1.GetAuthor(id);
        return new ApiResponse<Author>(HttpStatusCode.OK, "Author with given id. ", conn);
    }

    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        var conn = await author1.GetAuthors();
        return new ApiResponse<List<Author>>(HttpStatusCode.OK, "List of author. ", conn);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        var conn = await author1.UpdateAuthor(author);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated !", conn);
    }

}
