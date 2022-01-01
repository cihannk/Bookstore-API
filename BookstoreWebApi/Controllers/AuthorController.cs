using AutoMapper;
using BookstoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookstoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using BookstoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthors;
using BookstoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BookstoreDbContext _context;
        public AuthorController(BookstoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_mapper, _context);
            var authors = query.Handle();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public ActionResult GetAuthor(int id)
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorQueryValidator validator = new GetAuthorQueryValidator();
            validator.ValidateAndThrow(query);

            var author = query.Handle();
            return Ok(author);
        }
        [HttpPost]
        public ActionResult CreateAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Author eklendi");
        }
        [HttpPut("{id}")]
        public ActionResult UpdateAuthor([FromBody] UpdateAuthorModel model, int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
            command.Model = model;
            command.AuthorId = id;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok("Author güncellendi");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context, _mapper);
            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Author silindi.");
        }
    }
}