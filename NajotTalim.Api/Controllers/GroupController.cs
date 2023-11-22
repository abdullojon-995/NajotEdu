using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Models;

namespace NajotTalim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateGroupModel model)
        {
            await _groupService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            return Ok(group);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllAsync();

            return Ok(groups);
        }

        [HttpGet("{groupId}/lessons")]
        [Authorize]
        public async Task<IActionResult> GetLessons(int groupId)
        {
            var lessons = await _groupService.GetLessonsAsync(groupId);

            return Ok(lessons);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update(UpdateGroupModel model)
        {
            await _groupService.UpdateAsync(model);

            return Ok();
        }

        [HttpPost("{groupId}/student")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> AddStudent([FromRoute] int groupId, AddStudentGroupModel model)
        {
            await _groupService.AddStudentAsync(model, groupId);

            return Ok();
        }

        [HttpDelete("{groupId}/student")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> RemoveStudent([FromRoute] int groupId, [FromBody] int studentId)
        {
            await _groupService.RemoveStudentAsync(studentId, groupId);

            return Ok();
        }
    }
}
