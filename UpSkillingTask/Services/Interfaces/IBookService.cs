using UpSkillingTask.DTOs.BooksDtos;

namespace UpSkillingTask.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<bool> AddBookAsync(AddBookDto addBookDto); 
        Task<bool> UpdateBookAsync(int id, EditBookDto editBookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
