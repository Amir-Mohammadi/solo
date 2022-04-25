using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solo.Models;

namespace Solo.Controller.UserController 
{
    [Route("/api/v1")]
    [ApiController]
    public partial class UserController
    {
        
        [HttpPost("add-user")]
        public async Task<UserResult> AddUser([FromBody] AddUserInput input)
        {
            return null;
        }

    }
}