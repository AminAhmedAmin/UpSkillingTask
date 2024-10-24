using UpSkillingTask.Models;
using UpSkillingTask.Services.Interfaces;
using UpSkillingTask.DTOs.BooksDtos;
using Microsoft.EntityFrameworkCore;

namespace UpSkillingTask.Services.Implemention
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var bookDtos = await _context.Books
                .Include(b => b.Category)
                .Select(book => new BookDto
                {
                    BookId = book.Id,
                    Name = book.Name,
                    Description = book.Description,
                    Price = book.Price,
                    Author = book.Author,
                    Stock = book.Stock,
                    CategoryId = book.CategoryId,
                    CategoryName = book.Category.Name 
                })
                .ToListAsync();

            return bookDtos;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.Include(b => b.Category).Where(x=>x.Id==id).Select(book=> new BookDto
            {
                BookId = book.Id,
                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                Author = book.Author,
                Stock = book.Stock,
                CategoryId = book.CategoryId,
                CategoryName = book.Category.Name

            }).FirstOrDefaultAsync();

           

            return book;
        }
        public async Task<bool> AddBookAsync(AddBookDto addBookDto)
        {

            try
            {
                var categoryExists = await _context.Categories
               .AnyAsync(c => c.Id == addBookDto.CategoryId);

                if (!categoryExists)
                {
                    return false;
                }

                var book = new Book
                {
                    Name = addBookDto.Name,
                    Description = addBookDto.Description,
                    Price = addBookDto.Price,
                    Author = addBookDto.Author,
                    Stock = addBookDto.Stock,
                    CategoryId = addBookDto.CategoryId
                };

                _context.Books.Add(book);


                var saved = await _context.SaveChangesAsync();

                return saved > 0;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public async Task<bool> UpdateBookAsync(int id, EditBookDto editBookDto)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return false;
                }
                var categoryExists = await _context.Categories
                   .AnyAsync(c => c.Id == editBookDto.CategoryId);

                if (!categoryExists)
                {
                    return false;
                }
                book.Name = editBookDto.Name;
                book.Description = editBookDto.Description;
                book.Price = editBookDto.Price;
                book.Author = editBookDto.Author;
                book.Stock = editBookDto.Stock;
                book.CategoryId = editBookDto.CategoryId;

                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                var deleted = await _context.SaveChangesAsync();
                return deleted > 0; 
            }
            return false; 
        }
    }
}
