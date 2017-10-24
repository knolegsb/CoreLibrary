using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreLibrary.Services;
using AutoMapper;
using CoreLibrary.ModelDtos;
using Microsoft.AspNetCore.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreLibrary.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            //try
            //{
                //throw new Exception("Random exception for testing purpose.");
                var authorsFromRepo = _libraryRepository.GetAuthors();

                var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
                
                //HttpContext.Response.Headers["Accept"] = "application/xml";
                return Ok(authors);
            //}
            //catch(Exception ex)
            //{
            //    return StatusCode(500, "An unexpected fault happened. Try again later.");                
            //}
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}
