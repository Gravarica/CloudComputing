using CentralLibrary.Dto;
using CentralLibrary.Exceptions;
using CentralLibrary.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace CentralLibrary.Controllers
{
    [ApiController]
    [Route("/api")]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }

        public UserController(IUserService userService)
        {
            UserService=userService;
        }

        [HttpGet("/user")]
        public IActionResult GetAll()
        {
            return Ok(UserService.GetAll());   
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {

            Console.WriteLine("Hit");

            var user = UserService.Register(registerDTO);

            if (user == null) return BadRequest("User already exists.");

            return Ok(user);
        }

        [HttpPut("/rent/{id}")]
        public IActionResult RentBook(Guid id)
        {
            try
            {
                var success = UserService.RentBook(id);

                if (success == false) return BadRequest("The user has exceeded the number of books");

                return Ok("Book successfully rented.");
            } 
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("/return/{id}")]
        public IActionResult ReturnBook(Guid id)
        {
            try
            {
                var success = UserService.ReturnBook(id);

                if (success == false) return BadRequest("The user has no rented books");

                return Ok("Book successfully rented.");
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
