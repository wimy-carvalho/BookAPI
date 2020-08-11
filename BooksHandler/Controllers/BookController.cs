using BooksCore.Entities;
using BooksHandler.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RollBack_Core.Interface;
using System;
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
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 404)]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var getBooks = await _serviceBook.GetAll();

            return Ok(getBooks);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Book), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult<Book>> Post([FromBody] BookViewModel value)
        {
            var searchBookByName = await _serviceBook.FindByName(value._name);
            if (searchBookByName != null)
                return Ok(searchBookByName);
            Book book;
            try
            {
                book = transformViewModelToModel(value);

                _serviceBook.Add(book);

                //everthing is ok
                await _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Dispose();
                throw;
            }

            return Created("/book", book);
        }

        public async Task<ActionResult<Book>> Delete(string id)
        {
            var foundBook = _serviceBook.GetById(new ObjectId(id));
            if (foundBook == null)
                return NotFound();

            try
            {
                _serviceBook.Remove(new ObjectId(id));

                //everthing is ok();
                await _uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        public async Task<ActionResult<Book>> GetById(string id)
        {
            var foundBook = _serviceBook.GetById(new ObjectId(id));
            if (foundBook == null)
                return NotFound();

            return Ok(foundBook);
        }

        public async Task<ActionResult<Book>> Update([FromBody] BookViewModel bookVM, string id)
        {
            Book book;
            var foundBook = _serviceBook.GetById(new ObjectId(id));
            if (foundBook == null)
                return NotFound();

            try
            {
                book = transformViewModelToModel(bookVM);

                _serviceBook.Update(book, id);

                //everthing is ok
                await _uow.Commit();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(await GetById(id));
        }

        private Book transformViewModelToModel(BookViewModel bookVM)
        {
            return new Book(
                 id: null,
                 Name: bookVM._name,
                 Editor: bookVM._editor,
                 Edition: bookVM._edition,
                 Details: new BookDetail(
                            iSBN: bookVM._details._isbn,
                            editionYear: bookVM._details._editionYear,
                            language: bookVM._details._language,
                            dimension: bookVM._details._dimension,
                            pages: bookVM._details._pages,
                            style: bookVM._details._style)
                );
        }
    }
}