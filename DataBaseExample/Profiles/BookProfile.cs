using AutoMapper;
using DataBaseExample.Dtos;
using DataBaseExample.Models;

namespace DataBaseExample.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, AddBookDto>();
            CreateMap<AddBookDto, Book>();
            CreateMap<Book, Book_List_UserDto>();
            CreateMap<Book_List_UserDto, Book>();

        }
    }
}
