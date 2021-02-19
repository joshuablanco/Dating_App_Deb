using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]//adding an endpoint
        public ActionResult<IEnumerable<AppUser>> GetUsers(){
            var users = _dataContext.Users.ToList();
            return users;
        }
        
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUsers(int id){
            AppUser user  = _dataContext.Users.Find(id);
             
            if(user == null){
                return new AppUser{
                    Id=id,
                    UserName = "NONREGISTERED"
                };
            }
            else{
                return user;
            }
        }
        
        //Asyn methods use Postman to compare time of execution
        //[HttpGet("async/id"]
        




    }   
}