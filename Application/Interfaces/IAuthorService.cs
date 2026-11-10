using Application.DTOs.Author;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthor(AuthorCreateDto author);
    Task<ApiResponse<bool>> UpdateAuthor(int id, AuthorUpdateDto author);
    Task<ApiResponse<bool>> DeleteAuthor(int id);
    Task<ApiResponse<AuthorResponseDto>> GetAuthor(int id);
    Task<ApiResponse<List<AuthorResponseDto>>> GetAuthors();

}
