using Bussines.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var result = await userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await userService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserAddDto userDto)
        {
            var result = await userService.AddAsync(userDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpPost]
        public async Task<ActionResult> Update([FromBody] UserUpdateDto userDto)
        {
            var result = await userService.UpdateAsync(userDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<ActionResult> Authenticate([FromBody] UserForLoginDto userForLoginDto)
        //{
        //    var result = await userService.Authenticate(userForLoginDto);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}
    }
}
