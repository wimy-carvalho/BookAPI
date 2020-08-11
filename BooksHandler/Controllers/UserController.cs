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
    [Route("/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;
        private readonly IUnitOfWork _uow;
        private IHttpContextAccessor _httpAntecessor;

        public UserController(IServiceUser serviceUser, IUnitOfWork uow, IHttpContextAccessor httpAntecessor)
        {
            _serviceUser = serviceUser;
            _uow = uow;
            _httpAntecessor = httpAntecessor;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(User), 404)]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _serviceUser.GetAll());
        }

        //[HttpGet("{id}")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(User), 200)]
        //public async Task<ActionResult<User>> GetById(string id)
        //{
        //    var foundUser = _serviceUser.GetById(new ObjectId(id));
        //    if (foundUser == null)
        //        return NotFound();
        //    return Ok(foundUser);
        //}

        //[HttpDelete("{id}")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(User), 200)]
        //public async Task<ActionResult<User>> Delete(string id)
        //{
        //    var foundUser = GetById(id);
        //    if (foundUser == null)
        //        return NotFound();

        //    try
        //    {
        //        _serviceUser.Remove(new ObjectId(id));

        //        //everthing is ok
        //        await _uow.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(User), 200)]
        //public async Task<ActionResult<User>> Update([FromBody] UserViewModel userVM, string id)
        //{
        //    var foundUser = GetById(id);
        //    if (foundUser == null)
        //        return NotFound();

        //    try
        //    {
        //        _serviceUser.Update(transformViewModelToModel(userVM), id);

        //        //everthing is ok
        //        await _uow.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return Ok(GetById(id).Result);
        //}

        //[HttpPost]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(User), 201)]
        //public async Task<ActionResult<IEnumerable<User>>> Post([FromBody] UserViewModel value)
        //{
        //    var foundUser = _serviceUser.FindByName(value.Name);
        //    if (foundUser != null)
        //        return Ok(foundUser);

        //    User u = transformViewModelToModel(value);

        //    try
        //    {
        //        _serviceUser.AddUser(u);

        //        await _uow.Commit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return null;
        //}

        public User transformViewModelToModel(UserViewModel userVM)
        {
            return new User(
                name: userVM.Name,
                birthday: userVM.Birthday,
                profession: userVM.Profession,
                location: userVM.Location
                );
        }
    }
}