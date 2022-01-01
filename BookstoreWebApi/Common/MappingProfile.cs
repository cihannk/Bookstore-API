using AutoMapper;
using BookstoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthors;
using BookstoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookstoreWebApi.Application.BookOperations.Queries.GetBook;
using BookstoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookstoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookstoreWebApi.Application.GenreOperations.Queries.GetGenre;
using BookstoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Common{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            // for book
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " "+ src.Author.LastName));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " "+ src.Author.LastName));

            // for genre
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            // for author
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();
        }
    }
}