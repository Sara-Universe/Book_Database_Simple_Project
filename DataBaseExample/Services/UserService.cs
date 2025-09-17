using DataBaseExample.Data;
using DataBaseExample.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseExample.Dtos;
using AutoMapper;


    namespace DataBaseExample.Services
    {
        public class UserService
        {
            private readonly LibraryContext _context;
            private readonly IMapper _mapper;

            public UserService(LibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // Get all users
            public async Task<List<UserOutputDto>> GetAllAsync()
            {
                var result = await _context.Users
                    .Include(u => u.FavoriteBooks)
                    .ToListAsync();
                 return _mapper.Map<List<UserOutputDto>>(result);
            }

            // Get user with favorite bookss
            public async Task<UserOutputDto?> GetByIdAsync(int id)
            {
               var result =  await _context.Users
                    .Include(u => u.FavoriteBooks)
                    .FirstOrDefaultAsync(u => u.Id == id);
                return _mapper.Map<UserOutputDto?>(result);
        }

            // Add new user
            public async Task<AddUserDto> AddAsync(UserDto userdto)
            {
                var user = _mapper.Map<User>(userdto);  
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                var userdtoresult = _mapper.Map<AddUserDto>(user);
            return userdtoresult;
            }

             // Delete user
            public async Task<bool> DeleteAsync(int id)
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null) return false;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }

        // Add a favorite book to a user
        public async Task<bool?> AddFavoriteAsync(int userId, int bookId)
            {
                var user = await _context.Users
                    .Include(u => u.FavoriteBooks)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                var book = await _context.Books.FindAsync(bookId);

                if (user == null || book == null)
                    return null;

                if (!user.FavoriteBooks.Contains(book))
                {
                    user.FavoriteBooks.Add(book);
                    await _context.SaveChangesAsync();
                    return true;
            }

                return false;
            }

            // Remove a favorite book from a user
            public async Task<bool> RemoveFavoriteAsync(int userId, int bookId)
            {
                var user = await _context.Users
                    .Include(u => u.FavoriteBooks)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null) return false;

                var book = user.FavoriteBooks.FirstOrDefault(b => b.Id == bookId);
                if (book == null) return false;

                user.FavoriteBooks.Remove(book);
                await _context.SaveChangesAsync();
            
                return true;
            }
        }
    }

