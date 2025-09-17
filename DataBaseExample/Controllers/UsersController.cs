using DataBaseExample.Models;
using DataBaseExample.Services;
using Microsoft.AspNetCore.Mvc;
using DataBaseExample.Dtos;
namespace DataBaseExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutputDto>>> GetUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutputDto>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<AddUserDto>> CreateUser(UserDto user)
        {
            var created = await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
        }

        [HttpPost("{userId}/favorites/{bookId}")]
        public async Task<IActionResult> AddFavorite(int userId, int bookId)
        {
            var success = await _userService.AddFavoriteAsync(userId, bookId);
            if (success == null) return NotFound();
            else if (success == false) return BadRequest("Book is already in favorites.");
            
                return Ok("Added Successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [HttpDelete("{userId}/favorites/{bookId}")]
        public async Task<IActionResult> RemoveFavorite(int userId, int bookId)
        {
            var success = await _userService.RemoveFavoriteAsync(userId, bookId);
            if (success == false) return NotFound();
           

            return NoContent();
        }
    }
}
