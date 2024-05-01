using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepo)
        {
            _groupRepository = groupRepo;
        }
        [Authorize(Roles = "Bla Bla Bla.Read")]
        [HttpGet("GetAllGroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupRepository.GetAllGroups();
            return Ok(groups);
        }
        [HttpGet("GetGroupById/{id:int}")]
        [Authorize(Roles = "Bla Bla Bla.Delete")]

        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await _groupRepository.GetGroupById(id);
            return Ok(group);
        }
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            await _groupRepository.CreateGroup(group);
            return Ok();
        }
    }
}
