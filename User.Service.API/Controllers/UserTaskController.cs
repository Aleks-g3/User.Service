using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Services;
using User.Service.API.Resources;

namespace User.Service.API.Controllers
{
    [Route("user")]
    public class UserTaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserTaskService userTaskService;

        public UserTaskController(IMapper mapper, IUserTaskService userTaskService)
        {
            this.mapper = mapper;
            this.userTaskService = userTaskService;
        }

        [HttpPost("{userID}/user-task")]
        public async Task<IActionResult> CreateAsync([FromQuery]int userID, [FromBody] UserTaskFormDTO userTaskFormDTO)
        {
            var userTask = mapper.Map<UserTask>(userTaskFormDTO);
            var result = await userTaskService.AddAsync(userID, userTask);

            return Ok(result);
        }

        [HttpPut("{userID}/user-task/{userTaskID}")]
        public async Task<IActionResult> UpdateAsync([FromQuery] int userID, [FromQuery] int userTaskID, [FromBody] UserTaskFormDTO userTaskFormDTO)
        {
            var userTask = mapper.Map<UserTask>(userTaskFormDTO);
            await userTaskService.UpdateAsync(userID, userTaskID, userTask);
            return Ok();
        }

        [HttpDelete("user-task/{userTaskID}")]
        public async Task<IActionResult> CreateAsync([FromQuery] int userTaskID)
        {
            await userTaskService.DeleteAsync(userTaskID);
            return Ok();
        }

        [HttpGet("{userID}/user-tasks")]
        public async Task<IActionResult> GetByUserIDAsync([FromQuery] int userID)
        {
            var userTasks = await userTaskService.GetByUserIDAsync(userID); ;

            return Ok(mapper.Map<IList<UserTaskDTO>>(userTasks));
        }

        [HttpGet("{userID}/user-task/{userTaskID}")]
        public async Task<IActionResult> GetByUserIDAsync([FromQuery] int userID,[FromQuery] int userTaskID)
        {
            var userTask = await userTaskService.GetByIDAsync(userID,userTaskID);

            return Ok(mapper.Map<UserTaskDTO>(userTask));
        }
    }
}
