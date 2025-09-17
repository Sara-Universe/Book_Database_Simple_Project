using AutoMapper;
using DataBaseExample.Data;
using DataBaseExample.Dtos;
using DataBaseExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseExample.Services
{
    public class CategoryService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public CategoryService(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all categories
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories
           .Include(c => c.Books)  // still needed to load related books
           .ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories); // convert entities to DTOs
        }

        // Get single category by Id
        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var categories =  await _context.Categories
                .Include(c => c.Books)      // <--- Load related books
                .FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CategoryDto>(categories); // convert entities to DTOs

        }

        // Add new category
        public async Task<Category> AddAsync(CategoryDto categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Optional: update category
        public async Task<bool> UpdateAsync(int id, CategoryDto categorydto)
        {
            var category = _mapper.Map<Category>(categorydto);
            if (id != category.Id) return false;

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // Optional: delete category
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
