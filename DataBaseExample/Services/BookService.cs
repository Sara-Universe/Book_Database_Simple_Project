using AutoMapper;
using DataBaseExample.Data;
using DataBaseExample.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseExample.Dtos;

namespace DataBaseExample.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        public BookService(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookDto?>(book);
        }

        public async Task<BookDto> AddBookAsync(AddBookDto bookdto)
        {
            var book = _mapper.Map<Book>(bookdto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            var bookDtoResult = _mapper.Map<BookDto>(book);
            return bookDtoResult;
        }

        public async Task<bool> UpdateBookAsync(int id, AddBookDto bookdto)
        {
            var book = _mapper.Map<Book>(bookdto);
            book.Id = id;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Book_List_UserDto?> GetBookWithUsersAsync(int id)
        {

            var result=  await _context.Books
                .Include(b => b.FavoriteByUsers)
                .FirstOrDefaultAsync(b => b.Id == id);
            return _mapper.Map<Book_List_UserDto?>(result);
        }

    }
}
