using AutoMapper;
using BookstoreWebApi.BookOperations.CreateBook;
using BookstoreWebApi.BookOperations.GetBook;
using BookstoreWebApi.BookOperations.GetBooks;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Common{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreID).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreID).ToString()));
        }
    }
}