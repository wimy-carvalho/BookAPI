using BooksCore.Entities;
using BooksCore.Services;
using BooksHandler.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollBack_Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksHandler.Controllers
{
    [Route("/book-user/")]
    [ApiController]
    public class BookUserController : ControllerBase
    {
        private readonly IServiceBookUser _serviceBookUser;
        private readonly IUnitOfWork _uow;
        private IHttpContextAccessor _httpContextAccessor;

        public BookUserController(IServiceBookUser serviceBookUser, IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _serviceBookUser = serviceBookUser;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(BooksUser), 200)]
        [ProducesResponseType(typeof(BooksUser), 404)]
        public async Task<ActionResult<IEnumerable<BooksUser>>> Get()
        {
            return Ok(await _serviceBookUser.GetAll());
        }

        //[HttpPost]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(BooksUser), 201)]
        //[ProducesResponseType(typeof(BooksUser), 404)]
        //public async Task<ActionResult<IEnumerable<BooksUser>>> Post(BooksUserViewModel booksUserVm)
        //{
        //    var booksUserByID = await _serviceBookUser.GetByParentID(booksUserVm._user);
        //    if (booksUserByID != null)
        //        return Ok(booksUserByID);

        //    try
        //    {
        //        _serviceBookUser.Add(transformViewModelToModel(booksUserVm));

        //        await _uow.Commit();
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }

        //    return Created("/book-user", await _serviceBookUser.GetByParentID(booksUserVm._user));
        //}

        //[HttpPut("{id}")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(BooksUser), 201)]
        //[ProducesResponseType(typeof(BooksUser), 404)]
        //public async Task<ActionResult<BooksUser>> Update(BooksUserViewModel booksUserVm)
        //{
        //    var booksUserByID = await _serviceBookUser.GetById(new ObjectId(booksUserVm._id));
        //    if (booksUserByID == null)
        //        return NotFound();

        //    try
        //    {
        //        _serviceBookUser.Update(transformViewModelToModel(booksUserVm), booksUserVm._id);

        //        await _uow.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return Ok(await _serviceBookUser.GetById(new ObjectId(booksUserByID._id)));
        //}

        private BooksUser transformViewModelToModel(BooksUserViewModel bookUserVM)
        {
            return new BooksUser(
                userID: bookUserVM._user,
                books: bookUserVM._books
            );
        }
    }
}