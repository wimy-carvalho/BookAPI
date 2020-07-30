using BooksCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollBack_Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksHandler.Controllers
{
    [Route("/book/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceBook _serviceBook;
        private readonly IUnitOfWork _uow;
        private IHttpContextAccessor _httpContextAncessor;

        public BookController(IServiceBook srvBook, IUnitOfWork UoW, IHttpContextAccessor http)
        {
            this._serviceBook = srvBook;
            this._uow = UoW;
            this._httpContextAncessor = http;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var getBooks = await _serviceBook.GetAll();

            return Ok(getBooks);
        }
    }
}