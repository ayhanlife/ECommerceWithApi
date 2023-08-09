using Bussines.Abstract;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService userService;
        public ValuesController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            return Ok(await userService.GetListAsync());
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
            var result = await userService.DeleteAsync(id));
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
