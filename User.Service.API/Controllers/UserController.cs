using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Repositories;
using User.Service.API.Domian.Services;
using User.Service.API.Resources;

namespace User.Service.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService userService;

        public UserController(IMapper _mapper, IUserService userService)
        {
            this._mapper = _mapper;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserFormDTO userFormDTO)
        {
            var user = _mapper.Map<UserEntity>(userFormDTO);
            var result = await userService.AddAsync(user);
            return Ok(result);
        }

        [HttpPut("{userID}")]
        public async Task<IActionResult> UpdateAsync(int userID, [FromBody] UserFormDTO userFormDTO)
        {
            var user = _mapper.Map<UserEntity>(userFormDTO);
            await userService.UpdateAsync(userID, user);
            return Ok();
        }

        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteAsync(int userID)
        {
            await userService.DeleteAsync(userID);
            return Ok();
        }

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetAsync([FromServices] IUserRepository userRepository,int userID)
        {
            var user = await userRepository.GetByIDAsync(userID);
            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromServices] IUserRepository userRepository)
        {
            var users = await userRepository.GetAllAsync();
            return Ok(_mapper.Map<IList<UserDTO>>(users));
        }
    }
}
